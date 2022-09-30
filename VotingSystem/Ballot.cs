using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystem
{
    public class Ballot
    {
        public string? ElectionWinner { get; set; }
        public int WinnerTotalVotes { get; set; }
        public List<Candidate> Candidates { get; set; }
        public bool ElectionIsActive { get; set; }

        public Ballot()
        {
            ElectionWinner = "";
            WinnerTotalVotes = 0;
            Candidates = new List<Candidate>();
            ElectionIsActive = false;
        }

        public void BeginOrEndElection()
        {
            ElectionIsActive = !ElectionIsActive;
        }

        public bool RegisterCandidate(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var candidate = new Candidate(name);
                Candidates.Add(candidate);

                return true;
            }

            return false;
        }

        public bool Vote(string name)
        {
            var chosenCandidate = Candidates.Where(x => x._name.ToUpperInvariant() == name.ToUpperInvariant()).FirstOrDefault();

            if (chosenCandidate is not null)
            {
                chosenCandidate.AddVote();

                return true;
            }

            return false;
        }

        public string DisplayElectionResult()
        {
            var winner = Candidates.OrderByDescending(x => x.GetVotes()).ThenBy(x => x._name).FirstOrDefault();

            return $"Winner: {winner!._name} \nTotal votes: {winner._votes}";
        }
    }
}
