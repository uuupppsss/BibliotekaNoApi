using Biblioteka.mvvm.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.mvvm.viewmodel
{
    public class LoginPageVM:BaseVM
    {
        private FakeDB connect;
        private MessagesServise messagesServise;
        public CommandVM LoginCommand {  get; set; }
        public CommandVM RegisterCommand { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public LoginPageVM()
        {
            connect = FakeDB.Instance;
            messagesServise = MessagesServise.Instance;

            RegisterCommand = new CommandVM(async () =>
            {
                await Shell.Current.GoToAsync("RegisterPage");
            });

            LoginCommand = new CommandVM(async () =>
            {
                if (Username == null || Password == null)
                {
                    await messagesServise.ShowWarning("Ошибка", "Заполните все поля");
                }
                else
                {
                    User foundUser=await connect.AuthenticateUserAsync(Username, Password);
                    if (foundUser != null)
                    {
                        connect.CurrentUser = foundUser;
                        await messagesServise.ShowWarning("Успешно",$"Добро пожаловать, {Username}");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        await messagesServise.ShowWarning("Ошибка", "Пользователь не найден");
                    }
                }
            });
        }
    }
}
