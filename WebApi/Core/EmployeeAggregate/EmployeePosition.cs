using System;

namespace Core.EmployeeAggregate
{
    public class EmployeePosition
    {
        public string PositionId { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public DateTimeOffset HiredAt { get; set; }
        public DateTimeOffset? LeftAt { get; set; }
    }
}