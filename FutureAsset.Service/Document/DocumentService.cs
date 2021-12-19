using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FutureAsset.DB.Entities.DatabaseContext;
using FutureAsset.Model;

namespace FutureAsset.Service.Document
{
    public class DocumentService:IDocumentService
    {
        private readonly IMapper _mapper;

        public DocumentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Response<bool> Create(DocumentViewModel newDocument)
        {
            try
            {
                var document = _mapper.Map<FutureAsset.DB.Entities.Document>(newDocument);

                document.CreateDate = DateTime.Now.Date;
                document.DocDate = DateTime.Now.Date.AddMonths(-1);
                document.IsActive = true;
                document.IsDeleted = false;

                using (var srv = new FutureAssetDBContext())
                {
                    srv.Document.Add(document);
                    srv.SaveChanges();
                    return new Response<bool>(true);
                }
            }
            catch (Exception ex)
            {
                return new Response<bool>(false);
            }
        }

        public Response<List<DocumentViewModel>> GetDocuments()
        {
            var response = new Response<List<DocumentViewModel>>();
            using (var srv = new FutureAssetDBContext())
            {
                var data = srv.Document.Where(a => a.IsActive && !a.IsDeleted).OrderBy(a => a.Id);

                if (data.Any())
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<List<DocumentViewModel>>(data);
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            return response;
        }

        public Response<DocumentViewModel> GetDocumentById(int id)
        {
            var response = new Response<DocumentViewModel>();
            using (var srv = new FutureAssetDBContext())
            {
                var data = srv.Document.Where(a => a.Id == id).FirstOrDefault();

                if (data is not null)
                {
                    response.IsSuccess = true;
                    response.Data =_mapper.Map<DocumentViewModel>(data);
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            return response;
        }

        public Response<DetailedDocumentModel> Update(int id, DetailedDocumentModel updatedDocument)
        {
            var response = new Response<DetailedDocumentModel>();
            using (var srv = new FutureAssetDBContext())
            {
                bool isAuthenticated = srv.Document.Any(a => a.IsActive && !a.IsDeleted && a.Type == updatedDocument.Type && a.Id == updatedDocument.Id);
                var document = srv.Document.SingleOrDefault(a => a.Id == id);

                if (isAuthenticated && document is not null)
                {
                    document.CreateDate = updatedDocument.CreateDate;
                    document.DocDate = updatedDocument.DocDate;
                    document.ModificationDate = DateTime.Now;
                    document.DocNumber = updatedDocument.DocNumber;
                    
                    srv.SaveChanges();
                    response.Data = _mapper.Map<DetailedDocumentModel>(document);
                    response.IsSuccess = true;
                }
                else
                {
                  
                    response.IsSuccess = false;
                }

                return response;
            }
        }

        public Response<List<DocumentViewModel>> GetDocumentByType(string type)
        {
            var response = new Response<List<DocumentViewModel>>();
            using (var srv = new FutureAssetDBContext())
            {
                var data = srv.Document.Where(a => a.IsActive && !a.IsDeleted && a.Type == type).OrderBy(a => a.Id);

                if (data.Any())
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<List<DocumentViewModel>>(data);
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            return response;
        }

        //Pagination Service
        public Response<List<DocumentViewModel>> GetDocumentsPagination(PaginationParameters parameters)
        {
            var response = new Response<List<DocumentViewModel>>();
            using (var srv = new FutureAssetDBContext())
            {
                var data = srv.Document.Where(a => a.IsActive && !a.IsDeleted).OrderBy(a => a.Id)
                    .Skip((parameters.PageNumber -1 )*parameters.PageSize).Take(parameters.PageSize);

                if (data.Any())
                {
                    response.IsSuccess = true;
                    response.Data = _mapper.Map<List<DocumentViewModel>>(data);
                }
                else
                {
                    response.IsSuccess = false;
                }
            }
            return response;
        }

    }
}
