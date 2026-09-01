using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MovieController(IMovieService _movieService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] MovieCreateDto movieCreateDto)
    {
        try
        {
            await _movieService.AddMovie(movieCreateDto);
            return Created();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return Problem(detail: ex.Message, title: "Unexpected Error occured");
        }
    }
    [HttpGet]
    public async Task<ActionResult<List<MovieGetDto>>> GetAllMovies()
    {
        try
        {            
            return Ok(await _movieService.GetAllMovies());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return Problem(detail: ex.Message, title:"Unexpected Error occured");
        }
    }
    [HttpGet("/{movieName}")]
    public async Task<ActionResult<MovieGetDto>> GetMovieByName(string movieName)
    {
        try
        {
            return Ok(await _movieService.GetMovieByName(movieName));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            return Problem(detail: ex.Message, title:"Unexpected Error occured");
        }
    }
}