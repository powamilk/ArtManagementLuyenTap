using BUS.Service;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetAllArtists()
        {
            var artists = await _artistService.GetAllArtistsAsync();
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(int id)
        {
            try
            {
                var artist = await _artistService.GetArtistByIdAsync(id);
                return Ok(artist);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Nghệ sĩ với ID {id} không tồn tại.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddArtist([FromBody] Artist artist)
        {
            if (artist == null)
                return BadRequest("Dữ liệu nghệ sĩ không hợp lệ.");

            await _artistService.AddArtistAsync(artist);
            return CreatedAtAction(nameof(GetArtistById), new { id = artist.ArtistId }, artist);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateArtist(int id, [FromBody] Artist artist)
        {
            try
            {
                await _artistService.UpdateArtistAsync(artist);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Nghệ sĩ với ID {id} không tồn tại.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArtist(int id)
        {
            try
            {
                await _artistService.DeleteArtistAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Nghệ sĩ với ID {id} không tồn tại.");
            }
        }
    }
}
