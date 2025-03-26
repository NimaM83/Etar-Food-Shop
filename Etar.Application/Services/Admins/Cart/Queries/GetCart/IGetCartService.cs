using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Etar.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etar.Application.Services.Admins.Cart.Queries.GetCart
{
    public interface IGetCartService
    {
        Result<List<ResGetCartDto>> Execute (Guid adminId, bool IsFinisheds = false);
    }

    public class GetCartService : IGetCartService
    {
        private readonly IDataBaseContext _context;

        public GetCartService (IDataBaseContext context)
        {
            _context = context;
        }

        public Result<List<ResGetCartDto>> Execute (Guid adminId, bool IsFinisheds = false)
        {
            if(!IsFinisheds)
            {
                var foundedCart = _context.adminCarts.Where(c => c.AdminId == adminId && !c.IsFinished)
                                  .FirstOrDefault();

                if(foundedCart != null)
                {
                    var foundedItems = _context.adminCartItems.Where(i => i.CartId == foundedCart.Id).ToList();
                    List<GetCartItemDto> items = new List<GetCartItemDto>();

                    foreach(var item in foundedItems)
                    {
                        items.Add(new GetCartItemDto()
                        {
                            Id = item.Id,
                            FoodId = item.FoodId,
                            count = item.count,
                            PriceForCount = item.PriceForCount,
                            PriceForOne = item.PriceForOne,
                        });
                    }

                    List<ResGetCartDto> result = new List<ResGetCartDto>();
                    result.Add(new ResGetCartDto()
                    {
                        Id = foundedCart.Id,
                        Items = items,
                        TotalPrice = foundedCart.TotalPrice,
                    });

                    return new Result<List<ResGetCartDto>>()
                    {
                        Data = result,
                        IsSuccess = true,
                        Message = "سبد با موفقیت دریافت شد"
                    };

                }

                return new Result<List<ResGetCartDto>>()
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "سبدی موجود نیست"
                };
            }

            var foundedCarts = _context.adminCarts.Where(c => c.AdminId == adminId && c.IsFinished).ToList();

            if(foundedCarts.Any())
            {
                List<ResGetCartDto> result = new List<ResGetCartDto>();
                List<GetCartItemDto> items = new List<GetCartItemDto>();

                foreach(var cart in foundedCarts)
                {
                    var foundedItems = _context.adminCartItems.Where(i => i.CartId == cart.Id).ToList();
                    foreach(var item in foundedItems)
                    {
                        items.Add(new GetCartItemDto()
                        {
                            Id = item.Id,
                            FoodId = item.FoodId,
                            count = item.count,
                            PriceForCount = item.PriceForCount,
                            PriceForOne = item.PriceForOne,
                        });
                    }

                    result.Add(new ResGetCartDto()
                    {
                        Id = cart.Id,
                        TotalPrice = cart.TotalPrice,
                        Items = items
                    });
                }

                return new Result<List<ResGetCartDto>>()
                {
                    Data = result,
                    IsSuccess = true,
                    Message = "سبد های ثبت شده با موفقیت دریافت شدند"
                };
            }

            return new Result<List<ResGetCartDto>>()
            {
                Data = null,
                IsSuccess = false,
                Message = "سبد ثبت شده ای یافت نشد"
            };
        }
    }
}
