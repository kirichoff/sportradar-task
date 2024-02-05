namespace Scoreboard.Lib;

public class Scoreboard
{
  public List<Match> Matches { get; }
  public IList<Match> MatchesSummaryList
  {
    get => _matchesSummaryList();
  }

  public Scoreboard()
  {
    Matches = new List<Match>();
  }

  public Match StartNewMatch(DateTime startTime = new())
  {
    var match = new Match(startTime);
		Matches.Add(match);

    return match;
  }

  public void UpdateScore(string matchId, int homeTeamScore, int awayTeamScore)
  {
    if (string.IsNullOrEmpty(matchId)) throw new ArgumentNullException(nameof(matchId));

    var match = Matches.FirstOrDefault(m => m.Id == matchId);

    if (match == null) return;

    match.UpdateScore(homeTeamScore,awayTeamScore);
  }

	public void FinishMatch(string matchId)
  {
    if (string.IsNullOrEmpty(matchId)) throw new ArgumentNullException(nameof(matchId));

    var match = Matches.FirstOrDefault(m => m.Id == matchId);

    if (match is null) return;

    Matches.Remove(match);
  }

  private IList<Match> _matchesSummaryList()
  {
    return Matches.OrderByDescending(match => match.AwayTeamScore + match.HomeTeamScore)
      .ThenBy(match => match.StartTime)
      .ToList();
  }

}

