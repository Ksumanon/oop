using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Team : INameAndCopy, IComparable
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        protected string NameOfOrganisation;
        protected int RegNumber;
        public Team(string NameOfOrg, int RegNumbers)
        {
            NameOfOrganisation = NameOfOrg;
            RegNumber = RegNumbers;
        }
        public Team() : this("NameOrg", 0) { }
        public string NameOfOrg
        {
            set { NameOfOrganisation = value; }
            get { return NameOfOrganisation; }
        }
        public int RegistrationNumber
        {
            get { return RegNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be more or equals 0 ");
                }
                else
                {
                    RegNumber = value;
                }
            }
        }
        public override bool Equals(object obj) //благодаря виртуальному методу реализованного посредством сравнения значения имени организации и рег номера и проверки на пустоту
        {
            if (obj == null)
            { return false; }
            Team objTeam = obj as Team;
            if (obj as Team == null)
            { return false; }
            return objTeam.NameOfOrganisation == NameOfOrganisation && objTeam.RegNumber == RegNumber;
        }
        public static bool operator ==(Team left, Team right) //с помощью Equals мы проверяем равны ли значения для для левой и правой  части
        {
            //сравниваем "левый" объект и "правый" объект
            if (Equals(left, right))
            { return true; }
            if ((object)left == null || (object)right == null) //проверяем, пустой ли он
            { return false; }
            return left.NameOfOrganisation == right.NameOfOrganisation && left.RegNumber == right.RegNumber;
        }
        public static bool operator !=(Team left, Team right)//проверяем их НЕ равенство
        {
            return !(left == right);
        }
        public object DeepCopy()
        {
            Team copy = new Team(this.NameOfOrganisation, this.RegNumber);
            return copy;
        }
        public override int GetHashCode()
        {
            int hashcode = 0;
            char[] NameChar = NameOfOrganisation.ToCharArray();

            foreach (char ch in NameChar)
            {
                hashcode += Convert.ToInt32(ch);
            }
            hashcode += RegNumber;
            return hashcode;
        }
        public override string ToString()
        {

            return string.Format("Registration number of organisation {0} is {1} ", NameOfOrganisation, RegNumber);
        }
        public int CompareTo(object obj)
        {
            Team tmp = obj as Team;
            if (tmp == null)
            {
                throw new ArgumentException("Wrong type!");
            }
            return RegNumber.CompareTo(tmp.RegNumber);
        }
    }
}