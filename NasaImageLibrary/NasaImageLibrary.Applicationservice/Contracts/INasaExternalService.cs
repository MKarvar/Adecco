using Microsoft.AspNetCore.Http;
using NasaImageLibrary.Applicationservice.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice.Contracts
{
    public interface INasaExternalService
    {
        Task<FileDto> Search(string queryString, CancellationToken cancellationToken);
        Task<AssetDto> GetAsset(string nasaId, CancellationToken cancellationToken);
        Task<MetaDataDto> GetMetaData(string nasaId, CancellationToken cancellationToken);
        Task<CaptionsDto> GetCaptions(string nasaId, CancellationToken cancellationToken);
    }
}
