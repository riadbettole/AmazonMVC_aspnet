using AmazonMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AmazonMVC.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Genre>> Genres()
        {
            return await _db.Genres.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetProducts(string sTerm = "", int genreId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Product> products = await (from product in _db.Products
                         join genre in _db.Genres
                         on product.GenreId equals genre.Id
                         where string.IsNullOrWhiteSpace(sTerm) || (product != null && product.Name.ToLower().StartsWith(sTerm))
                         select new Product
                         {
                             Id = product.Id,
                             Image = product.Image,
                             Name = product.Name,
                             GenreId = product.GenreId,
                             Price = product.Price,
                             GenreName = genre.Name
                         }
                         ).ToListAsync();
            if (genreId > 0)
            {

                products = products.Where(a => a.GenreId == genreId).ToList();
            }
            return products;

        }
    }
}
