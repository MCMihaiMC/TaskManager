using TaskManager.Business.BusinessEntities;

namespace TaskManager.Models
{
    public class ViewModel
    {
        public IEnumerable<Job> ListTasks { get; set; } 
        public IEnumerable<Step> ListSteps { get; set; }
    }
}
