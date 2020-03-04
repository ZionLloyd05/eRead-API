using System.Threading.Tasks;
using AutoMapper;
using Books.API.Dtos.Category;
using Books.API.DTOs.Category;
using Books.ApplicationCore.Entities.BookAggregate;
using Books.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Books.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryController(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
    
        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>All categories with id, name, description and slug fields</returns>
        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepository.ListAllAsync();

            if (categories == null || categories.Count == 0)
                return NotFound();

            return Ok(categories);
        }

        /// <summary>
        /// Get a single category by it's Id
        /// </summary>
        /// <param name="id">The Id of the category you wish to get</param>
        /// <returns>A category with id, name, description and slug</returns>
        // GET api/categories/5
        [HttpGet]
        [Route("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int? id = 0)
        {
            if (id == 0 || id == null)
                return BadRequest();

            var category = await _categoryRepository.GetByIdAsync(id);

            if (category == null)
                return NotFound();

            CategoryForReturnDto categoryForReturn = _mapper.Map<CategoryForReturnDto>(category);

            return Ok(categoryForReturn);
        }

        // POST api/category
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoryForCreationDto category)
        {
            Category categoryEntity = _mapper.Map<Category>(category);

            if (!ModelState.IsValid)
                return BadRequest();

            await _categoryRepository.AddAsync(categoryEntity);

            return CreatedAtRoute("GetCategory",
                new { id = categoryEntity.Id }, categoryEntity);
        }

        // PUT api/category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int? id, [FromBody] CategoryForCreationDto categoryFromUser)
        {
            if (id == null || !ModelState.IsValid)
                return BadRequest();

            var categoryInDb = await _categoryRepository.GetByIdAsync(id);

            if (categoryInDb == null)
                return NotFound();

            categoryInDb.Name = categoryFromUser.Name;
            categoryInDb.Description = categoryFromUser.Description;
            categoryInDb.Slug = categoryFromUser.Slug;

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
