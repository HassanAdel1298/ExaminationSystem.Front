namespace ExaminationSystem.Front.Dtos
{
    public class QuizDetailsDto
    {
        public int QuizID { get; set; }
        public string Name { get; set; }
        public List<QuestionsDto> Questions { get; set; }
    }
}
