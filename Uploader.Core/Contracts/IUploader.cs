namespace Uploader.Core.Contracts;

public interface IUploader
{
    Task UploadAsync(Video.Core.Entities.Video videoInfo, string videoPath);
}