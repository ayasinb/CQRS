using CQRS.CQRSDesignPattern.Results.ProductResults;
using CQRS.DAL.Context;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class GetProductQueryHandler
    {
        private readonly CQRSContext _context;

        public GetProductQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public List<GetProductQueryResult> Handle()
        {
            var values=_context.Products.Select(x=>new GetProductQueryResult()
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductDescription = x.ProductDescription,
                ImageURL = x.ImageURL,
                Price = x.Price,
                Quantity = x.Quantity                
            }).ToList();
            return values;
        }
    }
}
