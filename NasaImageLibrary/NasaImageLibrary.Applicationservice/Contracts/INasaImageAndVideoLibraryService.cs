using NasaImageLibrary.Applicationservice.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace NasaImageLibrary.Applicationservice.Contracts
{
    public interface INasaImageAndVideoLibraryService
    {
        Task Search(SearchFilesQuery query, CancellationToken cancellationToken);
        Task GetAsset(int nasaId, CancellationToken cancellationToken);
        Task GetMetaData(int nasaId, CancellationToken cancellationToken);
        Task GetCaptions(int nasaId, CancellationToken cancellationToken);
    }
}
