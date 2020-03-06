using System.Threading;
using System.Threading.Tasks;

namespace StableCube.DigitalOcean.DotNetClient
{
    public interface IBlockStorageEndpoint
    {
        Task<Volume> CreateVolumeAsync(
            BlockStorageVolCreate data,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Volume> GetVolumeAsync(
            string volumeId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Volume> GetVolumeByNameAsync(
            string volumeName,
            string region = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<Volume[]> GetAllVolumesAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<Volume[]> GetAllVolumesByNameAsync(
            string volumeName,
            string region = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task DeleteVolumeAsync(
            string volumeId,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task DeleteVolumeByNameAsync(
            string volumeName,
            string region = null,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<DigitalOceanAction> AttachVolumeAsync(
            string volumeId,
            VolumeAttach data,
            CancellationToken cancellationToken = default(CancellationToken)
        );

        Task<DigitalOceanAction> DetachVolumeAsync(
            string volumeId,
            VolumeDetach data,
            CancellationToken cancellationToken = default(CancellationToken)
        );
    }
}