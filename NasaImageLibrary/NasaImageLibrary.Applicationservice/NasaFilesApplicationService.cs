using NasaImageLibrary.Applicationservice.Contracts;
using NasaImageLibrary.Applicationservice.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice
{
    public class NasaFilesApplicationService
    {
        private readonly INasaImageAndVideoLibraryService _nasaService;
        public NasaFilesApplicationService(INasaImageAndVideoLibraryService nasaService)
        {
            _nasaService = nasaService ?? throw new ArgumentNullException(nameof(nasaService));
        }
        public Task Search(SearchFilesQuery query, CancellationToken cancellationToken)
        {
            return null;
        }
        Task GetAsset(int nasaId, CancellationToken cancellationToken)
        {
            return null;

        }
        Task GetMetaData(CancellationToken cancellationToken)
        {
            return null;

        }
        Task GetCaptions(CancellationToken cancellationToken)
        {
            return null;

        }
    }
}
