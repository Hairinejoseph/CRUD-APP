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
    public partial class WebForm1 : System.Web.UI.Page
    {
        Connectionclass obj = new Connectionclass(); 

        protected void Page_Load(object sender, EventArgs e)
        {

            Label2.Text = System.DateTime.Now.ToString();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string pa = "~/PHS/" + FileUpload2.FileName;
            FileUpload2.SaveAs(MapPath(pa));

            string strins = "insert into Tab_1 values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + pa + "','" + Label2.Text + "')";
            int i = obj.Fun_NonQuery(strins);
            if (i != 0)
            {
                Label1.Text = "Inserted";
                Response.Redirect("WebForm2.aspx");
            }
            else
            {
                Label1.Text = "failed";
            }
           
         
         
        }
    }
}

    
