using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restoran.Controllers
{
    [Route("upload")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        public IWebHostEnvironment _enviroment;
        public FileUploadController(IWebHostEnvironment enviroment)
        {
            _enviroment = enviroment;
        }

        public class FileUpload
        {
           public String Name { get; set; }

            public IFormFile ObjFile { get; set; }
        }

        public async Task<string> Post(FileUpload file)
        {
            DateTime dt = DateTime.Now;
            try
            {
                if (file.ObjFile.Length > 0)
                {
                    if (!Directory.Exists(_enviroment.WebRootPath + "\\Upload\\"))
                    {
                        Directory.CreateDirectory(_enviroment.WebRootPath + "\\Upload\\");

                    }
                    using (FileStream filestream = new FileStream(Path.Combine(_enviroment.ContentRootPath, "Upload",dt.Millisecond.ToString() + "file.pdf"), FileMode.Create, FileAccess.Write))
                    // using (FileStream fileStream = System.IO.File.Create(_enviroment.WebRootPath + "\\Upload\\" + objFile.files.FileName))
                    {
                        await file.ObjFile.CopyToAsync(filestream);
                        return "Uploaded";

                    }
                }

                else return "Failed";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();

            }
        }

        [Route("/getFile/{fileName}")]
        public ActionResult GetFile(string fileName)
        { 
            var stream = new FileStream(Path.Combine(_enviroment.ContentRootPath, "Upload", fileName), FileMode.Open);
            return new FileStreamResult(stream, "application/pdf");

        }
    }
}