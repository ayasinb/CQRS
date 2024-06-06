﻿using CQRS.CQRSDesignPattern.Commands.CategoryCommands;
using CQRS.CQRSDesignPattern.Commands.ProductCommands;
using CQRS.CQRSDesignPattern.Handlers.CategoryHandlers;
using CQRS.CQRSDesignPattern.Handlers.ProductHandlers;
using CQRS.CQRSDesignPattern.Queries.CategoryQueries;
using CQRS.CQRSDesignPattern.Queries.ProductQueries;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly UpdateProductCommandHandler _updateProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIdQueryHandler _getProductByIdQueryHandler;

        public ProductController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, UpdateProductCommandHandler updateProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIdQueryHandler getProductByIdQueryHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _updateProductCommandHandler = updateProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIdQueryHandler = getProductByIdQueryHandler;
        }

        public IActionResult ProductList()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }
        public IActionResult RemoveProduct(int id)
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value = _getProductByIdQueryHandler.Handle(new GetProductByIdQuery(id));
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(UpdateProductCommand command)
        {
            _updateProductCommandHandler.Handle(command);
            return RedirectToAction("ProductList");
        }
    }
}
