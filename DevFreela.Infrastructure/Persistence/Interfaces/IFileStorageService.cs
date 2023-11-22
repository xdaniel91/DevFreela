namespace DevFreela.Infrastructure.Persistence.Interfaces;
public interface IFileStorageService
{
    void UploadFile(byte[] bytes, string fileName);
}
