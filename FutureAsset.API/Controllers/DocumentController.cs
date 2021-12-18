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
        public Response<bool> Create([FromBody] DocumentViewModel request)
        {
            return _documentService.Create(request);
        }
    }
}