using System;

namespace Core.EmployeeAggregate
{
    public class EmployeePosition
    {
        public string PositionId { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
        public DateTimeOffset HiredAtUtc { get; set; }
        public DateTimeOffset? LeftAtUtc { get; set; }
    }
}