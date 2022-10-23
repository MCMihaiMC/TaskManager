namespace TaskManagerMVC.Models
{
    public class Step
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string step { get; set; }
        public List<Step> Steps { get; set; }
        public bool IsActive { get; set; }
    }
}
