using AutoMapper;
using Core.EmployeeAggregate;
using Core.PositionAggregate;
using Data.Read;

namespace Services
{
    public class ModelToViewMapperProfile : Profile
    {
        public ModelToViewMapperProfile()
        {
            CreateMap<Position, PositionDto>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeePosition, EmployeePositionDto>();
        }
    }
}