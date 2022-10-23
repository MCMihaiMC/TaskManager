using TaskManager.Database;
using TaskManager.Database.Entities;

namespace TaskManager.DataAccessLayer
{
    public class TaskRepository : ITaskRepository
    {
        public IEnumerable<Step> GetSteps(int taskId)
        {
            var query = from s in FakeDatabase.Steps
                        where taskId == s.TaskId
                        && s.ParentStepId == 0
                        select s;

            return query;
        }

        public IEnumerable<Step> GetStepsByParentId(int parentStepId)
        {
            var query = from s in FakeDatabase.Steps
                        where s.ParentStepId == parentStepId
                        select s;

            return query;
        }

        public IEnumerable<Job> GetTasks()
        {
            var query = from t in FakeDatabase.Tasks
                        select t;

            return query;
        }
    }
}
