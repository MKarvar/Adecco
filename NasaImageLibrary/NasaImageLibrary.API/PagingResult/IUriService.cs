using NasaImageLibrary.Applicationservice.Queries;
using System;

namespace NasaImageLibrary.API.PagingResult
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationQuery quey, string route);
    }
}
