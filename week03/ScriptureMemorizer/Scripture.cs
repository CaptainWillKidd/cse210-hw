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
        for(int i = 0; i < count; i++){
            int index = random.Next(_words.Count);
            _words[index].Hide();
        }
    }

    public string GetDisplayText(){
        string result = "";
        foreach(Word word in _words){
            result += word.GetDisplayText() + " ";
        }
        return result;
    }

    public bool IsCompletelyHidden(){
        foreach(Word word in _words){
            if(!word.IsHidden()){
                return false;
            }
        }
        return true;
    }
} 