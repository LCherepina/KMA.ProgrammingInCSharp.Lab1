using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.ProgrammingInCSharp.Lab1.Annotations;
using KMA.ProgrammingInCSharp.Lab1.Managers;
using KMA.ProgrammingInCSharp.Lab1.Models;
using KMA.ProgrammingInCSharp.Lab1.Tools;

namespace KMA.ProgrammingInCSharp.Lab1.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields

        private Horoscope _horoscope;

        private readonly string[] _westSigns = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius" };
        private readonly string[] _chineseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        #region Commands
        private ICommand _calculateCommand;
        #endregion

        #endregion

        #region Properties

        public Horoscope Horoscope
        {
            get { return _horoscope; }
            set
            {
                _horoscope = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date {
            get { return _horoscope.Date; }

            set { _horoscope.Date = value; }
        }

        

        public string Age
        {
            get
            {
                return _horoscope.Age;
            }
            set { _horoscope.Age = value; }
        }

        public string WAstrology
        {
            get { return _horoscope.WSign; }
            set { _horoscope.WSign = value; }
        }

        public string ChAstrology
        {
            get { return _horoscope.ESign;}
            set { _horoscope.ESign = value; }
        }


        #region Commands
        public ICommand CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new RelayCommand<KeyEventArgs>(Calculate));
            }
        }
        #endregion

        #endregion

        public MainViewViewModel()
        {
            _horoscope = new Horoscope();
        }


        private void CalculateAge()
        {
            if (Date.Day == DateTime.Now.Day && Date.Month == DateTime.Now.Month && (Date >= DateTime.Today.AddYears(-135) || Date >= DateTime.Now) )
            {
                MessageBox.Show("!!!!!!!!Happy Birthday!!!!!!!!!", "Greeting!", MessageBoxButton.OK);
            }
            if (Date < DateTime.Today.AddYears(-135) || Date > DateTime.Now)
            {

                MessageBox.Show("Invalid date birth!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                Date = DateTime.Now;
            }

            
            if (Date.Month > DateTime.Now.Month ||
                (Date.Month == DateTime.Now.Month && Date.Day > DateTime.Now.Day))
            {
                Age = (DateTime.Now.Year - Date.Year - 1).ToString();

            }
            else if (Date.Month < DateTime.Now.Month ||
                     (Date.Month == DateTime.Now.Month && Date.Day <= DateTime.Now.Day))
            {
                Age = (DateTime.Now.Year - Date.Year).ToString();

            }

        }

        private void CalculateWestSign()
        {
            switch (Date.Month)
            {
                case 1:
                    WAstrology = Date.Day >= 20 ? _westSigns[1] : _westSigns[0];
                    break;
                case 2:
                    WAstrology = Date.Day >= 19 ? _westSigns[2] : _westSigns[1];
                    break;
                case 3:
                    WAstrology = Date.Day >= 21 ? _westSigns[3] : _westSigns[2];
                    break;
                case 4:
                    WAstrology = Date.Day >= 20 ? _westSigns[4] : _westSigns[3];
                    break;
                case 5:
                    WAstrology = Date.Day >= 21 ? _westSigns[5] : _westSigns[4];
                    break;
                case 6:
                    WAstrology = Date.Day >= 21 ? _westSigns[6] : _westSigns[5];
                    break;
                case 7:
                    WAstrology = Date.Day >= 23 ? _westSigns[7] : _westSigns[6];
                    break;
                case 8:
                    WAstrology = Date.Day >= 23 ? _westSigns[8] : _westSigns[7];
                    break;
                case 9:
                    WAstrology = Date.Day >= 23 ? _westSigns[9] : _westSigns[8];
                    break;
                case 10:
                    WAstrology = Date.Day >= 23 ? _westSigns[10] : _westSigns[9];
                    break;
                case 11:
                    WAstrology = Date.Day >= 22 ? _westSigns[11] : _westSigns[10];
                    break;
                case 12:
                    WAstrology = Date.Day >= 22 ? _westSigns[0] : _westSigns[11];
                    break;

            }

           
        }

        private void CalculateChineseSign()
        {
            switch (( Date.Year - 4) % 12)
            {
                case 0:
                    ChAstrology = _chineseSigns[0];
                    break;
                case 1:
                    ChAstrology = _chineseSigns[1];
                    break;
                case 2:
                    ChAstrology = _chineseSigns[2];
                    break;
                case 3:
                    ChAstrology = _chineseSigns[3];
                    break;
                case 4:
                    ChAstrology = _chineseSigns[4];
                    break;
                case 5:
                    ChAstrology = _chineseSigns[5];
                    break;
                case 6:
                    ChAstrology = _chineseSigns[6];
                    break;
                case 7:
                    ChAstrology = _chineseSigns[7];
                    break;
                case 8:
                    ChAstrology = _chineseSigns[8];
                    break;
                case 9:
                    ChAstrology = _chineseSigns[9];
                    break;
                case 10:
                    ChAstrology = _chineseSigns[10];
                    break;
                case 11:
                    ChAstrology = _chineseSigns[11];
                    break;
                case 12:
                    ChAstrology = _chineseSigns[12];
                    break;
            }
        }

        private async void Calculate(KeyEventArgs args)
        {
            LoaderManager.Instance.ShowLoader();
            await Task.Run(() =>
            {
                CalculateAge();
                CalculateWestSign();
                CalculateChineseSign();
                OnPropertyChanged(nameof(Date));
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(WAstrology));
                OnPropertyChanged(nameof(ChAstrology));
                OnPropertyChanged();

                return true;
            });
            LoaderManager.Instance.HideLoader();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
