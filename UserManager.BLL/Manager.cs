using System;
using System.Collections.Generic;
using System.IO;
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

        // додавання нового користувача
        public void AddUser(User user)
        {
            if (Check(user))
            {
                this.userDataManager.Add(user);
                StreamWriter streamWriter = new StreamWriter("userlist.txt", true);
                streamWriter.WriteLine();
                streamWriter.Write(getUser(user));
                streamWriter.Close();
            }
            else
                throw new Exception("Такий користувач існує!");
        }

        // перевірка чи існує користувач
        private bool Check(User us)
        {
            bool ret = true;
            foreach (User user in this.userDataManager.GetAll())
            {
                if (us.Name.Equals(user.Name) && us.LastName.Equals(user.LastName) && us.Login.Equals(user.Login) &&
                    us.Password.Equals(user.Password) && us.Active.Equals(user.Active))
                    ret = false;
            }
            if (ret)
                return true;
            else
                return false;
        }

        // переведення типу User в рядок для запису в файл
        private string getUser(User us)
        {
            string user = us.Name + ";" + us.LastName + ";" + us.Login + ";" + us.Password + ";" + us.Active;
            return user;
        }

        // повертає користувача по індексу
        public User getUserFromSelectedIndex(int index)
        {
            User[] user = this.userDataManager.getUserArray();
            return user[index];
        }

        // зміна даних користувача
        public void ChangeUser(User user, int index)
        {
            User change = getUserFromSelectedIndex(index);
            foreach (User us in this.userDataManager.GetAll())
            {
                if (us.Equals(change))
                {
                    us.Name = user.Name;
                    us.LastName = user.LastName;
                    us.Login = user.Login;
                    us.Password = user.Password;
                    us.Active = user.Active;
                }
            }
            StreamWriter streamWriter = new StreamWriter("userlist.txt", false);
            int i = 0;
            foreach (User us in this.userDataManager.GetAll())
            {
                i++;
                streamWriter.Write(getUser(us));
                if (i < this.userDataManager.getSize())
                    streamWriter.WriteLine();
            }
            streamWriter.Close();
        }

    }
}