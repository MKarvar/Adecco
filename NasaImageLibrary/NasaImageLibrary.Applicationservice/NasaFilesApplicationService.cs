using NasaImageLibrary.Applicationservice.Contracts;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice
{
    public class NasaFilesApplicationService : INasaFilesApplicationService
    {
        private readonly INasaExternalService _nasaService;
        public NasaFilesApplicationService(INasaExternalService nasaService)
        {
            _nasaService = nasaService ?? throw new ArgumentNullException(nameof(nasaService));
        }
        public async Task<List<Item>> Search(SearchFilesQuery query, CancellationToken cancellationToken)
        {
            var fileDto =  await _nasaService.Search(query, cancellationToken);
            return  fileDto?.collection?.items;
        }
        public async Task<AssetDto> GetAsset(int nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetAsset(nasaId, cancellationToken);
        }
        public async Task<MetaDataDto> GetMetaData(int nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetMetaData(nasaId, cancellationToken);
        }
        public async Task<CaptionsDto> GetCaptions(int nasaId, CancellationToken cancellationToken)
        {
            return await _nasaService.GetCaptions(nasaId, cancellationToken);
        }
    }
}
