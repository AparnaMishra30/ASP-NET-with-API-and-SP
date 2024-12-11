using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training_webApp.training
{
    public partial class To_do_list : System.Web.UI.Page
    {
        string con = "Data Source=occweb05; Initial Catalog=Student; User Id=sa; Password=odpserver550810998@;";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindgrid();
            }
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            string Name = txtname.Text;
            string con = "Data Source=occweb05; Initial Catalog=Student; User Id=sa; Password=odpserver550810998@;";
            SqlConnection conn = new SqlConnection(con);
            conn.Open();
            //SqlCommand cmd = new SqlCommand("Insert into Todo values('" + Name + "')", conn);
            //cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter("Insert into Employee values('" + Name + "')", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();

        }
         public void bindgrid()
        {
            SqlDataAdapter ad = new SqlDataAdapter("select * from Employee", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            gridd.DataSource=dt;
            gridd.DataBind();
        }

        protected void btnedit_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow grdrow = (GridViewRow)btn.NamingContainer;

            Label lbl = (Label)grdrow.FindControl("Id");
            lblTaskId.Text = lbl.Text;

            string Task = ((Label)grdrow.FindControl("Name")).Text;
            txtname.Text = Task;
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection sq = new SqlConnection(con);
            sq.Open();
            string taskid = lblTaskId.Text;
            SqlCommand cd = new SqlCommand("update Employee set Name = ('" + txtname.Text + "') where Id = ('"+ taskid + "')", sq);
            DataTable dt = new DataTable();
            cd.ExecuteNonQuery();
            sq.Close();
        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow grid = (GridViewRow)btn.NamingContainer;
            Label id = (Label)grid.FindControl("Id");
            string gid = id.Text;
            SqlConnection ss = new SqlConnection(con);
            ss.Open();
            SqlCommand cmm = new SqlCommand("delete from Employee where Id = (" + gid + ")", ss);
            cmm.ExecuteNonQuery();
            ss.Close();
        }
    }
}