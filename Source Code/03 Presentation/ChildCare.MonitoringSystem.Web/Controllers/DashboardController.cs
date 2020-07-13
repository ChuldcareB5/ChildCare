
﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChildCare.MonitoringSystem.Web.Models;
using ChildCare.MonitoringSystem.Model;
using ChildCare.MonitoringSystem.Business;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using ChildCare.MonitoringSystem.Core.Models;
using Google.Apis.Drive.v3;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using Microsoft.AspNetCore.Hosting.Internal;
using System.Web;
using ChildCare.MonitoringSystem.Common.Helpers;
using System.Collections;
using Google.Apis.Download;
using GoogleDriveUploadMVC.Models;
using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;

namespace ChildCare.MonitoringSystem.Web.Controllers
{
    //  [Authorize(Roles = "1")]

    //[Route("api/[controller]")]
    //[ApiController]
    public class DashboardController : Controller
	{
		private readonly ApplicationContext applicationContext;
		private readonly StudentBusiness studentBusiness;
		private readonly UserBusiness userBusiness;
		private readonly string profilePicPath = "profilepics";
		private static List<string> uploadedImages = new List<string>();
		private readonly IHostingEnvironment environment;
        private readonly MsgBusiness msgBusiness;
        private readonly RoomBusiness roomBusiness;
        

        //HostingEnvironment HostingEnvironment = new HostingEnvironment();
       
        //static string ApplicationName = "Quickstart";
        public static string[] Scopes = { Google.Apis.Drive.v3.DriveService.Scope.Drive };
        private readonly string profilePicPath1 = "Drive";
        static string ApplicationName = "Quickstart";

        public DashboardController(StudentBusiness studentBusiness, ApplicationContext applicationContext, UserBusiness userBusiness, IHostingEnvironment environment, MsgBusiness msgBusiness, RoomBusiness roomBusiness)
		{
			this.studentBusiness = studentBusiness;
			this.userBusiness = userBusiness;
			this.applicationContext = applicationContext;
			this.environment = environment;
            this.msgBusiness = msgBusiness;
            this.roomBusiness = roomBusiness;

        }
		public IActionResult StudentRegistration()
		{
			return View("StudentRegistration");
		}

		public IActionResult TeacherRegistration()
		{
			return View();
		}


		public IActionResult StudentView()
		{
			return View();
		}

        public IActionResult CamaraView()
        {
            return View();
        }

        public IActionResult ParentCamaraView()
        {
            return View();
        }

        public IActionResult BusTracking()
        {
            return View();
        }
        public IActionResult StudentTracking()
        {
            return View();
        }
        public IActionResult RoomSchedule()
		{
			return View();
		}
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult BusSchedule()
		{
			return View();
		}

	

		public ActionResult<Int32> GetUserId()
		{
			var userid = this.userBusiness.GetUserId(applicationContext.UserId);
			return userid;
		}
        

