using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shopp.ProductAPI.Context;
using Shopp.ProductAPI.Data.ValueObjects;
using Shopp.ProductAPI.Model;

namespace Shopp.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySQLContex _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContex context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<ProductVO> Create(ProductVO product)
        {
            Product eProduct = _mapper.Map<Product>(product);
            _context.Products.Add(eProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO product)
        {
            Product eProduct = _mapper.Map<Product>(product);
            _context.Products.Update(eProduct);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
        public async Task<bool> Delete(long id)
        {
            try
            {
                Product product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync() ?? new Product();
                if(product.Id <= 0)
                    return false;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
