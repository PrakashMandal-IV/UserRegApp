using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserWebFormApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                GetuserList();
            }
        }


        SqlConnection _connection = new SqlConnection("Data Source=.;Initial Catalog=NewDb;Integrated Security=True");
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
            if (firstName != "" && lastName != null && email != null && address != null && state != null && mobile != null && password != null)
            {
                _connection.Open();
                SqlCommand query = new SqlCommand("exec stp_AddUser '" + firstName + "','" + "','" + lastName+mobile+ "','" + "','" + email + "','" + password + "','" + dateOfBirth + "','" + address + "','" + state + "'", _connection);
                query.ExecuteNonQuery();
                _connection.Close();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Registered')", true);
                GetuserList();
            }
            else msg.Text = "Above fields are required";
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
            SqlCommand query = new SqlCommand(" exec stp_GetAllUser",_connection);
            SqlDataAdapter sd = new SqlDataAdapter(query);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FirstName.Text = GridView1.SelectedRow.Cells[2].Text;
            LastName.Text = GridView1.SelectedRow.Cells[3].Text;
            Email.Text = GridView1.SelectedRow.Cells[4].Text;
            Password.Text = GridView1.SelectedRow.Cells[5].Text;
            ConfirmPassword.Text = GridView1.SelectedRow.Cells[5].Text;
            DOB.Text = GridView1.SelectedRow.Cells[6].Text;
            Address.Text = GridView1.SelectedRow.Cells[7].Text;
            State.Text = GridView1.SelectedRow.Cells[8].Text;

        }
    }
}