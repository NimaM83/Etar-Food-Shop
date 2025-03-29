using Etar.Application.Interfaces.Context;
using Etar.Application.Interfaces.Services.Admin;
using Etar.Application.Services.Admins.Cart.Commands.AddItem;
using Etar.Application.Services.Admins.Cart.Commands.ConfirmCart;
using Etar.Application.Services.Admins.Cart.Commands.RemoveItem;
using Etar.Application.Services.Admins.Cart.Queries.GetCart;
using Etar.Application.Services.Admins.Cart.Queries.GetCartDetails;
using Etar.Application.Services.Admins.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Cart
{
    public interface ICartService
    {
        IAddItemService AddItemService { get; }
        IRemoveItemService RemoveItemService { get; }
        IGetCartService GetCartService { get; }
        IConfirmCartService ConfirmCartService { get; }
        IGetCartDetailsService GetCartDetailsService { get; }
    }

    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        private readonly IOrderService _orderServices;

        public CartService (IDataBaseContext context, IOrderService orderServices)
        {
            _orderServices = orderServices;
            _context = context;
        }

        private IAddItemService _addItem;
        public IAddItemService AddItemService
        {
            get
            {
                return _addItem = _addItem ?? new AddItemService(_context);
            }
        }

        private IRemoveItemService _removeItem;
        public IRemoveItemService RemoveItemService
        {
            get
            {
                return _removeItem = _removeItem ?? new RemoveItemService(_context);
            }
        }

        private IGetCartService _getCart;
        public IGetCartService GetCartService
        {
            get
            {
                return _getCart = _getCart ?? new GetCartService(_context);
            }
        }

        private IConfirmCartService _confirmCart;
        public IConfirmCartService ConfirmCartService
        {
            get
            {
                return _confirmCart = _confirmCart ?? new ConfirmCartService(_context,_orderServices);
            }
        }

        private IGetCartDetailsService _getCartDetails;
        public IGetCartDetailsService GetCartDetailsService
        {
            get
            {
                return _getCartDetails = _getCartDetails ?? new GetCartDetailsService(_context);
            }
        }
    }
}
