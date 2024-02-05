namespace Scoreboard.Lib;

public class Scoreboard
{
  public List<Match> Matches { get; private set; }

  public IList<Match> MatchesSummaryList
  {
    get => throw new NotImplementedException();
  }

  public Match StartNewMatch()
	{
		throw new NotImplementedException();
	}

  public void UpdateScore(string matchId, int homeTeamScore, int awayTeamScore)
	{
		throw new NotImplementedException();
	}

	public void FinishMatch(string matchId)
	{
		throw new NotImplementedException();
	}
}

