using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetterSpace;
using UserSpace;

namespace CollectionOfUsers
{
    static class UsersCollection
    {
        public static List<User> _users = new List<User>();
        public static List<User> Users
        {
            get => new List<User>(_users);
        }

        public static void AddUser(User user)
        {
            if (!Users.Contains(user))
            {
                _users.Add(user);
            }
            else
            {
                throw new ArgumentException("User already added");
            }
        }

        // пользователь с самым коротким письмом
        public static User FindUserWithTheShortesLetter()
        {
            var minLength = int.MaxValue;
            User soughtUser = null;

            foreach(User user in _users)
            {
                List<Letter> letters = user.Letters;

                foreach(Letter letter in letters)
                {
                    if(letter.Text.Length < minLength)
                    {
                        minLength = letter.Text.Length;
                        soughtUser = user; 
                    }
                }
            }

            return soughtUser;
        }

        // информация о пользователях и их количестве полученных / отправленных писем
        public static string GetUsersInfo()
        {
            StringBuilder info = new StringBuilder();

            foreach(User user in _users)
            {
                info.Append(user + $"Sent letters: {user.LettersSent}\nReceived letters: {user.LettersReceived}\n\n");
            }

            return info.ToString();
        }

        // информация о пользователях, которые получили хотя бы одно сообщение с заданной темой
        public static string GetUsersWithSuchTopic(string topic)
        {
            StringBuilder info = new StringBuilder();

            foreach (User user in _users)
            {
                List<Letter> letters = user.Letters;

                foreach (Letter letter in letters)
                {
                    if (letter.Topic == topic)
                    {
                        info.Append(user + "\n");
                    }
                }
            }

            return info.ToString();
        }

        // информация о пользователях, которые не получали сообщения с заданной темой.
        public static string GetUsersWithoutSuchTopic(string topic)
        {
            StringBuilder info = new StringBuilder();
            bool hasSuchTopic;

            foreach (User user in _users)
            {
                List<Letter> letters = user.Letters;
                hasSuchTopic = false;

                if (!letters.Any())
                {
                    info.Append(user + "\n");
                    break;
                }

                foreach (Letter letter in letters)
                {
                    if (letter.Topic == topic)
                    {
                        hasSuchTopic = true;
                    }
                }

                if(!hasSuchTopic)
                    info.Append(user + "\n");
            }

            return info.ToString();
        }

    }
}
