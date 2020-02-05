using System;

namespace ChildCare.MonitoringSystem.Core.Models
{
    public class ApplicationContext
    {
        public string CorrelationId { get; } = Guid.NewGuid().ToString();

        public int StudentId { get; set; } = -1;

        public int UserId { get; set; } = -1;

        public string UserName { get; set; }
    }
}
