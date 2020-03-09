using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dating.App_Code;
using System.IO;

namespace Dating
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtUsername_TextChanged(object sender, EventArgs e)
        {
            UserName_exists.Text = "";

            Users user = new Users();

            //set property, so it can be used as a parameter for the query
            user.UserName = txtUsername.Text;


            //check if username exists
            if (user.userNameExists() > 0)
            {
                //already exists so output error
                UserName_exists.Text = "Username already exists...!";
                UserName_exists.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                UserName_exists.Text = "Username Available...!";
                UserName_exists.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {
            EmailExist.Text = "";

            Users user = new Users();

            //set property, so it can be used as a parameter for the query
            user.Email = txtemail.Text;

            //check if username exists
            if (user.emailExists() >0)
            {
                //already exists so output error
                EmailExist.Text = "Email already exists...!";
                EmailExist.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                EmailExist.Text = "Email Available...!";
                EmailExist.ForeColor = System.Drawing.Color.Green;
            }
        }
        public bool checkforEmail(String email)
        {
            bool isValid = false;
            Regex rEmail = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (rEmail.IsMatch(email))
                isValid = true;
            return isValid;
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (txtUsername.Text.Length < 5 || txtUsername.Text.Length > 20)
                {
                    lblError.Text = "User name should be greater than 5 or less than 20";
                }
                else if (txtpwd.Text.Length < 6)
                {
                    lblError.Text = "password should be 6 character";
                }
                else if (txtage.Text.Length <0)
                {
                    lblError.Text = "Enter Age";
                }
                else if (!txtpwd.Text.Equals(txtcnfmpwd.Text))
                {
                    lblError.Text = "Password did not match";
                }
                else if (String.IsNullOrWhiteSpace(txtFullname.Text))
                {
                    lblError.Text = "please enter full name";
                }
                else if (String.IsNullOrWhiteSpace(txtemail.Text) || !checkforEmail(txtemail.Text.ToString()))
                {
                    lblError.Text = "please enter valid email";
                }
                else if (String.IsNullOrWhiteSpace(txtlocation.Text))
                {
                    lblError.Text = "please enter Location";
                }
                else if (String.IsNullOrWhiteSpace(txtBio.Text))
                {
                    lblError.Text = "please enter Bio";
                }
                else if (FileUpload1.HasFile == false)
                {
                    lblError.Text = "Please first select a image file to upload...";
                }
                else
                {
                    lblError.Text = "";

                    Users user = new Users();

                    //set property, so it can be used as a parameter for the query
                    user.UserName = txtUsername.Text;

                   int username_exists = user.userNameExists();
                    //check if username exists
                    if (username_exists>0)
                    {
                        //already exists so output error
                        lblError.Text = "Username already exists, please select another";
                    }
                    else
                    {
                        HttpPostedFile postedFile = FileUpload1.PostedFile;
                        string filename = Path.GetFileName(postedFile.FileName);
                        string fileExtension = Path.GetExtension(filename);
                        
                        if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                        {
                            Stream stream = postedFile.InputStream;
                            BinaryReader binaryReader = new BinaryReader(stream);
                            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                            lblFilename.Text = filename;

                            user.UserName = txtUsername.Text;
                            user.FullName = txtFullname.Text;
                            user.Age = Int32.Parse(txtage.Text);
                            user.Email = txtemail.Text;
                            user.Password = txtpwd.Text;
                            user.location = txtlocation.Text;
                            user.Bio = txtBio.Text;
                            user.imageName = filename;
                            user.image = bytes;

                            if (user.addUser() > 0)
                            {
                                Response.Redirect("~/UserLogin.aspx?Registration=Successfull");
                            }
                            else
                            {
                                //exception thrown so display error
                                lblError.Text = "Database connection error - failed to insert record.";
                            }
                        }
                        else
                        {
                            lblError.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
                        }
                    }

                }
            }
        }
    }
}