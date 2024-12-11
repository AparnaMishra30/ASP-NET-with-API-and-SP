using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Training_webApp.training
{
    public partial class revise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Vector<int> v = new Vector<int>();
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            if (flup.HasFile)
            {
                string name = (string)Session["fname"];
                string fn = System.IO.Path.GetFileName(flup.PostedFile.FileName);
                string SaveLocation = Server.MapPath("~/upload/") + fn + "("+name+")";
                flup.PostedFile.SaveAs(SaveLocation);
                lblfile.Text = "file uploaded";
                lblfile.Style["color"] = "orange";
            }
        }

    }
}