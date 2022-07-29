using MiniSepetim.Entities.Concrete;
using MiniSepetim.Entities.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSepetim.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IList<CategoryDto>> GetListCategoryDto();
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByName(string categoryName);
        Task<IList<Category>> GetListCategory();
        Task CategoryAdd(CategoryDto categoryDto);
        Task CategoryUpdate(Category category);
        Task CategoryDelete(string name);
    }
}
