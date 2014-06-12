using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class ModelController : IModel  {
	private static ModelController self = new ModelController();
    private List<ProgrammingUnit> units = new List<ProgrammingUnit>();
    private List<User> users = new List<User>();

    public List<ProgrammingUnit> GetProgrammingUnits()
    {
        return units;
    }
	public List<User> GetUsers() {
        return users;
    }

    //public void SortByPrimaryReq()
    //{
    //    units = self.GetProgrammingUnits().OrderBy(o => o.GetReqID()).ToList();

    //}
    //public void SortByProgrammerName()
    //{
    //    units = self.GetProgrammingUnits().OrderBy(o => o.GetProgrammer()).ToList();
    //}

    public void LoadDatabase() {
        var reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\PMSDatabase.csv");
        var line = reader.ReadLine();

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            var values = line.Split(',');


            units.Add(new ProgrammingUnit(values[0], (Unit_Type)Enum.Parse(typeof(Unit_Type), UppercaseFirst(values[1])), values[2], (Status)Enum.Parse(typeof(Status), UppercaseFirst(values[3]).Replace(' ', '_')), values[4], new Requirements_Document(values[5]), values[6]));
        }
        reader.Close();

        reader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + @"\UserDatabase.csv");
        line = reader.ReadLine();

        while (!reader.EndOfStream)
        {
            line = reader.ReadLine();
            var values = line.Split(',');

            User usr;
            if (values[2].Equals("Y"))
            {
                usr = new Manager(values[0], values[1]);
                usr.IsManager = true;
            }
            else
            {
                usr = new User(values[0], values[1]);
            }
            users.Add(usr);
        }
        reader.Close();

    
    }

    private string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

    public void SaveDatabase() {
        var writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\PMSDatabase.csv");
        using (writer)
        {
            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}", "Name", "Type", "Version", "Status", "Programmer", "Req Doc", "Req ID");

             foreach (ProgrammingUnit unit in units)
            {
                writer.WriteLine("{0},{1},{2},{3},{4},{5},{6}", unit.GetName(), unit.GetUnitType().ToString(), unit.GetVersion(), unit.GetStatus().ToString().Replace('_', ' '), unit.GetProgrammer(), unit.GetReqDoc().ToString(), unit.GetReqID()  );
            }
        }
        writer.Close();
    }

    public static ModelController Create()
    {
        return self;
    }

    public void AddProgrammingUnit(ProgrammingUnit unit)
    {
        GetProgrammingUnits().Add(unit);
    }
    public ProgrammingUnit CreateProgrammingUnit(string name, Unit_Type type, string version, Status status, string programmer, Requirements_Document reqDoc, string reqID)
    {
        ProgrammingUnit unit = new ProgrammingUnit(name, type, version, status, programmer, reqDoc, reqID);
        return unit;
    }
    public void DeleteProgrammingUnit(ProgrammingUnit unit)
    {
        GetProgrammingUnits().Remove(unit);

    }
    //public void EditProgrammingUnit(ProgrammingUnit unit)
    //{
    //    throw new System.Exception("Not implemented");
    //}
    //public List<ProgrammingUnit> GetAllProgrammingUnits()
    //{
    //    return GetProgrammingUnits();
    //}
   
    public ProgrammingUnit FindProgrammingUnit(string id)
    {
        return GetProgrammingUnits().Find(item => item.GetReqID() == id);
    }

}
}