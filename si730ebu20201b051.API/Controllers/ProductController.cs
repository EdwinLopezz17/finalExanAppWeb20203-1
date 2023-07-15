using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using si730ebu20201b051.Domain.Interfaces;
using si730ebu20201b051.Domain.Request;
using si730ebu20201b051.Domain.Response;
using si730ebu20201b051.Infraestructure.Models;

namespace si730ebu20201b051.API.Controllers
{
    [Route("api/v1/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductDomain _productDomain;
        
        public ProductController(IProductDomain productDomain)
        {
            _productDomain = productDomain;
        }

        // GET: api/v1/products/{id}
        [HttpGet("{id}", Name = "Get")]
        public ProductResponse Get(int id)
        {
            return _productDomain.GetById(id);
        }

        // POST: api/v1/products
        [HttpPost]
        public Product Post([FromBody] ProductRequest productRequest)
        {
            return _productDomain.Create(productRequest);
        }
    }
}
