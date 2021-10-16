using System;
using UserSpace;
using LetterSpace;
using CollectionOfUsers;

namespace VariantC
{
    class Testing
    {
        static void Main(string[] args)
        {
            User userAndrey = new User("Andrey", "Syradoev", new DateTime(2001, 12, 31));
            User userSony = new User("Sony", "Podmogilnay", new DateTime(2002, 4, 10));
            User userIvan = new User("Ivan", "Ivanov", new DateTime(2005, 2, 3));
            User userDima = new User("Dima", "Pogrib", new DateTime(2000, 9, 17));
            User userRoman = new User("Roman", "Romanov", new DateTime(1989, 7, 1));
                
            Letter letter1 = new Letter("Congratulations", "Happy Birthday!");
            Letter letter2 = new Letter("Work", "When will the report be submitted?");
            Letter letter3 = new Letter("Concert", "Are you going to go to the concert tonight?");
            Letter letter4 = new Letter("Study", "Can you share your homework?");
            Letter letter5 = new Letter("Study", "Link to videoconference");

            userAndrey.SendLetter(userSony, letter1);
            userDima.SendLetter(userIvan, letter2);
            userIvan.SendLetter(userAndrey, letter3);
            userRoman.SendLetter(userDima, letter4);

            // Направить письмо заданного человека с заданной темой всем адресатам.
            userRoman.SendToAll(letter5);

            // Найти пользователя, длина писем которого наименьшая.
            Console.WriteLine(UsersCollection.FindUserWithTheShortesLetter());
            Console.WriteLine(new string('*', 40));
            // Вывести информацию о пользователях, а также количестве полученных и отправленных ими письмах.
            Console.WriteLine(UsersCollection.GetUsersInfo());
            Console.WriteLine(new string('*', 40));
            // Вывести информацию о пользователях, которые получили хотя бы одно сообщение с заданной темой.
            Console.WriteLine(UsersCollection.GetUsersWithSuchTopic("Work"));
            Console.WriteLine(new string('*', 40));
            // Вывести информацию о пользователях, которые не получали сообщения с заданной темой.
            Console.WriteLine(UsersCollection.GetUsersWithoutSuchTopic("Study"));
            Console.WriteLine(new string('*', 40));
        }
    }
}
