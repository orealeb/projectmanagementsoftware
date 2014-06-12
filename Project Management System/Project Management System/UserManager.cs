using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class UserManager
    {

        private User currentUser;
        private bool isUserLoggedin = false;
        private bool isManagerLoggedin = false;

        //public void AddUser(string userName, string password, bool isManager)
        //{
        //    if (isManager)
        //    {
        //        modelController.GetUsers().Add(new Manager(userName, password));
        //    }
        //    else
        //    {
        //        modelController.GetUsers().Add(new User(userName, password));
        //    }
        //}
        public void Login(string userName, string password, IModel modelController)
        {
            User usr = modelController.GetUsers().Find(item => item.GetUserName() == userName);
            if (usr != null && usr.VerifyUser(password))
            {
                isUserLoggedin = true;
                if (usr.IsManager)
                {
                    isManagerLoggedin = true;
                }
                currentUser = usr;
            }

        }

        public bool IsUserLoggedin
        {
            get
            {
                return isUserLoggedin;
            }
        }


        public bool IsManagerLoggedin
        {
            get
            {
                return isManagerLoggedin;
            }
        }
        public User getUser()
        {
            return currentUser;
        }
    }
}