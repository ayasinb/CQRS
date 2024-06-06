using CQRS.CQRSDesignPattern.Commands.ProductCommands;
using CQRS.DAL.Context;

namespace CQRS.CQRSDesignPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler
    {
        private readonly CQRSContext _context;

        public UpdateProductCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(UpdateProductCommand command) 
        { 
            var value=_context.Products.Find(command.ProductId);
            value.ProductName = command.ProductName;
            value.ProductDescription = command.ProductDescription;
            value.Price = command.Price;
            value.Quantity = command.Quantity;
            value.ImageURL = command.ImageURL;
            value.CategoryId = command.CategoryId;
            _context.SaveChanges();
        }
    }
}
