using Etar.Application.Interfaces.Context;
using Etar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Etar.Application.Services.Owners.Order.Queries.GetOrders
{
    public class GetOrdersService : IGetOrdersService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersService(IDataBaseContext context)
        {
            _context = context;
        }

        public Result<ResGetOrdersDto> Execute(GetOrdersBy orderBy, string? adminName = null)
        {
            switch (orderBy)
            {
                case GetOrdersBy.All:
                    return GetAll();

                case GetOrdersBy.Admin:
                    return GetByAdmin(_context.admins.Where(a => a.UserName.Equals(adminName))
                                      .FirstOrDefault().Id);

                case GetOrdersBy.Day:
                    return GetByDay();

                case GetOrdersBy.Month:
                    return GetByMonth();

                case GetOrdersBy.Year:
                    return GetByYear();
            }

            return new Result<ResGetOrdersDto>()
            {
                IsSuccess = false,
                Message = "Bad Request"
            };
        }

        private Result<ResGetOrdersDto> GetAll()
        {
            var foundedOrders = _context.adminOrders.Include(o => o.Cart)
                                .ThenInclude(c => c.Admin).ToList();

            if(foundedOrders.Any())
            {
                List<GetOrderItemsDto> items = new List<GetOrderItemsDto>();
                double Price = 0;

                foreach (var item in foundedOrders)
                {
                    items.Add(new GetOrderItemsDto()
                    {
                        AdminName = item.Cart.Admin.UserName,
                        Id = item.Id,
                        RegisterTime = item.RegisterTime.ToLongDateString() + " / "
                                       + item.RegisterTime.ToShortTimeString(),
                        TotalPrice = item.TotalPrice,
                    });

                    Price += item.TotalPrice;
                }

                return new Result<ResGetOrdersDto>()
                {
                    Data = new ResGetOrdersDto()
                    {
                        FiltredBy = "تمام سفارشات",
                        PriceByFilter = Price,
                        Items = items
                    },

                    IsSuccess = true,
                    Message = "سفارشات دریافت شدند"
                };
            }

            return new Result<ResGetOrdersDto>()
            {
                Data = null,
                IsSuccess = false,
                Message = "تا به حال سفارشی در رستوران ثبت نشده است"
            };

        }

        private Result<ResGetOrdersDto> GetByAdmin(Guid adminId)
        {
            var foundedOrders = _context.adminOrders.Include(o => o.Cart)
                                .Where(o => o.Cart.AdminId == adminId)
                                .Include(o => o.Cart.Admin)
                                .ToList();

            if(foundedOrders.Any())
            {
                List<GetOrderItemsDto> items = new List<GetOrderItemsDto>();
                double Price = 0;

                foreach(var item in foundedOrders)
                {
                    items.Add(new GetOrderItemsDto()
                    {
                        AdminName = item.Cart.Admin.UserName,
                        Id = item.Id,
                        RegisterTime = item.RegisterTime.ToLongDateString() + " / "
                                       + item.RegisterTime.ToShortTimeString(),
                        TotalPrice = item.TotalPrice,
                    });

                    Price += item.TotalPrice;
                }

                return new Result<ResGetOrdersDto>()
                {
                    Data = new ResGetOrdersDto()
                    {
                        FiltredBy = $"سفارشات : {foundedOrders.First().Cart.Admin.UserName}",
                        PriceByFilter = Price,
                        Items = items
                    },

                    IsSuccess = true,
                    Message = "سفارشات دریافت شدند"
                };
            }

            return new Result<ResGetOrdersDto>()
            {
                IsSuccess = false,
                Message = "این ادمین تا به حال سفارشی ثبت نکرده است"
            };
        }

        private Result<ResGetOrdersDto> GetByDay()
        {
            var foundedOrders = _context.adminOrders.Where(o => (o.RegisterTime.Year == DateTime.Now.Year) &&
                                                                (o.RegisterTime.Month == DateTime.Now.Month) &&
                                                                (o.RegisterTime.Day == DateTime.Now.Day))
                                .Include(o => o.Cart)
                                .ThenInclude(c => c.Admin)
                                .ToList();

            if(foundedOrders.Any())
            {
                List<GetOrderItemsDto> items = new List<GetOrderItemsDto>();
                double Price = 0;

                foreach (var item in foundedOrders)
                {
                    items.Add(new GetOrderItemsDto()
                    {
                        AdminName = item.Cart.Admin.UserName,
                        Id = item.Id,
                        RegisterTime = item.RegisterTime.ToLongDateString() + " / "
                                       + item.RegisterTime.ToShortTimeString(),
                        TotalPrice = item.TotalPrice,
                    });

                    Price += item.TotalPrice;
                }

                return new Result<ResGetOrdersDto>()
                {
                    Data = new ResGetOrdersDto()
                    {
                        FiltredBy = "سفارشات امروز",
                        PriceByFilter = Price,
                        Items = items
                    },

                    IsSuccess = true,
                    Message = "سفارشات دریافت شدند"
                };
            }

            return new Result<ResGetOrdersDto>()
            {
                IsSuccess = false,
                Message = "امروز سفارشی ثبت نشده است"
            };
        }
        private Result<ResGetOrdersDto> GetByMonth()
        {
            var foundedOrders = _context.adminOrders.Where(o => (o.RegisterTime.Year == DateTime.Now.Year) &&
                                                                (o.RegisterTime.Month == DateTime.Now.Month))                              
                                .Include(o => o.Cart)
                                .ThenInclude(c => c.Admin)
                                .ToList();

            if (foundedOrders.Any())
            {
                List<GetOrderItemsDto> items = new List<GetOrderItemsDto>();
                double Price = 0;

                foreach (var item in foundedOrders)
                {
                    items.Add(new GetOrderItemsDto()
                    {
                        AdminName = item.Cart.Admin.UserName,
                        Id = item.Id,
                        RegisterTime = item.RegisterTime.ToLongDateString() + " / "
                                       + item.RegisterTime.ToShortTimeString(),
                        TotalPrice = item.TotalPrice,
                    });

                    Price += item.TotalPrice;
                }

                return new Result<ResGetOrdersDto>()
                {
                    Data = new ResGetOrdersDto()
                    {
                        FiltredBy = "سفارشات این ماه",
                        PriceByFilter = Price,
                        Items = items
                    },

                    IsSuccess = true,
                    Message = "سفارشات دریافت شدند"
                };
            }

            return new Result<ResGetOrdersDto>()
            {
                IsSuccess = false,
                Message = "این ماه سفارشی ثبت نشده است"
            };
        }
        private Result<ResGetOrdersDto> GetByYear()
        {
            var foundedOrders = _context.adminOrders.Where(o => (o.RegisterTime.Year == DateTime.Now.Year))
                                .Include(o => o.Cart)
                                .ThenInclude(c => c.Admin)
                                .ToList();

            if (foundedOrders.Any())
            {
                List<GetOrderItemsDto> items = new List<GetOrderItemsDto>();
                double Price = 0;

                foreach (var item in foundedOrders)
                {
                    items.Add(new GetOrderItemsDto()
                    {
                        AdminName = item.Cart.Admin.UserName,
                        Id = item.Id,
                        RegisterTime = item.RegisterTime.ToLongDateString() + " / "
                                       + item.RegisterTime.ToShortTimeString(),
                        TotalPrice = item.TotalPrice,
                    });

                    Price += item.TotalPrice;
                }

                return new Result<ResGetOrdersDto>()
                {
                    Data = new ResGetOrdersDto()
                    {
                        FiltredBy = "سفارشات امسال",
                        PriceByFilter = Price,
                        Items = items
                    },

                    IsSuccess = true,
                    Message = "سفارشات دریافت شدند"
                };
            }

            return new Result<ResGetOrdersDto>()
            {
                IsSuccess = false,
                Message = "امسال سفارشی ثبت نشده است"
            };
        }
    }
}
