using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GoogleDriveUploader.GoogleDrive;
using System.Threading;

namespace PowerPoint
{
    public class PageSaver : IPageSaver
    {
        const string APPLICATION_NAME = "PowerPoint";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
        GoogleDriveService _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);

        // save
        public void Upload(string fileContent)
        {
            const string CONTENT_TYPE = "text/plain";
            string fileName = Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(fileContent);
            }
            _service.UploadFile(fileName, CONTENT_TYPE);
        }
    }
}
