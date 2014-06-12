using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class Requirements_Document {
	private string id;
    private string str;

    public Requirements_Document(string p)
    {
        // TODO: Complete member initialization
        this.str = p;
    }


    public string ID   // the ID property
    {
        set
        {
            id = value;
        }
        get
        {
            return id;
        }
    }

    public string Str   // the document details property
    {
       
        get
        {
            return str;
        }
    }

}

}
