using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class User {
	protected string userName;
	protected string password;
	protected bool isManager = false;

	public string GetUserName() {
        return userName;
    }
    public bool IsManager
    {
        get
        {
            return isManager;
        }
        set
        {
            isManager = value;
        }
    }
    public bool VerifyUser(string password)
    {
        if (this.password == password)
        {
            if (this is Manager)
            {
                isManager = true;
            }
            return true;
        }
        return false;
        //not sure
    }
	public User(string userName, string password) {
        this.userName = userName;
        this.password = password;
	}

    public User()
    {
    }
}
}