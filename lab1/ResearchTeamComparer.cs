using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam? x, ResearchTeam? y)
        {
            return x.ListOfPapers.Count.CompareTo(y.ListOfPapers.Count);
        }
    }
}
