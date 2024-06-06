using CQRS.CQRSDesignPattern.Queries.ProductQueries;
using CQRS.CQRSDesignPattern.Results.ProductResults;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler
    {
        private readonly CQRSContext _context;

        public GetProductByIdQueryHandler(CQRSContext context)
        {
            _context = context;
        }
        public GetProductByIdQueryResult Handle(GetProductByIdQuery query)
        {
            var value= _context.Products.Find(query.ProductId);
            return new GetProductByIdQueryResult
            {
                ProductId = value.ProductId,
                CategoryId = value.CategoryId,
                ProductDescription = value.ProductDescription,
                ProductName = value.ProductName,
                Price = value.Price,
                Quantity = value.Quantity,
                ImageURL = value.ImageURL
            };
        }
    }
}