        public static DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            string imageName = Guid.NewGuid().ToString();
            //Root Folder of project
            var CSPath ="~/";
            using (var stream = new FileStream(Path.Combine("38482218592-fhko765150i2sc70cjfn4saff9jegnah.apps.googleusercontent.com.json"), FileMode.Open, FileAccess.Read))
            {
                String FolderPath = "cred.json";
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
        public ActionResult<Int32> GetFiles()
        {
            string[] filearry = Directory.GetFiles(Path.Combine(environment.WebRootPath, "video"));
            int k = filearry.Length;
            for (int i=0;i<k;i++)
            {
                Student1(filearry[i]);
                string[] filearry1 = Directory.GetFiles(Path.Combine(environment.WebRootPath, "video"));
                k = filearry1.Length;
            }
            return 1;
        }
        [HttpPost]
        public ActionResult Student1(string paths)
        {
            var path1 = paths;
            //var path1 = Path.Combine(environment.WebRootPath, "video", videoname);
          //  var stream1 = new FileStream(Path.Combine(path1), FileMode.Open, FileAccess.Read);


            string folderId = "1DnhxryfNvQKaYvZXwDXa6gZgi1f7xpip";
            if (path1 != null)
            {
                //create service
                DriveService service = GetService();
                //string path = Guid.NewGuid().ToString() + Path.GetExtension(file.StudentImg.FileName);
                //string imageName = Guid.NewGuid().ToString() + Path.GetExtension(file.StudentImg.FileName);
                //string savePath = Path.Combine(environment.WebRootPath, this.profilePicPath1, imageName);
                //using (var stream = new FileStream(savePath, FileMode.Create))
                //{
                //    file.StudentImg.CopyTo(stream);

                //}

               // uploadedImages.Add(stream1);
                Path.GetFileName(path1);
              string  path = path1;
                //  file.SaveAs(path);
                var FileMetaData = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = Path.GetFileName(path1),
                    MimeType = MimeTypes.GetMimeType(path1),
                    Parents = new List<string>
                    {
                        folderId
                    }
                };
                //FileMetaData.Name = Path.GetFileName(file.StudentImg.FileName);
                //FileMetaData.MimeType = MimeTypes.GetMimeType(path);
                //  FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);

                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(path1, System.IO.FileMode.Open))
                {
               
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                    
                }
                var file1 = request.ResponseBody;
                var roomvideo = this.roomBusiness.Updatedvideoid(file1.Id);
                if (System.IO.File.Exists(path1))
                {
                    System.IO.File.Delete(path1);
                }
               

            }
            return null;

        }
        public  void CreateFolder(string FolderName="vishalnew")
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
        private static void SaveStream(MemoryStream stream, string FilePath)
        {
            using (FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }
        public List<String> videofile()
        {
            var roomvideolist = this.roomBusiness.GetRoomvideourlId();
            
            var pathlist = new List<string>();
            for(int i=0;i<roomvideolist.Count;i++)
            {
               string paths= DownloadGoogleFile(roomvideolist[i].RoomVideoUrlId);
                pathlist.Add(paths);
                var updatedurlist = this.roomBusiness.Updatedpath(roomvideolist[i].RoomVideoId, paths);
            }
           var videolist= Getvideofile();
            return videolist;
        }
        public List<String> Getvideofile()
        {
            var roomvideolist = this.roomBusiness.GetAllRoomvideos();
            return roomvideolist;
        }
        public  string DownloadGoogleFile(string fileId)
        {
            DriveService service = GetService();
            
            string FolderP = "DFile";
            string FolderPath=Path.Combine(environment.WebRootPath, FolderP);
            FilesResource.GetRequest request = service.Files.Get(fileId);
            string FileName = request.Execute().Name;
            string Fname = Guid.NewGuid().ToString() + Path.GetExtension(FileName);
            //string FilePath = Path.Combine(FolderPath,FileName);         
            string FilePath = Path.Combine(FolderPath,Fname);
            MemoryStream stream1 = new MemoryStream();
            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
         //   string savePath = Path.Combine(environment.WebRootPath, FolderPath);
           
            request.MediaDownloader.ProgressChanged += (IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            /// var stream = new FileStream(FilePath, FileMode.Create);

                            SaveStream(stream1, FilePath);
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream1);
            var filename ="/"+FolderP+"/"+Fname;
            return filename;
        }
        // file save to server path
      
        [HttpPost]
        public  List<GoogleDriveFile> GetDriveFolders()
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
        [HttpPost]
        public IActionResult StudentRegistration(StudentDetail studentDetail)
        {
            try
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(studentDetail.StudentImg.FileName);

                string savePath = Path.Combine(environment.WebRootPath, this.profilePicPath, imageName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    studentDetail.StudentImg.CopyTo(stream);
                }
                uploadedImages.Add(imageName);
                imageName = "/profilepics/" + imageName;
                StudentModel studentModel = new StudentModel();
                UserModel userModel = new UserModel();
                userModel.UserName = studentDetail.UserName;
                userModel.UserEmail = studentDetail.UserEmail;
                userModel.UserPassword = studentDetail.UserPassword;
                userModel.UserMobileNo = studentDetail.UserMobileNo;
                var user = this.userBusiness.AddParent(userModel);
                studentModel.StudentName = studentDetail.StudentName;
                studentModel.StudentImg = imageName;
                studentModel.StudentAddress = studentDetail.StudentAddress;
                studentModel.StudentGender = studentDetail.StudentGender;
                studentModel.StudentDob = studentDetail.StudentDob;
                studentModel.FatherName = studentDetail.FatherName;
                studentModel.MotherName = studentDetail.MotherName;
                studentModel.ParentId = user.UserId;
                studentModel.Batch = studentDetail.Batch;
                var student = this.studentBusiness.AddStudent(studentModel, studentDetail.Sheduleid);
                ModelState.AddModelError(nameof(StudentDetail.ErrorMessage), "Registered Successfully");


            }
            catch (Exception e)
            {
                ModelState.AddModelError(nameof(StudentDetail.ErrorMessage), "Failed to register due to " + e);
            }



            return View(studentDetail);
        }

    
        }
}

