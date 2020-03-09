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
    public partial class Matches : System.Web.UI.Page
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

                if (dt_userdata.Rows.Count > 0)
                {
                    myDIV.Visible = false;
                    foreach (DataRow row in dt_userdata.Rows)
                    {
                        string liked_user = row["LikedUser"].ToString();
                        Users user_object = new Users();
                        user_object.Username = liked_user;
                        user_object.LikedUser = UserName;
                        DataTable dt_load_users = user_object.getMatchedUsers();
                        if (dt_load_users != null && dt_load_users.Rows.Count > 0)
                        {
                            Users user_objects = new Users();
                            user_objects.UserName = liked_user;
                            DataTable dt_load_user_data = user_object.LoadLikedusers();

                            if (dt_load_user_data.Rows.Count > 0)
                            {
                                foreach (DataRow rows in dt_load_user_data.Rows)
                                {
                                    DataRow dr1 = dt.NewRow();

                                    dr1["UserName"] = rows["UserName"].ToString();
                                    dr1["FullName"] = rows["FullName"].ToString();
                                    dr1["Age"] = rows["Age"].ToString();
                                    dr1["location"] = rows["location"].ToString();
                                    dr1["Bio"] = rows["Bio"].ToString();
                                    dr1["image"] = rows["image"];

                                    dt.Rows.Add(dr1.ItemArray);

                                    dtlist.DataSource = dt;
                                    dtlist.DataBind();

                                }

                            }
                            else
                            {
                                myDIV.InnerHtml = "Like request pending with " + liked_user + " user...";
                                myDIV.Visible = true;
                            }

                        }
                        else
                        {
                            myDIV.InnerHtml = "Like request pending with " + liked_user + " user...";
                            myDIV.Visible = true;
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