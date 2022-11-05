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
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-ECNEPPI\SQLEXPRESS;database=Users;Integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                bind_grid();

            }
        }
        public void bind_grid()
        {
            string s = "select * from Tab_1";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow rw = GridView1.Rows[e.NewSelectedIndex];
            Label3.Text = rw.Cells[3].Text;
            Label4.Text = rw.Cells[4].Text;
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int uid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from Tab_1 where id="+ uid +"";
            SqlCommand cmd = new SqlCommand(del, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            bind_grid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind_grid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind_grid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int i = e.RowIndex;
            int uid = Convert.ToInt32(GridView1.DataKeys[i].Value);
            TextBox txtnme = (TextBox)GridView1.Rows[i].Cells[4].Controls[0];
            TextBox txtem = (TextBox)GridView1.Rows[i].Cells[5].Controls[0];
            string strup = "update Tab_1 set Username='"+txtnme.Text+"',Email_id='"+ txtem.Text +"' where Id="+uid+"";
            SqlCommand cmd = new SqlCommand(strup, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GridView1.EditIndex = -1;
            bind_grid();
            
        }
    }
}