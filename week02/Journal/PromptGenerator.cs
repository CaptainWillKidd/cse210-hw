public class PromptGenerator{
    public List<string> _prompts;

    public string GetRandomPrompt()
    {
        if (_prompts == null || _prompts.Count == 0)
        {
            return "No prompts available.";
        }

        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}