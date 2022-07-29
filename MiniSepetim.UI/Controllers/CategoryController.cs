using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSepetim.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categoryDtoList = await _categoryService.GetListCategoryDto();

            return View(categoryDtoList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.CategoryAdd(categoryDto);
                return RedirectToAction("Index");
            }
            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string categoryName)
        {
            var categoryDto = (await _categoryService.GetListCategoryDto()).SingleOrDefault(x => x.Name == categoryName);
            categoryDto.UniqueName = categoryDto.Name;
            return View(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            
            var category = await _categoryService.GetCategoryByName(categoryDto.UniqueName);
            if (ModelState.IsValid)
            {
                if (category != null)
                {

                    category.State = categoryDto.State;
                    category.Name = categoryDto.Name;
                    await _categoryService.CategoryUpdate(category);
                    return RedirectToAction("Index");
                }

            }
            return RedirectToAction("Update", categoryDto);
        }

        [HttpGet]
        public async Task< IActionResult> Delete(string uniqueName)
        {
            await _categoryService.CategoryDelete(uniqueName);
            return RedirectToAction("Index");
           
        }

    }
}
