using System;

namespace KMA.ProgrammingInCSharp.Lab1
{
    class Horoscope
    {

        #region Properties

        public DateTime Date { get; set; }

        public int Age { get; set; }

        public string WAstrology { get; set; }

        public string ChAstrology { get; set; }

        #endregion

        public Horoscope()
        {
            Age = 0;
            Date = DateTime.Now;
            WAstrology = "";
            ChAstrology = "";
        }
    }
}