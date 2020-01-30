using BHOurProject.Models.Entity;
using BHOurProject.Areas.Admin.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class SliderController : Controller
    {
        // GET: Admin/Slider
        public ActionResult Index()
        {
            return View();
        }
       [HttpPost]
       public string GetReferance()
        {
            List<Reference> list = Reference.GetReference();
            return JsonConvert.SerializeObject(list);
        }
        [HttpPost]
        public string Addreferance(string image,bool check,bool checkBanner,string customerName)
        {
            //FTP Folder name. Leave blank if you want to upload to root folder.
            string ftpFolder = "/Files/Image";
            string imageType = ImageUpload.GetFileType(image);
            string FileIconeName = Guid.NewGuid().ToString();

            byte[] fileBytes = ImageUpload.Parse(image);
            string Fullftp = "ftp://demoproje.site/File/Image/" + FileIconeName + "." + imageType;

            FtpWebRequest reqFtp =
                (FtpWebRequest)
                    FtpWebRequest.Create(Fullftp);


            reqFtp.Credentials = new NetworkCredential("u9172314", "OImu28B6");
            reqFtp.KeepAlive = false;
            reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
            reqFtp.UseBinary = true;
            reqFtp.UsePassive = true;

            try
            {
                using (Stream strm = reqFtp.GetRequestStream())
                {
                    strm.Write(fileBytes, 0, fileBytes.Length);
                    strm.Close();

                }


            }
            catch (Exception ex)
            {

            }
            Reference reference = new Reference();
            {
                reference.CustomerName = customerName;
                reference.Image = Fullftp;
                reference.IsBanner = checkBanner;
                reference.IsActive = check;
                bool result = reference.AddReferance(reference);
            }

            return JsonConvert.SerializeObject("File uploaded successfully");
        }



    }
}
