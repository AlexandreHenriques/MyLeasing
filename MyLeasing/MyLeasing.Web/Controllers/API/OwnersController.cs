﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLeasing.Web.Data;

namespace MyLeasing.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : Controller
    {

        private readonly IOwnerRepository _productRepository;

        public OwnersController(IOwnerRepository ownerRepository) 
        {

            _productRepository = ownerRepository;

        }

        [HttpGet]
        public IActionResult GetOwners() 
        { 
        return Ok(_productRepository.GetAll());
        }
    }
}