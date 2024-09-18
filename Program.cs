// See https://aka.ms/new-console-template for more information
using System.Linq.Expressions;

public class CardHold
{

    public class CardHolder
    {
        public string CardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set; }
        public double Balance { get; set; }
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose one of the options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.Balance = deposit;
            Console.WriteLine("Your deposit has been received. Your new balance is:" + currentUser.Balance);

        }
        void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much money would you like to withdraw? ");
            double withdraw = Double.Parse(Console.ReadLine());
            if (currentUser.Balance > withdraw)
            {
                Console.WriteLine("Insufficient Balance");
            }
            else
            {
                currentUser.Balance = currentUser.Balance - withdraw;
                Console.WriteLine("You're good to go. Thank You");
            }
        }
        List<CardHolder> cardHolders = new List<CardHolder>();
        
        cardHolders.Add(new CardHolder(){ CardId = "243366785", FirstName = "Mike", LastName = "Kent", Pin = 2234, Balance = 387.98 });
        cardHolders.Add(new CardHolder(){ CardId = "245467885", FirstName = "John", LastName = "Doe", Pin = 4478, Balance = 657.66 });
        cardHolders.Add(new CardHolder(){ CardId = "243366785", FirstName = "Mary", LastName = "luke", Pin = 2234, Balance = 987.33 });
        cardHolders.Add(new CardHolder(){ CardId = "652389835", FirstName = "Charice", LastName = "will", Pin = 2234, Balance = 321.48 });
        cardHolders.Add(new CardHolder(){ CardId = "54679976", FirstName = "Lily", LastName = "Jea", Pin = 2234, Balance = 128.00 });

        //prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card");
        string debitcardId = "";
        CardHolder currentUser= new CardHolder(); //declare current user as null

        while (true)
        {
            try
            {
                debitcardId = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.CardId == debitcardId);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card is not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card is not recognized. Please try again");
            }
            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            CardHolder userCard;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    //check against our db
                    //currentUser = cardHolders.FirstOrDefault(a => a.pin == userPin);
                    if (currentUser.Pin == userPin) { break; }
                    else { Console.WriteLine("Incorrect pin. Please try again"); }
                }
                catch
                {
                    Console.WriteLine("Incorrect pin. Please try again");
                }

                Console.WriteLine("Welcome");
                int option = 0;
                do
                {
                    printOptions();
                    try
                    {
                        option = int.Parse(Console.ReadLine());
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
                    else if (option == 3)
                    {
                        //TO-DO
                        // balance(currentUser);
                    }
                    else if (option == 4)
                    {
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
    }
}