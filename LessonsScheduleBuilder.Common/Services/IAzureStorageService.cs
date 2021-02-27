using Microsoft.WindowsAzure.Storage.Queue;
using System.IO;
using System.Threading.Tasks;

namespace LessonsScheduleBuilder.Common.Services
{
    //interface added just an example of common service which can be reused in any app
    public interface IAzureStorageService
    {
        Task<bool> FileExistsAsync(string fileName, string containerName);

        Task ConnectAsync();

        Task<long> UploadFileAsync(Stream fileContents, string fileName, string containerName);

        Task<Stream> OpenFileAsync(string fileName, string containerName);

        Task InsertMessageToWebJobQueue(CloudQueueMessage message);
    }
}