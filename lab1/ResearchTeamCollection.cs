using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class ResearchTeamCollection
    {
        List<ResearchTeam> researchteams = new List<ResearchTeam>();
        public void AddDefaults()
        {
            for (int i = 0; i < 10; i++)
            {
                researchteams.Add(new ResearchTeam());
            }
        }
        public void AddResearchTeams(params ResearchTeam[] resteams)
        {
            researchteams.AddRange(resteams);
        }
        public override string ToString()
        {
            string ResearchTeamString = "";
            foreach (ResearchTeam research in researchteams)
            {
                ResearchTeamString += research.ToString();
            }
            return ResearchTeamString;
        }
        public string ToShortString()
        {
            string ResearchTeamString = "";
            foreach (ResearchTeam research in researchteams)
            {
                ResearchTeamString += research.ToShortString();
            }
            return ResearchTeamString;
        }
        public void SortByRegisterNumber()
        {
            researchteams.Sort((x, y) => x.RegistrationNumber.CompareTo(y.RegistrationNumber));
        }
        public void SortByTheme()
        {

            researchteams.Sort((x, y) => x.Access_theme.CompareTo(y.Access_theme));
        }
        public void SortByNumberOfPublications()
        {
            ResearchTeamComparer comp = new ResearchTeamComparer();
            researchteams.Sort(comp);
        }
        public int MinRegNumber
        {
            get
            {
                if (researchteams.Count == 0)
                {
                    return 0;
                }
                return researchteams.Min(teams => teams.RegistrationNumber);
            }
        }
        public IEnumerable<ResearchTeam> TwoYears
        {
            get
            {
                IEnumerable<ResearchTeam> TwoTearsL = researchteams.Where(time => time.Access_Last == TimeFrame.TwoYears);
                return TwoTearsL;
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < researchteams.Count; i++)
            {
                yield return researchteams[i];
            }
        }
        public List<ResearchTeam> Group(int value)
        {
            IEnumerable<IGrouping<int, ResearchTeam>> someGroup = researchteams.GroupBy(team => team.ListOfPapers.Count);

            foreach (IGrouping<int, ResearchTeam> teams in someGroup)
            {
                if (teams.Key == value)
                {
                    return teams.ToList();
                }
            }
            return null;
        }

    }
}
