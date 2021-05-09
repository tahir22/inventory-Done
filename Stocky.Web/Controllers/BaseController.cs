using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stocky.Data.Models;
using Stocky.Data.Entities;
using Stocky.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNet.OData.Query;

namespace Stocky.Web.Controllers
{
    [ApiController, Route("api/[controller]"), Authorize]
    public class BaseController<T> : ControllerBase where T : class, IBaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseController(AppDbContext context, DbSet<T> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        //[HttpGet(""), EnableQuery()]
        //virtual public IEnumerable<T> Get()
        //{
        //    return _dbSet.AsNoTracking().Where(c => c.SharedKey == SharedKey); 
        //}

        [HttpGet("")]
        public IActionResult Get(ODataQueryOptions<T> options)
        {
            var data = _dbSet.Where(x => x.SharedKey == SharedKey).AsNoTracking();  
            var Items = options.ApplyTo(data); 
            AddHeaders(options, data);

            //return Items;
            return Ok(Items);
        }

        [HttpGet("{id}"), EnableQuery]
        virtual public SingleResult<T> Get(Guid id)
        {
            var result = _dbSet.AsNoTracking().Where(c => c.Id == id && c.SharedKey == SharedKey);
            return SingleResult.Create(result);
        }

        [HttpPut("{id}")]
        virtual public async Task<IActionResult> Put(Guid id, [FromBody] T dbEntity)
        {
            if (id != dbEntity.Id && dbEntity.SharedKey == SharedKey) return BadRequest();
            dbEntity.SharedKey = SharedKey;
            dbEntity.UpdatedBy = UserId;
            dbEntity.UpdatedDate = DateTime.Now;

            _context.Entry(dbEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Exists(id) == false) return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        virtual public async Task<ActionResult<T>> Post([FromBody] T dbEntity)
        {
            dbEntity.SharedKey = SharedKey;
            dbEntity.CreatedBy = UserId;
            dbEntity.CreatedDate = DateTime.Now;
            dbEntity.IsActive = true;

            _dbSet.Add(dbEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = dbEntity.Id }, dbEntity);
        }

        [HttpDelete("{id}")]
        virtual public async Task<ActionResult<T>> Delete(Guid id)
        {
            var dbEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id && x.SharedKey == SharedKey);
            if (dbEntity == null) return NotFound();

            _dbSet.Remove(dbEntity);
            await _context.SaveChangesAsync();

            return dbEntity;
        }

        [HttpDelete("deletelist")]
        virtual public async Task<ActionResult> DeleteList([FromBody] ListModel<T> model)
        {
            if (model.List == null || model.List.Count() <= 0) return BadRequest();

            try
            {
                _dbSet.RemoveRange(model.List);
                await _context.SaveChangesAsync();

                return Ok(model.List);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut("updatelist")]
        virtual public async Task<ActionResult> UpdateList([FromBody] ListModel<T> model)
        {
            if (model.List == null || model.List.Count() <= 0) return BadRequest();

            try
            {
                foreach (var x in model.List)
                {
                    x.SharedKey = SharedKey;
                    x.UpdatedDate = DateTime.Now;
                    x.UpdatedBy = UserId;
                }

                _dbSet.UpdateRange(model.List);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void AddHeaders(ODataQueryOptions<T> options, IQueryable<T> data)
        {
                //options.Count?.GetEntityCount(options.Filter?.ApplyTo(data, new ODataQuerySettings()) ?? data);
                var Count = data.Count();
                int pageSize = (options?.Top?.Value == null || options?.Top?.Value <= 0) ? 500 : options.Top.Value;
                var totalPages = (int)Math.Ceiling((double)Count / pageSize);

                var pagination = new
                {
                    totalPages,
                    Count,
                };

                var headers = HttpContext.Response.Headers;
                //headers.Add("Access-Control-Allow-Headers", "X-Pagination");
                headers.Add("Access-Control-Expose-Headers", "X-Pagination");

                headers.Add("X-Pagination", JsonConvert.SerializeObject(pagination));
        }

        private bool Exists(Guid id)
        {
            return _dbSet.Any(e => e.Id == id);
        }

        protected string SharedKey
        {
            get
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == "Key");
                if (claim == null) return "";

                return claim.Value;
            }
        }

        protected Guid UserId
        {
            get
            {
                Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out Guid val);

                return val;
            }
        }
    }
}
