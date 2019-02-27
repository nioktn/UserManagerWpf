using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain;

namespace UserManager.DAL
{
    public class UserDataManager
    {
        // список класу User для збереження даних про користувача
        private readonly List<User> userCollection = new List<User>();

        public UserDataManager()
        {
            this.LoadFromFile("userlist.txt");
        }

        // метод для считування користувачів з файлу
        public List<User> LoadFromFile(string cFile)
        {
            StreamReader streamReader = new StreamReader(cFile);
            string line;
            // Читання і відображення рядка з файлу, поки кінець файлу досягнутий.
            while ((line = streamReader.ReadLine()) != null)
            {
                this.userCollection.Add(this.GetFromLine(line));
            }
            streamReader.Close();
            return this.userCollection;
        }

        // метод повертає колекцію користувачів
        public List<User> GetAll()
        {
            return this.userCollection;
        }

        // пошук користувача за логіном і паролем
        public User Get(string login, string password)
        {
            foreach (User user in this.userCollection)
            {
                if (user.Login.Equals(login) && user.Password.Equals(password))
                    return user;
            }

            return null;
        }

        // перетворення рядку в інформацію про користувача
        private User GetFromLine(string line)
        {
            string[] tokens = line.Split(new char[] { ';' });

            if (tokens.Length != 5)
            {
                throw new ApplicationException(
                     String.Format("Формат вводу користувальницьких файлів. " +
                    "Очікувана довжина рядка в файлі {0}; отримана довжина {1}", 5,
                     tokens.Length));
            }
            User user = new User();
            user.Name = tokens[0];
            user.LastName = tokens[1];
            user.Login = tokens[2];
            user.Password = tokens[3];
            user.Active = Convert.ToInt32(tokens[4]);
            return user;
        }
    }
}