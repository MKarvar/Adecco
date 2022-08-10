using NasaImageLibrary.Applicationservice.Contracts;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using NasaImageLibrary.Infrastructure.Exceptions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Infrastructure
{
    public class NasaImageAndVideoLibraryService : INasaImageAndVideoLibraryService
    {
        private readonly INasaImageAndVideoLibraryClient _nasaImageAndVideoLibraryClient;

        public NasaImageAndVideoLibraryService(INasaImageAndVideoLibraryClient nasaImageAndVideoLibraryClient)
        {
            _nasaImageAndVideoLibraryClient = nasaImageAndVideoLibraryClient;
        }

        public Task GetAsset(int nasaId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task GetCaptions(int nasaId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task GetMetaData(int nasaId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<FileDto> Search(SearchFilesQuery query, CancellationToken cancellationToken)
        {
            var response = await _nasaImageAndVideoLibraryClient.Search(query, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new InfrastructureException($"Errot from Nasa api. ErrorCode = {response.StatusCode}", response.Error); if (!response.IsSuccessStatusCode)
            if (response.Content == null)
                    throw new InfrastructureException($"No content from Nasa api");
            return response.Content;
        }

    }
}
