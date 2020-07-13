using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.IO;
using Google.Apis.Drive.v3;
using Google.Apis.Download;
using System.Web;
using Microsoft.AspNetCore.Hosting.Internal;
using ChildCare.MonitoringSystem.Common.Extensions;
using ChildCare.MonitoringSystem.Web.Models;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Hosting;
namespace GoogleDriveUploadMVC.Models
{
    
    public class GoogleDriveAPIHelper 
    {
        HostingEnvironment HostingEnvironment = new HostingEnvironment();
        private readonly IHostingEnvironment environment;
        //add scope
        //static string ApplicationName = "Quickstart";
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };
        private readonly string profilePicPath = "Drive";
        static string ApplicationName = "Quickstart";
        public GoogleDriveAPIHelper()
        {
            this.environment = environment;
        }
        //create Drive API service.
        public static DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            string imageName = Guid.NewGuid().ToString();
            //Root Folder of project
            var CSPath = Guid.NewGuid().ToString();
            using (var stream = new FileStream(Path.Combine(CSPath, "38482218592-fhko765150i2sc70cjfn4saff9jegnah.apps.googleusercontent.com.json"), FileMode.Open, FileAccess.Read))
            {
                String FolderPath = Guid.NewGuid().ToString();
                String FilePath = Path.Combine(FolderPath, "credentialss.json");
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(FilePath, true)).Result;
            }
            //create Drive API service.
            DriveService service = new Google.Apis.Drive.v3.DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }


        //get all files from Google Drive.
        public static List<GoogleDriveFile> GetDriveFiles()
        {
            Google.Apis.Drive.v3.DriveService service = GetService();
            // Define parameters of request.
            Google.Apis.Drive.v3.FilesResource.ListRequest FileListRequest = service.Files.List();

            // for getting folders only.
            //FileListRequest.Q = "mimeType='application/vnd.google-apps.folder'";
            FileListRequest.Fields = "nextPageToken, files(*)";
            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDriveFile> FileList = new List<GoogleDriveFile>();
            // For getting only folders
            // files = files.Where(x => x.MimeType == "application/vnd.google-apps.folder").ToList();
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    GoogleDriveFile File = new GoogleDriveFile
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime,
                        Parents = file.Parents,
                        MimeType = file.MimeType
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }


        //file Upload to the Google Drive root folder.
        public static void UplaodFileOnDrive(StudentDetail file)
        {
            if (file != null)
            {
                //create service
                DriveService service = GetService();
                string path = Path.Combine(Guid.NewGuid().ToString());
                Path.GetFileName(file.StudentName);
              //  file.SaveAs(path);
                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(file.StudentName);
               // FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
             


            }
        }
     
        //Download file from Google Drive by fileId.
        //public static string DownloadGoogleFile(string fileId)
        //{
        //    DriveService service = GetService();
        //    string FolderPath = HttpContext.Current.Server.MapPath("/GoogleDriveFiles/");
        //   FilesResource.GetRequest request = service.Files.Get(fileId);
        //    string FileName = request.Execute().Name;
        //    string FilePath = Path.Combine(FolderPath, FileName);
        //    MemoryStream stream1 = new MemoryStream();
        //    // Add a handler which will be notified on progress changes.
        //    // It will notify on each chunk download and when the
        //    // download is completed or failed.
        //    request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
        //    {
        //        switch (progress.Status)
        //        {
        //            case DownloadStatus.Downloading:
        //                {
        //                    Console.WriteLine(progress.BytesDownloaded);
        //                    break;
        //                }
        //            case DownloadStatus.Completed:
        //                {
        //                    Console.WriteLine("Download complete.");
        //                    SaveStream(stream1, FilePath);
        //                    break;
        //                }
        //            case DownloadStatus.Failed:
        //                {
        //                    Console.WriteLine("Download failed.");
        //                    break;
        //                }
        //        }
        //    };
        //    request.Download(stream1);
        //    return FilePath;
        //}

        // file save to server path
        private static void SaveStream(MemoryStream stream, string FilePath)
        {
            using (FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }


        // Create Folder in root
        public static void CreateFolder(string FolderName)
        {
            DriveService service = GetService();
            var FileMetaData = new Google.Apis.Drive.v3.Data.File();
            FileMetaData.Name = FolderName;
            //this mimetype specify that we need folder in google drive
            FileMetaData.MimeType = "application/vnd.google-apps.folder";
           FilesResource.CreateRequest request;
            request = service.Files.Create(FileMetaData);
            request.Fields = "id";
            var file = request.Execute();
            
        }

        // File upload in existing folder
        //public static void FileUploadInFolder(string folderId, HttpPostedFileBase file)
        //{
        //    if (file != null && file.ContentLength > 0)
        //    {
        //        //create service
        //        DriveService service = GetService();
        //        //get file path
        //        string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
        //        Path.GetFileName(file.FileName));
        //        file.SaveAs(path);
        //        //create file metadata
        //        var FileMetaData = new Google.Apis.Drive.v3.Data.File()
        //        {
        //            Name = Path.GetFileName(file.FileName),
        //            MimeType = MimeMapping.GetMimeMapping(path),
        //            //id of parent folder 
        //            Parents = new List<string>
        //            {
        //                folderId
        //            }
        //        };
        //        FilesResource.CreateMediaUpload request;
        //        //create stream and upload
        //        using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
        //        {
        //            request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
        //            request.Fields = "id";
        //            request.Upload();
        //        }
        //        var file1 = request.ResponseBody;
        //    }
        //}


        public static List<GoogleDriveFile> GetDriveFolders()
        {
            DriveService service = GetService();
            List<GoogleDriveFile> FolderList = new List<GoogleDriveFile>();
            FilesResource.ListRequest request = service.Files.List();
            request.Q = "mimeType='application/vnd.google-apps.folder'";
            request.Fields = "files(id, name)";
            Google.Apis.Drive.v3.Data.FileList result = request.Execute();
            foreach (var file in result.Files)
            {
                GoogleDriveFile File = new GoogleDriveFile
                {
                    Id = file.Id,
                    Name = file.Name,
                    Size = file.Size,
                    Version = file.Version,
                    CreatedTime = file.CreatedTime
                };
                FolderList.Add(File);
            }
            return FolderList;
        }
    }
}