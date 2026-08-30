using System.ComponentModel.DataAnnotations;

public class MovieCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public DateTimeOffset ReleaseDate { get; set; }
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
}