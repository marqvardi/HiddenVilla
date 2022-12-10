using Microsoft.AspNetCore.Components.Forms;

namespace HiddenVilla_server.IService
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);
        bool DeleteFile(string fileName);
    }
}
