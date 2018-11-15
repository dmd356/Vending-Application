using System;
namespace VendingMachine
{
    public class User
    {
        int id;
        String name;
        String password;
        double bankAmmount;
        
        public User(int id, String name, String password, double bankAmmount)
        {
            this.id = id;
            this.name = name;
            this.password = password;
            this.bankAmmount = bankAmmount;
        }
        public void setName(string name){
            this.name = name;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public void setBank(double bankAmmount)
        {
            this.bankAmmount = bankAmmount;
        }
        public String getName()
        {
            return name;
        }
        public String getPassword()
        {
            return password;
        }
        public double getBankAmmount()
        {
            return bankAmmount;
        }
        public int getID(){
            return id;
        }

    }
}
