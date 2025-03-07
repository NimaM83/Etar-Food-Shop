using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Admins.Food.Commands.AddCategory;
using Etar.Application.Services.Admins.Food.Commands.RemoveCategoory;
using Etar.Application.Services.Admins.Food.Commands.UpdateCategory;
using Etar.Application.Services.Admins.Food.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Food
{
    public interface IFoodService
    {
        IAddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        IRemoveCategoryService RemoveCategoryService { get; }
        IUpdateCategoryService UpdateCategoryService { get; }
    }

    public class FoodService : IFoodService
    {
        private readonly IDataBaseContext _context;
        public FoodService(IDataBaseContext context)
        {
            _context = context;
        }

        private IAddNewCategoryService _addCategory;
        public IAddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addCategory = _addCategory ?? new AddNewCategoryService(_context);
            }
        }

        private IGetCategoriesService _getcategories;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getcategories = _getcategories ?? new GetCategoriesService(_context);
            }
        }

        private  IRemoveCategoryService _removeCategory;
        public IRemoveCategoryService RemoveCategoryService
        {
            get 
            {
                return _removeCategory = _removeCategory ?? new RemoveCategoryService(_context);
            }
        }

        private IUpdateCategoryService _updateCategory;
        public IUpdateCategoryService UpdateCategoryService
        {
            get
            {
                return _updateCategory =  _updateCategory ?? new UpdateCategoryService(_context);
            }
        }
    }
}
