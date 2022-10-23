using TaskManager.DataAccessLayer;
using TaskManager.Business.BusinessEntities;

namespace TaskManager.Business
{
    public class TaskLoadHandler : ITaskLoadHandler
    {
        private ITaskRepository _taskRepository;

        public TaskLoadHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // TODO Async all the way.

        public IEnumerable<Job> GetTasks()
        {
            return _taskRepository.GetTasks().Select(s => new Job()
            {
                Id = s.Id,
                Name = s.Name,
            });
        }

        public IEnumerable<Step> GetSteps(int taskId)
        {
            var owner = "anonymus";
            return _taskRepository.GetSteps(taskId).Select(s => new Step()
            {
                Id = s.Id,
                Label = $"{s.Name}-{s.Owner}",
            });
        }

        public IEnumerable<Step> GetStepsByParentId(int parentStepId)
        {
            return _taskRepository.GetStepsByParentId(parentStepId).Select(s => new Step()
            {
                Id = s.Id,
                Label = $"{s.Name}-{s.Owner}",
            });
        }

    }
}