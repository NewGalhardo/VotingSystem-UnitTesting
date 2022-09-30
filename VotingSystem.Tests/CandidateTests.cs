namespace VotingSystem.Tests
{
    public class CandidateTests
    {
        [Theory]
        [InlineData("John Doe")]
        [InlineData("João Gomes")]
        [InlineData("José Bragança")]
        public void Constructor_NameExitingConstructorShouldBeCorrect(string name)
        {
            //Arrange
            var expected = name;

            //Act
            var candidate = new Candidate(expected);
            var actual = candidate._name;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Constructor_NumberOfVotesExitingConstructorShouldBeZero()
        {
            //Arrange
            var expected = 0;

            //Act
            var candidate = new Candidate("John Doe");
            var actual = candidate._votes;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(53)]
        public void AddVote_NumberOfVotesShouldIncreaseByOne(int increments)
        {
            //Arrange
            var expected = increments;

            //Act
            var candidate = new Candidate("John Doe");

            for (int i = 0; i < increments; i++)
            {
                candidate.AddVote();
            }

            var actual = candidate._votes;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}