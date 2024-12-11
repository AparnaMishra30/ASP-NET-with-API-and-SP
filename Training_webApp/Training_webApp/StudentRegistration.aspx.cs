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
    public partial class StudentRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { 
                deptdrop();
                Statedrop();
                
            }
            
        }

        private void Districtdrop(int stid)
        {
            int stateid = Convert.ToInt32(stid);
            DataSet ds = studentController.CallApiGetds($"student/Districtdrop?Ind=8&stateid={stateid}");
            if (ds != null)
            {
                DDList6.DataSource = ds.Tables[0];
                DDList6.DataTextField = "districtName";
                DDList6.DataValueField = "districtId";
                DDList6.DataBind();
                DDList6.Items.Insert(0, new ListItem("--Select District--", "0"));
            }
            else
            {
                DDList6.DataSource = null;
                DDList6.DataTextField = "districtName";
                DDList6.DataValueField = "districtId";
                DDList6.DataBind();
                DDList6.Items.Insert(0, new ListItem("--select District--", "0"));
            }
        }

        private void Statedrop()
        {
            DataSet ds = studentController.CallApiGetds("student/Deptdrop?Ind=2");
            if (ds != null)
            {
                DDList5.DataSource = ds.Tables[1];
                DDList5.DataTextField = "StateName";
                DDList5.DataValueField = "StateId";
                DDList5.DataBind();
                DDList5.Items.Insert(0, new ListItem("--Select State--", "0"));
            }
            else
            {
                DDList5.DataSource = null;
                DDList5.DataTextField = "StateName";
                DDList5.DataValueField = "StateId";
                DDList5.DataBind();
                DDList5.Items.Insert(0, new ListItem("select State", "0"));
            }
        }

        private void deptdrop()
        
        
        {
            DataSet ds = studentController.CallApiGetds("student/Deptdrop?Ind=2");
            // DataSet ds = studentController.CallApiGetDs("api/studentController/Deptdrop?Ind=2");
            if (ds != null)
            {
                DropDownList2.DataSource = ds.Tables[0];
                DropDownList2.DataValueField = "deptname";
                DropDownList2.DataTextField = "deptname";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("--Select Service--", "0"));
            }
            else
            {
                DropDownList2.DataSource = null;
                DropDownList2.DataValueField = "deptname";
                DropDownList2.DataTextField = "deptname";
                DropDownList2.DataBind();
                DropDownList2.Items.Insert(0, new ListItem("select Dept Name", "0"));
            }
        }
     
       protected void submit_Click(object sender, EventArgs e)
        {
            PL_student plobj = new PL_student();
            plobj.fname = fname.Text;
            plobj.mob = mob.Text;
            plobj.calender = calender.Text;
            plobj.gen = gen.Text;
            plobj.cat = cat.Text;
            if (DropDownList2.SelectedValue == "Other")
            {
                plobj.Department = txtdept.Text;
            }
            else
            {
                plobj.Department = DropDownList2.Text;
            }
            plobj.pswd = pswd.Text;
            plobj.conpswd = conpswd.Text;
            plobj.StateId = DDList5.SelectedValue;
            plobj.districtId = DDList6.SelectedValue;
            DataSet ds = studentController.CallApiPostds(plobj, "student/Savedetail?Ind=1");
            
            if (ds.Tables.Count>0)
            {
                string message = "User created successfully.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                Clear();
            }
            else
            {
                string message = "Username already exists.";
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
                Clear();
            }
      
            
        }

        public void Clear()
        {
            fname.Text = "";
            mob.Text = "";
            calender.Text = "";
            gen.Text = "";
            cat.SelectedValue = "0";
            DropDownList2.SelectedValue = "0";
            pswd.Text = "";
            conpswd.Text = "";
            DDList5.SelectedValue = "0";
            DDList6.SelectedValue = "0";

        }

        protected void clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx");
        }

        protected void DDList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            int stid = Convert.ToInt32(DDList5.SelectedValue);
            Districtdrop(stid);
            submit.Visible = true;
        }

    }
}