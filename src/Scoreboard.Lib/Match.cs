namespace Scoreboard.Lib;

public class Match
{
  public string Id { get; }
  public DateTime StartTime { get; }
  public int HomeTeamScore { get; private set; }
  public int AwayTeamScore { get; private set; }

  public Match(DateTime startTime)
  {
    StartTime = startTime;
    Id = Guid.NewGuid().ToString();
    HomeTeamScore = 0;
    AwayTeamScore = 0;
  }
  public void UpdateScore(int homeTeamScore, int awayTeamScore)
  {
    if (homeTeamScore < 0 ) throw new ArgumentOutOfRangeException(nameof(homeTeamScore));

    if (awayTeamScore < 0) throw new ArgumentOutOfRangeException(nameof(awayTeamScore));

    if(homeTeamScore < HomeTeamScore) return;

    if(awayTeamScore < AwayTeamScore) return;

    HomeTeamScore = homeTeamScore;

    AwayTeamScore = awayTeamScore;
  }
}
