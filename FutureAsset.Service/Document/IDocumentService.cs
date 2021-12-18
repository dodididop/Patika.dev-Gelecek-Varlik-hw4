using System;
using FutureAsset.Model;

namespace FutureAsset.Service.Document
{
    public interface IDocumentService
    {
        public Response<bool> Create(DocumentViewModel newDocument);
    }
}
