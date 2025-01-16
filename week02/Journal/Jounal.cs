using System.ComponentModel.DataAnnotations;

public class Journal{
    public List<Entry> _entries;
    
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.display();
        }
    }

    public void SaveToFIle(string filename)
    {
        // Save all entries to a file
    }

    public void LoadFromFile(string filename)
    {
        // Load all entries from a file
    }
}