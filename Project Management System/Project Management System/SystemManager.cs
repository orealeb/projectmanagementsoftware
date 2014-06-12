using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class SystemManager : IPresenter  {
    private static SystemManager self = new SystemManager();
  //  private ProgrammingUnitManager unitManager = new ProgrammingUnitManager();
    private UserManager userManager = new UserManager();
    private IModel modelController = new ModelController();
 //   private ModelManager modelManager = new ModelManager();

    public void ProcessInput(string input, User usr, UserInterface ui)
    {
        if (usr is Manager)
        {
            switch (input)
            {
                case "1":
                    List<ProgrammingUnit> list1 =  SortByProgrammerName();
                    foreach (ProgrammingUnit l in list1)
                    {
                        ui.DisplayOutput(l.GetProgrammer() + " " + l.GetName() + " " + l.GetUnitType().ToString() + " " + l.GetVersion() + " " + l.GetStatus().ToString() + " " + l.GetReqDoc().ToString() + " " + l.GetReqID());
                    }
                    break;
                case "2":
                    List<ProgrammingUnit> list = SortByPrimaryReq();
                    foreach (ProgrammingUnit l in list)
                    {
                         ui.DisplayOutput(l.GetReqID() + " " + l.GetName() + " " + l.GetUnitType().ToString() + " " + l.GetVersion() + " " + l.GetStatus().ToString() + " " + l.GetProgrammer() + " " + l.GetReqDoc().ToString() );
                    }
                    break;
                case "3":
                    ui.DisplayOutput("Select Programming Unit");                 
                    Console.Write("Enter Primary Requirement id:  ");
                    string selection = Console.ReadLine();
                    ProgrammingUnit selectedUnit = FindProgrammingUnit(selection);
                    if (selectedUnit != null)
                    {
                        ui.DisplayOutput(selectedUnit.GetName() + " " + selectedUnit.GetUnitType().ToString() + " " + selectedUnit.GetVersion() + " " + selectedUnit.GetStatus().ToString() + " " + selectedUnit.GetProgrammer() + " " + selectedUnit.GetReqDoc().ToString() + " " + selectedUnit.GetReqID());
                    }
                    else
                    {
                        ui.DisplayOutput("Invalid Selection");
                    }
                    break;
                case "4":
                     ui.DisplayOutput(ProgrammingUnitStatistics());
                    break;
                case "5":
                     ui.DisplayOutput("Enter name: ");
                    string name = Console.ReadLine();
                     ui.DisplayOutput("Enter unit type (Package or Class): ");
                    string unitType = Console.ReadLine();
                    while (!unitType.Equals("Package") && !unitType.Equals("Class"))
                    {
                         ui.DisplayOutput("Please enter valid Unit Type: ");
                        unitType = Console.ReadLine();
                    }
                     ui.DisplayOutput("Enter version: ");
                    string version = Console.ReadLine();
                     ui.DisplayOutput("Enter Status (Integration Testing, Unit Testing, Coding, Not Started, or Design): ");
                    string status = Console.ReadLine();
                    while (!status.Equals("Integration Testing") && !status.Equals("Unit Testing") && !status.Equals("Coding") && !status.Equals("Not Started") && !status.Equals("Design"))
                    {
                         ui.DisplayOutput("Please enter valid Status: ");
                        status = Console.ReadLine();
                    }
                     ui.DisplayOutput("Enter Programmer name: ");
                    string programmer = Console.ReadLine();
                     ui.DisplayOutput("Enter Requirements Document (DSS): ");
                    string reqDoc = Console.ReadLine();
                     ui.DisplayOutput("Enter Requirements Document id: ");
                    string reqID = Console.ReadLine();
                    ProgrammingUnit unit2 = FindProgrammingUnit(reqID);
                    while (unit2 != null)
                    {
                         ui.DisplayOutput("Please enter Requirements Document id that does not exisit in database:");
                        reqID = Console.ReadLine();
                        unit2 = FindProgrammingUnit(reqID);
                    }
                    AddProgrammingUnit(name, unitType, version, status.Replace(' ', '_'), programmer, reqDoc, reqID);
                     ui.DisplayOutput("Program unit " + name + " has been added ");
                    break;
                case "6":
                     ui.DisplayOutput("Enter req ID: ");
                    reqID = Console.ReadLine();
                     unit2 = FindProgrammingUnit(reqID);
                    while (unit2 == null)
                    {
                         ui.DisplayOutput("Please enter Requirements Document id that exist in database: ");
                        reqID = Console.ReadLine();
                        unit2 = FindProgrammingUnit(reqID);

                    }

                    ProgrammingUnit editUnit = FindProgrammingUnit(reqID);
                     ui.DisplayOutput(editUnit.GetName() + " " + editUnit.GetUnitType().ToString() + " " + editUnit.GetVersion() + " " + editUnit.GetStatus().ToString() + " " + editUnit.GetProgrammer() + " " + editUnit.GetReqDoc().ToString() + " " + editUnit.GetReqID());
                     ui.DisplayOutput("Enter name: ");
                    name = Console.ReadLine();
                     ui.DisplayOutput("Enter unit type (Package or Class): ");
                    unitType = Console.ReadLine();
                    while (!unitType.Equals("Package") && !unitType.Equals("Class"))
                    {
                         ui.DisplayOutput("Please enter valid Unit Type: ");
                        unitType = Console.ReadLine();
                    }
                     ui.DisplayOutput("Enter version: ");
                    version = Console.ReadLine();
                     ui.DisplayOutput("Enter Status (Integration Testing, Unit Testing, Coding, Not Started, or Design): ");
                    status = Console.ReadLine();
                    while (!status.Equals("Integration Testing") && !status.Equals("Unit Testing") && !status.Equals("Coding") && !status.Equals("Not Started") && !status.Equals("Design"))
                    {
                         ui.DisplayOutput("Please enter valid Status: ");
                        status = Console.ReadLine();
                    }
                     ui.DisplayOutput("Enter Programmer name: ");
                    programmer = Console.ReadLine();
                     ui.DisplayOutput("Enter Requirements Document (DSS): ");
                    reqDoc = Console.ReadLine();
                    
                    EditProgrammingUnit(name, unitType, version, status.Replace(' ', '_'), programmer, reqDoc, reqID);
                     ui.DisplayOutput("Program unit " + name + " has been edited ");

                    break;
                case "7":
                     ui.DisplayOutput("Enter req ID: ");
                    reqID = Console.ReadLine();
                    DeleteProgrammingUnit(reqID);
                    break;
                default:
                    if ((input != "5" && !(usr is Manager)) || input != "8")
                    {
                         ui.DisplayOutput("Make valid selection");
                    }
                    break;
            }
        }
        else
        {
            switch (input)
            {
                case "1":
                    List<ProgrammingUnit> list1 =  SortByProgrammerName();
                    foreach (ProgrammingUnit l in list1)
                    {
                        ui.DisplayOutput(l.GetProgrammer() + " " + l.GetName() + " " + l.GetUnitType().ToString() + " " + l.GetVersion() + " " + l.GetStatus().ToString() + " " + l.GetReqDoc().ToString() + " " + l.GetReqID());
                    }
                    break;
                case "2":
                    List<ProgrammingUnit> list = SortByPrimaryReq();
                    foreach (ProgrammingUnit l in list)
                    {
                         ui.DisplayOutput(l.GetReqID() + " " + l.GetName() + " " + l.GetUnitType().ToString() + " " + l.GetVersion() + " " + l.GetStatus().ToString() + " " + l.GetProgrammer() + " " + l.GetReqDoc().ToString() );
                    }
                    break;
                case "3":
                     ui.DisplayOutput("Select Programming Unit");
                    Console.Write("Enter Primary Requirement id:  ");
                    string selection = Console.ReadLine();
                    ProgrammingUnit selectedUnit = FindProgrammingUnit(selection);
                    if (selectedUnit != null)
                    {
                        ui.DisplayOutput(selectedUnit.GetName() + " " + selectedUnit.GetUnitType().ToString() + " " + selectedUnit.GetVersion() + " " + selectedUnit.GetStatus().ToString() + " " + selectedUnit.GetProgrammer() + " " + selectedUnit.GetReqDoc().ToString() + " " + selectedUnit.GetReqID());
                    }
                    else
                    {
                        ui.DisplayOutput("Invalid Selection");
                    }
                    break;
                case "4":
                     ui.DisplayOutput(ProgrammingUnitStatistics());
                    break;
                default:
                    if ((input != "5" && !(usr is Manager)))
                    {
                         ui.DisplayOutput("Make valid selection");
                    }
                    break;

            }
        }
    }

    //public void AddUser(string userName, string password, bool isManager)
    //{
    //     userManager.AddUser( userName,  password,  isManager);
       
    //}

    public void DeleteProgrammingUnit(string id)
    {
        ProgrammingUnit unit = modelController.FindProgrammingUnit(id);
        modelController.DeleteProgrammingUnit(unit);
    }
	public void EditProgrammingUnit( string name, string type, string version, string status, string programmer, string reqDoc, string reqID) {
        ProgrammingUnit unit = modelController.FindProgrammingUnit(reqID);
        modelController.DeleteProgrammingUnit(unit);
       AddProgrammingUnit(name, type, version, status, programmer, reqDoc, reqID);
    
    }
	public List<ProgrammingUnit> GetAllProgrammingUnits() {
        return modelController.GetProgrammingUnits();
    }
    public void LoadDatabase()
    {

        modelController.LoadDatabase();
    }
	public bool Login(string username,   string password) {
        userManager.Login(username, password, modelController);
        if (userManager.IsUserLoggedin)
        {
            return true;
        }
        return false;
    }
    public User getUser()
    {
        if (userManager.IsUserLoggedin)
        {
            return userManager.getUser();
        }
        return null;

    }
    public void SaveDatabase( ) {
        modelController.SaveDatabase();
    }
	public List<ProgrammingUnit> SortByPrimaryReq() {
        return modelController.GetProgrammingUnits().OrderBy(o => o.GetReqID()).ToList();
    }
    public List<ProgrammingUnit> SortByProgrammerName(){
       return modelController.GetProgrammingUnits().OrderBy(o => o.GetProgrammer()).ToList(); 
    }
	public static IPresenter Create() {
        return self;
    }
   	public ProgrammingUnit FindProgrammingUnit(  string id) {
        return modelController.FindProgrammingUnit(id);
    }
	public void AddProgrammingUnit(string name, string type, string version, string status, string programmer, string reqDoc, string reqID)
    {
        ProgrammingUnit unit = new ProgrammingUnit(name, (Unit_Type)Enum.Parse(typeof(Unit_Type), type), version, (Status)Enum.Parse(typeof(Status), status), programmer, new Requirements_Document(reqDoc), reqID);
        modelController.AddProgrammingUnit(unit);	
    }
	public String ProgrammingUnitStatistics() {

        int notStarted = modelController.GetProgrammingUnits().Where(item => item.GetStatus() == ((Status)Enum.Parse(typeof(Status), "Not_Started"))).Count();
        int design = modelController.GetProgrammingUnits().Where(item => item.GetStatus() == ((Status)Enum.Parse(typeof(Status), "Design"))).Count();
        int coding = modelController.GetProgrammingUnits().Where(item => item.GetStatus() == ((Status)Enum.Parse(typeof(Status), "Coding"))).Count();
        int testing = modelController.GetProgrammingUnits().Where(item => item.GetStatus() == ((Status)Enum.Parse(typeof(Status), "Unit_Testing"))).Count()
            + modelController.GetProgrammingUnits().Where(item => item.GetStatus() == ((Status)Enum.Parse(typeof(Status), "Integration_Testing"))).Count();

        return "NotStarted: " + notStarted.ToString() + "\nDesign: " + design.ToString() + "\nCoding: " + coding.ToString() + "\nTesting: " + testing.ToString();
    }


}
}