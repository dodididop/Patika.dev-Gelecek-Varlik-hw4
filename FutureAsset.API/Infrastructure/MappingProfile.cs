using System;
using AutoMapper;

namespace FutureAsset.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FutureAsset.Model.UserViewModel, FutureAsset.DB.Entities.User>();
            CreateMap<FutureAsset.DB.Entities.User, FutureAsset.Model.UserViewModel>();
            CreateMap<FutureAsset.Model.CustomerViewModel, FutureAsset.DB.Entities.Customer>();
            CreateMap<FutureAsset.DB.Entities.Customer, FutureAsset.Model.CustomerViewModel>();
            CreateMap<FutureAsset.Model.DocumentViewModel, FutureAsset.DB.Entities.Document>();
            CreateMap<FutureAsset.DB.Entities.Document, FutureAsset.Model.DocumentViewModel>();
            CreateMap<FutureAsset.DB.Entities.Document, FutureAsset.Model.DetailedDocumentModel>();
            CreateMap<FutureAsset.Model.DetailedDocumentModel, FutureAsset.DB.Entities.Document>();
        }
    }
}
