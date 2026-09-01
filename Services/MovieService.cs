public class MovieService(MovieRepository _movieRepository) : IMovieService
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
        await _movieRepository.AddMovie(movie);
    }

    public async Task<IEnumerable<MovieGetDto>> GetAllMovies()
    {
        var movies = await _movieRepository.GetAllMovies();
        return movies.Select(m => new MovieGetDto
        {
            Id = m.Id,
            Name = m.Name,
            Description = m.Description,
            ReleaseDate = m.ReleaseDate,
            Rating = m.Rating
        }).ToList();
    }

    public async Task<MovieGetDto?> GetMovieByName(string name)
    {
        var movie = await _movieRepository.GetMovieByName(name);
        if (movie == null) return null;

        return new MovieGetDto
        {
            Id = movie.Id,
            Name = movie.Name,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            Description = movie.Description
        };
    }
}