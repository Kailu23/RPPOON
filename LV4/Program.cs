using System;
using System.Collections.Generic;
using System.Linq;
using LV4;

class Program
{
    static void Main(string[] args)
    {
        //Zad1i2();
        //Zad3();
        //Zad4();
        //Zad5();
        //Zad6();
        Zad7();
    }

    public static void Zad1i2()
    {
        Dataset dataset = new Dataset(@"data.csv"); // putanja do tvoje CSV datoteke
        Analyzer3rdParty thirdParty = new Analyzer3rdParty();
        IAnalytics analytics = new Adapter(thirdParty);

        var rowAverages = analytics.CalculateAveragePerRow(dataset);
        var colAverages = analytics.CalculateAveragePerColumn(dataset);

        Console.WriteLine("Prosjek po retcima:");
        foreach (var val in rowAverages)
            Console.WriteLine(val);

        Console.WriteLine("Prosjek po stupcima:");
        foreach (var val in colAverages)
            Console.WriteLine(val);
    }

    public static void Zad3()
    {
        List<IRentable> rentables = new List<IRentable>
        {
            new Book("Harry Potter"),
            new Video("Interstellar"),
        };
        RentingConsolePrinter printer = new RentingConsolePrinter();
        printer.DisplayItems(rentables);
    }

    public static void Zad4()
    {
        List<IRentable> rentables = new List<IRentable>
        {
            new Book("Harry Potter"),
            new Video("Interstellar"),
            new HotItem(new Book("The Hobbit")),
            new HotItem(new Video("Pitch Black")),
        };
        RentingConsolePrinter printer = new RentingConsolePrinter();
        printer.DisplayItems(rentables);
    }
    public static void Zad5()
    {
        List<IRentable> rentables = new List<IRentable>
        {
            new DiscountedItem(new Book("Harry Potter"), 20),
            new DiscountedItem(new Video("Interstellar"), 15),
             new DiscountedItem(new HotItem(new Book("The Hobbit")), 25),
             new DiscountedItem(new HotItem(new Video("Pitch Black")), 10),
        };
        RentingConsolePrinter printer = new RentingConsolePrinter();
        printer.DisplayItems(rentables);
    }

    public static void Zad6()
    {
        IPasswordValidatorService pwdValidator = new PasswordValidator(8);
        string[] passwords = { "Test123", "password", "P@ssw0rd123", "12345678" };

        Console.WriteLine("Provjera lozinki:");
        foreach (var pwd in passwords)
        {
            Console.WriteLine($"'{pwd}': {pwdValidator.IsValidPassword(pwd)}");
        }

        IEmailValidatorService emailValidator = new EmailValidator();
        string[] emails = { "test@example.com", "user@site.hr", "invalid.com", "noatsign.hr", "test@site.org" };

        Console.WriteLine("\nProvjera e-mail adresa: ");
        foreach (var email in emails)
        {
            Console.WriteLine($"'{email}': {emailValidator.IsValidAddress(email)}");
        }
    }

    public static void Zad7()
    {
        RegistrationValidator validator = new RegistrationValidator(new PasswordValidator(8), new EmailValidator());
        bool isValid;
        do
        {
            UserEntry newUser = UserEntry.ReadUserFromConsole();
            isValid = validator.IsUserEntryValid(newUser);
        }
        while (!isValid);
        Console.WriteLine("Input data is valid.");
    }
}
