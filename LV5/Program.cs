using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
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
            //TestZad5();
            //TestZad6();
            TestZad7();
        }

        public static void TestZad3()
        {
            User user1 = User.GenerateUser("Marin");
            User user2 = User.GenerateUser("Luka");
            IDataset proxy1 = new ProtectionProxyDataset(user1);
            IDataset proxy2 = new ProtectionProxyDataset(user2);
            ReadOnlyCollection<List<string>> data = proxy1.GetData();
            ReadOnlyCollection<List<string>> data2 = proxy2.GetData();
            DataConsolePrinter.Print(data);
            DataConsolePrinter.Print(data2);
        }
        public static void TestZad4()
        {
            string path = "sensitiveData.csv";
            IDataset dataset = new LoggingProxyDataset(path);

            var data = dataset.GetData();
            //DataConsolePrinter.Print(data);
        }
        public static void TestZad5()
        {
            ITheme lightTheme = new LightTheme();
            Note reminderNote = new ReminderNote("Buy groceries", lightTheme);
            reminderNote.Show();
            ITheme darkTheme = new DarkTheme();
            Note todoNote = new ReminderNote("Finish homework", darkTheme);
            todoNote.Show();
        }
        public static void TestZad6()
        {
            ITheme lightTheme = new DarkTheme();
            GroupNote groupNote = new GroupNote("Team meeting at 3 PM", lightTheme);
            groupNote.AddUser("Alice");
            groupNote.AddUser("Bob");
            groupNote.Show();
            groupNote.RemoveUser("Alice");
            groupNote.Show();
        }
        public static void TestZad7()
        {
            ITheme lightTheme = new LightTheme();
            Notebook notebook = new Notebook(lightTheme);
            Note reminderNote = new ReminderNote("Buy groceries", lightTheme);
            notebook.AddNote(reminderNote);
            Note todoNote = new ReminderNote("Finish homework", lightTheme);
            notebook.AddNote(todoNote);
            notebook.Display();
            ITheme darkTheme = new DarkTheme();
            GroupNote groupNote1 = new GroupNote("Buy groceries", lightTheme);
            groupNote1.AddUser("Alice");
            groupNote1.AddUser("Bob");
            notebook.AddNote(groupNote1);
            GroupNote groupNote2 = new GroupNote("Finish homework", darkTheme);
            groupNote2.AddUser("Charlie");
            groupNote2.AddUser("Dave");
            notebook.AddNote(groupNote2);

            notebook.Display();
            notebook.ChangeTheme(darkTheme);
            notebook.Display();
        }
    }
}
