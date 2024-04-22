using System;
using System.Collections.Generic;

class MusicRecommendation
{
    private Dictionary<string, List<string>> userPreferences;

    public MusicRecommendation()
    {
        userPreferences = new Dictionary<string, List<string>>();
    }

    public void AddUserPreference(string user, string musicGenre)
    {
        if (!userPreferences.ContainsKey(user))
        {
            userPreferences[user] = new List<string>();
        }
        userPreferences[user].Add(musicGenre);
    }

    public List<string> GetRecommendedMusic(string user)
    {
        List<string> recommendedMusic = new List<string>();

        foreach (var preference in userPreferences[user])
        {
            if (preference == "rock")
            {
                recommendedMusic.Add("Queen - Bohemian Rhapsody");
            }
            else if (preference == "pop")
            {
                recommendedMusic.Add("Justin Bieber - Yummy");
            }
        }

        return recommendedMusic;
    }
}

class Program
{
    static void Main()
    {
        MusicRecommendation recommendationSystem = new MusicRecommendation();

        recommendationSystem.AddUserPreference("user1", "rock");
        recommendationSystem.AddUserPreference("user1", "pop");

        List<string> recommendedMusic = recommendationSystem.GetRecommendedMusic("user1");

        Console.WriteLine("Recommended music for user1:");
        foreach (var music in recommendedMusic)
        {
            Console.WriteLine(music);
        }
    }
}
