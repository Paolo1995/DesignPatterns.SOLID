using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// <summary>
// Single Responsibility Principle
// A typical class is responsible for one thing ans has one reason to change.
// </summary>

namespace DesignPatterns.SOLID
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int Count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++Count}: {text}");
            return Count; //memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // <summary>
        // If we put these methods here, we would violate the SRP principle because these methods
        // commented below can be used with a different purpose than the one declared in the name of the class.
        // In this situation, in order to respect this principle,
        // the most correct thing is to create a new class to call Persistence.
        // </summary>
        //public void Save(string fileName)
        //{
        //    File.WriteAllText(fileName, ToString());
        //}

        //public static Jurnal Load(string fileName)
        //{

        //}

        //public void Load(Uri uri)
        //{

        //}
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName, bool overWrite = false)
        {
            if(overWrite || !File.Exists(fileName))
                File.WriteAllText(fileName, j.ToString());
        }
    }
}
