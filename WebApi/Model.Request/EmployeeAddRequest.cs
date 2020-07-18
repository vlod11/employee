using System;
using System.ComponentModel.DataAnnotations;
using Requests.Attributes;

namespace Requests
{
    public class EmployeeAddRequest
    {
        [Required]
        public DateTimeOffset HiredAt { get; set; }
        [Required]
        public DateTimeOffset? LeftAt { get; set; }
        [RequiredNotEmpty]
        public string Name { get; set; }
        [RequiredNotEmpty]
        public string Surname { get; set; }
        [Range(0, Int32.MaxValue)]
        public int Salary { get; set; }
        public string PositionId { get; set; }
    }
}