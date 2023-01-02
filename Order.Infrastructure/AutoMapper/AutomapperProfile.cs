using AutoMapper;
using Order.Core.Dtos;
using Order.Core.ViewModels;
using Order.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.AutoMapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();

            CreateMap<User, UserViewModel>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();

        }

    }
}
