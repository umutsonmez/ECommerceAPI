﻿using ECommerceAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task Get()
        {
           await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id=Guid.NewGuid(),Name="Product 1",Price=100, CreatedDate=DateTime.Now,Stock=10},
                new(){Id=Guid.NewGuid(),Name="Product 2",Price=200, CreatedDate=DateTime.Now,Stock=12},
                new(){Id=Guid.NewGuid(),Name="Product 3",Price=300, CreatedDate=DateTime.Now,Stock=8},
            });
           var count= await _productWriteRepository.SaveAsync();
        }
    }
}
