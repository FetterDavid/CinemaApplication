using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api.Controllers
{
    public abstract class CinemaControllerBase<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly CinemaContext _cinemaContext;

        protected CinemaControllerBase(CinemaContext cinemaContext)
        {
            this._cinemaContext = cinemaContext;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _cinemaContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            _cinemaContext.Set<TEntity>().Remove(entity);
            await _cinemaContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            _cinemaContext.Set<TEntity>().Add(entity);
            await _cinemaContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TEntity entityToUpdate)
        {
            var entity = await _cinemaContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _cinemaContext.Entry(entity).CurrentValues.SetValues(entityToUpdate);
            await _cinemaContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            var entities = await _cinemaContext.Set<TEntity>().ToListAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetById(int id)
        {
            var entity = await _cinemaContext.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
