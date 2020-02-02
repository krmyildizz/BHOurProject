﻿using BHOurProject.Areas.Admin.Models;
using BHOurProject.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BHOurProject.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetProductList()
        {
            return JsonConvert.SerializeObject(Product.GetProductList());
        }
        [HttpPost]
        public string SaveProduct(Product product, string image, string pdf, CategoryDTO subCategory)
        {
            string ftpFolder = "/Files/Image";
            string imageType = ImageUpload.GetFileType(image);
            string FileIconeName = Guid.NewGuid().ToString();
            string imagepdf = ImageUpload.GetFileType(pdf);

            byte[] fileBytes = ImageUpload.Parse(image);
            byte[] pdfByte = ImageUpload.Parse(pdf);
            string Fullftp = "ftp://demoproje.site/httpdocs/Files/Image/" + FileIconeName + "." + imageType;
            string FullPdf = "ftp://demoproje.site/httpdocs/Files/Image/" + imagepdf + "." + imagepdf;
            string Httpimg= "http://demoproje.site/Files/Image/" + FileIconeName + "." + imageType;
            string HttpPdf = "http://demoproje.site/Files/Image/" + imagepdf + "." + imagepdf;
            if (image != null)
            {
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
            }
            if (pdf != null)
            {
                FtpWebRequest reqFtp =
                              (FtpWebRequest)
                                  FtpWebRequest.Create(FullPdf);
                reqFtp.Credentials = new NetworkCredential("u9172314", "OImu28B6");
                reqFtp.KeepAlive = false;
                reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
                reqFtp.UseBinary = true;
                reqFtp.UsePassive = true;

                try
                {
                    using (Stream strm = reqFtp.GetRequestStream())
                    {
                        strm.Write(pdfByte, 0, pdfByte.Length);
                        strm.Close();

                    }


                }
                catch (Exception ex)
                {

                }

            }
            bool result = false;
            Product pro = new Product();
            {
                pro.Name = product.Name;
                pro.CategoryId = subCategory.SubCategoryId;
                pro.Description = product.Description;
                pro.Description2 = product.Description2;
                pro.AplicationAreas = product.AplicationAreas;
                pro.ManufacturingPlace = product.ManufacturingPlace;
                pro.Image = Httpimg;
                pro.SubName = product.SubName;
                pro.Pdf = HttpPdf;
                pro.IsActive = product.IsActive;
                result = pro.AddProduct(pro);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string UpdateCategory(Product product, CategoryDTO subCategory,string image,string pdf)
        {
            string ftpFolder = "/Files/Image";
            string imageType = ImageUpload.GetFileType(image);
            string FileIconeName = Guid.NewGuid().ToString();
            string imagepdf = ImageUpload.GetFileType(pdf);

            byte[] fileBytes = ImageUpload.Parse(image);
            byte[] pdfByte= ImageUpload.Parse(pdf);
            string Fullftp = "ftp://demoproje.site/httpdocs/Files/Image/" + FileIconeName + "." + imageType;
            string FullPdf = "ftp://demoproje.site/httpdocs/Files/Image/" + imagepdf + "." + imagepdf;
            string httpAdres = "http://demoproje.site/Files/Image/" + FileIconeName + "." + imageType;
            string FullPdfHttp= "http://demoproje.site/Files/Image/" + FileIconeName + "." + imageType;
            if (image != null)
            {
                FtpWebRequest reqFtp =
                               (FtpWebRequest)
                                   FtpWebRequest.Create(Fullftp);


                reqFtp.Credentials = new NetworkCredential("u9172314", "OImu38B6");
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
            }
            if (pdf!=null)
            {
                FtpWebRequest reqFtp =
                              (FtpWebRequest)
                                  FtpWebRequest.Create(FullPdf);
                reqFtp.Credentials = new NetworkCredential("u9172314", "OImu38B6");
                reqFtp.KeepAlive = false;
                reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
                reqFtp.UseBinary = true;
                reqFtp.UsePassive = true;

                try
                {
                    using (Stream strm = reqFtp.GetRequestStream())
                    {
                        strm.Write(pdfByte, 0, pdfByte.Length);
                        strm.Close();

                    }


                }
                catch (Exception ex)
                {

                }

            }
            bool result = false;
            Product pro = new Product();
            {
                pro.Id = product.Id;
                pro.Name = product.Name;
                pro.CategoryId = subCategory.SubCategoryId;
                pro.Description = product.Description;
                pro.Description2 = product.Description2;
                pro.AplicationAreas = product.AplicationAreas;
                pro.ManufacturingPlace = product.ManufacturingPlace;
                pro.Image = httpAdres;
                pro.SubName = product.SubName;
                pro.Pdf = FullPdfHttp;
                pro.IsActive = product.IsActive;
                result = pro.UpdateProduct(product);

            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }
        [HttpPost]
        public string DeleteProduct(int id)
        {
            bool result = false;
            Product pro = new Product();
            {
                result = pro.DeleteProduct(id);
            }
            string message = result ? "İşlem Tamamlandı." : "Hata Oluştu.";
            return JsonConvert.SerializeObject(message);
        }

    }
}