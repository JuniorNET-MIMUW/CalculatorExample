using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorExample.ViewModels;
using Xamarin.Forms;

namespace CalculatorExample
{
    public partial class MainPage : ContentPage
    {
        public ResultViewModel Result { get; }

        public MainPage()
        {
            InitializeComponent();
            Result = new ResultViewModel {NumericalResult = 5};
            BindingContext = Result;
            Zero.Clicked += NumButtonClickedFactory(0);
            One.Clicked += NumButtonClickedFactory(1);
            Two.Clicked += NumButtonClickedFactory(2);
            Three.Clicked += NumButtonClickedFactory(3);
            Four.Clicked += NumButtonClickedFactory(4);
            Five.Clicked += NumButtonClickedFactory(5);
            Six.Clicked += NumButtonClickedFactory(6);
            Seven.Clicked += NumButtonClickedFactory(7);
            Eight.Clicked += NumButtonClickedFactory(8);
            Nine.Clicked += NumButtonClickedFactory(9);
        }

        private void ClearButtonClicked(object sender, EventArgs e)
        {
            Result.NumericalResult = 0;
        }

        private EventHandler NumButtonClickedFactory(int number)
        {
            return delegate
            {
                Result.NumericalResult *= 10;
                Result.NumericalResult += number;
            };
        }

        private void PlusMinusButtonClicked(object sender, EventArgs e)
        {
            Result.NumericalResult *= -1;
        }

        private void PercentButtonClicked(object sender, EventArgs e)
        {
            Result.NumericalResult /= 100;
        }

        private void DivisionButtonClicked(object sender, EventArgs e)
        {
            if (Result.NumericalTemp == null)
            {
                Result.NumericalTemp = Result.NumericalResult;
                Result.NumericalResult = 0;
            }
            else
            {
                
            }
        }
    }
}
