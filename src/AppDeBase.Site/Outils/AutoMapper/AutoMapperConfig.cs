using AppDeBase.Affaires.Models;
using AppDeBase.Site.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDeBase.Site.Outils.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Adresse, AdresseViewModel>().ReverseMap();
            CreateMap<Fournisseur, FournisseurViewModel>().ReverseMap();
            CreateMap<Produit, ProduitViewModel>().ReverseMap();
        }
    }
}