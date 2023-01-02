﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Order.API.Data;
using Order.Core.Dtos;
using Order.Core.ViewModels;
using Order.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly OrderDbContext _db;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserService(OrderDbContext db, IMapper mapper, UserManager<User> userManager)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<UserViewModel>> GetAll(string serachKey)
        {
            var users = _db.Users.Where(x => x.FullName.Contains(serachKey) || x.PhoneNumber.Contains(serachKey) || string.IsNullOrWhiteSpace(serachKey)).ToList();
            return  _mapper.Map<List<UserViewModel>>(users);
        }

        public async Task<string> Create(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.PhoneNumber;
            await  _userManager.CreateAsync(user, dto.Password);
            return user.Id;
        }

        public async Task<string> Update(UpdateUserDto dto)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == dto.Id);
            if (user == null)
            {
                //throw 
            }
            var updatedUser = _mapper.Map(dto, user);
            _db.Users.Update(updatedUser);
            _db.SaveChanges();
            return user.Id;
        }

        public async Task<string> Delete(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                //throw 
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            _db.SaveChanges();
            return user.Id;
        }

        public async Task<UserViewModel> Get(string id)
        {
            var user = _db.Users.SingleOrDefault(x => x.Id == id);
            if (user == null)
            {
                //throw 
            }
            return _mapper.Map<UserViewModel>(user);
        }




    }
}
