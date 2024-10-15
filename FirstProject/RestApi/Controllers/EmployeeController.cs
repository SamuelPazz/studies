using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestApi.Application.ViewModel;
using RestApi.Domain.Models;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize]
        [HttpPost]
        [Route("createUser")]
        public IActionResult Add([FromForm]EmployeeViewModel employeeView)
        {
            var filePath = Path.Combine("Storage", employeeView.Photo.FileName);

            using Stream fileStream = new FileStream(filePath, FileMode.Create);
            employeeView.Photo.CopyTo(fileStream);

            var employee = new Employee(employeeView.Name, employeeView.Age, filePath);

            _employeeRepository.Add(employee);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("getAllUsers")]
        public IActionResult Get(int pageNumber, int pageQuantity)
        {
            var employee = _employeeRepository.Get(pageNumber, pageQuantity);

            if (pageNumber <= 0 || pageQuantity <= 0)
            {
                _logger.Log(LogLevel.Error, "Error on controller, route: getAllUsers");
                return BadRequest(employee);
            }

            _logger.LogInformation("OK, Information log");

            return Ok(employee);
        }

        [Authorize]
        [HttpPost]
        [Route("download/{id}")]
        public IActionResult DownloadPhoto(int id)
        {
            var employee = _employeeRepository.Get(id);

            var dataBytes = System.IO.File.ReadAllBytes(employee.Photo);

            return File(dataBytes, "image/png");
        }
    }
}
