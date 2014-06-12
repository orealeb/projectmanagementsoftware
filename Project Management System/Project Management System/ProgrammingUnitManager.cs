using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Management_System
{
    public class ProgrammingUnitManager {
        private IModel modelController = ModelController.Create();

	public void AddProgrammingUnit(ProgrammingUnit unit) {
        modelController.GetProgrammingUnits().Add(unit);
    }
	public ProgrammingUnit CreateProgrammingUnit(string name, Unit_Type type, string version, Status status, string programmer, Requirements_Document reqDoc, string reqID)
    {
        ProgrammingUnit unit = new ProgrammingUnit(name, type, version, status, programmer, reqDoc, reqID);
        return unit;
	}
	public void DeleteProgrammingUnit(ProgrammingUnit unit) {
        modelController.GetProgrammingUnits().Remove(unit);

    }
    public void EditProgrammingUnit(ProgrammingUnit unit)
    {
		throw new System.Exception("Not implemented");
	}
	public List<ProgrammingUnit> GetAllProgrammingUnits() {
        return modelController.GetProgrammingUnits();
    }
	public String ProgrammingUnitsStatistics() {
		throw new System.Exception("Not implemented");
	}
    public ProgrammingUnit FindProgrammingUnit(string id)
    {
        return modelController.GetProgrammingUnits().Find(item => item.GetReqID() == id);
	}


}
}