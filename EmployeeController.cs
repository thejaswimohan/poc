namespace SampleWebAPI.Controllers
{
    using System.Web.Http;
    using SampleWebAPI.Models;
    using System.Web.Http.Cors;
    using SampleWebAPI.Models.DBRepository;
    using System.Net;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        IGetEmployees getemployees = null;
        IAddorEditEmployee updateEmployees = null;
        IDeleteEmployee deleteEmployees = null;
        public EmployeeController()
        {
            getemployees = new GetEmployees();
            updateEmployees = new AddorEditEmployee();
            deleteEmployees = new DeleteEmployee();
        }

        [HttpGet]
        [Route("api/getEmployee")]
        public IHttpActionResult getEmployee()
        {
            var empDetails = getemployees.getAllEmployees();
            if (empDetails.Count == 0) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(empDetails);
        }       

        [HttpGet]
        [Route("api/EmployeesgetbyId/{id}")]
        public IHttpActionResult EmployeesgetbyId(int id)
        {
            IGetEmployees getemployees = new GetEmployees();
            var empDetails = getemployees.getEmployeeById(id);

            if (empDetails.Count == 0) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Ok(empDetails);
        }      

        [HttpPost]
        public IHttpActionResult updateEmployee(EmployeeModel emp)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            updateEmployees.AddOrEdit(emp);
            return Ok();
        }

        public IHttpActionResult deleteEmployee(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");
                deleteEmployees.delete(id);
            return Ok();
        }

    }

}
