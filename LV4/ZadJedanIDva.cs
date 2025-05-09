using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV4
{
    interface IAnalytics
    {
        double[] CalculateAveragePerColumn(Dataset dataset);
        double[] CalculateAveragePerRow(Dataset dataset);
    }

    class Adapter : IAnalytics
    {
        private Analyzer3rdParty analyticsService;
        public Adapter(Analyzer3rdParty service)
        {
            this.analyticsService = service;
        }
        private double[][] ConvertData(Dataset dataset)
        {
            var rows = dataset.GetData();
            int rowCount = rows.Count;

            double[][] data = new double[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                data[i] = rows[i].ToArray();
            }
            return data;
        }
        public double[] CalculateAveragePerColumn(Dataset dataset)
        {
            double[][] data = this.ConvertData(dataset);
            return this.analyticsService.PerColumnAverage(data);
        }
        public double[] CalculateAveragePerRow(Dataset dataset)
        {
            double[][] data = this.ConvertData(dataset);
            return this.analyticsService.PerRowAverage(data);
        }
    }
    class Dataset
    {
        private List<List<double>> data;
        public Dataset()
        {
            this.data = new List<List<double>>();
        }
        public Dataset(string filePath) : this()
        {
            this.LoadDataFromCSV(filePath);
        }
        public void LoadDataFromCSV(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                List<double> row =
               new List<double>(Array.ConvertAll(line.Split(','), double.Parse));
                this.data.Add(row);
            }
        }
        public IList<List<double>> GetData()
        {
            return new System.Collections.ObjectModel.ReadOnlyCollection<List<double>>(this.data);
        }
    }
    class Analyzer3rdParty
    {
        public double[] PerRowAverage(double[][] data)
        {
            int rowCount = data.Length;
            double[] results = new double[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                results[i] = data[i].Average();
            }
            return results;
        }
        public double[] PerColumnAverage(double[][] data)
        {
            int rowCount = data.Length;
            int columnCount = data[0].Length;
            double[] results = new double[columnCount];

            for (int col = 0; col < columnCount; col++)
            {
                double sum = 0;
                for (int row = 0; row < rowCount; row++)
                {
                    sum += data[row][col];
                }
                results[col] = sum / rowCount;
            }
            return results;
        }
    }

}
