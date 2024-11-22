namespace TaskExaminantionSystem.ViewModels.CourseView
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Duration { get; set; }

        public string Description { get; set; }

        public int InstructorId { get; set; }
    }
}
