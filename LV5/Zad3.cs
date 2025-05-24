using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    public interface IDataset
    {
        ReadOnlyCollection<List<string>> GetData();
    }
    class Dataset : IDataset
    {
        private string filePath;
        private List<List<string>> data;
        public Dataset(string filePath)
        {
            this.filePath = filePath;
            this.data = new List<List<string>>();
            this.LoadDataFromCSV();
        }
        private void LoadDataFromCSV()
        {
            string[] lines = System.IO.File.ReadAllLines(this.filePath);
            foreach (string line in lines)
            {
                List<string> row = new List<string>(line.Split(','));
                data.Add(row);
            }
        }
        public ReadOnlyCollection<List<string>> GetData()
        {
            return new ReadOnlyCollection<List<string>>(this.data);
        }
    }
    public class VirtualProxy : IDataset
    {
        private string filePath;
        private Dataset dataset;

        public VirtualProxy(string filePath)
        {
            this.filePath = filePath;
        }

        public ReadOnlyCollection<List<string>> GetData()
        {
            if (this.dataset == null)
            {
                dataset = new Dataset(this.filePath);
            }
            return dataset.GetData();
        }
    }

    public class User
    {
        private static int id = 0;
        public string Name { get; private set; }
        public int ID { get; private set; }

        private User(string name, int ID)
        {
            this.Name = name;
            this.ID = ID;
        }
        public static User GenerateUser(string name)
        {
            id++;
            return new User(name, id);
        }
    }
    public class ProtectionProxyDataset : IDataset
    {
        private Dataset dataset;
        private List<int> allowedIDs;
        public User user { private get; set; }

        public ProtectionProxyDataset(User user)
        {
            this.allowedIDs = new List<int>(new int[] { 1, 3, 5 });
            this.user = user;
        }
        private bool AuthenticateUser() { return allowedIDs.Contains(this.user.ID); }
        public ReadOnlyCollection<List<string>> GetData() {
            if (this.AuthenticateUser())
            {
                if (this.dataset == null)
                {
                    this.dataset = new Dataset("sensitiveData.csv");
                }
                return this.dataset.GetData();
            }
            return null;
        }
    }
    public static class DataConsolePrinter
    {
        public static void Print(ReadOnlyCollection<List<string>> data)
        {
            if(data == null)
            {
                throw new ArgumentNullException("Illegal access.");
            }
            foreach (var row in data)
            {
                Console.WriteLine(string.Join("," ,row));
            }
        }
    }
}
