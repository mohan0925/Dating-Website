using Dating.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating
{
    public partial class Likes : System.Web.UI.Page
    {
        string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("UserName", typeof(string));
                dt.Columns.Add("FullName", typeof(string));
                dt.Columns.Add("Age", typeof(Int32));
                dt.Columns.Add("location", typeof(string));
                dt.Columns.Add("Bio", typeof(string));
                dt.Columns.Add("image", typeof(byte[]));
                dt.Columns.Add("imageName", typeof(string));


                UserName = Session["UserName"].ToString();
                Users user_obj = new Users();
                user_obj.Username = UserName;
                DataTable dt_userdata = user_obj.getLikedusersdata();

                if (dt_userdata.Rows.Count>0)
                {
                    myDIV.Visible = false;

                    foreach (DataRow row in dt_userdata.Rows)
                    {
                        string liked_user = row["LikedUser"].ToString();
                        Users user_object = new Users();
                        user_object.Username = liked_user;
                        DataTable dt_load_users = user_object.LoadLikedusers();
                        if (dt_load_users != null && dt_load_users.Rows.Count > 0)
                        {
                            DataRow dr1 = dt.NewRow();

                            dr1["UserName"] = dt_load_users.Rows[0]["UserName"].ToString();
                            dr1["FullName"] = dt_load_users.Rows[0]["FullName"].ToString();
                            dr1["Age"] = dt_load_users.Rows[0]["Age"].ToString();
                            dr1["location"] = dt_load_users.Rows[0]["location"].ToString();
                            dr1["Bio"] = dt_load_users.Rows[0]["Bio"].ToString();                 
                            dr1["image"] = dt_load_users.Rows[0]["image"];
                            dr1["imageName"] = dt_load_users.Rows[0]["imageName"].ToString();                            

                            dt.Rows.Add(dr1.ItemArray);

                            dtlist.DataSource = dt;
                            dtlist.DataBind();
                        }
                    }
                }
                else
                {
                    myDIV.Visible = true;
                }



            }
        }
    }
}