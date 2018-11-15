using System;
namespace VendingMachine
{
    
    public class Menu
    {
        User currentUser;



        public void startMenu(Item[] items, User[] users)
        {
            bool usingMenu = true;
            while (usingMenu)
            {
                currentUser = null;
                Console.WriteLine("Welcome to Umbrella Vending!");
                Console.WriteLine("Would you like to make a");
                Console.WriteLine(" 1). Purchase or 2). Look at Items?");
                Console.WriteLine(" 3). Returning User");
                int userOpt = getIntInput(1, 3,"=>");
                if (userOpt == 1)
                {
                    insertMoneyMenu(items);
                }
                else if (userOpt == 2)
                {
                    
                    showOptions(items);
                }

                else if (userOpt == 3)
                {
                    currentUser = returningUser(users);
                    insertMoneyMenu(items);
                }
                Console.Clear();
            }
        }//======================================Returning User============================================
        public User returningUser(User[] users)
        {
            while (true)
            {

                //Console.WriteLine(users[0].getName()); Helpful name
                //Console.WriteLine(users[0].getPassword());
                Console.WriteLine("Please insert your user name!");
                String userName = Console.ReadLine();
                Console.WriteLine("Please insert your password!");
                String password = Console.ReadLine();
                for (int i = 0; i < users.Length; i++)
                {
                    Console.WriteLine(users[i].getName());
                    Console.WriteLine(users[i].getPassword());
                    if (userName == users[i].getName() && password == users[i].getPassword())
                    {
                        return users[i];
                    }
                }
            }
        }//======================================Show Options============================================
        public void showOptions(Item[] items)
        {
            for (int x = 0; x < items.Length; x++)
            {
                if (items[x].getName()!= null)
                {
                    Console.WriteLine("-----Product Name:   " + items[x].getName() + "-------------");
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("Product ID: " + (items[x].getId()+1));
                    Console.WriteLine("Product Quantity: " + items[x].getQuantity());
                    Console.WriteLine("Product Price: $" + items[x].getPrice());
                    Console.WriteLine("-------------------------------------");
                }
            }
            int getInput = 0;
            while(getInput<1){
                Console.WriteLine("Press 1). to continue.");
                getInput= getIntInput(1, 1, "1=>");
            }
        }//======================================Insert Money============================================
        public void insertMoneyMenu(Item[] items)
        {
            //this is a temporary bank that gets erased after this method finishes

            Console.WriteLine("Please make a selection number less or equal to " +items.Length);
            int itemChoice = getIntInput(1, items.Length, "Product ID =>");// Here we select the ID number shown in the showOptions Method

            if(itemChoice==items.Length){
                itemChoice -= 1;
            }else if(itemChoice==0){
                itemChoice += 1;
            }
                Item item = items[itemChoice];//we put the ID number here
                if (itemChoice == item.getId()) //finding the item
                {
                    Console.WriteLine();
                    Console.WriteLine("You have selected: " + item.getName());
                    Console.WriteLine();
                    Console.WriteLine("Please Insert: " + item.getPrice());
                    Console.WriteLine();
                    double insertedMoney = purchaseMenu(item);
                    Console.WriteLine("Dispensing Your " + item.getName());
                    Console.WriteLine("Enjoy!!!");
                    Console.WriteLine("Please take your change : $"+(insertedMoney - item.getPrice()));
                }
            Console.Clear();
        }//======================================Purchase Menu============================================
        public double purchaseMenu(Item item)
        {
            Bank bank = new Bank(0);
            while (bank.getInsertedMoney() < item.getPrice())//while we haven't inserted enough money, insert more
            {
               
                Console.WriteLine();
                Console.WriteLine("You owe: " + (item.getPrice() - bank.getInsertedMoney()));
                Console.WriteLine("Please enter: 1) for $.05, 2) for $.10, 3) for $.25");
                Console.WriteLine("4) for $1.00, 5) for $5.00");
                Console.WriteLine("Or 5 for a custom amount of up to $10.00!");
                Console.WriteLine();
                int menuChoice = getIntInput(1,6,").");
                switch (menuChoice)
                {
                    case 1:
                        bank.insertCash(.05);
                        break;
                    case 2:
                        bank.insertCash(.10);
                        break;
                    case 3:
                        bank.insertCash(.25);
                        break;
                    case 4:
                        bank.insertCash(1);
                        break;
                    case 5:
                        bank.insertCash(5);
                        break;
                    case 6:
                        bank.insertCash(getDoubleInput(.05,10, "$"));
                        break;
                }
            }//end checking if user has enough or more
            return bank.getInsertedMoney();
        }
        public double getDoubleInput(double min, double maxNum, string say)
        {
            while (true)
            {
                Console.Write(say); String answer = Console.ReadLine();
                double num;
                if (double.TryParse(answer, out num) && double.Parse(answer) <= maxNum&&double.Parse(answer) >= min)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Please return a valid number!");
                    Console.WriteLine("$10.00 or less!");

                }
            }
        }
        public int getIntInput(int min, int maxNum, string say)
        {
            while (true)
            {
                Console.WriteLine();
                Console.Write(say) ;String answer = Console.ReadLine();
                int num;
                if (int.TryParse(answer, out num) && int.Parse(answer) <= maxNum&&int.Parse(answer) >= min)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Please return a valid number!");
                    Console.WriteLine("Cannot be over " + maxNum + " or under "+min+"!");
                    Console.WriteLine();
                }
            }
        }


    }
}
