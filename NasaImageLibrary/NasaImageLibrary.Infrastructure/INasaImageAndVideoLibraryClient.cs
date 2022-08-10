using Microsoft.AspNetCore.Http;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using Refit;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Infrastructure
{
    public interface INasaImageAndVideoLibraryClient
    {
        [QueryUriFormat(UriFormat.Unescaped)]
        [Get("/search?q={q}")]
        //[Get("/search?{q}")]
        Task<ApiResponse<FileDto>> Search([Query] string q, CancellationToken cancellationToken);
        [Get("/asset/{nasa_id}")]
        Task<ApiResponse<AssetDto>> GetAsset(string nasa_id, CancellationToken cancellationToken);
        [Get("/metadata/{nasa_id}")]
        Task<ApiResponse<MetaDataDto>> GetMetaData(string nasa_id, CancellationToken cancellationToken);
        [Get("/captions/{nasa_id}")]
        Task<ApiResponse<CaptionsDto>> GetCaptions(string nasa_id, CancellationToken cancellationToken);
    }
}
