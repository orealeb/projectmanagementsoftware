using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class UserInterface {
        IPresenter systemManager;
        public UserInterface()
        {
            systemManager = SystemManager.Create();
            Login();
        }
	public void Login() {

        /**Hardcode Users to Database**/
     //   systemManager.AddUser("1", "1", true);
        /**Hardcode Users to Database**/
        systemManager.LoadDatabase();

        string userName="", password="", input="";
        
        while (input != "q")
        {
            Console.WriteLine("\n**Enter q to Quit:** ");
            Console.Write("Enter Username: ");
            input = Console.ReadLine();
            if (input != "q")
            {
                userName = input;

                Console.Write("Enter password: ");
                input = Console.ReadLine();
                if (input != "q")
                {
                    password = input;
                }
                else
                {
                    return;
                }
                 
            }
            else
            {
                return;
            }
            if (systemManager.Login(userName, password))
            {
                User usr = systemManager.getUser();
                DisplayMainMenu(usr);
                systemManager.SaveDatabase();
                return;
            }
            else if (input != "q")
            {
                Console.WriteLine("Invalid Username and Password combination");
            }
            else
            {
                return;
            }
         
        }
    }

    public void DisplayOutput(string output)
    {
         Console.WriteLine(output);
    }

  /*  private void ProcessInput(string input, User usr)
    {
        if (usr is Manager)
        {
        switch (input)
        {
            case "1":
                systemManager.SortByProgrammerName();
                foreach (ProgrammingUnit unit in systemManager.GetAllProgrammingUnits())
                {
                    Console.WriteLine(unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());
                }
                break;
            case "2":
                systemManager.SortByPrimaryReq();
                foreach (ProgrammingUnit unit in systemManager.GetAllProgrammingUnits())
                {
                    Console.WriteLine(unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());
                }
                break;
            case "3":
                int i = 1;
                Console.WriteLine("Select Programming Unit");
                foreach (ProgrammingUnit unit in systemManager.GetAllProgrammingUnits())
                {
                    Console.WriteLine(i.ToString() + " " + unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());
                    i++;
                }
                Console.WriteLine("Enter Number:  ");
                int num;
                int.TryParse(Console.ReadLine(), out num);
                if (num < 1 && num > i)
                {
                    Console.WriteLine("Invalid Selection");
                }
                else
                {
                    ProgrammingUnit unit = systemManager.FindProgrammingUnit(num.ToString());
                    Console.WriteLine(unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());

                }
                break;
            case "4":
                Console.WriteLine(systemManager.ProgrammingUnitStatistics());
                break;
            case "5":
                Console.WriteLine("Enter name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter unit type (Package or Class): ");
                string unitType = Console.ReadLine();
                while (!unitType.Equals("Package") && !unitType.Equals("Class"))
                {
                    Console.WriteLine("Please enter valid Unit Type: ");
                    unitType = Console.ReadLine();
                }
                Console.WriteLine("Enter version: ");
                string version = Console.ReadLine();
                Console.WriteLine("Enter Status (Integration Testing, Unit Testing, Coding, Not Started, or Design): ");
                string status = Console.ReadLine();
                while (!status.Equals("Integration Testing") && !status.Equals("Unit Testing") && !status.Equals("Coding") && !status.Equals("Not Started") && !status.Equals("Design"))
                {
                    Console.WriteLine("Please enter valid Status: ");
                    status = Console.ReadLine();
                }
                Console.WriteLine("Enter Programmer name: ");
                string programmer = Console.ReadLine();
                Console.WriteLine("Enter Requirements Document (DSS): ");
                string reqDoc = Console.ReadLine();
                Console.WriteLine("Enter Requirements Document id: ");
                string reqID = Console.ReadLine();
                ProgrammingUnit unit2 = systemManager.FindProgrammingUnit(reqID);
                while (unit2 != null)
                {
                    Console.WriteLine("Please enter Requirements Document id that does not exisit in database:");
                    reqID = Console.ReadLine();
                    unit2 = systemManager.FindProgrammingUnit(reqID);
                }
                systemManager.AddProgrammingUnit(name, unitType, version, status.Replace(' ', '_'), programmer, reqDoc, reqID);
                Console.WriteLine("Program unit " + name + " has been added ");
                break;
            case "6":
                Console.WriteLine("Enter req ID: ");
                reqID = Console.ReadLine();
                ProgrammingUnit editUnit = systemManager.FindProgrammingUnit(reqID);
                Console.WriteLine(editUnit.GetName() + " " + editUnit.GetUnitType().ToString() + " " + editUnit.GetVersion() + " " + editUnit.GetStatus().ToString() + " " + editUnit.GetProgrammer() + " " + editUnit.GetReqDoc().ToString() + " " + editUnit.GetReqID());
                Console.WriteLine("Enter name: ");
                name = Console.ReadLine();
                Console.WriteLine("Enter unit type (Package or Class): ");
                unitType = Console.ReadLine();
                while (!unitType.Equals("Package") && !unitType.Equals("Class"))
                {
                    Console.WriteLine("Please enter valid Unit Type: ");
                    unitType = Console.ReadLine();
                }
                Console.WriteLine("Enter version: ");
                version = Console.ReadLine();
                Console.WriteLine("Enter Status (Integration Testing, Unit Testing, Coding, Not Started, or Design): ");
                status = Console.ReadLine();
                while (!status.Equals("Integration Testing") && !status.Equals("Unit Testing") && !status.Equals("Coding") && !status.Equals("Not Started") && !status.Equals("Design"))
                {
                    Console.WriteLine("Please enter valid Status: ");
                    status = Console.ReadLine();
                }
                Console.WriteLine("Enter Programmer name: ");
                programmer = Console.ReadLine();
                Console.WriteLine("Enter Requirements Document (DSS): ");
                reqDoc = Console.ReadLine();
                Console.WriteLine("Enter Requirements Document id: ");
                unit2 = systemManager.FindProgrammingUnit(reqID);
                while (unit2 != null)
                {
                    Console.WriteLine("Please enter Requirements Document id that does not exisit in database: ");
                    reqID = Console.ReadLine();
                    unit2 = systemManager.FindProgrammingUnit(reqID);

                }
                systemManager.EditProgrammingUnit(name, unitType, version, status.Replace(' ', '_'), programmer, reqDoc, reqID);
                Console.WriteLine("Program unit " + name + " has been edited ");

                break;
            case "7":
                Console.WriteLine("Enter req ID: ");
                reqID = Console.ReadLine();
                systemManager.DeleteProgrammingUnit(reqID);
                break;
            default:
                if ((input != "5" && !(usr is Manager)) || input != "8")
                {
                    Console.WriteLine("Make valid selection");
                }
                break;
        }
    }
        else{
        switch (input)
                {
                    case "1":
                        systemManager.SortByProgrammerName();
                        foreach (ProgrammingUnit unit in systemManager.GetAllProgrammingUnits())
                        {
                            Console.WriteLine(unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());
                        }
                        break;
                    case "2":
                        systemManager.SortByPrimaryReq();
                        foreach (ProgrammingUnit unit in systemManager.GetAllProgrammingUnits())
                        {
                            Console.WriteLine(unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());
                        }
                        break;
                    case "3":
                        int i = 1;
                        Console.WriteLine("Select Programming Unit");
                        foreach (ProgrammingUnit unit in systemManager.GetAllProgrammingUnits())
                        {
                            Console.WriteLine(i.ToString() + " " + unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());
                            i++;
                        }
                        Console.Write("Enter Number:  ");
                        int num;
                        int.TryParse(Console.ReadLine(), out num);
                        if (num < 1 || num > i)
                        {
                            Console.WriteLine("Invalid Selection");
                        }
                        else
                        {
                            ProgrammingUnit unit = systemManager.FindProgrammingUnit(systemManager.GetAllProgrammingUnits()[num-1].GetReqID());
                            Console.WriteLine(unit.GetName() + " " + unit.GetUnitType().ToString() + " " + unit.GetVersion() + " " + unit.GetStatus().ToString() + " " + unit.GetProgrammer() + " " + unit.GetReqDoc().ToString() + " " + unit.GetReqID());

                        }
                        break;
                    case "4":
                        Console.WriteLine(systemManager.ProgrammingUnitStatistics());
                        break;
                    default:
                        if ((input != "5" && !(usr is Manager)) || input != "8")
                        {
                            Console.WriteLine("Make valid selection");
                        }
                        break;
                
            }
        }
    }
**/

	public void DisplayMainMenu(User usr) {
        string input = "";
        while ((input != "5" && !(usr is Manager)) || (input != "8" && (usr is Manager)))
        {
            if (usr is Manager)
            {

                Console.WriteLine("\n         PMS Main Menu       ");
                Console.WriteLine("1. List project data by programmer name ");
                Console.WriteLine("2. List project data by primary requirement ");
                Console.WriteLine("3. Display information on a selected program unit ");
                Console.WriteLine("4. Display statistics for all programming units ");
                Console.WriteLine("5. Add a new programming unit ");
                Console.WriteLine("6. Edit programming unit data ");
                Console.WriteLine("7. Delete a programming unit ");
                Console.WriteLine("8. Quit ");
                Console.Write("\nEnter number: ");
                input = Console.ReadLine();
                Console.WriteLine();
                systemManager.ProcessInput(input, usr, this);
               
            }
            else
            {
                Console.WriteLine("\n         PMS Main Menu       ");
                Console.WriteLine("1. List project data by programmer name ");
                Console.WriteLine("2. List project data by primary requirement ");
                Console.WriteLine("3. Display information on a selected program unit ");
                Console.WriteLine("4. Display statistics for all programming units ");
                Console.WriteLine("5. Quit ");
                Console.Write("\nEnter number: ");
                input = Console.ReadLine();
                Console.WriteLine();
                systemManager.ProcessInput(input, usr, this);
            
           

           

        }
}
 
    
    }



    }
}
