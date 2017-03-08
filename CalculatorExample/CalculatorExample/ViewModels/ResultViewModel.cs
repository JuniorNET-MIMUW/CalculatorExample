using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CalculatorExample.Annotations;

namespace CalculatorExample.ViewModels
{
    public class ResultViewModel : INotifyPropertyChanged
    {
        public string Result => NumericalResult.ToString();

        public double NumericalResult
        {
            get { return _numericalResult; }
            set
            {
                _numericalResult = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Result));
            }
        }

        public string TempResult 
            => NumericalTemp == null ? string.Empty : NumericalTemp.Value.ToString();

        public double? NumericalTemp
        {
            get { return _numericalTemp; }
            set
            {
                _numericalTemp = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TempResult));
            }
        }

        private double? _numericalTemp;

        private double _numericalResult;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static implicit operator double(ResultViewModel model)
        {
            return model.NumericalResult;
        }

        public static ResultViewModel operator *(ResultViewModel model, double value)
        {
            return new ResultViewModel {NumericalResult = value * model.NumericalResult};
        }
    }
}
