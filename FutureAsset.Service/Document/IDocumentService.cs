using System;
using System.Collections.Generic;
using FutureAsset.Model;

namespace FutureAsset.Service.Document
{
    public interface IDocumentService
    {
        public Response<bool> Create(DocumentViewModel newDocument);
        public Response<List<DocumentViewModel>> GetDocuments();
        public Response<DocumentViewModel> GetDocumentById(int id);
        public Response<DetailedDocumentModel> Update(int id, DetailedDocumentModel updatedDocument);
        public Response<List<DocumentViewModel>> GetDocumentByType(string type);
    }
}
