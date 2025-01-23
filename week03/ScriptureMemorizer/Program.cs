using System;
// I  put a random function to chose a scripture from the library and then hide some words from it.
class Program
{
    static void Main(string[] args)
        {
        ScriptureLibrary library = new ScriptureLibrary();
        library.Add(new Scripture(new Reference("1 Nephi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));
        library.Add(new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        library.Add(new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));
        library.Add(new Scripture(new Reference("Doctrine and Covenants", 88, 118), "And as all have not faith, seek ye diligently and teach one another words of wisdom; yea, seek ye out of the best books words of wisdom; seek learning, even by study and also by faith."));
        library.Add(new Scripture(new Reference("Mosiah", 2, 17), "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."));

        Scripture scripture = library.GetRandom();
        while(true)
        {
            Console.WriteLine(scripture.GetReference().GetDisplayText());
            Console.WriteLine(scripture.GetDisplayText());

            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                return;
            }

            scripture.HideRandomWords(3);

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine(scripture.GetReference().GetDisplayText());
                Console.WriteLine(scripture.GetDisplayText());

                Console.WriteLine("Congratulations! You've hidden all the words.");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
                return;
            }
        }

    }

}