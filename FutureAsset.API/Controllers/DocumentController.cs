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

        [HttpGet]

        public Response<List<DetailedDocumentModel>> List([FromQuery] int pageSize, int currentPage, string nameStartsWith = "")
        {
            return _documentService.List(pageSize, currentPage, nameStartsWith);
        }

        [HttpPut]

        public Response<DetailedDocumentModel> Update(DetailedDocumentModel request)
        {
            return _documentService.Update(request);
        }
    }
}