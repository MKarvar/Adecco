﻿using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice.Contracts
{
    public interface INasaImageAndVideoLibraryService
    {
        Task<FileDto> Search(SearchFilesQuery query, CancellationToken cancellationToken);
        Task GetAsset(int nasaId, CancellationToken cancellationToken);
        Task GetMetaData(int nasaId, CancellationToken cancellationToken);
        Task GetCaptions(int nasaId, CancellationToken cancellationToken);
    }
}
