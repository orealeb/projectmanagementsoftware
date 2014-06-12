using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class ProgrammingUnit {
	private string name;
    private Unit_Type type;
	private string version;
	private Status status;
	private string programmer;
	private Requirements_Document reqDoc;
    private string reqID;
    public ProgrammingUnit(string name, Unit_Type type, string version, Status status, string programmer, Requirements_Document reqDoc, string reqID)
    {
        this.name = name;
        this.type = type;
        this.version = version;
        this.status = status;
        this.programmer = programmer;
        this.reqDoc = reqDoc;
        this.reqDoc.ID = reqID;
        this.reqID = reqID;

    }
	public string GetName() {
        return name;
    }
    public Unit_Type GetUnitType()
    {
        return type;
    }
	public string GetVersion() {
        return version;
    }
    public Status GetStatus()
    {
        return status;
    }
	public string GetProgrammer() {
        return programmer;
    }
    public string GetReqDoc()
    {
        return reqDoc.Str;
	}
	public string GetReqID() {
        return reqID;
    }

}
}
