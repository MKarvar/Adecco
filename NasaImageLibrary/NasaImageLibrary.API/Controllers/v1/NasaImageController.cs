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
            //SearchFilesWithPaginationQuery query = new SearchFilesWithPaginationQuery() { GetUsersQuery = fileQuery, PageNumber = pagingQuery.PageNumber, PageSize = pagingQuery.PageSize };
            //var usersDtos = await _mediator.Send(query, cancellationToken);
            var result = await _nasaService.Search(fileQuery, pagingQuery, cancellationToken);
            var pagedReponse = PaginationHelper.CreatePagedReponse(result.Items, pagingQuery, result.ItemsCount, _uriService, route);
            return Ok(pagedReponse);
        }
    }
}
