using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.DAL;
using UserManager.Domain;

namespace UserManager.BLL
{
    public class Manager
    {
        private UserDataManager userDataManager = new UserDataManager();

        // перевірка чи існує користувач за вказаними даними 
        public User GetUser(string login, string password)
        {
            try
            {
                if (this.CheckPolicy(login, password))
                {
                    User user = this.userDataManager.Get(login, password);

                    if (user == null)
                    {
                        throw new Exception("Не вірні дані! Повторіть знову");
                    }
                    else
                    {
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        // метод перевірки на порожні поля
        private bool CheckPolicy(string login, string password)
        {
            if (login == string.Empty && password == string.Empty)
            {
                throw new Exception("Дані не введені!");
            }

            else if (login == string.Empty)
            {
                throw new Exception("Логін не введено!");
            }
            else if (password == string.Empty)
            {
                throw new Exception("Пароль не введено!");
            }

            return true;
        }
    }
}