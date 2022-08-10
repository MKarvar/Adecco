﻿
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice.Contracts
{
    public interface INasaFilesApplicationService
    {
        //Task<PagedResultDto<Item>> Search(SearchFilesQuery query, CancellationToken cancellationToken);
        Task<ItemSetDto> Search(SearchFilesQuery query, PaginationQuery pagingQuery, CancellationToken cancellationToken);
        Task<AssetDto> GetAsset(int nasaId, CancellationToken cancellationToken);
        Task<MetaDataDto> GetMetaData(int nasaId, CancellationToken cancellationToken);
        Task<CaptionsDto> GetCaptions(int nasaId, CancellationToken cancellationToken);
    }
}
