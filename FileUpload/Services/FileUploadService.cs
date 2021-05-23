using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace FileUpload.Services
{
    public interface IFileUploadService
    {
        List<string> UploadFiles(List<IFormFile> postedFiles);
    }
    
    public class FileUploadService:IFileUploadService
    {
        public List<string> UploadFiles(List<IFormFile> postedFiles)
        {
            var uploadedFiles = new List<string>();
            string path = Path.Combine(Path.GetTempPath(), "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var postedFile in postedFiles)
            {
                string fileName = Path.GetFileName(postedFile.FileName);
                using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    uploadedFiles.Add(fileName);
                }
            }

            return uploadedFiles;
        }
    }
}