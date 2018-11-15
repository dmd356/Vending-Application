using System;
using System.IO;
namespace VendingMachine
{
    public class UserDB
    {
        
        public User[] stockUsers()
        {
            StreamReader sr = new StreamReader("/Users/devindistelhorst/Projects/VendingMachine/VendingMachine/database.txt");
            int userNum = countUsersInDB();
            String line = sr.ReadLine();
            String[] words = new String[5];
            User[] users = new User[userNum];
            while (line != null)
            {
                if (line.Contains("Table User("))//beginning of the Table 
                {

                    for (int i = 0; i < userNum; i++)
                    {
                        if (!line.Contains(");")) //checks the end of Table
                        {
                            line = sr.ReadLine();
                            line = line.Replace("{", "|").Replace("}", "|");
                            //Console.Write(line);
                            words = line.Split("||");
                            User user = new User(int.Parse(words[1]), words[2], words[3], double.Parse(words[4]));
                            users[i] = user;
                        }
                    }
                }
                line = sr.ReadLine();
            }
            return users;
        }

        public int countUsersInDB() //this method lets the User[] have as many as there are in the DataBase
        {
            StreamReader sr = new StreamReader("/Users/devindistelhorst/Projects/VendingMachine/VendingMachine/database.txt");
            int count = 0;
            String line = sr.ReadLine();
            while (line != null)
            {
                if (line.Contains("Table User("))
                {
                    line = sr.ReadLine();
                    while (line != ");")
                    {
                        count++;
                        line = sr.ReadLine();
                    }
                }
                line = sr.ReadLine();
            }
            return count;
        }
    }
}
