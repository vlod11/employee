using System;

namespace Data.Read
{
    public class EmployeePositionDto
    {
        public string PositionId { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public DateTimeOffset HiredAt { get; set; }
        public DateTimeOffset? LeftAt { get; set; }
    }
}