using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class Manager : User
    {

        public Manager(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
            this.isManager = true;
        }
    }

}