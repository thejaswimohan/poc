namespace SampleWebAPI.Models.DBRepository
{
    using SampleWebAPI;
    using System.Collections.Generic;
    using System.Linq;

    public class GetEmployees : IGetEmployees
    {
        IList<EmployeeModel> emp = null;
        
        public IList<EmployeeModel> getAllEmployees()
        {
            
            using (var ctx = new SampleDBEntities())
            {
                emp = ctx.Employees.Select(s => new EmployeeModel()
                {
                    id = s.ID,
                    name = s.Name,
                    department = s.Department,
                    salary = s.Salary
                }).ToList<EmployeeModel>();
            }
            return emp;
        }

        public IList<EmployeeModel> getEmployeeById(int id)
        {

            IList<EmployeeModel> emp = null;

            using (var ctx = new SampleDBEntities())
            {
                emp = ctx.Employees.Where(x => x.ID == id).Select(s => new EmployeeModel()
                {
                    id = s.ID,
                    name = s.Name,
                    department = s.Department,
                    salary = s.Salary
                }).ToList<EmployeeModel>();
            }
            return emp;
        }
    }
}
