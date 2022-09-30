namespace VotingSystem
{
    public class Candidate
    {
        public string _name;
        public int _votes;

        public Candidate(string name)
        {
            _name = name;
            _votes = 0;
        }

        public void AddVote()
        {
            _votes++;
        }

        public int GetVotes()
        {
            return _votes;
        }
    }
}