using System;

class Program
{

    private List<Video> _videos;

    static void Main(string[] args)
    {
        Program program = new Program();
        program.InitializeVideos();
        program.DisplayVideos();
        
    }

    public Program(){
        _videos = new List<Video>();
    }

    public void InitializeVideos(){
        Video video1 = new Video("Games for Life", "Boruto", 10.5);
        video1.AddComment(new Comment("Hiruka", "I liked"));
        video1.AddComment(new Comment("Naruto", "WOW BEST VIDEO EVER MAN!!!"));
        video1.AddComment(new Comment("Sasuke", "hmm could be better"));

        Video video2 = new Video("I want to say somethings...", "Myamoto Musashi", 8.2);
        video2.AddComment(new Comment("Oko", "You're incredible"));
        video2.AddComment(new Comment("Sasaki Kojiro", "I can't hear your sound"));
        video2.AddComment(new Comment("Jotaro", "Good words, master!"));

        Video video3 = new Video("How get your shape", "Toji Fushiguro", 15.0);
        video3.AddComment(new Comment("Saturou Gojo", "Yo bro, half of your video it's missing 🤣🤣🤣🤣"));
        video3.AddComment(new Comment("Megumi", "You remember me..."));
        video3.AddComment(new Comment("Sukuna", "OH YES... I don't get the shape since Heian Era, thanks."));

        _videos.Add(video1);
        _videos.Add(video2);
        _videos.Add(video3);

    }

    public void DisplayVideos(){
        Console.WriteLine("Videos: ");
        foreach (Video video in _videos){
            Console.WriteLine("\n");
            Console.WriteLine(video.DisplayVideoInfo());
            video.DisplayComments();
        }
    }
}