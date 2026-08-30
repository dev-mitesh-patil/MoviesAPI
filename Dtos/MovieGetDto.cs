public class MovieGetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset ReleaseDate { get; set; }
    public double Rating { get; set; }
}