using NasaImageLibrary.Applicationservice.Contracts;
using NasaImageLibrary.Applicationservice.Dtos;
using NasaImageLibrary.Applicationservice.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice
{
    public class NasaFilesApplicationService
    {
        private readonly INasaFilesApplicationService _nasaService;
        public NasaFilesApplicationService(INasaFilesApplicationService nasaService)
        {
            _nasaService = nasaService ?? throw new ArgumentNullException(nameof(nasaService));
        }
        public async Task<FileDto> Search(SearchFilesQuery query, CancellationToken cancellationToken)
        {
            return await _nasaService.Search(query, cancellationToken);
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
