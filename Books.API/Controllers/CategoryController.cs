using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.API.Dtos;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAsyncRepository<Category> _categoryRepository;

        public CategoryController(IAsyncRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    
        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.ListAllAsync();

            if (categories == null || categories.Count == 0)
                return NotFound();

            return Ok(categories);
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int? id = 0)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        // POST api/category
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryDto categoryObj)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = new Category
            {
                Name = categoryObj.Name,
                Description = categoryObj.Description
            };

            var newCategory = await _categoryRepository.AddAsync(category);
            return Ok(newCategory);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, [FromBody] CategoryDto categoryFromUser)
        {
            if (id == null || !ModelState.IsValid)
                return BadRequest();

            var categoryInDb = await _categoryRepository.GetByIdAsync(id);

            if (categoryInDb == null)
                return NotFound();

            categoryInDb.Name = categoryFromUser.Name;
            categoryInDb.Description = categoryFromUser.Description;

            await _categoryRepository.UpdateAsync(categoryInDb);

            return Ok();
        }

        // DELETE api/category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 1)
                return BadRequest();

            var categoryInDb = await _categoryRepository.GetByIdAsync(id);

            if (categoryInDb == null)
                return NotFound();

            await _categoryRepository.DeleteAsync(categoryInDb);

            return Ok();
        }
    }
}
