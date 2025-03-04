namespace QuizApp.Domain.DTO
{
    public record CreateQuestion
    {
        public required string Question { get; init; }
        public required string Answer { get; init; }

        public required int CreatedBy { get; init; }
    }

    public record UpdateQuestion
    {
        public required string Question { get; init; }
        public required string Answer { get; init; }
    }

    public record DeleteQuestion
    {
        public int QuizId { get; init; }
    }

    public record QuestionDTO
    {
        public int QuizId { get; set; }

        public required string Question { get; set; }

        public required string Answer { get; set; }

        public required int CreatedBy { get; init; }

    }
}
