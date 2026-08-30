using Microsoft.EntityFrameworkCore;

public class MovieRepository(AppDBContext _dbContext)
{
    public async Task AddMovie(Movie movie)
    {
        _dbContext.Movies.Add(movie);
        await _dbContext.SaveChangesAsync();
    } 
    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        return await _dbContext.Movies.ToListAsync();
    }

    public async Task<Movie?> GetMovieByName(string name)
    {
        return await _dbContext.Movies.Where(m => m.Name == name).FirstOrDefaultAsync();
    }
}