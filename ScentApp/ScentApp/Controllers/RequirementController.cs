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
    [Route("api/[controller]")]
    [ApiController]
    public class RequirementController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        private readonly ILogger<RequirementController> _logger;

        public RequirementController(ILogger<RequirementController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<int> Create(int projectId, Requirement item)
        {
            _dbContext.Projects.Where(p=>p.ID == projectId).FirstOrDefault().Requirements.Add(item);
            await _dbContext.SaveChangesAsync();
            return item.ID;
        }


        [HttpGet]
        public async Task<IEnumerable<Requirement>> Get(int projectId)
        {
            var project = await _dbContext.Projects.FirstOrDefaultAsync(p => p.ID == projectId);
            return project.Requirements;
        }

        [HttpPut("{id}")]
        public async Task<bool> Update(int id, Requirement item)
        {
            var existingItem = await _dbContext.Requirements.FirstOrDefaultAsync(i => i.ID == id);
            existingItem.Content = item.Content;
            // existingItem.Categories  = item.Categories;
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }


        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext.Requirements.FirstOrDefaultAsync(item => item.ID == id);
            _dbContext.Requirements.Remove(item);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}