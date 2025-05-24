using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    public interface ITheme
    {
        void SetBackgroundColor();
        void SetFontColor();
        string GetHeader(int width);
        string GetFooter(int width);
    }
    public abstract class Note
    {
        private string message;
        private ITheme theme;
        public Note(string message, ITheme theme)
        {
            this.message = message;
            this.theme = theme;
        }
        public string Message { get { return this.message; } }
        public ITheme Theme { set { this.theme = value; } }
        protected void ChangeColor()
        {
            this.theme.SetBackgroundColor();
            this.theme.SetFontColor();
        }
        protected string GetFramedMessage()
        {
            int width = this.message.Length;
            return this.theme.GetHeader(width) + "\n" +
           message + "\n" + this.theme.GetFooter(width);
        }
        public abstract void Show();
    }
    class LightTheme : ITheme
    {
        public void SetBackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.White;
        }
        public void SetFontColor()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public string GetHeader(int width)
        {
            return new string('+', width);
        }
        public string GetFooter(int width)
        {
            return new string('_', width);
        }
    }
    class ReminderNote : Note
    {
        public ReminderNote(string message, ITheme theme) : base(message, theme) { }
        public override void Show()
        {
            this.ChangeColor();
            Console.WriteLine("REMINDER: ");
            string framedMessage = this.GetFramedMessage();
            Console.WriteLine(framedMessage);
            Console.ResetColor();
        }
    }

    class DarkTheme : ITheme
    {
        public void SetBackgroundColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }   
        public void SetFontColor()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        public string GetHeader(int width)
        {
            return new string('-', width);
        }
        public string GetFooter(int width)
        {
            return new string('=', width);
        }
    }


}