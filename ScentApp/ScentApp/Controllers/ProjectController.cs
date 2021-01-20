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
    public class ProjectController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        private readonly ILogger<ProjectController> _logger;

        public ProjectController(ILogger<ProjectController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<int> Create(Project item)
        {
            _dbContext.Projects.Add(item);
            await _dbContext.SaveChangesAsync();
            return item.ID;
        }

        [HttpGet]
        public async Task<IEnumerable<Project>> Get()
        {
            var items = await _dbContext.Projects.ToListAsync();
            return items;
        }
        [HttpGet("{id}")]
        public async Task<Project> Get(int id)
        {
            var item = await _dbContext.Projects.FirstOrDefaultAsync(item => item.ID == id);
            return item;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, Project item)
        {
            var existingItem = await _dbContext.Projects.FirstOrDefaultAsync(i => i.ID == id);
            existingItem.Name = item.Name;
           // existingItem.Categories  = item.Categories;
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }


        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.Projects.FirstOrDefaultAsync(item => item.ID == id);
            _dbContext.Projects.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
