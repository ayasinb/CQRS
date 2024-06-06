using CQRS.CQRSDesignPattern.Commands.CategoryCommands;
using CQRS.DAL.Context;
using CQRS.DAL.Entities;

namespace CQRS.CQRSDesignPattern.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly CQRSContext _context;

        public CreateCategoryCommandHandler(CQRSContext context)
        {
            _context = context;
        }
        public void Handle(CreateCategoryCommand command)
        {
            _context.Categories.Add(new Category()
            {
                CategoryName = command.CategoryName
            });
            _context.SaveChanges();
        }
    }
}
