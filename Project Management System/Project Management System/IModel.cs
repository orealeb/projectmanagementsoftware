using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{

    public interface IModel
    {
        void LoadDatabase();
        void SaveDatabase();
        List<ProgrammingUnit> GetProgrammingUnits();
        List<User> GetUsers();
     //   void SortByPrimaryReq();
     //   void SortByProgrammerName();
        void AddProgrammingUnit(ProgrammingUnit unit);
        ProgrammingUnit CreateProgrammingUnit(string name, Unit_Type type, string version, Status status, string programmer, Requirements_Document reqDoc, string reqID);
        void DeleteProgrammingUnit(ProgrammingUnit unit);
      //  void EditProgrammingUnit(ProgrammingUnit unit);
      //  List<ProgrammingUnit> GetAllProgrammingUnits();
     //   String ProgrammingUnitsStatistics();
        ProgrammingUnit FindProgrammingUnit(string id);

    }

}