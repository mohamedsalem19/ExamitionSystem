namespace TaskExaminantionSystem.Models
{
    public class Question : BaseEntity
    {
        public Question()
        {
            QuizQuestions = new List<QuizQuestion>();
            Choices = new List<Choice>();
            StudentAnswers = new List<StudentAnswer>();

        }
        public string Body { get; set; }
        public int Number { get; set; }
        public ICollection<QuizQuestion> QuizQuestions { get; set; }
        public ICollection<Choice> Choices { get; set; }

        public ICollection<StudentAnswer> StudentAnswers { get; set; }


    }
}
