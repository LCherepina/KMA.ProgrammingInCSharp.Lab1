using System;

namespace KMA.ProgrammingInCSharp.Lab1.Models
{
    class Horoscope
    {
        private DateTime _dateTime = DateTime.Now;
        private string _age;
        private string _wSign;
        private string _eSign;
        public DateTime Date{
            get{return _dateTime;}
            set { _dateTime = value; }
        }

        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string WSign
        {
            get { return _wSign; }
            set { _wSign = value; }
        }

        public string ESign
        {
            get { return _eSign; }
            set { _eSign = value; }
        }

    }
}


