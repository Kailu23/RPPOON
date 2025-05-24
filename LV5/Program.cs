using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestZad3();
            //TestZad4();
        }

        public static void TestZad3()
        {
            User user1 = User.GenerateUser("Marin");
            IDataset proxy1 = new ProtectionProxyDataset(user1);
            ReadOnlyCollection<List<string>> data = proxy1.GetData();
            DataConsolePrinter.Print(data);
        }
        public static void TestZad4()
        {
            string path = "sensitiveData.csv";
            IDataset dataset = new LoggingProxyDataset(path);

            var data = dataset.GetData();
            DataConsolePrinter.Print(data);
        }
    }
}
