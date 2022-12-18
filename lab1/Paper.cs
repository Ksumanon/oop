using System;
namespace lab1
{
    class Paper //Создаем класс Paper, который имеет три открытых автореализуемых свойства, доступных для чтения и записи
    {
        public string NameP { get; set; } //создаем свойство типа string, в котором хранится название публикации
        public Person Author { get; set; } //создаем свойство типа Person для автора публикации
        public DateTime Data { get; set; } //создаем свойство типа DateTime c датой публикации

        //создаем конструктор c параметрами типа string, Person, DateTime для инициализации всех свойств класса;
        public Paper(string name, Person author, DateTime data)
        {
            NameP = name;
            Author = author;
            Data = data;
        }

        //создаем конструктор без параметров, инициализирующий все свойства класса некоторыми значениями по умолчанию,
        //для типа Person мы берем значения по умолчанию, созданные в соответсвующем классе
        public Paper() : this("Default_NameP", new Person(), new DateTime(2000, 1, 1))
        { }


        // перегруженную(override) версию виртуального метода string To-String() для формирования строки со значениями всех полей класса
        public override string ToString()
        {

            return string.Format("Book {0} written by {1} in {2}", NameP, Author, Data);
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
            { return false; }
            Paper objPaper = obj as Paper;
            if (obj as Paper == null)
            { return false; }
            return objPaper.NameP == NameP && objPaper.Author == Author && objPaper.Data == Data;
        }
        public static bool operator ==(Paper left, Paper right)
        {
            //будем сравнивать "левый" объект и "правый" объект
            if (Equals(left, right))
            { return true; }
            if ((object)left == null || (object)right == null)
            { return false; }
            return left.NameP == right.NameP && left.Author == right.Author && left.Data == right.Data;
        }
        public static bool operator !=(Paper left, Paper right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            return NameP.GetHashCode() + Author.GetHashCode() + Data.GetHashCode();
        }
        public object DeepCopy()
        {
            Paper copy = new Paper(this.NameP, this.Author, this.Data);
            return copy;
        }
    }
}
