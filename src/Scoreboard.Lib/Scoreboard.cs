namespace Scoreboard.Lib;

public class Scoreboard
{
	private List<Match> matches;

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

