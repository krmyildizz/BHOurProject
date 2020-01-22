using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BHOurProject.Areas.Admin.Models
{
    public  class ImageUpload
    {
        public static string GetFileType(string imageBase)
        {
            int indexColon = imageBase.IndexOf(";", StringComparison.OrdinalIgnoreCase);
            string datalabel = imageBase.Substring(0, indexColon);
            string imageType = datalabel.Split(':').Last().Split('/').Last();
            return imageType;
        }
        public static byte[] Parse(string base64Content)
        {
            if (string.IsNullOrEmpty(base64Content))
            {
                throw new ArgumentNullException(nameof(base64Content));

            }
            int indexColon = base64Content.IndexOf(";", StringComparison.OrdinalIgnoreCase);
            string datalabel = base64Content.Substring(0, indexColon);
            string contentType = datalabel.Split(':').Last();
            var startIndex = base64Content.IndexOf("base64,", StringComparison.OrdinalIgnoreCase) + 7;
            var fileContents = base64Content.Substring(startIndex);
            byte[] bytes = Convert.FromBase64String(fileContents);
            return bytes;

        }
    }
}