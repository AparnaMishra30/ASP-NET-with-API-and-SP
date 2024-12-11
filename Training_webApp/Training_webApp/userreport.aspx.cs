using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training_webApp.Models;

namespace Training_webApp
{
    public partial class userreport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bindgrid();
            }
        }

        private void Bindgrid()
        
        {
            DataSet ds = studentController.CallApiGetds("student/Bindgrid?Ind=5");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridd.DataSource = ds.Tables[0];
                    gridd.DataBind();
                    AddTheadToGrid(gridd);
                }
                else
                {
                    gridd.DataSource = new DataTable();
                    gridd.DataBind();

                }
            }

        }

        private void AddTheadToGrid(GridView gridd)
        {

            //LevelCodeDept();
            gridd.UseAccessibleHeader = true;
            gridd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Dashboard.aspx");
        }

        protected void gridd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridd.EditIndex = e.NewEditIndex;
            Bindgrid();
        }

        protected void gridd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label id = gridd.Rows[e.RowIndex].FindControl("Labelid") as Label;
            TextBox name = gridd.Rows[e.RowIndex].FindControl("editname") as TextBox;
            TextBox mobb = gridd.Rows[e.RowIndex].FindControl("editmob") as TextBox;
            TextBox dob = gridd.Rows[e.RowIndex].FindControl("editdob") as TextBox;

            PL_student plobj = new PL_student();
              plobj.fname = name?.Text;
            plobj.mob = mobb?.Text;
            plobj.calender = dob?.Text;
            plobj.id = id?.Text;
            DataSet ds = studentController.CallApiPostds(plobj,"student/Update?Ind=6");
            gridd.EditIndex = -1;
            Bindgrid();

        }

        protected void gridd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridd.EditIndex = -1;
            Bindgrid();
        }

        protected void gridd_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            Label id = gridd.Rows[e.RowIndex].FindControl("Labelid") as Label;
            PL_student plobj = new PL_student();
            plobj.id = id?.Text;
            DataSet ds = studentController.CallApiPostds(plobj, "student/Delete?Ind=7");
            Bindgrid();
        }
    }
}