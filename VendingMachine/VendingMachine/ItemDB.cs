using System;
using System.IO;
namespace VendingMachine
{
    public class ItemDB//This class reads from the database under Table Item and creates a model for each item
                       //which is then stored in an array Item items[] = StockItems(sr)
    {
        public Item[] StockItems()
        {
            StreamReader sr = new StreamReader("/Users/devindistelhorst/Projects/VendingMachine/VendingMachine/database.txt");
            int itemNum = countItemsInDB();
            String[] words = new String[5];
            Item[] items = new Item[itemNum];
            String line = sr.ReadLine();
            while (line!=null)
            {
                if (line.Contains("Table Item("))//beginning of the Table 
                {
                    for (int i = 0; i < itemNum; i++)
                    {
                        if (!line.Contains(");")) //checks the end of Table
                        {
                            line = sr.ReadLine();
                            line = line.Replace("{", "|").Replace("}", "|");
                            //Console.Write(line);
                            words = line.Split("||");
                            Item item = new Item(int.Parse(words[1]), words[2], Double.Parse(words[3]), int.Parse(words[4]));
                            items[i] = item;
                        }
                    }
                }
                line = sr.ReadLine();
            }
            return items;
        }

        public int countItemsInDB() //this method lets the Items[] have as many as there are in the DataBase
        {
            StreamReader  sr = new StreamReader("/Users/devindistelhorst/Projects/VendingMachine/VendingMachine/database.txt");
            int count = 0;
            String line = sr.ReadLine();
            while (line != null)
            {
                if (line.Contains("Table Item("))
                {
                    line = sr.ReadLine();
                    while(line!=");"){
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
    