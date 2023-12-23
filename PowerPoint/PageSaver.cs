using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GoogleDriveUploader.GoogleDrive;
using System.Threading;
using GoogleDriveFile = Google.Apis.Drive.v2.Data.File;
using Point = System.Drawing.Point;

namespace PowerPoint
{
    public class PageSaver : IPageSaver
    {
        const string APPLICATION_NAME = "PowerPoint";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
        const string FILE_NAME_TYPE = "ShapesInfo";
        const string FILE_EXTENSION = ".txt";
        GoogleDriveService _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);

        // save
        public void Save(string fileContent)
        {
            const string CONTENT_TYPE = "text/plain";
            string fileName = Path.GetTempPath() + FILE_NAME_TYPE + Guid.NewGuid().ToString() + FILE_EXTENSION;
            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(fileContent);
            }
            _service.UploadFile(fileName, CONTENT_TYPE);
        }

        // get
        private List<GoogleDriveFile> GetAllShapeInfoFileNames()
        {
            const string FOLDER_MIME_TYPE = @"application/vnd.google-apps.folder";

            var rootFolderFiles = _service.ListRootFileAndFolder();
            rootFolderFiles.RemoveAll(removeItem => removeItem.MimeType == FOLDER_MIME_TYPE);
            rootFolderFiles.RemoveAll(removeItem => removeItem.FileExtension == FILE_EXTENSION);
            rootFolderFiles.RemoveAll(removeItem => removeItem.OriginalFilename == null || !removeItem.OriginalFilename.StartsWith(FILE_NAME_TYPE));
            rootFolderFiles.Reverse();

            return rootFolderFiles;
        }

        // get shape type
        private ShapeType GetShapeType(string shapeName)
        {
            if (shapeName == Circle.SHAPE_NAME)
            {
                return ShapeType.Circle;
            }
            if (shapeName == Rectangle.SHAPE_NAME)
            {
                return ShapeType.Rectangle;
            }
            if (shapeName == Line.SHAPE_NAME)
            {
                return ShapeType.Line;
            }
            return ShapeType.None;
        }

        // parse
        private void ConstructPage(string fileName, List<Page> pages)
        {
            try
            {
                using (var reader = new StreamReader(fileName))
                {
                    const int EXPECTED_LINE_LENGTH = 5;
                    while (reader.Peek() > 0)
                    {
                        var lineData = reader.ReadLine().Trim().Split(Shape.SEPARATOR);
                        if (lineData.Length != EXPECTED_LINE_LENGTH)
                            throw new FileFormatException();
                        var shapeType = GetShapeType(lineData[0]);
                        if (shapeType == ShapeType.None)
                            throw new FileFormatException();
                        const int P1_X_INDEX = 1;
                        const int P1_Y_INDEX = 2;
                        const int P2_X_INDEX = 3;
                        const int P2_Y_INDEX = 4;
                        var pointFirst = new Point(int.Parse(lineData[P1_X_INDEX]), int.Parse(lineData[P1_Y_INDEX]));
                        var pointSecond = new Point(int.Parse(lineData[P2_X_INDEX]), int.Parse(lineData[P2_Y_INDEX]));
                        pages.Last().AddShape(shapeType, pointFirst, pointSecond);
                    }
                }
            }
            catch (Exception)
            {
                pages.Remove(pages.Last());
            }
        }

        // load
        public List<Page> Load()
        {
            var files = GetAllShapeInfoFileNames();
            var pages = new List<Page>();
            foreach (var file in files)
            {
                const string SLASH = @"\";
                var fileName = Path.GetTempPath() + SLASH + file.OriginalFilename;
                _service.DownloadFile(file, Path.GetTempPath());
                if (!File.Exists(fileName))
                    continue;
                pages.Add(new Page());
                ConstructPage(fileName, pages);
            }
            return pages;
        }
    }
}
