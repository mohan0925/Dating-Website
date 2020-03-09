using Dating.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Dating.App_Code;
using System.Data.Common;

namespace Dating
{
    public partial class Home : System.Web.UI.Page
    {
        string UserName = "";
        string FullName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                Response.Redirect("~/UserLogin.aspx");
            }
            else
            {
                UserName = Session["UserName"].ToString();
                FullName= Session["FullName"].ToString();
                Users user_obj = new Users();
                user_obj.UserName = UserName;
                DataTable dt_userdata = user_obj.getusers();

                if (dt_userdata != null)
                {
                    dtlist.DataSource = dt_userdata;
                    dtlist.DataBind();
                }
            }
        }

        protected void LikeBtn_Click(object sender, EventArgs e)
        {
            LinkButton lBtn = sender as LinkButton;
            string liked_user = ((LinkButton)sender).CommandArgument.ToString();
            Users user_obj = new Users();
            user_obj.Username = UserName;
            user_obj.LikedUser = liked_user;
            DataTable dt_likeduserdata = user_obj.getLikedUser();

            if (dt_likeduserdata.Rows.Count > 0)
            {
                
            }
            else
            {
                Users user = new Users();
                user.Username = UserName;
                user.LikedUser = liked_user;
                user.value = 1;
                int inserted = user.Like_user();
                if (inserted > 0)
                {
                    DataTable dt_likeduser = user.getLikedUser();
                    lBtn.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void DislikeBtn_Click(object sender, EventArgs e)
        {
            LinkButton lBtn = sender as LinkButton;
            string liked_user = ((LinkButton)sender).CommandArgument.ToString();
            Users user_obj = new Users();
            user_obj.Username = UserName;
            user_obj.LikedUser = liked_user;
            DataTable dt_likeduserdata = user_obj.getLikedUser();

            if (dt_likeduserdata.Rows.Count > 0)
            {
                Users user = new Users();
                user.Username = UserName;
                user.LikedUser = liked_user;

                int removed = user.Remove_Like_user();
                if (removed > 0)
                {
                    Users user_object = new Users();
                    user_object.UserName = liked_user;
                    DataTable dt_userFullName = user_object.getFullName();
                    if (dt_userFullName.Rows.Count>0)
                    {
                        Users user_object1 = new Users();
                        user_object1.Sender = FullName;
                        user_object1.Receiver = dt_userFullName.Rows[0]["FullName"].ToString();
                        DataTable dt_usermessage = user_object1.hasUserMessages();
                        if (dt_usermessage.Rows.Count > 0)
                        {
                            Users user_object2 = new Users();
                            user_object2.Sender = FullName;
                            user_object2.Receiver = dt_userFullName.Rows[0]["FullName"].ToString(); ;
                            int message_deleted = user_object2.deleteUserMessage();
                            if (message_deleted > 0)
                            {
                                Console.WriteLine("Messages deleted");
                            }
                        }
                    }

                    DataTable dt_likeduser = user.getLikedUser();
                    lBtn.BackColor = System.Drawing.Color.Green;
                }
                lBtn.BackColor = System.Drawing.Color.Green;
            }
            
        }

    }
}