using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeamCollection Universities = new ResearchTeamCollection(); // создаем коллекцию, с которой будет проводить свои опыты
            var Un1 = new ResearchTeam("Physics", "Misis", 0, TimeFrame.TwoYears); // добавим в нее 4 организации, занимающиеся исследованиями,
                                                                               // где будет разное количество записей, для наглядности последующих действий
            Un1.AddPapers(new Paper());
            Un1.AddPapers(new Paper());
            Un1.AddPapers(new Paper());
            Universities.AddResearchTeams(Un1);
            var Un2 = new ResearchTeam("Information systems and technologies", "Mirea", 1, TimeFrame.Year);
            Un2.AddPapers(new Paper());
            Universities.AddResearchTeams(Un2);
            var Un3 = new ResearchTeam("Programming", "Mstu", 3, TimeFrame.Year);
            Un3.AddPapers(new Paper());
            Un3.AddPapers(new Paper());
            Universities.AddResearchTeams(Un3);
            var Un4 = new ResearchTeam("Mechanics and Mathematics", "PSU", 2, TimeFrame.Year);
            Un4.AddPapers(new Paper());
            Universities.AddResearchTeams(Un4);
            Console.WriteLine(Universities); //выводим нашу полную коллекцию из организаций
            Console.WriteLine();

            Universities.SortByRegisterNumber(); //производим сортировку по рег. номеру 
            Console.WriteLine("Отсортировано по рег. номеру:");
            foreach (ResearchTeam t in Universities) // проверяем сортировку
            {
                Console.WriteLine(t.ToShortString());
            }

            Universities.SortByTheme(); //аналогично проводим сортировку нашей коллекции по теме исследований
            Console.WriteLine();
            Console.WriteLine("Отсортировано по теме:");
            foreach (ResearchTeam t in Universities)
            {
                Console.WriteLine(t.ToShortString());
            }

            Universities.SortByNumberOfPublications(); //теперь проводим сортировку по количеству публикаций 
            Console.WriteLine();
            Console.WriteLine("Отсортировано по количеству публикаций:");
            foreach (ResearchTeam t in Universities)
            {
                Console.WriteLine(t.ToShortString());
            }

            Console.WriteLine($"Минимальный регистрационный номер: {Universities.MinRegNumber.ToString()}");
            Console.WriteLine();

            Console.WriteLine("Фильтр на \"TwoYears\": ");
            foreach (var twoyears in Universities.TwoYears.ToList())
                Console.WriteLine(twoyears.ToShortString());
            Console.WriteLine();

            Console.WriteLine("с 3 публикациями: ");
            foreach (var persons in Universities.Group(3).ToList())
                Console.WriteLine(persons.ToShortString());
            Console.WriteLine();
            Console.WriteLine("с 2 публикациями: ");
            foreach (var persons in Universities.Group(2).ToList())
                Console.WriteLine(persons.ToShortString());
            Console.WriteLine();
            Console.WriteLine("с 1 публикацией: ");
            foreach (var persons in Universities.Group(1).ToList())
                Console.WriteLine(persons.ToShortString());

            TeamCollections test = new TeamCollections(1);
            test.TimeOfSearching();
        }
    }
}


