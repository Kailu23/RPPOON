using System;
using System.Collections.Generic;
using System.Linq;
using LV4;

class Program
{
    static void Main(string[] args)
    {
        Zad1();
        //Zad2();
        //Zad3();
        //Zad4();
        //Zad5();
        //Zad6();
        //Zad7();
    }

    public static void Zad1()
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
}
