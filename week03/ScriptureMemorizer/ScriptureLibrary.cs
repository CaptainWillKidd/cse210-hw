public class ScriptureLibrary{
    private List<Scripture> _scriptures;

    public ScriptureLibrary(){
        _scriptures = new List<Scripture>();
    }

    public void Add(Scripture scripture){
        _scriptures.Add(scripture);
    }

    public Scripture GetRandom(){
        if (_scriptures.Count == 0)
        {
            return null;
        }

        Random random = new Random();
        int index = random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}