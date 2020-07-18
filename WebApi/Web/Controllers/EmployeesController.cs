using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Helpers;
using Data.Read;
using Microsoft.AspNetCore.Mvc;
using Requests;
using Services.Interfaces;

namespace Web.Controllers
{
    [ApiVersion("1.0")]
    [Route("/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //private readonly IServiceResultMapper _viewMapper;
        private readonly IMapper _mapper;
        private readonly IDateService _dateService;
        private readonly IPositionService _positionService;
        private readonly IEmployeeService _employeeService;


        public EmployeesController(IMapper mapper, IDateService dateService, IPositionService positionService, IEmployeeService employeeService)
        {
            //_viewMapper = viewMapper;
            _mapper = mapper;
            _dateService = dateService;
            _positionService = positionService;
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> AddEmployeeAsync([FromBody] EmployeeAddRequest request)
        {
            var employeeDto = await _employeeService.AddEmployeeAsync(request);
            return new ActionResult<EmployeeDto>(employeeDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployeesAsync()
        {
            var employeeDtos = await _employeeService.GetAllEmployeesAsync();
            return new ActionResult<IEnumerable<EmployeeDto>>(employeeDtos);
        }
    }
}