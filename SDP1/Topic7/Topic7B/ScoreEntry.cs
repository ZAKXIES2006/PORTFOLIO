public class ScoreEntry
{
    public ScoreEntry(int score, int stageReached, DateTime achievedAt)
    {
        Score = score;
        StageReached = stageReached;
        AchievedAt = achievedAt;
    }

    public ScoreEntry(int score, int levelReached) : this(score, levelReached, DateTime.Now)
    {
    }

    public int Score { get; set; }
    public int StageReached { get; set; }
    public DateTime AchievedAt { get; set; }

    public override string ToString() => $"Score: {Score}, Stage: {StageReached}, Time: {AchievedAt:HH:mm:ss}";
}