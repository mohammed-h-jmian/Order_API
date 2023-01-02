﻿using Microsoft.AspNetCore.Mvc;
using Order.Core.Dtos;
using Order.Core.ViewModels;
using Order.Infrastructure.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
   
    public class CategoryController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult GetAll(string serachkey)
        {
           var categories = _categoryService.GetAll(serachkey);
            return Ok(GetResponse(categories));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var category = _categoryService.Get(id);
            return Ok(GetResponse(category));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateCategoryDto dto)
        {
            var savedId = await _categoryService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var savedId = _categoryService.Update(dto);
            return Ok(GetResponse(savedId));
        }
        
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedId = _categoryService.Delete(id);       
            return Ok(GetResponse(deletedId));
        }

    }
}
