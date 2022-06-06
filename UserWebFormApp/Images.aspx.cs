using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;

namespace UserWebFormApp
{
    public partial class About : Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            UploadImage();

            string date = DateTime.Now.ToString("yyyy-mm-dd");
            string filepath = Server.MapPath("/Image/" + date + "/Original/");
            Directory.CreateDirectory(filepath);
        }


        protected void UploadImage()
        {
            //Check if the file is selected or not 
            if (ImageSelector.HasFile)
            {
                string fileExtension = Path.GetExtension(ImageSelector.FileName).ToLower();
                string date = DateTime.Now.ToString("yyyy-mm-dd");
                //Check the file type
                if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    string filepath = Server.MapPath("/Image/" + date + "/Original/");
                    //check if directory exist or not
                    if(!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    ImageSelector.SaveAs(filepath + "NEW FILE NAME");
                }
                else msg.Text = "File must be png/jpg/jpeg";
            }
            else msg.Text = "Please Select a file";
        }
    }
}