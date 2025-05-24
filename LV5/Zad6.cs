using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV5
{
    public class GroupNote : Note
    {
        private List<string> people;
        public GroupNote(string message, ITheme theme) : base(message, theme)
        {
            this.people = new List<string>();
        }

        public void AddUser(string name)
        {
            this.people.Add(name);
        }
        public void RemoveUser(string name)
        {
            this.people.Remove(name);
        }
        public override void Show()
        {
            this.ChangeColor();
            Console.WriteLine("REMINDER FOR: ");
            foreach (string person in this.people)
            {
                Console.WriteLine(person);
            }
            string framedMessage = this.GetFramedMessage();
            Console.WriteLine(framedMessage);
            Console.ResetColor();
        }
    }   
}
