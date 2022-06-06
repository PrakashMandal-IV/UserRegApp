using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace UserWebFormApp
{
    public partial class About : Page
    {
        SqlConnection _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlDatabase"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            UploadImage();
        }


        protected void UploadImage()
        {
            string originalFilenName = Path.GetFileName(ImageSelector.FileName);
            //Check if the file is selected or not 
            if (ImageSelector.HasFile)
            {
                string fileExtension = Path.GetExtension(ImageSelector.FileName).ToLower();
                string date = DateTime.Now.ToShortDateString();
                //Check the file type
                if (fileExtension == ".jpg" || fileExtension == ".png" || fileExtension == ".jpeg")
                {
                    string filepath = Server.MapPath("/Image/" + date + "/Original/");
                    //check if directory exist or not
                    if(!Directory.Exists(filepath))
                    {
                        Directory.CreateDirectory(filepath);
                    }

                    ImageSelector.SaveAs(filepath + SaveImageToDB(filepath,originalFilenName,fileExtension));
                    successMsg.Text = "Successfully Uploaded !";
                }
                else msg.Text = "File must be png/jpg/jpeg";
            }
            else msg.Text = "Please Select a file";
        }

       //Method to store file in Database
       protected string SaveImageToDB(string path,string filename,string filetype)
        {
            DateTime date =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _connection.Open();
            //ADD FILE TO DATABASE
            SqlCommand query = new SqlCommand("exec stp_AddImage '" + filename + "','" + path + "','" + date + "'", _connection);
            SqlParameter returnParameter = query.Parameters.Add("RetVal", SqlDbType.Int);
            returnParameter.Direction = ParameterDirection.ReturnValue;
            query.ExecuteNonQuery();
            _connection.Close();
            string id = returnParameter.Value.ToString();
            string NameDate = DateTime.Now.ToString("yyyyMMddhhmmss");
            string Newfilename = id+"-" + NameDate + filetype;
            string newPath = path + Newfilename;
            //Update File Path to DATABASE
            _connection.Open();
            SqlCommand UpdateQuery = new SqlCommand("exec stp_UpdateImagePath '" + id + "','" + newPath + "'", _connection);
            UpdateQuery.ExecuteNonQuery();
            _connection.Close();
            return Newfilename;
        }

    }
}