using Backend.Contexts;
using Backend.Models.DTO;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;


namespace Backend.Repository

{
    public class ProductRepository
    {

        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        {
            var items = await _context.Products.ToListAsync();

            var products = new List<ProductResponse>();

            foreach (var item in items)
            {

                products.Add(item);

            }
            return products;
        }

        public async Task<ProductResponse> CreateAsync(ProductEntity entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<ProductResponse> GetByIdAsync(string id)
        {

            var products = await _context.Products.ToListAsync();

            var response = products.Where(x => x.Id.ToString().ToLower() == id.ToLower()).FirstOrDefault();

            return response;
        }

        public async Task<IEnumerable<ProductResponse>> GetByTagAsync(string tag)
        {

            var products = await _context.Products.ToListAsync();

            var response = products.Where(x => x.Tag.ToString().ToLower() == tag.ToLower());

            var listan = new List<ProductResponse>();

            foreach (var item in response)
            {
                listan.Add(item);
            }

            return listan;
        }
    }
}
