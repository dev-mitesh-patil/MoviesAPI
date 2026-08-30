using Microsoft.EntityFrameworkCore;

public class MovieService(AppDBContext _dbContext)
{
    public async Task AddMovie(MovieCreateDto movieCreateDto)
    {
        Movie movie = new Movie
        {
            Name = movieCreateDto.Name,
            Description = movieCreateDto.Description,
            ReleaseDate = movieCreateDto.ReleaseDate,
            Rating = movieCreateDto.Rating
        };

        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<MovieGetDto>> GetAllMovies()
    {
        return await _dbContext.Movies
        .Select(movie => new MovieGetDto
        {
            Id = movie.Id,
            Name = movie.Name,
            Description = movie.Description,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating
        }).ToListAsync();
    }
}