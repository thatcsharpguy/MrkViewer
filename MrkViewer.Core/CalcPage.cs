using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MrkViewer.Core
{
    public class CalcPage : ContentPage
    {
        Grid _layout;

        Button _b0, _b1, _b2, _b3, _b4, _b5, _b6, _b7;
        Button _calculateBtn, _plusBtn, _minusBtn, _clearBtn;
        Label _resultDisplay;

        string firstNumber, secondNumber, oper;

        public CalcPage()
        {
            _layout = CreateGridLayout();

            CreateUiElements();

            WireEvents();

            // Trick to make our calculater fullscreen
            var relativeLayout = new RelativeLayout();
            relativeLayout.Children.Add(_layout, // <= Original layout
                Constraint.Constant(0),
                Constraint.Constant(0),
                Constraint.RelativeToParent(p => p.Width),
                Constraint.RelativeToParent(p => p.Height));
            Content = relativeLayout;
        }

        private void WireEvents()
        {
            _b0.Clicked += OnNumericButtonClicked;
            _b1.Clicked += OnNumericButtonClicked;
            _b2.Clicked += OnNumericButtonClicked;
            _b3.Clicked += OnNumericButtonClicked;

            _calculateBtn.Clicked += OnControlButtonClicked;

            _clearBtn.Clicked += OnClearButtonClicked;
        }


        #region Events

        void OnClearButtonClicked(object sender, EventArgs e)
        {
            firstNumber = "";
            secondNumber = "";
            oper = "";
        }

        private void OnControlButtonClicked(object sender, EventArgs e)
        {
            Button botonClickeado = (Button)sender;
            string oper = botonClickeado.Text;
            if (oper == "=")
            {
                int r = 0;
                // Acá va la calculadora
                _resultDisplay.Text = "R:" + r;
            }
            else
            {
                // Otro oper
            }
        }

        void OnNumericButtonClicked(object sender, EventArgs e)
        {
            Button botonClickeado = (Button)sender;
            if (firstNumber == null || firstNumber == "")
            {
                firstNumber = botonClickeado.Text;
            }
            else
            {
                secondNumber = botonClickeado.Text;
            }
        }

        #endregion


        private void CreateUiElements()
        {
            _resultDisplay = new Label
            {
                FontSize = 40,
                Text = "0"
            };
            Grid.SetColumnSpan(_resultDisplay, 4);
            _layout.Children.Add(_resultDisplay);

            #region Numeric buttons

            _b0 = new Button { Text = "0" };
            Grid.SetColumn(_b0, 1);
            Grid.SetRow(_b0, 4);
            _layout.Children.Add(_b0);

            _b1 = new Button { Text = "1" };
            Grid.SetColumn(_b1, 0);
            Grid.SetRow(_b1, 3);
            _layout.Children.Add(_b1);

            _b2 = new Button { Text = "2" };
            Grid.SetColumn(_b2, 1);
            Grid.SetRow(_b2, 3);
            _layout.Children.Add(_b2);

            _b3 = new Button { Text = "3" };
            Grid.SetColumn(_b3, 2);
            Grid.SetRow(_b3, 3);
            _layout.Children.Add(_b3);

            // TODO: add missing buttons

            #endregion

            #region Control buttons

            _calculateBtn = new Button { Text = "=" };
            Grid.SetColumn(_calculateBtn, 3);
            Grid.SetRow(_calculateBtn, 4);
            _layout.Children.Add(_calculateBtn);

            _clearBtn = new Button { Text = "C" };
            Grid.SetColumn(_clearBtn, 3);
            Grid.SetRow(_clearBtn, 1);
            _layout.Children.Add(_clearBtn);

            // TODO: add missing buttons

            #endregion
        }

        private Grid CreateGridLayout()
        {
            var layout = new Grid();
            layout.HorizontalOptions = LayoutOptions.StartAndExpand;
            layout.VerticalOptions = LayoutOptions.StartAndExpand;

            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            return layout;
        }
    }

}
