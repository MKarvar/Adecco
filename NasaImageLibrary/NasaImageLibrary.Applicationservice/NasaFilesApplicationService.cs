using NasaImageLibrary.Applicationservice.Contracts;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace NasaImageLibrary.Applicationservice
{
    public class NasaFilesApplicationService : INasaFilesApplicationService
    {
        private readonly INasaExternalService _nasaService;
        const int defaultNasaPageCapacity = 100;
        const int defaultNasaPageNumber = 1;
        public NasaFilesApplicationService(INasaExternalService nasaService)
        {
            _nasaService = nasaService ?? throw new ArgumentNullException(nameof(nasaService));
        }

        public async Task<ItemSetDto> Search(SearchFilesQuery query, PaginationQuery pagingQuery, CancellationToken cancellationToken)
        {
            int nasaPageNumber = defaultNasaPageNumber;
            if (pagingQuery.PageNumber * pagingQuery.PageSize > defaultNasaPageCapacity)
            {
                nasaPageNumber = (pagingQuery.PageNumber * pagingQuery.PageSize) / defaultNasaPageCapacity + ((pagingQuery.PageNumber * pagingQuery.PageSize) % defaultNasaPageCapacity > 0 ? 1 : 0);
            }
            ExternalSearchFilesQuery mainQuery = new ExternalSearchFilesQuery()
            {
                q = query.SearchPhrase,
                year_start = query.StartYear,
                year_end = query.EndYear,
                page = nasaPageNumber
            };
            var fileDto = await _nasaService.Search(MakeQueryString(mainQuery), cancellationToken);
            int? totalRecords = fileDto?.collection?.metaData?.total_hits;

            ItemSetDto itemSet = new ItemSetDto()
            {
                Items = fileDto?.collection?.items,
                ItemsCount = totalRecords ?? 0
            };
            return itemSet;

        }
        public async Task<AssetDto> GetAsset(string nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetAsset(nasaId, cancellationToken);
        }
        public async Task<MetaDataDto> GetMetaData(string nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetMetaData(nasaId, cancellationToken);
        }
        public async Task<CaptionsDto> GetCaptions(string nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetCaptions(nasaId, cancellationToken);
        }

        private string MakeQueryString(ExternalSearchFilesQuery query)
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo propertyInfo in query.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(query, null);
                string name = propertyInfo.Name;
                if(propertyInfo.Name == "q")
                    sb.Append($"{value}&");
                else if (value != null)
                    sb.Append($"{propertyInfo.Name}={value}&");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

    }
}
