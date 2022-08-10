using System;
using System.Collections.Generic;


namespace NasaImageLibrary.Applicationservice.Dtos
{
    public class PagedResultDto<TEntity> where TEntity : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public Uri FirstPage { get; set; }
        public Uri LastPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public Uri NextPage { get; set; }
        public Uri PreviousPage { get; set; }
        public IEnumerable<TEntity> DataList { get; set; }

        public PagedResultDto(int pageSize, int pageNumber)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
        }
        public PagedResultDto(int pageSize, int pageNumber, IEnumerable<TEntity> dataList)
            : this(pageSize, pageNumber)
        {
            DataList = dataList;
        }

        public PagedResultDto(int pageSize, int pageNumber, IEnumerable<TEntity> dataList, int totalRecords)
            : this(pageSize, pageNumber, dataList)
        {
            TotalRecords = totalRecords;
        }
        public PagedResultDto(int pageSize, int pageNumber, IEnumerable<TEntity> dataList, int totalRecords, int totalPages)
           : this(pageSize, pageNumber, dataList, totalRecords)
        {
            TotalPages = totalPages;
        }
    }
}
