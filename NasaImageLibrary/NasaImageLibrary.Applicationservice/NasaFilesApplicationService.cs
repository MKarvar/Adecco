using NasaImageLibrary.Applicationservice.Contracts;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        //public async Task<PagedResultDto<Item>> Search(SearchFilesQuery query, CancellationToken cancellationToken)
        //{
        //    int nasaPageNumber = defaultNasaPageNumber;
        //    if (query.PageNumber * query.PageSize > defaultNasaPageCapacity)
        //    {
        //        nasaPageNumber = (query.PageNumber * query.PageSize) / defaultNasaPageCapacity + ((query.PageNumber * query.PageSize) % defaultNasaPageCapacity > 0 ? 1 : 0);
        //    }

        //    ExternalSearchFilesQuery mainQuery = new ExternalSearchFilesQuery()
        //    {
        //        SearchPhrase = query.SearchPhrase,
        //        StartYear = query.StartYear,
        //        EndYear = query.EndYear,
        //        NasaPageNumber = nasaPageNumber
        //    };

        //    var fileDto =  await _nasaService.Search(mainQuery, cancellationToken);
        //    int? totalRecords = fileDto?.collection?.metaData?.total_hits;
        //    int totalPages = totalRecords.HasValue ? (totalRecords.Value / query.PageSize) + ((totalRecords.Value % query.PageSize) > 0 ? 1 : 0) : 0;

        //    List<Item> items =  fileDto?.collection?.items;

        //    List<Item> itemsSlotTask = items.Skip((query.PageNumber - 1) * query.PageSize)
        //                      .Take(query.PageSize).ToList();

        //    return new PagedResultDto<Item>(query.PageSize, query.PageNumber, itemsSlotTask, totalRecords ?? 0, totalPages);

        //}

        public async Task<ItemSetDto> Search(SearchFilesQuery query,PaginationQuery pagingQuery, CancellationToken cancellationToken)
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
            var fileDto = await _nasaService.Search(mainQuery, cancellationToken);
            int? totalRecords = fileDto?.collection?.metaData?.total_hits;
            //int totalPages = totalRecords.HasValue ? (totalRecords.Value / pagingQuery.PageSize) + ((totalRecords.Value % pagingQuery.PageSize) > 0 ? 1 : 0) : 0;

            ItemSetDto itemSet = new ItemSetDto()
            {
                Items = fileDto?.collection?.items,
                ItemsCount = totalRecords ?? 0
            };
            return itemSet;

        }
        public async Task<AssetDto> GetAsset(int nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetAsset(nasaId, cancellationToken);
        }
        public async Task<MetaDataDto> GetMetaData(int nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetMetaData(nasaId, cancellationToken);
        }
        public async Task<CaptionsDto> GetCaptions(int nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetCaptions(nasaId, cancellationToken);
        }

        private string MakeQueryString(ExternalSearchFilesQuery query)
        {
            //string queryString = JsonConvert.SerializeObject(query);
            //"https://images-api.nasa.gov/search?q=apollo%2011&description=moon%20landing&media_type=image"

            StringBuilder sb = new StringBuilder();
            sb.Append("search?");
            foreach (PropertyInfo propertyInfo in query.GetType().GetProperties())
            {
                sb.Append($"{propertyInfo.Name}={propertyInfo.GetValue(query, null)}");
            }
            return sb.ToString();
        }
    }
}
