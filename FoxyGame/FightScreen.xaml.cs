using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Drawing;

namespace FoxyGame
{
    /// <summary>
    /// Interaction logic for FightScreen.xaml
    /// </summary>
    public partial class FightScreen : UserControl
    {
        private Character Hero, Enemy;

        public FightScreen(Character hero, Character enemy)
        {
            Hero = hero;
            Enemy = enemy;
            InitializeComponent();
            EnemyNameAndLevel.Content = string.Format("{0} {1}", Enemy.name, Enemy.Level);
            HeroNameAndLevel.Content = string.Format("{0} {1}", Hero.name, Hero.Level);
            EnemyHealthBar.Maximum = Enemy.MaxHealthPoints;
            HeroHealthBar.Maximum = Hero.MaxHealthPoints;
            Info.Text = $"Spotykasz {Enemy.name}!";
            
            HeroImage.Source = StaticHelpers.BitmapToImageSource(hero.FightImage);
            EnemyImage.Source = StaticHelpers.BitmapToImageSource(enemy.FightImage);
            
            RedrawScreen();
        }

        private void EvadeButton_Click(object sender, RoutedEventArgs e)
        {

            EnemyTurn();
        }

        private void BlockButton_Click(object sender, RoutedEventArgs e)
        {
            Hero.IsBlocking = true;
            EnemyTurn();
        }

        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            int statDifference = Hero.Attack - Enemy.Defense;
            Enemy.GetDamage(Convert.ToInt32((1 + statDifference * 0.1) * 5));
            EnemyTurn();
        }

        private void RecoverButton_Click(object sender, RoutedEventArgs e)
        {
            Hero.Heal();
            EnemyTurn();
        }

        private void EnemyTurn()
        {
            Thread.Sleep(300);
            if (!Enemy.IsDead)
            {
                switch (StaticHelpers.RandomNumberGenerator.Next(3))
                {
                    case 0:
                        int statDifference = Enemy.Attack - Hero.Defense;
                        Hero.GetDamage(Convert.ToInt32((1 + statDifference * 0.1) * 5));
                        Info.Text = $"{Enemy.name} cię zaatakował";
                        break;
                    case 1:
                        Enemy.IsBlocking = true;
                        Info.Text = $"{Enemy.name} cię zablokował";
                        break;
                    case 2:
                        Enemy.Heal();
                        Info.Text = $"{Enemy.name} się uleczył";
                        break;
                }
                if(!Hero.IsDead)
                {
                    Hero.IsBlocking = false;
                    Enemy.IsBlocking = false;
                    RedrawScreen();
                    return;
                }
                EnemyWon();
            }
            HeroWon();
        }

        private void HeroWon()
        {
            Hero.LevelUp();
            StaticHelpers.Characters.Remove(Enemy);

            BattleHasEnded();
        }

        private void EnemyWon()
        {
            Hero.FillHealth();
            Enemy.FillHealth();
            BattleHasEnded();
        }

        private void BattleHasEnded()
        {
            Hero.IsBlocking = false;
            Enemy.IsBlocking = false;
            //if (StaticHelpers.ScreenType == ScreenType.Fight)
            //{
            //    StaticHelpers.ScreenType = ScreenType.Exploration;
                MainGameScreen mainGameScreen = new MainGameScreen();
                Application.Current.MainWindow.Content = mainGameScreen;
            //}
        }

        private void RedrawScreen()
        {
            EnemyHealthBar.Value = Enemy.CurrentHealthPoints;
            HeroHealthBar.Value = Hero.CurrentHealthPoints;
        }
    }
}
