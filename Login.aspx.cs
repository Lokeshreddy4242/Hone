using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace HomeSearch
{
    public partial class HomeSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string getUserId()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
            con.Open();
            string q = "select Userid from USERS1 where  username='" + txtUserName.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            string sr = cmd.ExecuteScalar().ToString();
            con.Close();
            return sr;
        }
        protected void button_Click(object sender, EventArgs e)
        {
            string user = txtUserName.Text;
            string pass = txtPassword.Text;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ToString());
            con.Open();
            string q = "select count(*) from USERS1 where USERNAME='" + user + "'and PASSWORD='" + pass + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            object sr = cmd.ExecuteScalar();
            int a = Convert.ToInt32(sr);
            Label1.Visible = true;

            if (a == 1)
            {
                Session["uname"] = getUserId();
                Server.Transfer("HomePage.aspx");
            }
            else
            {
                Label1.Text = "login failed";
            }
            con.Close();
        }
    }
}

    
