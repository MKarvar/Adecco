using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using System;
using System.Collections.Generic;

namespace NasaImageLibrary.API.PagingResult
{
    public class PaginationHelper
    {
        public static PagedResultDto<T> CreatePagedReponse<T>(IEnumerable<T> pagedData, PaginationQuery query, int totalRecords, IUriService uriService, string route) where T : class
        {
            var respose = new PagedResultDto<T>(query.PageSize, query.PageNumber, pagedData);
            var totalPages = ((double)totalRecords / (double)query.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages));
            respose.NextPage =
                query.PageNumber >= 1 && query.PageNumber < roundedTotalPages
                ? uriService.GetPageUri(new PaginationQuery() { PageNumber = query.PageNumber + 1, PageSize = query.PageSize }, route)
                : null;
            respose.PreviousPage =
                query.PageNumber - 1 >= 1 && query.PageNumber <= roundedTotalPages
                ? uriService.GetPageUri(new PaginationQuery() { PageNumber = query.PageNumber - 1, PageSize = query.PageSize }, route)
                : null;
            respose.FirstPage = uriService.GetPageUri(new PaginationQuery() { PageNumber = totalPages == 0 ? 0 : 1, PageSize = query.PageSize }, route);
            respose.LastPage = uriService.GetPageUri(new PaginationQuery() { PageNumber = roundedTotalPages, PageSize = query.PageSize }, route);
            respose.TotalPages = roundedTotalPages;
            respose.TotalRecords = totalRecords;
            return respose;
        }
    }
}
