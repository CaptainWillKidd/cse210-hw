public class Scripture{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text){
        _reference = reference;
        _words = new List<Word>();
        string[] words = text.Split(' ');
        foreach(string word in words){
            _words.Add(new Word(word));
        }
    }

    public void HideRandomWords(int count){
        Random random = new Random();
        int hiddenCount = 0;
        while (hiddenCount < count)
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }

            if (IsCompletelyHidden())
            {
                break;
            }
        }
    }

     public string GetDisplayText()
    {
        string result = "";
        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }
        return result.Trim();
    }

    public bool IsCompletelyHidden(){
        foreach(Word word in _words){
            if(!word.IsHidden()){
                return false;
            }
        }
        return true;
    }

    public Reference GetReference(){
        return _reference;
    }
} 