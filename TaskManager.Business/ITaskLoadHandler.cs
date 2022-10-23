using TaskManager.Business.BusinessEntities;

namespace TaskManager.Business
{
    public interface ITaskLoadHandler
    {
        IEnumerable<Step> GetSteps(int taskId);
        IEnumerable<Step> GetStepsByParentId(int parentStepId);
        IEnumerable<Job> GetTasks();
    }
}
