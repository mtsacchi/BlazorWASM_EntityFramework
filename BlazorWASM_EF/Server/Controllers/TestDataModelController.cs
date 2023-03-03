using BlazorWASM_EF.Server.Data;
using BlazorWASM_EF.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWASM_EF.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDataModelController : ControllerBase
    {
        private readonly MyPublicGitHubContext _context;

        public TestDataModelController(MyPublicGitHubContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestDataModel>>> GetDataModel()
        {
            return Ok(await _context.TestData.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestDataModel>> GetDataModel(int id)
        {
            var data = await _context.TestData.FindAsync(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(data);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataModel(int id, TestDataModel data)
        {
            int result = 0;

            if (id != data.Id)
            {
                return BadRequest();
            }

            _context.Entry(data).State = EntityState.Modified;

            try
            {
                result = await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataModelExists(id))
                    return NotFound();
                else
                    return BadRequest();
            }
            catch(Exception)
            {
                return BadRequest();
            }

            if (result == 1)
                return Ok();
            else
                return BadRequest();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestDataModel>> PostDataModel(TestDataModel data)
        {
            _context.TestData.Add(data);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataModel", new { id = data.Id }, data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataModel(int id)
        {
            var data = await _context.TestData.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            _context.TestData.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DataModelExists(int id)
        {
            return _context.TestData.Any(e => e.Id == id);
        }
    }
}
