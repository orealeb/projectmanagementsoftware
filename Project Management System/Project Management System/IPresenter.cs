using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Management_System
{
    public interface IPresenter 
    {
        User getUser();
        void ProcessInput(string input, User usr, UserInterface ui);
        bool Login(string username, string password);
	    void SaveDatabase( );
	    void LoadDatabase( );
        List<ProgrammingUnit> SortByProgrammerName();
        List<ProgrammingUnit> SortByPrimaryReq();
        List<ProgrammingUnit> GetAllProgrammingUnits();
        void DeleteProgrammingUnit(string id);
        void EditProgrammingUnit(string name, string type, string version, string status, string programmer, string reqDoc, string reqID);
        String ProgrammingUnitStatistics();
        void AddProgrammingUnit(string name, string type, string version, string status, string programmer, string reqDoc, string reqID);
        ProgrammingUnit FindProgrammingUnit(string id);
        //void AddUser(string userName, string password, bool isManager);
}
}