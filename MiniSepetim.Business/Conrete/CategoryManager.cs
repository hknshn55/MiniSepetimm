using AutoMapper;
using FluentValidation.Results;
using MiniSepetim.Business.Abstract;
using MiniSepetim.Business.ValidationRules.FluentValidation;
using MiniSepetim.DataAccess.Abstract;
using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Conrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        CategoryValidator rule = new CategoryValidator();
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _mapper = mapper;
            _categoryDal = categoryDal;
        }
        
        public ValidationResult Validator(Category category)
        {
          return   rule.Validate(category);
        }
        public async Task CategoryAdd(CategoryDto categoryDto)
        {
            Category newCategory = _mapper.Map<Category>(categoryDto);

            var result = Validator(newCategory);
            if (result.IsValid)
            {
                Category category = await GetCategoryByName(categoryDto.Name);
                if (category is null)
                {
                    await _categoryDal.Add(newCategory);
                    return;
                }
                category.State = true;
                await CategoryUpdate(category);
            }
        }
        public async Task CategoryDelete(string name)
        {
            var category = await GetCategoryByName(name);
           
            if (category !=null)
            {
                category.State = false;
                await _categoryDal.Update(category);
            }
        }
        public async Task CategoryUpdate(Category category)
        {
            var result = Validator(category);
            if (result.IsValid)
            {
                await _categoryDal.Update(category);
            }
            
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _categoryDal.Get(x=>x.Id == id);
        }

        public async Task<Category> GetCategoryByName(string categoryName)
        {
            return (await GetListCategory()).FirstOrDefault(x=>x.Name == categoryName);
        }

        public async Task<IList<Category>> GetListCategory()
        {
            return (await _categoryDal.GetList()).Where(x=>x.State == true).ToList();
        }
        public async Task<IList<CategoryDto>> GetListCategoryDto()
        {
            var categoryList = await GetListCategory();
            List<CategoryDto> categoryDtoList = new List<CategoryDto>();
            foreach (var item in categoryList)
            {
                if (item.State)
                {
                    categoryDtoList.Add(new CategoryDto { UniqueName=item.Name, Name = item.Name, CreateDate = item.CreateDate, State = item.State });
                }
            }
            return categoryDtoList;
        }
    }
}
