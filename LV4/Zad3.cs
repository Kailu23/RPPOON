using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    public interface IRentable
    {
        String Description { get; }
        double CalculatePrice();
    }
    class Video : IRentable
    {
        private readonly double BaseVideoPrice = 9.99;
        public String Name { get; private set; }
        public Video(String name) { this.Name = name; }
        public string Description { get { return this.Name; } }
        public double CalculatePrice() { return BaseVideoPrice; }
    }
    class Book : IRentable
    {
        private readonly double BaseBookPrice = 3.99;
        public String Name { get; private set; }
        public Book(String name) { this.Name = name; }
        public string Description { get { return this.Name; } }
        public double CalculatePrice() { return BaseBookPrice; }
    }
    class RentingConsolePrinter
    {
        public void PrintTotalPrice(List<IRentable> items)
        {
            Console.WriteLine(items.Sum(r => r.CalculatePrice()));
        }
        public void DisplayItems(List<IRentable> items)
        {
            items.ForEach(r => Console.WriteLine(r.Description));
        }
    }

}
