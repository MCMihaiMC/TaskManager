using TaskManager.Database.Entities;

namespace TaskManager.Database
{
    public static class FakeDatabase
    {
        private static IEnumerable<Job> _tasks;
        private static IEnumerable<Step> _steps;

        public static IQueryable<Job> Tasks
        {
            get 
            {
                if(_tasks == null)
                {
                    _tasks = new List<Job>()
                    {
                        new Job() { Id = 1, Name="Task_1" },
                        new Job() { Id = 2,  Name="Task_2"}
                    };
                }

                return _tasks.AsQueryable(); 
            }
        }

        public static IQueryable<Step> Steps
        {
            get
            {
                if(_steps == null)
                {
                    _steps = new List<Step>()
                    {
                        new Step() { Id = 1, Name = "Step_1_1", Owner = "Marcel", TaskId = 1, ParentStepId = 0},
                        new Step() { Id = 2, Name = "Step_1_2", Owner = "Joe", TaskId = 1, ParentStepId = 0 },
                        new Step() { Id = 3, Name = "Step_1_2_1", Owner = "anonymous", TaskId = 1, ParentStepId = 2 },
                        new Step() { Id = 4, Name = "Step_1_2_1_1", Owner = "anonymous", TaskId = 1, ParentStepId = 3 },
                        new Step() { Id = 5, Name = "Step_1_2_2", Owner = "anonymous", TaskId = 1, ParentStepId = 2 },
                        new Step() { Id = 6, Name = "Step_1_3", Owner = "Joe", TaskId = 1, ParentStepId = 0 },
                        new Step() { Id = 7, Name = "Step_2_1", Owner = "Bob", TaskId = 2, ParentStepId = 0 },
                        new Step() { Id = 8, Name = "Step_2_1_1", Owner = "Bob&Alice", TaskId = 2, ParentStepId = 7 },
                        new Step() { Id = 9, Name = "Step_2_1_2", Owner = "Bob&Max", TaskId = 2, ParentStepId = 7 },
                        new Step() { Id = 10, Name = "Step_2_2", Owner = "Joe", TaskId = 2, ParentStepId = 0 },
                        new Step() { Id = 11, Name = "Step_2_3", Owner = "Joe", TaskId = 2, ParentStepId = 0 },
                    };
                }

                return _steps.AsQueryable();
            }
        }


    }
}
