using TaskManager.Database;
using TaskManager.Database.Entities;

namespace TaskManager.DataAccessLayer
{
    public interface ITaskRepository
    {
        public IEnumerable<Job> GetTasks();

        public IEnumerable<Step> GetSteps(int taskId);

        public IEnumerable<Step> GetStepsByParentId(int parentStepId);
    }
}