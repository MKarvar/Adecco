using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Infrastructure
{
    public interface INasaImageAndVideoLibraryClient
    {
        [Get("/search?q={q}")]
        Task<ApiResponse<FileDto>> Search(string q, CancellationToken cancellationToken);
        [Get("/asset/{nasa_id}")]
        Task<ApiResponse<AssetDto>> GetAsset(int nasa_id, CancellationToken cancellationToken);
        [Get("/metadata/{nasa_id}")]
        Task<ApiResponse<MetaDataDto>> GetMetaData(int nasa_id, CancellationToken cancellationToken);
        [Get("/captions/{nasa_id}")]
        Task<ApiResponse<CaptionsDto>> GetCaptions(int nasa_id, CancellationToken cancellationToken);
    }
}
