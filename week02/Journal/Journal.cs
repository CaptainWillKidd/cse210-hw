using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToString());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        _entries.Clear();
        using (StreamReader inputFile = new StreamReader(filename))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                string[] parts = line.Split(new[] { " - " }, StringSplitOptions.None);
                if (parts.Length == 3)
                {
                    Entry entry = new Entry(parts[0], parts[1], parts[2], "default mood");
                    _entries.Add(entry);
                }
            }
        }
    }
}