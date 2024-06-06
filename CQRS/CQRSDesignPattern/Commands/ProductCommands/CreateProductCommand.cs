﻿namespace CQRS.CQRSDesignPattern.Commands.ProductCommands
{
    public class CreateProductCommand
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
