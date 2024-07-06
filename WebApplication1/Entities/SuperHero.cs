namespace WebApplication1.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;

    }
}
