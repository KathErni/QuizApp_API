namespace QuizApp.Domain.DTO
{
    public record CreateStudent
    {
        public required string PlayerName { get; set; }

        public int Score { get; set; }
    }

    public record UpdateStudent
    {
        public required string PlayerName { get; set; }

        public int Score { get; set; }
    }

    public record DeleteStudent
    {
        public int UserId { get; init; }
    }

    public record StudentDTO
    {
        public int UserId { get; set; }
        public required string PlayerName { get; set; }
        public int Score { get; set; }

    }
}

