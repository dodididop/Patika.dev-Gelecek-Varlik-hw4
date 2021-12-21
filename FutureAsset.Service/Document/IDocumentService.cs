using System;
using System.Collections.Generic;
using FutureAsset.Model;

namespace FutureAsset.Service.Document
{
    public interface IDocumentService
    {
        public Response<bool> Create(DocumentCreationModel newDocument);
        public Response<List<DocumentViewModel>> GetDocuments();
        public Response<DetailedDocumentModel> Update(DetailedDocumentModel updatedDocument);
        public Response<List<DetailedDocumentModel>> List(int pageSize, int currentPage, string nameStartsWith = "");
        public Response<bool> Delete(int id);
    }
}
