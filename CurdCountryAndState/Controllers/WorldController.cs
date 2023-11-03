using CurdCountryAndState.Data;
using CurdCountryAndState.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CurdCountryAndState.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorldController : ControllerBase
    {
        private readonly MyWorldDbContext _myWorldDbContext;
        public WorldController(MyWorldDbContext myWorldDbContext)
        {
            _myWorldDbContext = myWorldDbContext;
        }
        [HttpGet("countries")]
        public async Task<IActionResult> GetAsync()
        {
            var students = await _myWorldDbContext.Tbl_Coutries.ToListAsync();
            return Ok(students);
        }
        [HttpGet]
        [Route("get-county-by-id")]
        public async Task<IActionResult> GetCountriesByIdAsync(int id)
        {
            var student = await _myWorldDbContext.Tbl_Coutries.FindAsync(id);
            return Ok(student);
        }  
        [HttpGet]
        [Route("get-state-by-id")]
        public async Task<IActionResult> GetStateByIdAsync(int id)
        {
            var student = await _myWorldDbContext.Tbl_States.FindAsync(id);
            return Ok(student);
        }

        [HttpPost]
        [Route("AddCountry")]
        public async Task<IActionResult> PostAsync(Coutries coutries)
        {
            _myWorldDbContext.Tbl_Coutries.Add(coutries);
            await _myWorldDbContext.SaveChangesAsync();
            return Created($"/get-county-by-id?id={coutries.CountryId}", coutries);
        }

        [HttpPost]
        [Route("State")]
        public async Task<IActionResult> PostAsync(States states)
        {
            _myWorldDbContext.Tbl_States.Add(states);
            await _myWorldDbContext.SaveChangesAsync();
            return Created($"/get-state-by-id?id={states.StateId}", states);
        }

        [HttpPut]
        [Route("UpdateState")]
        public async Task<IActionResult> PutAsync(States states)
        {
            _myWorldDbContext.Tbl_States.Update(states);
            await _myWorldDbContext.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        [Route("UpdateCountry")]
        public async Task<IActionResult> PutAsync(Coutries coutries)
        {
            _myWorldDbContext.Tbl_Coutries.Update(coutries);
            await _myWorldDbContext.SaveChangesAsync();
            return NoContent();
        }
        [Route("DeleteCountry/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCountryAsync(int id)
        {
            var countryToDelete = await _myWorldDbContext.Tbl_Coutries.FindAsync(id);
            if (countryToDelete == null)
            {
                return NotFound();
            }
            _myWorldDbContext.Tbl_Coutries.Remove(countryToDelete);
            await _myWorldDbContext.SaveChangesAsync();
            return NoContent();
        }

        [Route("DeleteState/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStateAsync(int id)
        {
            var stateToDelete = await _myWorldDbContext.Tbl_States.FindAsync(id);
            if (stateToDelete == null)
            {
                return NotFound();
            }
            _myWorldDbContext.Tbl_States.Remove(stateToDelete);
            await _myWorldDbContext.SaveChangesAsync();
            return NoContent();
        }

    }
}
