using CinemaApplication.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api.Controllers
{
    public abstract class CinemaControllerBase<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;

        protected CinemaControllerBase(ApplicationDbContext cinemaContext)
        {
            this._applicationDbContext = cinemaContext;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _applicationDbContext.Set<TEntity>().Remove(entity);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TEntity entityToUpdate)
        {
            var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _applicationDbContext.Entry(entity).CurrentValues.SetValues(entityToUpdate);
            await _applicationDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            var entities = await _applicationDbContext.Set<TEntity>().ToListAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(int id)
        {
            var entity = await _applicationDbContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
