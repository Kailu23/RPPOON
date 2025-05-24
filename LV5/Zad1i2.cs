using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    public interface IShipable
    {
        double Price { get; }
        double Weight { get; }
        string Description(int depth = 0);
    }
    public class Product : IShipable
    {
        private double price;
        private string description;
        private double weight;
        public Product(string description, double price)
        {
            this.description = description;
            this.price = price;
        }
        public double Price { get { return this.price; } }
        public double Weight { get { return this.weight; } }
        public string Description(int depth = 0){ return new string(' ', depth) + this.description; }
    }
    public class Box : IShipable
    {
        private List<IShipable> items;
        private string name;
        public Box(string name)
        {
            this.items = new List<IShipable>();
            this.name = name;
        }
        public void Add(IShipable item)
        {
            this.items.Add(item);
        }
        public void Remove(IShipable item)
        {
            this.items.Remove(item);
        }
        public double Price
        {
            get
            {
                double totalPrice = 0;
                foreach (IShipable item in items)
                {
                    totalPrice += item.Price;
                }
                return totalPrice;
            }
        }
        public double Weight
        {
            get { 
                double totalWeight = 0;
                foreach (IShipable item in items)
                {
                    totalWeight += item.Weight;
                }
                return totalWeight;
            }
        }
        public string Description(int depth = 0)
        {
            StringBuilder builder = new StringBuilder(new string(' ', depth) + this.name + "\n");
            foreach (IShipable item in items)
            {
                builder.Append(item.Description(depth + 2)).Append("\n");
            }
            return builder.ToString();
        }
    }

    public class ShippingService
    {
        private static double unitPricePerKilogram = 1.5;
        public double CalculateShippingCost(IShipable box)
        {
            return box.Weight * unitPricePerKilogram;
        }
    }
}
