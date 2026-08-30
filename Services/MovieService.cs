public class MovieService(MovieRepository _movieRepository) : IMovieService
{
    public async Task AddMovie(MovieCreateDto movieCreateDto)
    {
        await _movieRepository.AddMovie(movieCreateDto);
    }

    public async Task<IEnumerable<MovieGetDto>> GetAllMovies()
    {
        return await _movieRepository.GetAllMovies();
    }
}