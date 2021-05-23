using System;
using System.Collections.Generic;
using FileUpload.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }
            [HttpPost("Index")]
            public IActionResult Index(List<IFormFile> postedFiles)
            {
                var uploadedFiles = _fileUploadService.UploadFiles(postedFiles);
                foreach (var uploadedFile in uploadedFiles)
                {
                    ViewBag.Message += $"{uploadedFile} uploaded. {Environment.NewLine}";    
                }
                return View();
            }
        }
}
