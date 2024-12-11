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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            PL_student plobj = new PL_student();
            plobj.fname = fname.Text;
            plobj.pswd = pswd.Text;
            DataSet ds =  studentController.CallApiPostds(plobj, "student/Logindetails?Ind=3");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Session["fname"] = ds.Tables[0].Rows[0]["fname"].ToString();
                    Session["mob"] = ds.Tables[0].Rows[0]["mob"].ToString();
                    Session["deptname"] = ds.Tables[0].Rows[0]["Department"].ToString();
                    Session["typeofuser"] = ds.Tables[0].Rows[0]["typeofuser"];
                    Response.Redirect("~/Dashboard.aspx");
                }
                else
                {
                    string message = "Invalid crediental";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                }
            }
            

        }
        protected void Unnamed_Load1(object sender, EventArgs e)
        {
            Response.Redirect("~/StudentRegistration.aspx");
        }

        private void Clear()
        {
            fname.Text = "";
            pswd.Text = "";
        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}