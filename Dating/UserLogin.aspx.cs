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
    public partial class UserLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string registration_success = Request.QueryString["Registration"];

            if (registration_success != null)
            {
                lblError.Text = " Registration successful..";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                if (txtUsername.Text.Length < 5)
                {
                    lblError.Text = "invalid username";
                }
                else if (txtpwd.Text.Length < 6)
                {
                    lblError.Text = "invalid password";
                }
                else
                {
                    
                    Users user_obj = new Users();


                    user_obj.UserName = txtUsername.Text;
                    user_obj.Password = txtpwd.Text;

                    // calling function to check username exists or not
                    DataTable check_user = user_obj.CheckUser();

                    // condition to check if data table is not empty 
                    if (check_user.Rows.Count > 0)
                    {
                        string user = check_user.Rows[0]["UserName"].ToString();

                        DataTable dt_user_login = user_obj.LoginCredentials();

                        // condition to check if data table is not empty 
                        if (dt_user_login.Rows.Count > 0)
                        {
                                Session["UserName"] = dt_user_login.Rows[0]["UserName"].ToString();
                                Session["FullName"] = dt_user_login.Rows[0]["FullName"].ToString();
                                Session["Age"] = dt_user_login.Rows[0]["Age"].ToString();
                                Session["Email"] = dt_user_login.Rows[0]["Email"].ToString();
                                Session["Password"] = dt_user_login.Rows[0]["Password"].ToString();
                                Session["location"] = dt_user_login.Rows[0]["location"].ToString();
                                Session["Bio"] = dt_user_login.Rows[0]["Bio"].ToString();
                                Session["image"] = dt_user_login.Rows[0]["image"].ToString();
                                Session["imageName"] = dt_user_login.Rows[0]["imageName"].ToString();

                            // Redirect to the User login 
                            Response.Redirect("~/UserAccount.aspx");                
                        }
                        else
                        {
                            lblError.Text = "Credentials are not correct";
                        }
                    }
                    else
                    {
                        lblError.Text = "User not found";
                    }
                }
            }
        }
    }
}