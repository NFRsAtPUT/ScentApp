using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ScentApp.Model;

namespace ScentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        private readonly ILogger<TemplateController> _logger;

        public TemplateController(ILogger<TemplateController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<int> Create(Template item)
        {
            _dbContext.Templates.Add(item);
            await _dbContext.SaveChangesAsync();
            return item.ID;
        }

        [HttpGet]
        public async Task<IEnumerable<Template>> Get()
        {
            var items = await _dbContext.Templates.ToListAsync();
            return items;
        }
        [HttpGet("{id}")]
        public async Task<Template> Get(int id)
        {
            var item = await _dbContext.Templates.FirstOrDefaultAsync(item => item.ID == id);
            return item;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, Template item)
        {
            var existingItem = await _dbContext.Templates.FirstOrDefaultAsync(i => i.ID == id);
            existingItem.Content = item.Content;
           // existingItem.Categories  = item.Categories;
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }


        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.Templates.FirstOrDefaultAsync(item => item.ID == id);
            _dbContext.Templates.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
