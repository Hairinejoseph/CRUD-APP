using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Users_web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-ECNEPPI\SQLEXPRESS;database=Users;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Visible = true;
            string strselect = "select count(id) from Table_1 where Username='" + TextBox3.Text + "'and Mobile_number='" + TextBox4.Text + "'";
            SqlCommand cmd = new SqlCommand(strselect, con);
            con.Open();
            string cid = cmd.ExecuteScalar().ToString();
            con.Close();
            if (cid == "1")
            {
                string strsel = "select Id from Table_1 where Username='" + TextBox3.Text + "'and Mobile_number='" + TextBox4.Text + "'";
                SqlCommand cmd1 = new SqlCommand(strsel, con);
                con.Open();
                string id = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["uid"] = id;
                Response.Redirect("WebForm4.aspx");
            }
            else
            {
                Label1.Text = "invalid username or email id";
            }


        }
    }
}

