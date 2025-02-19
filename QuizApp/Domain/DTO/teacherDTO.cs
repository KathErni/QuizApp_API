namespace QuizApp.Domain.DTO
{
    public record CreateTeacher
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public record UpdateTeacher
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }

    public record DeleteTeacher
    {
        public int Id { get; init; }
    }

    public record TeacherDTO
    {
        public int Id { get; init; }

        public required string Username { get; set; }
        public required string Password { get; set; }

    }
}
