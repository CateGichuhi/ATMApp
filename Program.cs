// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

public class cardHolder
{
    String cardId;
    String firstName;
    String lastName;
    int pin;
    double balance;

    public cardHolder(String cardId, String firstName, String lastName, int pin, double balance)
    {
        this.cardId = cardId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.pin = pin;
        this.balance = balance;
            
    }
    public String Id()
    {
        return cardId;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public int getPin()
    {
        return pin;
    }
    public double getBalance()
    {
        return balance;
    }
    public void setId(string newCardId) {
        cardId = newCardId;
         }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setBalance(double newBalance)
    {
            balance = newBalance;
    }
    public static void main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of the options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            Console.WriteLine("Your deposit has been received. Your new balance is:" + currentUser.balance);

        }
        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());
            if (currentUser.getBalance() > withdraw)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                Console.WriteLine("You're good to go. Thank You");
            }
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("243366785", "Mike", "Kent", 2234, 387.98));
        cardHolders.Add(new cardHolder("245467885", "John", "Doe", 4478, 657.66));
        cardHolders.Add(new cardHolder("243366785", "Mary", "luke", 2234, 987.33));
        cardHolders.Add(new cardHolder("652389835", "Charice", "will", 2234, 321.48));
        cardHolders.Add(new cardHolder("54679976", "Lily", "Jea", 2234, 128.00));

        //prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card");
        string debitcardId = "";
        cardHolder currentUser;

        while (true) {
            try
            {
                debitcardId = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardId == debitcardId);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card is not recognized. Please try again"); }
            }
                catch{
                    Console.WriteLine("Card is not recognized. Please try again");
                }
        /*Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        cardHolder userCard;
            while (true)
            {
                try
                {
                    userPin =int.Parse( Console.ReadLine());
                    //check against our db
                    //currentUser = cardHolders.FirstOrDefault(a => a.pin == userPin);
                    if (userCard.getPin() == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin. Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }
        */
        Console.WriteLine("Welcome");
        int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option=int.Parse(Console.ReadLine()) ;
                    }
                    catch { }
                    if (option == 1)
                    {
                        deposit(currentUser);
                    }
                    else if (option == 2)
                    {
                        withdraw(currentUser);
                    }
                    else if(option == 3)
                    {
                        balance(currentUser);
                    }
                    else if (option == 4){
                        break;
                    }
                    else
                    {
                        option = 0;
                    }

                }
                while (option != 4);
                Console.WriteLine("Thank You! Have a nice day");
                

    }
}
