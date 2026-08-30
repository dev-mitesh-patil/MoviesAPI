public class Movie : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTimeOffset ReleaseDate { get; set; }
    public double Rating { get; set; } = 0;
}