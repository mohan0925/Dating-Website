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
    public partial class Messages : System.Web.UI.Page
    {
        String UserName = "";
        String FullName = "";
        String Age = "";
        String Location = "";
        String Bio = "";
        String receiver_name = null;

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
                Age = Session["Age"].ToString();
                Location = Session["location"].ToString();
                Bio = Session["Bio"].ToString();

                user_obj.UserName = UserName;
                DataTable dt_userdata = user_obj.getProfiledata();

                if (dt_userdata != null)
                {
                    byte[] bytes = (byte[])dt_userdata.Rows[0]["image"];
                    string strBase64 = Convert.ToBase64String(bytes);
                    Image1.ImageUrl = "data:Image/png;base64," + strBase64;
                    lbluser.Text = FullName;
                }
            }
            Load_Friends();
        }

        public void Load_Friends()
        {
            //UserName = Session["UserName"].ToString();
            //Users user_obj = new Users();
            //user_obj.UserName = UserName;
            //DataTable dt_userdata = user_obj.getusers();

            //if (dt_userdata != null)
            //{
            //    DataListFriends.DataSource = dt_userdata;
            //    DataListFriends.DataBind();
            //}

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
                            }
                            DataListFriends.DataSource = dt;
                            DataListFriends.DataBind();                         
                        }
                    }
                }
            }
        }

        protected void OpenFriendChat_Click(object sender, EventArgs e)
        {
            LinkButton lBtn = sender as LinkButton;
//            string id = ((LinkButton)sender).CommandArgument.ToString();

            Users user_obj = new Users();
            user_obj.FullName = lBtn.Text;
            lblReceiver.Text = lBtn.Text;
            DataTable dt_userdata = user_obj.getReceiverdata();

            if (dt_userdata != null)
            {
                DataList1.DataSource = dt_userdata;
                DataList1.DataBind();
                LoadChatbox();
            }
        }

        public void LoadChatbox()   
        {
            //DateTime date = DateTime.Now;
            //string date3 = date.ToString("dd-MM-yyyy");

            Users user = new Users();
            user.Sender = lbluser.Text;
            user.Receiver = lblReceiver.Text;
//            user.Date = date3;

            DataTable dt_userdata = user.getUserMessage();

            if (dt_userdata != null)
            {
                DataList3.DataSource = dt_userdata;
                DataList3.DataBind();
            }
        }

        protected void Unnamed_ServerClick(object sender, EventArgs e)
        {
            //DateTime date = DateTime.Now;
            //string date3 = date.ToString("dd-MM-yyyy");
            //string time = date.ToString("HH:mm:ss");

            Users user = new Users();
            user.Sender = lbluser.Text;
            user.Receiver = lblReceiver.Text;
            user.Message = txtmsgBox.Text;
            //user.Date = date3;
            //user.Time = time;

            user.UserName = UserName;
            DataTable dt_userdata = user.getProfiledata();

            if (dt_userdata != null)
            {
                byte[] bytes = (byte[])dt_userdata.Rows[0]["image"];
                user.image = bytes;
            }

            if (user.sendUserMessage() > 0)
            {
                txtmsgBox.Text = "";
                LoadChatbox();
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            LoadChatbox();
        }
    }
}