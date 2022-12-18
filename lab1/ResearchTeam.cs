using System;
using System.Collections;
using System.Security.Cryptography;

namespace lab1
{
    //Создаем тип TimeFrame перечисление(enum) со значениями Year, TwoYears, Long.
    enum TimeFrame { Year, TwoYears, Long }
    //Создаем класс ResearchTeam, который имеет
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    //Team, //INameAndCopy
    {
        private string Theme; //закрытое поле типа string c названием темы исследований
        private string NameOfOrg; //закрытое поле типа string с названием организации
        private int NumberOfRed; //закрытое поле типа int - регистрационный номер
        private TimeFrame last; //закрытое поле типа TimeFrame для информации о продолжительности исследований
        private Paper[] Publications; //закрытое поле типа Paper[], в котором хранится список публикаций
        //ArrayList ListOfAuthors = new ArrayList();
        //ArrayList ListOfPublications = new ArrayList();
        public List<Person> ListOfPersons = new List<Person>();
        public List<Paper> ListOfPapers = new List<Paper>();
        //В классе ResearchTeam определить конструкторы
        //Конструктор c параметрами типа string, string, int, TimeFrame для инициализации соответствующих полей класса
        public ResearchTeam(string theme, string nameoforg, int numberofred, TimeFrame Last)
        {
            Theme = theme;
            NameOfOrg = nameoforg;
            RegNumber = numberofred;
            last = Last;

        }

        //Конструктор без параметров, инициализирующий поля класса значениями по умолчанию
        public ResearchTeam()
            : this("Theme", "NameOrg", 0, TimeFrame.Year) //конструктор без параметров
                                                          //инициализирующий поля класса значениями по умолчанию
        { }

        //В классе ResearchTeam определить свойства c методами get и set
        //Cвойство типа string для доступа к полю с названием темы исследований
        public string Access_theme
        {
            set
            {
                Theme = value;
            }
            get
            {
                return Theme;
            }
        }

        //Cвойство типа string для доступа к полю с названием организации
        public string Access_nameofogr
        {
            set
            {
                NameOfOrg = value;
            }
            get
            {
                return NameOfOrg;
            }
        }

        //Cвойство типа int для доступа к полю с номером регистрации
        public int Access_numberofred
        {
            set
            {
                NumberOfRed = value;
            }
            get
            {
                return NumberOfRed;
            }
        }

        //Cвойство типа TimeFrame для доступа к полю с продолжительностью исследований
        public TimeFrame Access_Last
        {
            set
            {
                last = value;
            }
            get
            {
                return last;
            }
        }

        //Cвойство типа Paper[] для доступа к полю со списком публикаций по теме исследований
        public Paper[] Access_publications
        {
            set
            {
                Publications = value;
            }
            get
            {
                return Publications;
            }
        }

        //Cвойство типа Paper ( только с методом get), которое возвращает ссылку на публикацию с самой поздней датой выхода;
        //если список публикаций пустой, свойство возвращает значение null
        public Paper LastPublic
        {
            get
            {
                if (ListOfPapers == null)//проверка на то, что список пуст
                    return null;
                else
                {
                    return (Paper)ListOfPapers[ListOfPapers.Count - 1];
                }

            }
        }
        //создаем индексатор булевского типа (только с методом get) с одним параметром
        //типа TimeFrame; значение индикатора равно true, если значение поля с
        //информацией о продолжительности исследований совпадает со значением
        //индекса, и false в противном случае;
        public bool this[TimeFrame rez_prov]
        {
            get
            {
                bool rez;
                if (rez_prov == last) rez = true;
                else rez = false;
                return rez;
            }
        }

        //создаем void AddPapers ( params Paper[] ) для добавления элементов в список публикаций
        public void AddPapers(params Paper[] AdditionalPapers)
        {
            ListOfPapers.AddRange(AdditionalPapers);
        }


        //перегруженную версию виртуального метода string ToString() для
        //формирования строки со значениями всех полей класса, включая список
        //публикаций
        public override string ToString()
        {
            string PublicationString = "";

            foreach (Paper sp in ListOfPapers)
            {
                PublicationString += sp.ToString() + "\n";
            }
            return string.Format("\nТема исследований - " + Theme + "; Наименование организации- " + NameOfOrg + "; Номер регистрации - " + RegNumber.ToString() + "; Время - " + last.ToString() + "\n " + PublicationString);
            // return string.Format(PublicationString);

        }

        //Виртуальный метод string ToShortString(), который формирует строку
        //со значениями всех полей класса без списка публикаций
        public string ToShortString()
        {
            return string.Format("\nТема исследований - " + Theme.ToString() + "; Наименование организации- " + NameOfOrg.ToString() + "; Номер регистрации - " + RegNumber.ToString() + "; Время - " + last.ToString());
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            ResearchTeam objResearchTeam = obj as ResearchTeam;
            if (obj as ResearchTeam == null)
            { return false; }
            return objResearchTeam.Theme == Theme && objResearchTeam.NameOfOrg == NameOfOrg && objResearchTeam.NumberOfRed == NumberOfRed && objResearchTeam.last == last && objResearchTeam.Publications == Publications;
        }
        public static bool operator ==(ResearchTeam left, ResearchTeam right)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(left, right))
            { return true; }
            if ((object)left == null || (object)right == null)
            { return false; }
            return left.Theme == right.Theme && left.NameOfOrg == right.NameOfOrg && left.NumberOfRed == right.NumberOfRed && left.last == right.last && left.Publications == right.Publications;
        }
        public static bool operator !=(ResearchTeam left, ResearchTeam right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return Theme.GetHashCode() + NameOfOrg.GetHashCode() + NumberOfRed.GetHashCode() + last.GetHashCode() + Publications.GetHashCode();
        }

        public object DeepCopy()
        {
            ResearchTeam CopyTeam = new ResearchTeam(this.Theme, this.NameOfOrg, this.NumberOfRed, this.last);
            CopyTeam.ListOfPersons = ListOfPersons;
            CopyTeam.ListOfPapers = ListOfPapers;
            return CopyTeam;

        }
        //public List Access_ListOfPublications { get { return ListOfPapers; } set { ListOfPublications = value; } }
        //public List Access_ListOfAuthors { get { return ListOfAuthors; } set { ListOfAuthors = value; } }
        public void AddMembers(params Person[] Members)
        {
            ListOfPersons.AddRange(Members);
        }
        public Team TeamType
        {
            get
            {
                return new Team(NameOfOrg, RegNumber);
            }
            set
            {
                NameOfOrg = value.NameOfOrg;
                RegistrationNumber = value.RegistrationNumber;
            }
        }
        public IEnumerable<Person> MembersWithoutPublications()
        {
            ArrayList AutorsWithoutPublic = new ArrayList();
            bool someBool;
            foreach (Person pers in ListOfPersons)
            {
                someBool = true;
                foreach (Paper pap in ListOfPapers)
                {
                    if (pap.Author == pers)
                    {
                        someBool = false;
                        break;
                    }
                }
                if (someBool)
                {
                    AutorsWithoutPublic.Add(pers);
                }

            }
            for (int i = 0; i < AutorsWithoutPublic.Count; i++)
            {
                yield return (Person)AutorsWithoutPublic[i];
            }

        }
        public IEnumerable<Paper> LastPapers(int n)
        {
            for (int i = 0; i < ListOfPapers.Count; i++)
            {
                if (((Paper)ListOfPapers[i]).Data.Year >= DateTime.Now.Year - n)
                {
                    yield return (Paper)ListOfPapers[i];

                    //Console.Write(((Paper)ListOfPublications[i]).ToString());
                }
            }
        }
        public int Compare(ResearchTeam? x, ResearchTeam? y)
        {
            return x.CompareTo(y);
        }
        string INameAndCopy.Name { get; set; }
    }
}