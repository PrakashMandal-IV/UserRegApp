using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace UserWebFormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetuserList();
                GetDepartmentList();
            }
        }
        SqlConnection _connection = new SqlConnection("Data Source=.;Initial Catalog=NewDb;Integrated Security=True");
        public void GetDepartmentList()
        {
            SqlCommand query = new SqlCommand("exec stp_GetAllDepartment", _connection);
            SqlDataAdapter sd = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            DepartmentList.DataSource = dt;
            DepartmentList.DataBind();
            DepartmentList.DataTextField = "DepartmentName";
            DepartmentList.DataValueField = "Id";
            DepartmentList.DataBind();
        }
        
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstName = FirstName.Text;  
            string lastName = LastName.Text;
            string email = Email.Text;
            string address = Address.Text;
            string state = State.Text;
            string dateOfBirth = DOB.Text;
            string mobile = Mobile.Text;
            string password = Password.Text;
            int DepartmentId = Convert.ToInt32(DepartmentList.SelectedValue.ToString());
            if (firstName != "" && lastName != null && email != null && address != null && state != null && mobile != null && password != null)
            {    
                _connection.Open();
                SqlCommand query = new SqlCommand("exec stp_AddUser '" + firstName + "','" + lastName + "','" + mobile +"','" + email + "','" + password + "','" + dateOfBirth + "','" + address + "','" + state + "','" + DepartmentId+"'", _connection);
                query.ExecuteNonQuery();
                _connection.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Registered')", true);
                GetuserList();
            }
            else msg.Text = "Above fields are required";
        }
        protected void Update_Click(object sender,EventArgs e)
        {
            
           
            
            if (UserId.Text != "")
            {
                string firstName = FirstName.Text;
                string lastName = LastName.Text;
                string email = Email.Text;
                string address = Address.Text;
                string state = State.Text;
                string dateOfBirth = DOB.Text;
                string mobile = Mobile.Text;
                string password = Password.Text;
                int DepartmentId = Convert.ToInt32(DepartmentList.SelectedValue.ToString());
                int Id = Convert.ToInt32(UserId.Text);
                SqlCommand checkQuery = new SqlCommand("stp_CheckDuplicateRelation '" +Id+"','"+DepartmentId+ "'", _connection);
                SqlParameter returnParameter = checkQuery.Parameters.Add("RetVal", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                _connection.Open();
                checkQuery.ExecuteNonQuery();
                _connection.Close();
                if (returnParameter.Value.ToString() == "0")
                {
                    _connection.Open();
                    SqlCommand query = new SqlCommand("exec stp_UpdateUser '" + Id + "','" + firstName + "','" + lastName + "','" + email + "','" + mobile + "','" + password + "','" + dateOfBirth + "','" + address + "','" + state + "','" + DepartmentId + "'", _connection);
                    query.ExecuteNonQuery();
                    _connection.Close();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated')", true);
                    GetuserList();
                }
                else msg.Text = "User is already in selected department";
            }
            else msg.Text = "Please Select the use to edit";
                
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            
            if (UserId.Text != "")
            {
                int Id = Convert.ToInt32(UserId.Text);
                _connection.Open();
                SqlCommand query = new SqlCommand("exec stp_DeleteUser '" + Id + "'", _connection);
                query.ExecuteNonQuery();
                _connection.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('User Deleted Successfully')", true);
                GetuserList();
            }
            else msg.Text = "Please select User";
        }

        protected void ConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            string pass = Password.Text;
            string confpass = ConfirmPassword.Text;
            if (pass != confpass)
            {
                msg.Text = "Password not matching";
            }
            else msg.Text = "";
        }

        public void GetuserList()
        {
            SqlCommand query = new SqlCommand(" exec stp_GetAllUserWithDepartment", _connection);
            SqlDataAdapter sd = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dt.Columns.Remove("Password");

            GridView1.DataSource = dt;
            GridView1.DataBind();
            
            
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserId.Text = GridView1.SelectedRow.Cells[1].Text;
            FirstName.Text = GridView1.SelectedRow.Cells[2].Text;
            LastName.Text = GridView1.SelectedRow.Cells[3].Text;
            Email.Text = GridView1.SelectedRow.Cells[4].Text;
            Mobile.Text = GridView1.SelectedRow.Cells[5].Text;
            
            DOB.Text = GridView1.SelectedRow.Cells[6].Text;
            Address.Text = GridView1.SelectedRow.Cells[7].Text;
            State.Text = GridView1.SelectedRow.Cells[8].Text;
            GetUserDepartmentList(Convert.ToInt32(GridView1.SelectedRow.Cells[1].Text));

        }

        public void GetUserDepartmentList(int id)
        {
            SqlCommand query = new SqlCommand(" exec stp_GetSelectedUserDepartment '"+id+"'", _connection);
            SqlDataAdapter sd = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            

            UserDepartmentList.DataSource = dt;
            UserDepartmentList.DataBind();
        }
        protected void Search_Click(object sender, EventArgs e)
        {
            string input = Search.Text;
            if(input != "" )
            {
                _connection.Open();
                SqlCommand query = new SqlCommand("exec stp_SearchUserByName '" + input + "'", _connection);
                SqlDataAdapter sd = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void Search_Click_By_Button(object sender, KeyEventArgs e)
        {
            string input = Search.Text;
            if (input != "" && e.KeyCode == Keys.Enter)
            {
                _connection.Open();
                SqlCommand query = new SqlCommand("exec stp_SearchUserByName '" + input + "'", _connection);
                SqlDataAdapter sd = new SqlDataAdapter(query);
                DataTable dt = new DataTable();
                sd.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
    }
}