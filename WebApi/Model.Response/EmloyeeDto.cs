using System.Collections.Generic;

namespace Data.Read
{
    public class EmployeeDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public IEnumerable<EmployeePositionDto> Positions { get; set; }
    }
}