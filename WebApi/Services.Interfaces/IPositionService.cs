using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Read;
using Requests;

namespace Services.Interfaces
{
    public interface IPositionService
    {
        Task<PositionDto> AddPosition(PositionAddRequest positionAddRequest);
        Task<IEnumerable<PositionDto>> GetAllPositonsAsync();
    }
}