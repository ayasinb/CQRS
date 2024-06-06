using CQRS.CQRSDesignPattern.Commands.ProductCommands;
using CQRS.DAL.Context;
using CQRS.DAL.Entities;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler
    {
        private readonly CQRSContext _context;

        public CreateProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                CategoryId = command.CategoryId,
                ProductDescription = command.ProductDescription,
                ProductName = command.ProductName,
                ImageURL = command.ImageURL,
                Price = command.Price,
                Quantity = command.Quantity
            });
            _context.SaveChanges();
        }
    }
}
