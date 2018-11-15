using System;
namespace VendingMachine
{
    public class Bank
    {
        double insertedMoney;


        public Bank(double startingCash)
        {
            if (startingCash >= 0)
            {
                insertedMoney = startingCash;
            }
            else
            {
                Console.WriteLine("Warning; no cash inserted.");
                insertedMoney = 0;
            }
        }




        public void insertCash(double cashInserted)
        {
            insertedMoney += cashInserted;
        }



        public double getInsertedMoney()
        {
            return insertedMoney;
        }
    }
}
