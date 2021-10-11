using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LetterSpace;
using Server;

namespace UserSpace
{
    class User
    {
        // У каждого пользователья генерируется уникальный id
        public string ID { get; private set; } = Guid.NewGuid().ToString();
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime Birthdate { get; private set; }
        public int LettersSent { get; private set; }
        public int LettersReceived { get => _letters.Count; }

        // В списке храним письма, которые получил юзер
        private List<Letter> _letters = new List<Letter>();
        public List<Letter> Letters
        {
            get => new List<Letter>(_letters);

            private set => _letters = value;
        }

        private User(string name, string surname)
        {
            if(IsNameValid(name) && IsNameValid(surname))
            {
                Name = Regex.Replace(name.Trim(), "\\s+", " ");
                Surname = Regex.Replace(surname.Trim(), "\\s+", " ");
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public User(string name, string surname, DateTime birthdate) : this(name, surname)
        {
            if(birthdate > new DateTime(1900,1,1) && birthdate < DateTime.Now)
            {
                Birthdate = birthdate;
                UsersCollction.AddUser(this);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public User(User other)
        {
            Name = other.Name;
            Surname = other.Surname;
            Birthdate = other.Birthdate;
        }

        public void SendLetter(User reciper, Letter letter)
        {
            Letter copyLetter = new Letter(letter);
            copyLetter.Sender = this;
            copyLetter.Recipient = reciper;
            copyLetter.SendingDate = DateTime.Now;
            reciper._letters.Add(copyLetter);
            LettersSent++;
        }

        public void SendToAll(Letter letter)
        {
            List<User> users = UsersCollction.Users;
            users.Remove(this);

            foreach(User user in users)
            {
                this.SendLetter(user, letter);
            }
        }

        public override string ToString()
        {
            return $"ID: {ID} \nName: {Name} \nSurname: {Surname} \nBirthdate: {Birthdate} \n";
        }

        private bool IsNameValid(string name) => !string.IsNullOrEmpty(name) && Regex.IsMatch(name, @"^[a-zA-Z ]+$");
    }
}
