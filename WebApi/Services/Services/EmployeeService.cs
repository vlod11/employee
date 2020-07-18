using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Helpers;
using Core.EmployeeAggregate;
using Data.MongoDb.Repositories.Interfaces;
using Data.Read;
using Requests;
using Services.Interfaces;

namespace Services.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDateService _dateService;

        public EmployeeService(IMapper mapper, IDateService dateService, IPositionRepository positionRepository, IEmployeeRepository employeeRepository)
        {
            _dateService = dateService;
            _mapper = mapper;
            _positionRepository = positionRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> AddEmployeeAsync(EmployeeAddRequest employeeAddRequest)
        {
            var position = await _positionRepository.GetByIdAsync(employeeAddRequest.PositionId);

            var employee = new Employee()
                           {
                               Name = employeeAddRequest.Name,
                               Surname = employeeAddRequest.Surname,
                               CreatedAtUtc = _dateService.GetDateTimeUtcNow(),
                               ModifiedAtUtc = _dateService.GetDateTimeUtcNow(),
                               Positions = new List<EmployeePosition>()
                                           {
                                               new EmployeePosition
                                               {
                                                   HiredAtUtc = employeeAddRequest.HiredAtUtc,
                                                   LeftAtUtc = employeeAddRequest.LeftAtUtc,
                                                   PositionId = employeeAddRequest.PositionId,
                                                   Title = position.Title,
                                                   Salary = employeeAddRequest.Salary
                                               }
                                           }
                           };

           await _employeeRepository.InsertAsync(employee);

            return _mapper.Map<Employee, EmployeeDto>(employee);
        }
        
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var po = await _employeeRepository.GetAllAsync();
            return 
                _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(po);
        }
    }
}