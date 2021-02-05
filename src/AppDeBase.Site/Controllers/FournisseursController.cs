using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AppDeBase.Affaires.Models;
using Microsoft.AspNetCore.Authorization;
using AppDeBase.Affaires.Interfaces;
using AppDeBase.Site.ViewModels;

namespace DevIO.App.Controllers
{
    public class FournisseursController : BaseController
    {
        private readonly IFournisseurRepository _fournisseurRepository;
        private readonly IMapper _mapper;

        public FournisseursController(IFournisseurRepository fournisseurRepository, IMapper mapper)
        {
            _fournisseurRepository = fournisseurRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FournisseurViewModel>>(await _fournisseurRepository.ObtenirTouts()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var FournisseurViewModel = await ObtenirFournisseurAdresse(id);

            if (FournisseurViewModel == null)
            {
                return NotFound();
            }

            return View(FournisseurViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FournisseurViewModel fournisseurViewModel)
        {
            if (!ModelState.IsValid)
                return View(fournisseurViewModel);

            var Fournisseur = _mapper.Map<Fournisseur>(fournisseurViewModel);
            await _fournisseurRepository.Ajouter(Fournisseur);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var FournisseurViewModel = await ObtenirFournisseurProduitsAdresse(id);

            if (FournisseurViewModel == null)
            {
                return NotFound();
            }

            return View(FournisseurViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, FournisseurViewModel FournisseurViewModel)
        {
            if (id != FournisseurViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(FournisseurViewModel);

            var Fournisseur = _mapper.Map<Fournisseur>(FournisseurViewModel);
            await _fournisseurRepository.Update(Fournisseur);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Supprimir(Guid id)
        {
            var FournisseurViewModel = await ObtenirFournisseurAdresse(id);

            if (FournisseurViewModel == null)
            {
                return NotFound();
            }

            return View(FournisseurViewModel);
        }

        [HttpPost, ActionName("Supprimir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupprimirConfirmation(Guid id)
        {
            var Fournisseur = await ObtenirFournisseurAdresse(id);

            if (Fournisseur == null)
                return NotFound();

            await _fournisseurRepository.Supprimir(id);

            return RedirectToAction("Index");
        }

        private async Task<FournisseurViewModel> ObtenirFournisseurAdresse(Guid id)
        {
            return _mapper.Map<FournisseurViewModel>(await _fournisseurRepository.ObtenirFournisseurAdresse(id));
        }

        private async Task<FournisseurViewModel> ObtenirFournisseurProduitsAdresse(Guid id)
        {
            return _mapper.Map<FournisseurViewModel>(await _fournisseurRepository.ObtenirFournisseurProduitsAdresse(id));
        }
    }
}