using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Dating.App_Code
{
    public class Users
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string location { get; set; }
        public string Bio { get; set; }

        public string imageName { get; set; }
        public byte[] image { get; set; }

        public int ID { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public string Username { get; set; }
        public string LikedUser { get; set; }
        public int value { get; set; }

        private DatabaseConnection dataConn;

        public Users()
        {
            dataConn = new DatabaseConnection();
        }

        public int userNameExists() //boolean means true or false
        {
            dataConn.addParameter("@UserName", UserName);

            string command = "Select COUNT(UserName) FROM [User] WHERE UserName=@UserName";

            int result = dataConn.executeScalar(command); //result of count

            if (result > 0)
            {
                return result; //if record found or exception caught

            }
            else
            {
                return result; //if record found or exception caught

            }
        }

        // boolean functions returns whether email exist or not in db
        public int emailExists() //boolean means true or false
        {
            dataConn.addParameter("@Email", Email);

            string command = "Select COUNT(Email) FROM [User] WHERE Email=@Email";

            int result = dataConn.executeScalar(command); //result of count

            if (result>0)
            {
                return result; //if record found or exception caught

            }
            else
            {
                return result; //if record found or exception caught

            }

        }

        public int addUser()
        {
            dataConn.addParameter("@UserName", UserName);
            dataConn.addParameter("@FullName", FullName);
            dataConn.addParameter("@Age", Age);
            dataConn.addParameter("@Email", Email);
            dataConn.addParameter("@Password", Password);
            dataConn.addParameter("@location", location);
            dataConn.addParameter("@Bio", Bio);
            dataConn.addParameter("@image", image);
            dataConn.addParameter("@imageName", imageName);

            string command = "INSERT INTO [User](UserName, FullName, Age, Email, Password, location,Bio,image,imageName) " +
                            "VALUES(@UserName, @FullName, @Age, @Email, @Password, @location,@Bio,@image,@imageName)";
            int result = dataConn.executeNonQuery(command);
            if (result > 0)
            {
                return result; //if record found or exception caught
            }
            else
            {
                return result; //if record found or exception caught
            }
        }
        public DataTable CheckUser()
        {
            dataConn.addParameter("@UserName", UserName);
            string command = "Select UserName from [User] WHERE UserName = @UserName";
            //         int res = dataConn.executeNonQuery(command);
            return dataConn.executeReader(command);  //i.e. 1 or more rows affected
        }
        public DataTable LoginCredentials()
        {
            dataConn.addParameter("@UserName", UserName);
            dataConn.addParameter("@Password", Password);
            string command = "Select * from [User] WHERE UserName = @UserName and Password= @Password";
            return dataConn.executeReader(command);
        }

        public DataTable getProfiledata()
        {
            dataConn.addParameter("@UserName", UserName);
            string command = "Select image from [User] WHERE UserName = @UserName";
            //         int res = dataConn.executeNonQuery(command);
            return dataConn.executeReader(command);  //i.e. 1 or more rows affected
        }

        public DataTable getReceiverdata()
        {
            dataConn.addParameter("@FullName", FullName);
            string command = "Select image from [User] WHERE FullName = @FullName";
            //         int res = dataConn.executeNonQuery(command);
            return dataConn.executeReader(command);  //i.e. 1 or more rows affected
        }

        public DataTable getFullName()
        {
            dataConn.addParameter("@UserName", UserName);
            string command = "Select FullName from [User] WHERE UserName = @UserName";
            //         int res = dataConn.executeNonQuery(command);
            return dataConn.executeReader(command);  //i.e. 1 or more rows affected
        }

        public DataTable getusers()
        {
            dataConn.addParameter("@UserName", UserName);
            string command = "Select * from [User] WHERE NOT UserName=@UserName";      
            return dataConn.executeReader(command);
        }

        public DataTable getLikedusersdata()
        {
            dataConn.addParameter("@Username", Username);
            string command = "Select [LikedUser] from [Likes] WHERE [Username]=@Username";
            return dataConn.executeReader(command);
        }

        public DataTable LoadLikedusers()
        {
            dataConn.addParameter("@UserName", Username);
            string command = "Select * from [User] WHERE UserName=@UserName";
            return dataConn.executeReader(command);
        }

        public int sendUserMessage()
        {
            dataConn.addParameter("@Sender", Sender);
            dataConn.addParameter("@Receiver", Receiver);
            dataConn.addParameter("@Message", Message);
//            dataConn.addParameter("@Date", Date);
//            dataConn.addParameter("@Time", Time);
            dataConn.addParameter("@image", image);
            //            dataConn.addParameter("@ID", ID);

            //string command = "INSERT INTO [chat](Sender, Receiver,Message, Date, Time,image) " +
            //                "VALUES(@Sender, @Receiver,@Message, @Date, @Time,@image)";

                        string command = "INSERT INTO [chat](Sender, Receiver,Message,image) " +
                            "VALUES(@Sender, @Receiver,@Message,@image)";
            int result = dataConn.executeNonQuery(command);
            
           if (result > 0)
            {
                return result; //if record found or exception caught
            }
            else
            {
                return result; //if record found or exception caught
            }
        }

        public int deleteUserMessage()
        {
            dataConn.addParameter("@Sender", Sender);
            dataConn.addParameter("@Receiver", Receiver);
            string command = "DELETE FROM  [chat] WHERE Sender = @Sender and Receiver = @Receiver or Sender = @Receiver and Receiver = @Sender";
             
            int result = dataConn.executeNonQuery(command);
            if (result > 0)
            {
                return result; //if record found or exception caught
            }
            else
            {
                return result; //if record found or exception caught
            }
        }

        public DataTable getID()
        {
            string command = "select ID from [chat]";
            return dataConn.executeReader(command);
        }

        public DataTable getUserMessage()
        {
            dataConn.addParameter("@Sender", Sender);
            dataConn.addParameter("@Receiver", Receiver);
            //            dataConn.addParameter("@Date", Date);

            //            string command = "select * from [chat] where Sender=@Sender and Receiver=@Receiver or Sender=@Receiver and Receiver=@Sender and Date=@Date ORDER BY ID";
            string command = "select * from [chat] where Sender=@Sender and Receiver=@Receiver or Sender=@Receiver and Receiver=@Sender ORDER BY ID";
            return dataConn.executeReader(command);
        }

        public DataTable hasUserMessages()
        {
            dataConn.addParameter("@Sender", Sender);
            dataConn.addParameter("@Receiver", Receiver);

            string command = "select * from [chat] where Sender=@Sender and Receiver=@Receiver or Sender=@Receiver and Receiver=@Sender";
            return dataConn.executeReader(command);
        }

        public DataTable getLikedUser()
        {
            dataConn.addParameter("@Username", Username);
            dataConn.addParameter("@LikedUser", LikedUser);

            //            string command = "select * from [Likes] where [Username]=@Username and [LikedUser]=@LikedUser or [Username]=@LikedUser and [LikedUser]=@Username";
            string command = "select * from [Likes] where [Username]=@Username and [LikedUser]=@LikedUser";
            return dataConn.executeReader(command);
        }

        public int Like_user()
        {
            dataConn.addParameter("@Username", Username);
            dataConn.addParameter("@LikedUser", LikedUser);
            dataConn.addParameter("@value", value);

            string command = "INSERT INTO [Likes]([Username],[LikedUser],[value]) " +
                            "VALUES(@Username,@LikedUser,@value)";
            int result = dataConn.executeNonQuery(command);
            if (result > 0)
            {
                return result; //if record found or exception caught
            }
            else
            {
                return result; //if record found or exception caught
            }
        }
        public int Remove_Like_user()
        {
            dataConn.addParameter("@Username", Username);
            dataConn.addParameter("@LikedUser", LikedUser);

            string command = "DELETE FROM [Likes] WHERE [Username]=@Username and [LikedUser]=@LikedUser or [Username]=@LikedUser and [LikedUser]=@Username";
            int result = dataConn.executeNonQuery(command);
            if (result > 0)
            {
                return result; //if record found or exception caught
            }
            else
            {
                return result; //if record found or exception caught
            }
        }

        public DataTable getMatchedUsers()
        {
            dataConn.addParameter("@Username", Username);
            dataConn.addParameter("@LikedUser", LikedUser);

            string command = "select * from [Likes] where [Username]=@Username and [LikedUser]=@LikedUser";
            return dataConn.executeReader(command);
        }
    }
}