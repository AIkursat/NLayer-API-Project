using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Service;
using NLayerProject.Web.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace NLayerProject.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

       public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
                _categoryService = categoryService;
                _mapper = mapper; 
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();


            return View(_mapper.Map<IEnumerable<CategoryDto>>(categories));
        }
    }
}
