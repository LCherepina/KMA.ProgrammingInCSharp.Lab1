using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using KMA.ProgrammingInCSharp.Lab1.Annotations;

namespace KMA.ProgrammingInCSharp.Lab1
{
    class MainViewViewModel : INotifyPropertyChanged
    {
        #region Fields

        private DateTime _dateTime=DateTime.Now;
        private readonly string[] _westSigns = { "Capricorn","Aquarius","Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio" , "Sagittarius" };
        private readonly string[] _chineseSigns =  { "Rat","Ox","Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey","Rooster","Dog","Pig"};
        #region Commands
        private ICommand _calculateCommand;
        #endregion

        #endregion

        #region Properties

        public DateTime Date
        {
            get { return _dateTime;}
            set
            {
                if (value < DateTime.Today.AddYears(-135) || value > DateTime.Now)
                {

                    MessageBox.Show("Invalid date birth!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    _dateTime = DateTime.Now;
                    CalculateWestSign();
                    CalculateChineseSign();
                    OnPropertyChanged(nameof(Date));
                    OnPropertyChanged(nameof(Age));
                    OnPropertyChanged(nameof(WAstrology));
                    OnPropertyChanged(nameof(ChAstrology));
                }
                else { 
                    _dateTime = value;
          
                }
            }
        }

        public int Age { get; set; }

        public string WAstrology { get; set; }

        public string ChAstrology { get; set; }

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


        private void CalculateAge()
        {
            if (_dateTime.Day == DateTime.Now.Day && _dateTime.Month == DateTime.Now.Month && (Age < 135 || Age >= 0))
            {
                MessageBox.Show("!!!!!!!!Happy Birthday!!!!!!!!!", "Greeting!", MessageBoxButton.OK);
            }
            if (_dateTime.Month > DateTime.Now.Month ||
                (_dateTime.Month == DateTime.Now.Month && _dateTime.Day > DateTime.Now.Day))
            {
                Age = DateTime.Now.Year - _dateTime.Year - 1;

            }
            else if (_dateTime.Month < DateTime.Now.Month ||
                     (_dateTime.Month == DateTime.Now.Month && _dateTime.Day <= DateTime.Now.Day))
            {
                Age = DateTime.Now.Year - _dateTime.Year;

            }

        }

        private void CalculateWestSign()
        {
            switch (_dateTime.Month)
            {
                case 1:
                    WAstrology = _dateTime.Day >= 20 ? _westSigns[1] : _westSigns[0];
                    break;
                case 2:
                    WAstrology = _dateTime.Day >= 19 ? _westSigns[2] : _westSigns[1];
                    break;
                case 3:
                    WAstrology = _dateTime.Day >= 21 ? _westSigns[3] : _westSigns[2];
                    break;
                case 4:
                    WAstrology = _dateTime.Day >= 20 ? _westSigns[4] : _westSigns[3];
                    break;
                case 5:
                    WAstrology = _dateTime.Day >= 21 ? _westSigns[5] : _westSigns[4];
                    break;
                case 6:
                    WAstrology = _dateTime.Day >= 21 ? _westSigns[6] : _westSigns[5];
                    break;
                case 7:
                    WAstrology = _dateTime.Day >= 23 ? _westSigns[7] : _westSigns[6];
                    break;
                case 8:
                    WAstrology = _dateTime.Day >= 23 ? _westSigns[8] : _westSigns[7];
                    break;
                case 9:
                    WAstrology = _dateTime.Day >= 23 ? _westSigns[9] : _westSigns[8];
                    break;
                case 10:
                    WAstrology = _dateTime.Day >= 23 ? _westSigns[10] : _westSigns[9];
                    break;
                case 11:
                    WAstrology = _dateTime.Day >= 22 ? _westSigns[11] : _westSigns[10];
                    break;
                case 12:
                    WAstrology = _dateTime.Day >= 22 ? _westSigns[0] : _westSigns[11];
                    break;

            }

        }

        private void CalculateChineseSign()
        {
            switch ((_dateTime.Year - 4) % 12)
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
            await Task.Run(() =>
            {
                CalculateAge();
                CalculateWestSign();
                CalculateChineseSign();
                OnPropertyChanged(nameof(Age));
                OnPropertyChanged(nameof(WAstrology));
                OnPropertyChanged(nameof(ChAstrology));

                return true;
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
