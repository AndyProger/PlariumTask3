using System;
using UserSpace;
using LetterSpace;
using Server;

namespace VariantC
{
    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Andrey", "Syradoev", new DateTime(2001, 12, 31));
            User user2 = new User("Sony", "Podmogilnay", new DateTime(2002, 4, 10));
            User user3 = new User("Ivan", "Ivanov", new DateTime(2005, 2, 3));
            User user4 = new User("Dima", "Pogrib", new DateTime(2000, 9, 17));
                
            Letter letter1 = new Letter("Love", "I love you all!");
            Letter letter2 = new Letter("Love", "выфвфывфывфвфвфывывы");
            Letter letter3 = new Letter("Love", "фывввввввввввввввввввввввв");
            Letter letter4 = new Letter("Love", "вфывфывфывфвфвыфвфвфывфыфывфвфы");

            user1.SendToAll(letter1);

            Console.WriteLine(UsersCollction.GetUsersWithSuchTopic("Love"));
        }
    }
}
