using Microsoft.AspNetCore.Http;
using NasaImageLibrary.Applicationservice.Contracts;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using NasaImageLibrary.Infrastructure.Exceptions;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Infrastructure
{
    public class NasaExternalService : INasaExternalService
    {
        private readonly INasaImageAndVideoLibraryClient _nasaImageAndVideoLibraryClient;

        public NasaExternalService(INasaImageAndVideoLibraryClient nasaImageAndVideoLibraryClient)
        {
            _nasaImageAndVideoLibraryClient = nasaImageAndVideoLibraryClient;
        }

        public async Task<AssetDto> GetAsset(string nasaId, CancellationToken cancellationToken)
        {
            var response = await _nasaImageAndVideoLibraryClient.GetAsset(nasaId, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new InfrastructureException($"Errot from Nasa api GetAsset action. ErrorCode = {response.StatusCode}", response.Error); if (!response.IsSuccessStatusCode)
                if (response.Content == null)
                    throw new InfrastructureException($"No content from Nasa api");
            return response.Content;
        }

        public async Task<CaptionsDto> GetCaptions(string nasaId, CancellationToken cancellationToken)
        {
            var response = await _nasaImageAndVideoLibraryClient.GetCaptions(nasaId, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new InfrastructureException($"Errot from Nasa api GetCaptions action. ErrorCode = {response.StatusCode}", response.Error); if (!response.IsSuccessStatusCode)
                if (response.Content == null)
                    throw new InfrastructureException($"No content from Nasa api");
            return response.Content;
        }

        public async Task<MetaDataDto> GetMetaData(string nasaId, CancellationToken cancellationToken)
        {
            var response = await _nasaImageAndVideoLibraryClient.GetMetaData(nasaId, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new InfrastructureException($"Errot from Nasa api GetMetaData action. ErrorCode = {response.StatusCode}", response.Error); if (!response.IsSuccessStatusCode)
                if (response.Content == null)
                    throw new InfrastructureException($"No content from Nasa api");
            return response.Content;
        }

        public async Task<FileDto> Search(string queryString, CancellationToken cancellationToken)
        {
            var response = await _nasaImageAndVideoLibraryClient.Search(queryString, cancellationToken);
            if (!response.IsSuccessStatusCode)
                throw new InfrastructureException($"Errot from Nasa api Search action. ErrorCode = {response.StatusCode}", response.Error);
            if (response.Content == null)
                    throw new InfrastructureException($"No content from Nasa api");
            return response.Content;
        }
    }
}
