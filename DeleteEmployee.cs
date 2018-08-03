namespace SampleWebAPI.Models.DBRepository
{
    using System.Linq;

    public class DeleteEmployee : IDeleteEmployee
    {
        public void delete(int id)
        {
            using (var ctx = new SampleDBEntities())
            {
                var emp = ctx.Employees.Where(s => s.ID == id).FirstOrDefault();
                ctx.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
    }
}