using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dating.App_Code;
using System.Data.Common;

namespace Dating
{
    public partial class UserAccount : System.Web.UI.Page
    {
        String UserName = "";
        String FullName = "";
        String Age = "";
        String Location = "";
        String Bio = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Users user_obj = new Users();


            // checking if sessions exists or not
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                UserName = Session["UserName"].ToString();
                FullName = Session["FullName"].ToString();
                Age= Session["Age"].ToString();
                Location = Session["location"].ToString();
                Bio= Session["Bio"].ToString();

                lblWelcome.Text = "Welcome  " + FullName + "   to your Dating account";

                user_obj.UserName = UserName;
                DataTable dt_userdata = user_obj.getProfiledata();

                if (dt_userdata != null)
                {
                    byte[] bytes = (byte[])dt_userdata.Rows[0]["image"];
                    string strBase64 = Convert.ToBase64String(bytes);
                    Image1.ImageUrl = "data:Image/png;base64," + strBase64;

                    lblNamedata.Text = UserName;
                    lblAgedata.Text = Age;
                    lbllocationdata.Text = Location;
                    lblBiodata.Text = Bio;
                }
            }
        }
    }
}