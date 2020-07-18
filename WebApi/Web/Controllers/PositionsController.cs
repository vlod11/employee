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
    public class PositionsController : ControllerBase
    {
        //private readonly IServiceResultMapper _viewMapper;
        private readonly IMapper _mapper;
        private readonly IDateService _dateService;
        private readonly IPositionService _positionService;


        public PositionsController(IMapper mapper, IDateService dateService, IPositionService positionService)
        {
            //_viewMapper = viewMapper;
            _mapper = mapper;
            _dateService = dateService;
            _positionService = positionService;
        }

        [HttpPost]
        public async Task<ActionResult<PositionDto>> AddPositionAsync([FromBody] PositionAddRequest request)
        {
            var positionDto = await _positionService.AddPosition(request);
            return new ActionResult<PositionDto>(positionDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionDto>>> GetAllPositionsAsync()
        {
            var positionDtos = await _positionService.GetAllPositonsAsync();
            return new ActionResult<IEnumerable<PositionDto>>(positionDtos);
        }
    }
}