using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab1
{
    class TeamCollections
    {
        List<Team> ListOfTeam = new List<Team>();
        List<string> ListOfString = new List<string>();
        Dictionary<Team, ResearchTeam> DictionaryOfTeamAndResearchTeam = new Dictionary<Team, ResearchTeam>();
        Dictionary<string, ResearchTeam> DictionaryOfStringAndResearchTeam = new Dictionary<string, ResearchTeam>();
        public TeamCollections(int Count)
        {
            for (int i = 0; i < Count; i++)
            {
                ListOfTeam.Add(new Team());
                DictionaryOfTeamAndResearchTeam.Add(new Team(), new ResearchTeam());
                ListOfString.Add(" ");
                DictionaryOfStringAndResearchTeam.Add(" ", new ResearchTeam());
            }
        }
        public void TimeOfSearching()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            ListOfTeam.Contains(ListOfTeam[0]);
            ListOfTeam.Contains(ListOfTeam[ListOfTeam.Count / 2]);
            ListOfTeam.Contains(ListOfTeam[ListOfTeam.Count - 1]);
            stopwatch.Stop();
            Console.WriteLine($"Time to find element in List<Team>: {stopwatch.Elapsed}");

            Stopwatch stopwatch1 = new Stopwatch();
            stopwatch1.Start();
            ListOfString.Contains(ListOfString[0]);
            ListOfString.Contains(ListOfString[ListOfString.Count / 2]);
            ListOfString.Contains(ListOfString[ListOfString.Count - 1]);
            stopwatch1.Stop();
            Console.WriteLine($"Time to find element in List<string>: {stopwatch1.Elapsed}");

            var first = DictionaryOfTeamAndResearchTeam.First();
            Team key = first.Key;
            var middle = DictionaryOfTeamAndResearchTeam.ElementAt(DictionaryOfTeamAndResearchTeam.Count / 2);
            Team keymiddle = middle.Key;
            var last = DictionaryOfTeamAndResearchTeam.Last();
            Team keylast = last.Key;

            var first1 = DictionaryOfStringAndResearchTeam.First();
            ResearchTeam key1 = first1.Value;
            var middle1 = DictionaryOfStringAndResearchTeam.ElementAt(DictionaryOfStringAndResearchTeam.Count / 2);
            ResearchTeam keymiddle1 = middle1.Value;
            var last1 = DictionaryOfStringAndResearchTeam.Last();
            ResearchTeam keylast1 = last1.Value;

            Stopwatch stopwatch2 = new Stopwatch();
            stopwatch2.Start();
            DictionaryOfTeamAndResearchTeam.ContainsKey(key);
            DictionaryOfTeamAndResearchTeam.ContainsKey(keymiddle);
            DictionaryOfTeamAndResearchTeam.ContainsKey(keylast);
            stopwatch2.Stop();
            Console.WriteLine($"Time to find element in Dictionary<Team, ResearchTeam>: {stopwatch2.Elapsed}");
            Stopwatch stopwatch3 = new Stopwatch();
            stopwatch3.Start();
            DictionaryOfStringAndResearchTeam.ContainsValue(key1);
            DictionaryOfStringAndResearchTeam.ContainsValue(keymiddle1);
            DictionaryOfStringAndResearchTeam.ContainsValue(keylast1);
            stopwatch3.Stop();
            Console.WriteLine($"Time to find element in Dictionary<string,ResearchTeam>: {stopwatch3.Elapsed}");

        }
    }
}
