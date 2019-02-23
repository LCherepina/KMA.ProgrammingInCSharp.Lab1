using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.ProgrammingInCSharp.Lab1.Annotations;
using KMA.ProgrammingInCSharp.Lab1.Managers;
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

        public DateTime Date
        {
            get { return _horoscope.Date; }
            set
            {
                if (value < DateTime.Today.AddYears(-135) || value > DateTime.Now)
                {

                    MessageBox.Show("Invalid date birth!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    _horoscope.Date = DateTime.Now;
                    CalculateWestSign();
                    CalculateChineseSign();
                    OnPropertyChanged(nameof(Date));
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(WAstrology));
                    OnPropertyChanged(nameof(ChAstrology));
                }
                else
                {
                    _horoscope.Date = value;

                }
            }
        }

        public int Age
        {
            get { return _horoscope.Age; }
            set { _horoscope.Age = value; }
        }

        public string WAstrology
        {
            get {return _horoscope.WAstrology;}
            set { _horoscope.WAstrology = value; }
        }

        public string ChAstrology
        {
            get { return _horoscope.ChAstrology;}
            set { _horoscope.ChAstrology = value; }
        }

            

//       
//    }




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
            if (Date.Day == DateTime.Now.Day && Date.Month == DateTime.Now.Month && (_horoscope.Age < 135 || _horoscope.Age >= 0))
            {
                MessageBox.Show("!!!!!!!!Happy Birthday!!!!!!!!!", "Greeting!", MessageBoxButton.OK);
            }
            if (Date.Month > DateTime.Now.Month ||
                (Date.Month == DateTime.Now.Month && Date.Day > DateTime.Now.Day))
            {
                _horoscope.Age = DateTime.Now.Year - _horoscope.Date.Year - 1;

            }
            else if (Date.Month < DateTime.Now.Month ||
                     (Date.Month == DateTime.Now.Month && Date.Day <= DateTime.Now.Day))
            {
                _horoscope.Age = DateTime.Now.Year - _horoscope.Date.Year;

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
            switch (( _horoscope.Date.Year - 4) % 12)
            {
                case 0:
                    _horoscope.ChAstrology = _chineseSigns[0];
                    break;
                case 1:
                    _horoscope.ChAstrology = _chineseSigns[1];
                    break;
                case 2:
                    _horoscope.ChAstrology = _chineseSigns[2];
                    break;
                case 3:
                    _horoscope.ChAstrology = _chineseSigns[3];
                    break;
                case 4:
                    _horoscope.ChAstrology = _chineseSigns[4];
                    break;
                case 5:
                    _horoscope.ChAstrology = _chineseSigns[5];
                    break;
                case 6:
                    _horoscope.ChAstrology = _chineseSigns[6];
                    break;
                case 7:
                    _horoscope.ChAstrology = _chineseSigns[7];
                    break;
                case 8:
                    _horoscope.ChAstrology = _chineseSigns[8];
                    break;
                case 9:
                    _horoscope.ChAstrology = _chineseSigns[9];
                    break;
                case 10:
                    _horoscope.ChAstrology = _chineseSigns[10];
                    break;
                case 11:
                    _horoscope.ChAstrology = _chineseSigns[11];
                    break;
                case 12:
                    _horoscope.ChAstrology = _chineseSigns[12];
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
                OnPropertyChanged(nameof(_horoscope.Age));
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
