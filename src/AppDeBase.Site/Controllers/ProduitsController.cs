using AppDeBase.Affaires.Interfaces;
using AppDeBase.Affaires.Models;
using AppDeBase.Site.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DevIO.App.Controllers
{
    public class ProduitsController : BaseController
    {
        private readonly IProduitRepository _ProduitRepository;
        private readonly IFournisseurRepository _FournisseurRepository;
        private readonly IMapper _mapper;

        public ProduitsController(IProduitRepository ProduitRepository,
                                  IFournisseurRepository FournisseurRepository,
                                  IMapper mapper)
        {
            _ProduitRepository = ProduitRepository;
            _FournisseurRepository = FournisseurRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<ProduitViewModel>>(await _ProduitRepository.ObtenirProduitsFournisseurs()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var ProduitViewModel = await ObtenirProduit(id);

            if (ProduitViewModel == null)
            {
                return NotFound();
            }

            return View(ProduitViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var ProduitViewModel = await ChargerFournisseur(new ProduitViewModel());

            return View(ProduitViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProduitViewModel ProduitViewModel)
        {
            ProduitViewModel = await ChargerFournisseur(ProduitViewModel);
            if (!ModelState.IsValid) return View(ProduitViewModel);

            var imgPrefixe = Guid.NewGuid() + "_";
            if (!await TelechargerFichier(ProduitViewModel.ImgTelecharger, imgPrefixe))
            {
                return View(ProduitViewModel);
            }

            ProduitViewModel.Image = imgPrefixe + ProduitViewModel.ImgTelecharger.FileName;
            await _ProduitRepository.Ajouter(_mapper.Map<Produit>(ProduitViewModel));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var ProduitViewModel = await ObtenirProduit(id);

            if (ProduitViewModel == null)
            {
                return NotFound();
            }

            return View(ProduitViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProduitViewModel ProduitViewModel)
        {
            if (id != ProduitViewModel.Id) return NotFound();

            var ProduitUpdate = await ObtenirProduit(id);
            ProduitViewModel.Fournisseur = ProduitUpdate.Fournisseur;
            ProduitViewModel.Image = ProduitUpdate.Image;
            if (!ModelState.IsValid) return View(ProduitViewModel);

            if (ProduitViewModel.ImgTelecharger != null)
            {
                var imgPrefixe = Guid.NewGuid() + "_";
                if (!await TelechargerFichier(ProduitViewModel.ImgTelecharger, imgPrefixe))
                {
                    return View(ProduitViewModel);
                }

                ProduitUpdate.Image = imgPrefixe + ProduitViewModel.ImgTelecharger.FileName;
            }

            ProduitUpdate.Nom = ProduitViewModel.Nom;
            ProduitUpdate.Description = ProduitViewModel.Description;
            ProduitUpdate.Valeur = ProduitViewModel.Valeur;
            ProduitUpdate.Active = ProduitViewModel.Active;

            await _ProduitRepository.Update(_mapper.Map<Produit>(ProduitUpdate));

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Supprimir(Guid id)
        {
            var Produit = await ObtenirProduit(id);

            if (Produit == null)
            {
                return NotFound();
            }

            return View(Produit);
        }

        [HttpPost, ActionName("Supprimir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupprimirConfirmation(Guid id)
        {
            var Produit = await ObtenirProduit(id);

            if (Produit == null)
            {
                return NotFound();
            }

            await _ProduitRepository.Supprimir(id);

            TempData["Sucesso"] = "Produit supprimé avec succès!";

            return RedirectToAction("Index");
        }

        private async Task<ProduitViewModel> ObtenirProduit(Guid id)
        {
            var Produit = _mapper.Map<ProduitViewModel>(await _ProduitRepository.ObtenirProduitFornisseur(id));
            Produit.Fournisseurs = _mapper.Map<IEnumerable<FournisseurViewModel>>(await _FournisseurRepository.ObtenirTouts());
            return Produit;
        }

        private async Task<ProduitViewModel> ChargerFournisseur(ProduitViewModel Produit)
        {
            Produit.Fournisseurs = _mapper.Map<IEnumerable<FournisseurViewModel>>(await _FournisseurRepository.ObtenirTouts());
            return Produit;
        }

        private async Task<bool> TelechargerFichier(IFormFile fichier, string imgPrefixe)
        {
            if (fichier.Length <= 0) return false;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgPrefixe + fichier.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Il existe déjà un fichier avec ce nom");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await fichier.CopyToAsync(stream);
            }

            return true;
        }
    }
}