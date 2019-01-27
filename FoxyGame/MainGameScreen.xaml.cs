using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using Brushes = System.Windows.Media.Brushes;

namespace FoxyGame
{
    /// <summary>
    /// Interaction logic for MainGameScreen.xaml
    /// </summary>
    public partial class MainGameScreen : UserControl
    {
        public MainGameScreen()
        {
            InitializeComponent();
            Gameboard.Background = new ImageBrush(StaticHelpers.BitmapToImageSource(StaticHelpers.MapImage));
            if (StaticHelpers.Characters == null)
            {
                CreateGameState();
            }
            StartTimer();

        }

        private void CreateGameState()
        {
            StaticHelpers.Characters = new List<Character> {
                    StaticHelpers.MainCharacter,
                    new Chicken { name = "Chicken", positionX = 25, positionY = 150, Level = 3 },
                    new Grasshopper { name = "Grasshopper", positionX = 60, positionY = 100, Level = 10 },
                    new Bunny { name = "Bunny", positionX = 200, positionY = 130, Level = 2 }
                };
            foreach (var character in StaticHelpers.Characters)
            {
                character.FillHealth();
            }
        }

        private void StartTimer()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromMilliseconds(18);
            dt.Tick += TickActions;
            dt.Start();
        }


        private void TickActions(object sender, EventArgs e)
        {
            RedrawExploration(sender, e);
            CheckKeyDown(sender, e);
            MoveVillains(sender, e);
        }

        private void RedrawExploration(object sender, EventArgs e)
        {
            Gameboard.Children.Clear();
            foreach (Character character in StaticHelpers.Characters)
            {
                DrawCharacter(character);
            }
        }

        private void MoveVillains(object sender, EventArgs e)
        {
            foreach (Character character in StaticHelpers.Characters)
            {
                if (character is Villain)
                {
                    ((Villain)character).MoveRandomly();
                }
            }
        }

        private void DrawCharacter(Character character)
        {
            Rectangle rectangle = new Rectangle { Width = character.Width, Height = character.Height }; //, Stroke = Brushes.Black };
            //if (character is Fox)
            //{
            //    rectangle.Stroke = Brushes.DarkOrange;
            //}
            //else if (character is Chicken)
            //{
            //    rectangle.Stroke = Brushes.Yellow;
            //}
            //else if (character is Grasshopper)
            //{
            //    rectangle.Stroke = Brushes.YellowGreen;
            //}
            //else if (character is Bunny)
            //{
            //    rectangle.Stroke = Brushes.DarkGray;
            //}
            rectangle.Fill = new ImageBrush(StaticHelpers.BitmapToImageSource(character.HeadIcon));
            Canvas.SetTop(rectangle, character.positionY);
            Canvas.SetLeft(rectangle, character.positionX);

            Gameboard.Children.Add(rectangle);
        }

        private void CheckKeyDown(object sender, EventArgs e)
        {
            Character colidedCharacter = null;
            if (Keyboard.IsKeyDown(Key.Down))
            {
                colidedCharacter = StaticHelpers.MainCharacter.Move(Direction.Down);
            }
            if (Keyboard.IsKeyDown(Key.Up))
            {
                colidedCharacter = StaticHelpers.MainCharacter.Move(Direction.Up);
            }
            if (Keyboard.IsKeyDown(Key.Left))
            {
                colidedCharacter = StaticHelpers.MainCharacter.Move(Direction.Left);
            }
            if (Keyboard.IsKeyDown(Key.Right))
            {
                colidedCharacter = StaticHelpers.MainCharacter.Move(Direction.Right);
            }
            if (colidedCharacter != null)
            {
                FightScreen fightScreen = new FightScreen(StaticHelpers.MainCharacter, colidedCharacter);
                Application.Current.MainWindow.Content = fightScreen;
            }

            if (Keyboard.IsKeyDown(Key.I))
            {
                StatsScreen statsScreen = new StatsScreen();
                Application.Current.MainWindow.Content = statsScreen;
            }
        }
    }
}
