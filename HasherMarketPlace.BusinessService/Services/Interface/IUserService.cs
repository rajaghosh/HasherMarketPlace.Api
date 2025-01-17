﻿using HasherMarketPlace.DBHelper.Entities;
using HasherMarketPlace.ModelHelper.DTO;

namespace HasherMarketPlace.BusinessService.Services.Interface
{
    public interface IUserService
    {
        Task<string> IsEmailValidAsync(string email, string password);

        Task<List<UserDto>> GetAllUserNameAsync();
        Task<List<UserMaster>> GetSpecificUserDetailsAsync(List<int> userIds);
        Task<bool> AddToUserAsync(AddUserDto userDto);
        Task<bool> UpdateUserAsync(UpdateUserDto userDto);
        Task<bool> DeleteUserAsync(int userId);
    }
}
