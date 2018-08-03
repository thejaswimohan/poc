namespace SampleWebAPI.Models.DBRepository
{
    using System.Linq;

    public class AddorEditEmployee : IAddorEditEmployee
    {
        public void AddOrEdit(EmployeeModel emp) {
           
            using (var ctx = new SampleDBEntities())
            {
                if (emp.id.ToString() != "0")
                {
                    EmpEdit(ctx, emp);
                }
                else
                {
                    EmpAdd(ctx, emp);
                }
            }
        }

        private void EmpAdd(SampleDBEntities ctx, EmployeeModel emp)
        {
            ctx.Employees.Add(new Employee()
            {
                Name = emp.name,
                Department = emp.department,
                Salary = emp.salary
            });
            ctx.SaveChanges();
        }

        private void EmpEdit(SampleDBEntities ctx, EmployeeModel emp)
        {
            var existingEmp = ctx.Employees.Where(s => s.ID == emp.id).FirstOrDefault<Employee>();
            if (existingEmp != null)
            {
                existingEmp.Name = emp.name;
                existingEmp.Department = emp.department;
                existingEmp.Salary = emp.salary;

                ctx.SaveChanges();
            }
        }
    }
}