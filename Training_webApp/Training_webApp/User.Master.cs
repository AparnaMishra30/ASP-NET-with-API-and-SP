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
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Session["fname"] !=null)
                {
                    if (Session["deptname"].ToString() != "")
                    {
                        string DesgDesc = "Department :- " + Session["deptname"].ToString();
                        lblDesgDesc.Text = DesgDesc.ToUpper();
                    }
                    string UserName = "UserName :- " + Session["fname"].ToString();
                    lbluser.Text = UserName.ToUpper();
                    MenuItemBinding();
                }
                else
                {
                    Response.Redirect("~/login.aspx");
                }
            }

        }

        private void MenuItemBinding()
        {
            PL_student plobj = new PL_student();
            plobj.typeofuser = Convert.ToInt32(Session["typeofuser"]);
            plobj.fname = Session["fname"].ToString();
            DataSet ds = studentController.CallApiPostds(plobj, "student/Menulist?Ind=4");
            if (ds != null && ds.Tables.Count > 0)
            {
                
                Menu1.Items.Clear();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string menuName = row["menutype"].ToString(); 
                    string itemUrl = row["url"].ToString(); 

                    MenuItem menuItem = new MenuItem(menuName, "", "", itemUrl);
                    Menu1.Items.Add(menuItem);
                }
            }

        }

        protected void lnlLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Login.aspx");
        }
    }
}