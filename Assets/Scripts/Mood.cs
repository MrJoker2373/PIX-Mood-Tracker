namespace PixMoodTracker
{
    public struct Mood
    {
        public bool IsFull;
        public MoodType Type;

        public static MoodType Parse(string mood)
        {
            if (mood == MoodType.Neutral.ToString())
                return MoodType.Neutral;
            else if (mood == MoodType.Happy.ToString())
                return MoodType.Happy;
            else if (mood == MoodType.Sad.ToString())
                return MoodType.Sad;
            else if (mood == MoodType.Angry.ToString())
                return MoodType.Angry;
            else if (mood == MoodType.Excited.ToString())
                return MoodType.Excited;
            else
                return default;
        }
    }
}