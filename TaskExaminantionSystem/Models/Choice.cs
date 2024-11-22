namespace TaskExaminantionSystem.Models
{
    public class Choice : BaseEntity
    {
        public Choice()
        {
            StudentAnswers = new List<StudentAnswer>();
        }
        public char Number { get; set; }

        public string Body { get; set; }

        public bool IsCorrect { get; set; } = false;

        public int QuestionId { get; set; }

        public Question Question { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; }
    }
}
