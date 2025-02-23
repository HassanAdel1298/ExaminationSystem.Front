namespace ExaminationSystem.Front.Dtos
{
    public class QuestionsDto
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public List<ChoisesDto> Choises { get; set; }
    }
}
