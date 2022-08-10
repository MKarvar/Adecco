using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using NasaImageLibrary.API.PagingResult;
using NasaImageLibrary.Applicationservice.Contracts;

namespace NasaImageLibrary.API.Controllers.v1
{
    [ApiVersion("1")]
    public class NasaImageController : BaseApiController
    {
        protected readonly ILogger<NasaImageController> _logger;
        private readonly IUriService _uriService;
        private readonly INasaFilesApplicationService _nasaService;
        public NasaImageController(ILogger<NasaImageController> iLogger, IUriService uriService, INasaFilesApplicationService nasaService)
        {
            _logger = iLogger ?? throw new ArgumentNullException(nameof(iLogger)); 
            _uriService = uriService ?? throw new ArgumentNullException(nameof(uriService));
            _nasaService = nasaService ?? throw new ArgumentNullException(nameof(nasaService));
        }


        [HttpGet("[action]")]
        public virtual async Task<ApiResult<PagedResultDto<Item>>> GetAll([FromQuery]SearchFilesQuery fileQuery, [FromQuery] PaginationQuery pagingQuery, CancellationToken cancellationToken)
        {
            var route = Request.Path.Value;
            var result = await _nasaService.Search(fileQuery, pagingQuery, cancellationToken);
            var pagedReponse = PaginationHelper.CreatePagedReponse(result.Items, pagingQuery, result.ItemsCount, _uriService, route);
            return Ok(pagedReponse);
        }
        [HttpGet("[action]")]
        public virtual async Task<ApiResult<AssetDto>> GetAssets([FromQuery] string id, CancellationToken cancellationToken)
        {
            var result = await _nasaService.GetAsset(id, cancellationToken);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public virtual async Task<ApiResult<MetaDataDto>> GetMetaData([FromQuery] string id, CancellationToken cancellationToken)
        {
            var result = await _nasaService.GetMetaData(id, cancellationToken);
            return Ok(result);
        }
        [HttpGet("[action]")]
        public virtual async Task<ApiResult<CaptionsDto>> GetCaption([FromQuery] string id, CancellationToken cancellationToken)
        {
            var result = await _nasaService.GetCaptions(id, cancellationToken);
            return Ok(result);
        }
    }
}
