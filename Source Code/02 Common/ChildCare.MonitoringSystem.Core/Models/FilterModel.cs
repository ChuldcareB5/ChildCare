using System.Collections.Generic;

namespace ChildCare.MonitoringSystem.Core.Models
{
    public class FilterModel
    {
        public int PageNumber { get; set; }

        public string SortMember { get; set; }

        public int PageSize { get; set; }

        public bool SortDescending { get; set; }

        public List<FilterOption> Filters { get; set; }

        public bool IsInActive { get; set; }
    }

    public class FilterOption
    {
        public string Value { get; set; }

        public string Property { get; set; }

        public string Operator { get; set; }
    }
}
