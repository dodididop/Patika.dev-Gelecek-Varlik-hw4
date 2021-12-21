using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FutureAsset.DB.Entities.DatabaseContext;
using FutureAsset.Model;

namespace FutureAsset.Service.Document
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper _mapper;

        public DocumentService(IMapper mapper)
        {
            _mapper = mapper;
        }

        //Create new document
        public Response<bool> Create(DocumentCreationModel newDocument)
        {
            try
            {
                var document = _mapper.Map<FutureAsset.DB.Entities.Document>(newDocument);

                document.CreateDate = DateTime.Now.Date;
                document.IsActive = true;
                document.IsDeleted = false;

                using (var srv = new FutureAssetDBContext())
                {
                    srv.Document.Add(document);
                    srv.SaveChanges();
                    return new Response<bool>(true);
                }
            }
            catch (Exception)
            { 
                return new Response<bool>(false);
            }
        }

        //Get all the documents.
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

        //Pagination, filtering, sorting.
        public Response<List<DetailedDocumentModel>> List( int pageSize, int currentPage, string nameStartsWith="")
        {
            var result = new Response<List<DetailedDocumentModel>>() { IsSuccess = false };

            using (var srv = new FutureAssetDBContext())
            {
                var _result =srv.Document.Where(x=>x.IsActive && !x.IsDeleted);
                _result = String.IsNullOrEmpty(nameStartsWith) ? _result : _result.Where(x=> x.Type.StartsWith(nameStartsWith));//Filter
                _result = _result.OrderBy(x => x.DocDate);//ascending order by document date.
                _result = _result.Skip((currentPage - 1) * pageSize).Take(pageSize);//Pagination
                result.Data = _mapper.Map<List<DetailedDocumentModel>>(_result);
                result.IsSuccess = true;
                return result;
            }
        }

        //update document.
        public Response<DetailedDocumentModel> Update(DetailedDocumentModel updatedDocument)
        {
            var response = new Response<DetailedDocumentModel>();
            using (var srv = new FutureAssetDBContext())
            {
                var document = srv.Document.Find(updatedDocument.Id);

                if (document is not null)
                {
                    document.ModificationDate = DateTime.Now;
                    srv.SaveChanges();
                    response.Data = _mapper.Map<DetailedDocumentModel>(document);
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "Something went wrong.";
                    response.IsSuccess = false;
                }
                return response;
            }
        }
    }
}
