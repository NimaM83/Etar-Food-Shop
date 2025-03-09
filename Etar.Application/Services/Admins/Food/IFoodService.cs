using Etar.Application.Interfaces.Context;
using Etar.Application.Services.Admins.Food.Commands.AddCategory;
using Etar.Application.Services.Admins.Food.Commands.AddFood;
using Etar.Application.Services.Admins.Food.Commands.RemoveCategoory;
using Etar.Application.Services.Admins.Food.Commands.RemoveFood;
using Etar.Application.Services.Admins.Food.Commands.ResetInventory;
using Etar.Application.Services.Admins.Food.Commands.UpdateCategory;
using Etar.Application.Services.Admins.Food.Commands.UpdateFood;
using Etar.Application.Services.Admins.Food.Commands.UpdateInvenroy;
using Etar.Application.Services.Admins.Food.Queries.GetCategories;
using Etar.Application.Services.Admins.Food.Queries.GetFoodDetail;
using Etar.Application.Services.Admins.Food.Queries.GetFoods;


namespace Etar.Application.Services.Admins.Food
{
    public interface IFoodService
    {
        IAddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        IRemoveCategoryService RemoveCategoryService { get; }
        IUpdateCategoryService UpdateCategoryService { get; }

        IGetFoodsService GetFoodsService { get; }
        IAddFoodService AddFoodService { get; }
        IRemoveFoodService RemoveFoodService { get; }
        IGetFoodDetaisService GetFoodDetaisService { get; }
        IUpdateFoodService UpdateFoodService { get; }

        IUpdateInventoryService UpdateInventoryService { get; }
        IResetInventoryService ResetInventoryService { get; }
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

        private IGetFoodsService _getfoods;
        public IGetFoodsService GetFoodsService
        {
            get
            {
                return _getfoods = _getfoods ?? new GetFoodsService(_context);
            }
        }

        private IAddFoodService _addFood;
        public IAddFoodService AddFoodService
        {
            get
            {
                return _addFood = _addFood ?? new AddFoodService(_context);
            }
        }

        private IRemoveFoodService _removeFood;
        public IRemoveFoodService RemoveFoodService
        {
            get
            {
                return _removeFood = _removeFood ?? new RemoveFoodService(_context);
            }
        }

        private IGetFoodDetaisService _getfoodDetais;
        public IGetFoodDetaisService GetFoodDetaisService
        {
            get
            {
                return _getfoodDetais = _getfoodDetais ?? new GetFoodDetailsService(_context);
            }
        }

        private IUpdateFoodService _updatefood;
        public IUpdateFoodService UpdateFoodService
        {
            get
            {
                return _updatefood = _updatefood ?? new UpdateFoodService(_context);
            }
        }

        private IUpdateInventoryService _updateinventory;
        public IUpdateInventoryService UpdateInventoryService
        {
            get
            {
                return _updateinventory = _updateinventory ?? new UpdateInventoryService(_context);
            }
        }

        private IResetInventoryService _resetinventory;
        public IResetInventoryService ResetInventoryService
        {
            get
            {
                return _resetinventory = _resetinventory ?? new ResetInventoryService(_context);
            }
        }
    }
}
