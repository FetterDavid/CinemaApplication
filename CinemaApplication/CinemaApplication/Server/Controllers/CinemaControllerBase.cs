using CinemaApplication.Server.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CinemaApplication.Api.Controllers
{
    /// <summary>
    /// Base controller for cinema-related entities providing common CRUD operations.
    /// </summary>
    /// <typeparam name="TEntity">The entity type this controller manages.</typeparam>
    public abstract class CinemaControllerBase<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly ApplicationDbContext _applicationDbContext;
        /// <summary>
        /// Initializes a new instance of the cinema controller base class.
        /// </summary>
        /// <param name="cinemaContext">The database context used for entity operations.</param>
        protected CinemaControllerBase(ApplicationDbContext cinemaContext)
        {
            this._applicationDbContext = cinemaContext;
        }
        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation. The task result contains the action result.</returns>
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
        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>A task that represents the asynchronous add operation. The task result contains the action result.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            _applicationDbContext.Set<TEntity>().Add(entity);
            await _applicationDbContext.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entityToUpdate">The updated entity data.</param>
        /// <returns>A task that represents the asynchronous update operation. The task result contains the action result.</returns>
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
        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>A task that represents the asynchronous retrieval operation. The task result contains the action result with all entities.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            var entities = await _applicationDbContext.Set<TEntity>().ToListAsync();
            return Ok(entities);
        }
        /// <summary>
        /// Retrieves a specific entity by ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>A task that represents the asynchronous retrieval operation. The task result contains the action result with the specified entity.</returns>
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
