using System.Collections.Generic;
using AutoMapper;
using FutureAsset.Model;
using FutureAsset.Service.Document;
using Microsoft.AspNetCore.Mvc;

namespace FutureAsset.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentService documentService, IMapper mapper)
        {
            _documentService = documentService;
            _mapper = mapper;
        }

        [HttpPost]
        public Response<bool> Create([FromBody] DocumentCreationModel request)
        {
            return _documentService.Create(request);
        }

        [HttpGet("GetAll")]
        public Response<List<DocumentViewModel>> GetDocuments()
        {
            return _documentService.GetDocuments();
        }

        [HttpGet("GetById/{id}")]

        public Response<DocumentViewModel> GetDocumentById(int id)
        {
            return _documentService.GetDocumentById(id);
        }

        [HttpGet("GetByType/{type}")]

        public Response<List<DocumentViewModel>> GetDocumentByType(string type)
        {
            return _documentService.GetDocumentByType(type);
        }

        [HttpPut]

        public Response<DetailedDocumentModel> Update(DetailedDocumentModel request)
        {
            return _documentService.Update(request);
        }

        [HttpGet("GetDocumentsWithPage")]//Pagination

        public Response<List<DocumentViewModel>> GetDocuments([FromQuery]PaginationParameters parameters)
        {
            return _documentService.GetDocumentsPagination(parameters);
        }
    }
}