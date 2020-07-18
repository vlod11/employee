using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Common.Helpers;
using Core.PositionAggregate;
using Data.MongoDb.Repositories.Interfaces;
using Data.Read;
using Requests;
using Services.Interfaces;

namespace Services.Services
{
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDateService _dateService;


        public PositionService(IMapper mapper, IPositionRepository positionRepository,
            IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<PositionDto> AddPosition(PositionAddRequest positionAddRequest)
        {
            var em = new Position()
                     {
                         Title = positionAddRequest.Title
                     };

            await _positionRepository.InsertAsync(em);
            
            return _mapper.Map<Position, PositionDto>(em);
        }
        
        public async Task<IEnumerable<PositionDto>> GetAllPositonsAsync()
        {
            var po = await _positionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Position>, IEnumerable<PositionDto>>(po); 
        }
    }
}