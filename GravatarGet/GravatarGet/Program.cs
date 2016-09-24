using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace GravatarGet
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var email in args)
            {
                Console.Write(email + " ");
                string photoUrl = "/avatar/" + GravatarHash(email) + "?d=404&s=600";

                var client = new RestClient("http://www.gravatar.com");
                var request = new RestRequest(photoUrl, Method.GET);
                var response = client.Execute(request);
                Console.WriteLine(response.StatusCode);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    CreateImages("", email, response.RawBytes);
                }
            }
        }

        private static List<string> CreateImages(string imgPath, string name, byte[] EmployeePhoto)
        {
            var images = new List<string>();
            images.Add(name + "_large.jpeg");
            images.Add(name + "_medium.jpeg");

            using (var memoryStream = new MemoryStream(EmployeePhoto))
            {
                using (var img = Image.FromStream(memoryStream))
                {
                    var size = Math.Max(img.Width, img.Height);
                    using (var image = img.CropImage(size, size, 0, 0))
                    {
                        if (image.Width > 600 || image.Height > 600)
                        {
                            using (var largeImage = image.ResizeImage(600, 600))
                            {
                                largeImage.Save(imgPath + images[0], ImageFormat.Jpeg);
                            }
                        }
                        else
                        {
                            image.Save(imgPath + images[0], ImageFormat.Jpeg);
                        }

                        using (var mediumImage = image.ResizeImage(150, 150))
                        {
                            mediumImage.Save(imgPath + images[1], ImageFormat.Jpeg);
                        }
                    }
                }
            }
            return images;
        }

        public static string GravatarHash(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                var originalBytes = Encoding.Default.GetBytes(email);
                var encodedBytes = MD5.Create().ComputeHash(originalBytes);
                return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
            }
            return "";
        }
    }
}
