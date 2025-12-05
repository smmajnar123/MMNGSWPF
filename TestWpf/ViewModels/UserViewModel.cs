using MMNGS.DataAccess.Models;
using MMNGS.Services.IServices;
using MMNGS.Services.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestWpf.Helpers;
using TestWpf.Models;

namespace TestWpf.ViewModels
{
    public class UserViewModel
    {
        private readonly IUserService userService;

        public UserViewModel(IUserService userService)
        {
            Users = new ObservableCollection<UserModel>();
            this.userService = userService;
        }

        public ObservableCollection<UserModel> Users { get; }


        public async void LoadUsers()
        {
            try
            {
                var result = await userService.GetUserDetails();

                Users.Clear();

                foreach (var u in result)
                {
                    Users.Add(new UserModel
                    {
                        UserId = u.UserId,
                        AdminId = u.AdminId,
                        Name = u.Name,
                        Email = u.Email,
                        Phone = u.Phone,
                        PasswordHash = u.PasswordHash,
                        Address = u.Address,
                        FatherPhone = u.FatherPhone
                    });
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }
    }
}
