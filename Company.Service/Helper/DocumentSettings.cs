using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Helper
{
    public class DocumentSettings
    {
        public static string UploadFile (IFormFile file, string folderName)
        {
            //1 get folder path
            //var foldrPath = @"D:\backend\MVC\Company.Web\Company.Web\wwwroot\Files\Images\";

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\Files", folderName);

            //2. get file name
            var fileName = $"{Guid.NewGuid()}-{file.FileName}";

            //3. combine folderpath+ filepath
            var filePath=Path.Combine(folderPath, fileName);

            //4. save fi;e
            using var fileStream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fileStream);

            return fileName;
        }
    }
}
