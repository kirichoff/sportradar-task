namespace Scoreboard.Lib;

public class Match
{
  public Match(DateTime startTime)
  {
    StartTime = startTime;
    Id = Guid.NewGuid().ToString();
  }

  public string Id { get; }
  public DateTime StartTime { get; }
  public int HomeTeamScore { get; private set; }
  public int AwayTeamScore { get; private set; }

  private void UpdateScore(int homeTeamScore, int awayTeamScore)
  {
    throw new NotImplementedException();
  }
}
