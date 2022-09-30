using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace VotingSystem.Tests
{
    public class BallotTests
    {
        public List<Candidate> GetSampleListOfCandidates()
        {
            var sample = new List<Candidate>()
            {
                new Candidate("John Doe"),
                new Candidate("Mary Voghn"),
                new Candidate("Jack Daniels")
            };

            return sample;
        }
        
        [Fact]
        public void Constructor_InitialValuesShouldBeCorrect()
        {
            //Arrange
            var expected = new Ballot()
            {
                ElectionWinner = "",
                WinnerTotalVotes = 0,
                Candidates = new List<Candidate>(),
                ElectionIsActive = false
            };

            //Act
            var actual = new Ballot();

            //Assert
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void BeginOrEndElection_BoolValueShouldInvert()
        {
            //Arrange
            var ballot = new Ballot();
            var expected = !ballot.ElectionIsActive;

            //Act
            ballot.BeginOrEndElection();

            //Assert
            Assert.Equal(expected, ballot.ElectionIsActive);
        }

        [Fact]
        public void RegisterCandidate_NewestCandidateShouldBeLastOnTheList()
        {
            //Arrange
            var sampleListOfCandidates = GetSampleListOfCandidates();

            var ballot = new Ballot();
            ballot.Candidates = sampleListOfCandidates;

            var newCandidate = "Frank Miller";

            //Act
            ballot.RegisterCandidate(newCandidate);

            //Assert
            ballot.Candidates.Last()._name.Should().Be(newCandidate);
        }

        [Theory]
        [InlineData("Patrick Swayze")]
        [InlineData("Jimi Hendrix")]
        public void Vote_UnregisteredCandidatesShouldFail(string name)
        {
            //Arrange
            var sampleListOfCandidates = GetSampleListOfCandidates();

            var ballot = new Ballot();
            ballot.Candidates = sampleListOfCandidates;

            //Act
            var result = ballot.Vote(name);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("John Doe")]
        [InlineData("Mary Voghn")]
        [InlineData("Jack Daniels")]
        public void Vote_RegisteredCandidatesShouldWork(string name)
        {
            //Arrange
            var sampleListOfCandidates = GetSampleListOfCandidates();

            var ballot = new Ballot();
            ballot.Candidates = sampleListOfCandidates;

            //Act
            var result = ballot.Vote(name);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void DisplayElectionResult_ResultShouldBeCorrect()
        {
            //Arrange
            var sampleListOfCandidates = GetSampleListOfCandidates();

            var ballot = new Ballot();
            ballot.Candidates = sampleListOfCandidates;            

            //Act
            var counter = 1;
            foreach (var candidate in ballot.Candidates)
            {
                for (int i = 0; i <= counter; i++)
                {
                    ballot.Vote(candidate._name);
                }

                counter++;
            }

            var expected = ballot.Candidates.Last();
            var actual = ballot.DisplayElectionResult();

            //Assert
            actual.Should().Contain(expected._name).And.Contain(expected._votes.ToString());
        }
    }
}
