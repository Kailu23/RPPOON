using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{

    public class LoggingProxyDataset : IDataset
    {
        private ConsoleLogger logger;
        private Dataset dataset;
        private readonly string filePath;
        public LoggingProxyDataset(string filePath)
        {
            this.logger = ConsoleLogger.GetInstance();
            this.filePath = filePath;
        }
        public ReadOnlyCollection<List<string>> GetData()
        {
            if (this.dataset == null)
            {
                this.dataset = new Dataset(this.filePath);
            }

            logger.Log("File accessed from: " + this.filePath);
            return dataset.GetData();
        }

        public class ConsoleLogger
        {
            private static ConsoleLogger instance;
            public static ConsoleLogger GetInstance()
            {
                if (instance == null)
                {
                    instance = new ConsoleLogger();
                }
                return instance;
            }
            public void Log(string message)
            {
                Console.WriteLine($"{message} and data logged at {DateTime.Now}.");
            }
        }

    }
}
