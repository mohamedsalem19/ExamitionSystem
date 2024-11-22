namespace TaskExaminantionSystem.Models
{
    public class StudentAnswer : BaseEntity
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int ChoiceId { get; set; }

        public Choice Choice { get; set; }
    }
}
