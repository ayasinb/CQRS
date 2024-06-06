namespace CQRS.CQRSDesignPattern.Commands.ProductCommands
{
    public class RemoveProductCommand
    {
        public int ProductId { get; set; }

        public RemoveProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
