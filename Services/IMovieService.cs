public interface IMovieService
{
    Task AddMovie(MovieCreateDto movieCreateDto);
    Task<IEnumerable<MovieGetDto>> GetAllMovies();
    Task<MovieGetDto?> GetMovieByName(string movieName);
}