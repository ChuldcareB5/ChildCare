namespace ChildCare.MonitoringSystem.Core.Constraints
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
