﻿using System;
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
            if(!IsPostBack)
            {
                GetAllImages();
            }
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            UploadImage();    
        }

       
        protected void UploadImage()
        {
            try
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
                        string filepath = Server.MapPath("/CDN/Image/" + date + "/Original/");
                        string filepathfordb = "/CDN/Image/" + date + "/Original/";
                        //check if directory exist or not
                        if (!Directory.Exists(filepath))
                        {
                            Directory.CreateDirectory(filepath);
                        }
                        string filename = SaveImageToDB(filepathfordb, originalFilenName, fileExtension);
                        ImageSelector.SaveAs(filepath + filename);
                        successMsg.Text = "Successfully Uploaded !";
                        GetAllImages();
                        ThumbnailGenerateor(filepath, filename);
                    }
                    else msg.Text = "File must be png/jpg/jpeg";
                }
                else msg.Text = "Please Select a file";
            }
            catch (Exception ex)
            {
                msg.Text = ex.Message;
            }
        }

        public void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            getFilePath(Convert.ToInt32(ImageData.SelectedRow.Cells[1].Text));
            
        }



       //Method to store file in Database
       protected string SaveImageToDB(string path,string filename,string filetype)
        {
            DateTime date =Convert.ToDateTime(DateTime.Now.ToShortDateString());
            
            //ADD FILE TO DATABASE
            SqlCommand query = new SqlCommand("exec stp_AddImage '" + filename + "','" + path + "','" + date + "'", _connection);
            _connection.Open();
           int id= Convert.ToInt32(query.ExecuteScalar().ToString());
            _connection.Close();
           
            string NameDate = DateTime.Now.ToString("yyyyMMddhhmmss");
            string Newfilename = id+"-" + NameDate + filetype;
            string newPath = path + Newfilename;
            
           // Update File Path to DATABASE
            UpdatePath(id, newPath);
            return Newfilename;
        }
        protected void UpdatePath(int id,string newPath)
        {
            _connection.Open();
            SqlCommand UpdateQuery = new SqlCommand("exec stp_UpdateImagePath '" + id + "','" + newPath + "'", _connection);
            UpdateQuery.ExecuteNonQuery();
            _connection.Close();
        }
        protected void GetAllImages()
        {
            SqlCommand query = new SqlCommand(" exec stp_GetAllIamges", _connection);
            SqlDataAdapter sd = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dt.Columns.Remove("FilePath");
            ImageData.DataSource = dt;
            ImageData.DataBind();
        }


        protected void getFilePath(int id)
        {
            SqlCommand query = new SqlCommand(" exec stp_GetFilePathOfSelectedIamge '"+id+"'", _connection);
            _connection.Open();
            string path = query.ExecuteScalar().ToString();
            _connection.Close();
            path.Replace("/", @"\");
            ImageOrg.ImageUrl=path;
            //Get Thumbnail path
            string thumbnailPath = path.Replace("Original", "Thumbnail");
            Thumbnail.ImageUrl=thumbnailPath;
           
        }

        protected void ThumbnailGenerateor(string filepath,string name)
        {
             Imager.PerformImageResizeAndPutOnCanvas(filepath,name,name);
        }
    }
}