namespace SampleWebAPI.Models.DBRepository
{
    using System.Collections.Generic;

    public interface IGetEmployees
    {
        IList<EmployeeModel> getAllEmployees();
        IList<EmployeeModel> getEmployeeById(int id);
    }
}