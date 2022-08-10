
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice.Contracts
{
    public interface INasaFilesApplicationService
    {
        //Task<PagedResultDto<Item>> Search(SearchFilesQuery query, CancellationToken cancellationToken);
        Task<ItemSetDto> Search(SearchFilesQuery query, PaginationQuery pagingQuery, CancellationToken cancellationToken);
        Task<AssetDto> GetAsset(string nasaId, CancellationToken cancellationToken);
        Task<MetaDataDto> GetMetaData(string nasaId, CancellationToken cancellationToken);
        Task<CaptionsDto> GetCaptions(string nasaId, CancellationToken cancellationToken);
    }
}
