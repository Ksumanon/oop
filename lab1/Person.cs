using System;
namespace lab1
{
    public class Person //создаем класс Person
    {
        private string name; //создаем закрытое поле типа string, в котором хранится имя
        private string lastName; //создаем закрытое поле типа string, в котором хранится фамилия
        private DateTime BDate;//закрытое поле типа System.DateTime для даты рождения


        //создаем конструктор c тремя параметрами типа string, string, DateTime для инициализации всех полей класса
        public Person(string studentName, string studentLastName, DateTime studentBDate)
        {
            name = studentName;
            lastName = studentLastName;
            BDate = studentBDate;
        }

        //конструктор без параметров, инициализирующий все поля класса некоторыми значениями по умолчанию.
        public Person() : this("Default_Name", "Default_Sname", new DateTime(1970, 1, 1))
        { }

        // Свойства c методами get и set: 

        string Access_Name //создаем свойство типа string для доступа к полю с именем;
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }

        }

        string Access_LastName //создаем свойство типа string для доступа к полю с фамилией
        {
            set
            {
                lastName = value;
            }
            get
            {
                return lastName;
            }

        }

        DateTime Access_BDate //создаем свойство типа DateTime для доступа к полю с датой рождения
        {
            set
            {
                BDate = value;
            }
            get
            {
                return BDate;
            }

        }

        //создаем свойство типа int c методами get и set для получения информации(get) и изменения (set) года рождения
        //в закрытом поле типа DateTime, в котором хранится дата рождения
        int GS_Bdate
        {
            get
            {
                return Convert.ToInt32(BDate);
            }
            set
            {
                BDate = Convert.ToDateTime(value);
            }
        }


        //Перегруженную(override) версию виртуального метода string ToString()
        //для формирования строки со значениями всех полей класса       
        public override string ToString()
        {
            return string.Format("{0} {1},\n родившегося {2}", name, lastName, BDate, ',');
        }


        //Виртуальный метод string ToShortString(), который возвращает строку, содержащую только имя и фамилию.
        public string ToShortString()
        {
            return "\n" + "Имя: " + name + "\n" + "Фамилия: " + lastName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Person objPerson = obj as Person;
            if (obj as Person == null)
            { return false; }
            return objPerson.Access_Name == name && objPerson.Access_LastName == lastName && objPerson.Access_BDate == BDate;
        }
        public static bool operator ==(Person left, Person right)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(left, right))
            { return true; }
            if ((object)left == null || (object)right == null)
            { return false; }
            return left.Access_Name == right.Access_Name && left.Access_LastName == right.Access_LastName && left.Access_BDate == right.Access_BDate;
        }
        public static bool operator !=(Person left, Person right)
        {
            return !(left == right);
        }
        public object DeepCopy()
        {
            Person copy = new Person(this.Access_Name, this.Access_LastName, this.Access_BDate);
            return copy;
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = Access_Name.ToCharArray();
            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            char[] SurnameChar = Access_LastName.ToCharArray();
            foreach (char ch in SurnameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += Access_BDate.Year * Access_BDate.Month * Access_BDate.Day;
            return hashcode;
        }
    }
}