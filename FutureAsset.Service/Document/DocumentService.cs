using System;
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
    }
}
