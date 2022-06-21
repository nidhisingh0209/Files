using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment21
{
    public class RelayCommand: INotifyPropertyChanged
    {
        private Number n1 = new Number();
        int num, num1;

        public RelayCommand AddNew { get; set; }

        private string _number1;

        public string FirstArgument
        {
            get { return _number1; }

            set
            {
                this._number1 = value;
                if(int.TryParse(_number1.ToString(), out num))
                {
                     this.n1.number1 = num;
                    this.OnPropertychanged("FirstArgument");
                }
                else
                {
                    MessageBox.Show("The given value is not a Number");
                }
            }
        }

        private bool OnPropertychanged(string v)
        {
            return true;
        }

        private string _number2;

        public string SecondArgument
        {
            get { return _number2; }
            set
            {
                {
                    this._number2 = value;
                    if (int.TryParse(_number1.ToString(), out num))
                    {
                        this.n1.number2 = num;
                        this.OnPropertychanged("SecondArgument");
                    }
                    else
                    {
                        MessageBox.Show("The given value is not a Number");
                    }
                }
            }
        }

        private string _number3;
        private Action<object> value1;
        private Func<object, bool> value2;

        public string Addedargument
        {
            get { return _number3; }

            set
            {
                this._number3 = value;
                this.OnPropertychanged("Addedargument");
            }
        }

        public RelayCommand()
        {
            AddNew = new RelayCommand(o => AddNumbers(), o => true);
        }

        public RelayCommand(Action<object> value1, Func<object, bool> value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }

        private void AddNumbers()
        {
            var number1 = this.FirstArgument;
            var number2 = this.SecondArgument;
            var sum = (Convert.ToInt32(number1) + Convert.ToInt32(number2));
            Addedargument = sum.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
 
