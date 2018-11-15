using System;
using System.IO;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ItemDB ic = new ItemDB();
            UserDB userDB = new UserDB();
            Item[] stockedItems;
            User[] users;
            Menu menu = new Menu();
            users = userDB.stockUsers();
            stockedItems = ic.StockItems();
            menu.startMenu(stockedItems, users);

        }
    }
}
