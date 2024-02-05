namespace Scoreboard.Test;

using Lib;

[TestFixture]
public class ScoreboardTests
{
  private Scoreboard underTest;

  [SetUp]
  public void Setup()
  {
    underTest = new Scoreboard();
  }

  [Test]
  public void StartNewMatch_Should_Returns_Valid_Match_Object()
  {
    //act
    var match = underTest.StartNewMatch();

    //Assert
    Assert.NotNull(match);
    Assert.That(match.AwayTeamScore, Is.EqualTo(0));
    Assert.That(match.HomeTeamScore, Is.EqualTo(0));
  }

  [Test]
  public void MatchesSummaryList_Should_Returns_Matches_Ordered_By_Total_Score_and_Date()
  {
    //Arrange
    var matchDateA = new DateTime(2024, 1, 1, 12, 0, 0);
    var matchDateB = new DateTime(2024, 1, 2, 12, 0, 0);
    var matchDateC = new DateTime(2024, 1, 3, 12, 0, 0);
    var matchDateD = new DateTime(2024, 1, 4, 12, 0, 0);
    var matchDateE = new DateTime(2024, 1, 5, 12, 0, 0);

    var matchA = new Match(matchDateA); // Uruguay 6 - Italy 6
    var matchB = new Match(matchDateB); // Spain 10 - Brazil 2
    var matchC = new Match(matchDateC); // Mexico 0 - Canada 5
    var matchD = new Match(matchDateD); // Argentina 3 - Australia 1
    var matchE = new Match(matchDateE); // Germany 2 - France 2

    matchA.UpdateScore(6, 6);
    matchB.UpdateScore(10, 2);
    matchC.UpdateScore(0, 5);
    matchD.UpdateScore(3, 1);
    matchE.UpdateScore(2, 2);

    var expectedMatches = new List<Match> { matchA, matchB, matchC, matchD, matchE };

    matchC = underTest.StartNewMatch(matchDateC);
    matchB = underTest.StartNewMatch(matchDateB);
    matchE = underTest.StartNewMatch(matchDateE);
    matchA = underTest.StartNewMatch(matchDateA);
    matchD = underTest.StartNewMatch(matchDateD);

    matchA.UpdateScore(6, 6);
    matchB.UpdateScore(10, 2);
    matchC.UpdateScore(0, 5);
    matchD.UpdateScore(3, 1);
    matchE.UpdateScore(2, 2);

    //act
    var actual = underTest.MatchesSummaryList;

    //Assert
    CollectionAssert.AreEqual(expectedMatches.Select(m => (m.AwayTeamScore, m.HomeTeamScore, m.StartTime)),
      actual.Select(m => (m.AwayTeamScore, m.HomeTeamScore, m.StartTime)));
  }

  [Test]
  public void MatchesSummaryList_If_Matches_Wasnt_Started_Should_Returns_Empty_List()
  {
    //act
    var testResult = underTest.MatchesSummaryList;

    //Assert
    Assert.IsEmpty(testResult);
  }

  [TestCase(1, 1, 1, 1)]
  [TestCase(2, 1, 2, 1)]
  [TestCase(0, 2, 0, 2)]
  public void UpdateScore_Should_Update_Match_Score(int away, int home, int expectedAway, int expectedHome)
  {
    //Arrange
    var match = underTest.StartNewMatch();

    //act
    underTest.UpdateScore(match.Id, home, away);

    //Assert
    Assert.NotNull(match);
    Assert.That(expectedAway, Is.EqualTo(match.AwayTeamScore));
    Assert.That(expectedHome, Is.EqualTo(match.HomeTeamScore));
  }

  [TestCase(2, 1, 2, 2)]
  [TestCase(3, 3, 2, 2)]
  public void UpdateScore_When_New_Score_Lover_Then_Actual_Should_Not_Update_Score(int away, int home, int expectedAway,
    int expectedHome)
  {
    //Arrange
    var match = underTest.StartNewMatch();

    //act
    underTest.UpdateScore(match.Id, 2, 2);

    //Assert
    Assert.NotNull(match);
    Assert.That(expectedAway, Is.EqualTo(match.AwayTeamScore));
    Assert.That(expectedHome, Is.EqualTo(match.HomeTeamScore));
  }

  [Test]
  public void UpdateScore_When_Input_Team_Score_Less_Then_Zero_Should_Throw_Exception()
  {
    //Arrange
    var match = underTest.StartNewMatch();

    //Assert
    Assert.Throws<ArgumentOutOfRangeException>(() => underTest.UpdateScore(match.Id, 1, -1));
  }

  [Test]
  public void FinishMatch_Should_Delete_Match()
  {
    //Arrange
    var match = underTest.StartNewMatch();

    //Act
    underTest.FinishMatch(match.Id);

    //Assert
    Assert.IsEmpty(underTest.MatchesSummaryList);
  }


  [Test]
  public void FinishMatch_Should_Delete_Right_Match()
  {
    //Arrange
    var match = underTest.StartNewMatch();
    underTest.StartNewMatch();
    underTest.StartNewMatch();
    underTest.StartNewMatch();

    //Act
    underTest.FinishMatch(match.Id);

    //Assert
    Assert.IsTrue(underTest.MatchesSummaryList.IndexOf(match) < 0);
  }

  [Test]
  public void FinishMatch_If_Id_NullOrEmpty_Should_ThrowException()
  {
    //Assert
    Assert.Throws<ArgumentNullException>(() => underTest.FinishMatch(""));
    Assert.Throws<ArgumentNullException>(() => underTest.FinishMatch(null));
  }

  [Test]
  public void FinishMatch_If_Match_Wasnt_found_Should_Skip()
  {
    //Act
    underTest.FinishMatch("test");

    //Assert
    Assert.Pass();
  }
}
