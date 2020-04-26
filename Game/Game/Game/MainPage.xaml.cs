using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Game
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
        int buttonPressed;
		public MainPage()
		{
            List < Button > botones = new List<Button>();
            buttonPressed = 0;
			InitializeComponent();
            var layout = new StackLayout();
            Button pressed1 = new Button();
            Button pressed2 = new Button();
            Grid grid = new Grid();
            Title = "Memoria";
            var chars = "abcdefghijkl";
            var random = new Random();
            int columnsNum = 5;
            int rowsNum = 5;
            bool printClicked = false;
            Button print = new Button() {
                Margin = 100,
                Text = "Print"
            };
            
                for (int x = 0; x < columnsNum; x++)
            {
                for (int y = 0; y < rowsNum; y++)
                {
                    // Insert button into grid  
                    Button b = new Button() {
                        Text = chars[random.Next(chars.Length)].ToString(),
                        TextColor = Color.LightGray,
                        BackgroundColor = Color.LightGray
                    };
                    botones.Add(b);
                    b.Clicked += (sender, args) => {
                        if (b.BackgroundColor != Color.Yellow && b.BackgroundColor != Color.White)
                        {
                            if (buttonPressed == 0)
                            {
                                pressed1 = b;
                                buttonPressed = 1;
                                b.BackgroundColor = Color.Yellow;
                                b.TextColor = Color.Black;
                            }
                            else if (buttonPressed == 1)
                            {
                                buttonPressed = 2;
                                pressed2 = b;
                                b.BackgroundColor = Color.Yellow;
                                b.TextColor = Color.Black;
                            }
                            else
                            {
                                if (pressed1.Text == pressed2.Text)
                                {
                                    pressed1.BackgroundColor = Color.White;
                                    pressed2.BackgroundColor = Color.White;
                                }
                                else
                                {
                                    pressed1.BackgroundColor = Color.LightGray;
                                    pressed2.BackgroundColor = Color.LightGray;
                                    pressed1.TextColor = Color.LightGray;
                                    pressed2.TextColor = Color.LightGray;
                                }
                                pressed1 = b;
                                buttonPressed = 1;
                                b.BackgroundColor = Color.Yellow;
                                b.TextColor = Color.Black;

                            }
                        }
                    };
                    grid.Children.Add(b, x, y);
                }
            }
            print.Clicked += (sender, args) =>
            {
                if (!printClicked)
                {
                    print.Text = "Juego nuevo";
                    printClicked = !printClicked;
                    foreach(Button boton in botones){
                        boton.TextColor = Color.Black;
                        boton.BackgroundColor = Color.White;
                    }
                }
                else
                {
                    print.Text = "Print";
                    printClicked = !printClicked;
                    foreach (Button boton in botones)
                    {
                        boton.BackgroundColor = Color.LightGray;
                        boton.TextColor = Color.LightGray;
                        boton.Text = chars[random.Next(chars.Length)].ToString();
                    }
                }
            };
            layout.Children.Add(print);
            layout.Children.Add(grid);
            Content = layout;
        }


	}
}
