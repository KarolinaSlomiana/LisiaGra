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
using System.Windows.Shapes;

namespace FoxyGame
{
    /// <summary>
    /// Interaction logic for StatsScreen.xaml
    /// </summary>
    public partial class StatsScreen : UserControl
    {
        private int strengthAdded;
        private int staminaAdded;
        private int agilityAdded;
        private int luckAdded;

        public StatsScreen()
        {
            InitializeComponent();
            AgilityValueLabel.Content = StaticHelpers.MainCharacter.Agility;
            StrenghtValueLabel.Content = StaticHelpers.MainCharacter.Strength;
            StaminaValueLabel.Content = StaticHelpers.MainCharacter.Stamina;
            LuckValueLabel.Content = StaticHelpers.MainCharacter.Luck; 

            AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
        }

        private void StrenghtPlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaticHelpers.MainCharacter.SkillPoints > 0)
            {
                strengthAdded++;
                StrenghtValueLabel.Content = StaticHelpers.MainCharacter.Strength + strengthAdded;
                StaticHelpers.MainCharacter.SkillPoints--;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }
        }

        private void StrenghtMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (strengthAdded > 0)
            {
                strengthAdded--;
                StrenghtValueLabel.Content = StaticHelpers.MainCharacter.Strength + strengthAdded;
                StaticHelpers.MainCharacter.SkillPoints++;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }
        }

        private void StaminaPlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaticHelpers.MainCharacter.SkillPoints > 0)
            {
                staminaAdded++;
                StaminaValueLabel.Content = StaticHelpers.MainCharacter.Stamina + staminaAdded;
                StaticHelpers.MainCharacter.SkillPoints--;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }

        }

        private void StaminaMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (staminaAdded > 0)
            {
                staminaAdded--;
                StaminaValueLabel.Content = StaticHelpers.MainCharacter.Stamina + staminaAdded;
                StaticHelpers.MainCharacter.SkillPoints++;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }
        }

        private void AgilityPlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaticHelpers.MainCharacter.SkillPoints > 0)
            {
                agilityAdded++;
                AgilityValueLabel.Content = StaticHelpers.MainCharacter.Agility + agilityAdded;
                StaticHelpers.MainCharacter.SkillPoints--;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }
        }

        private void AgilityMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (agilityAdded > 0)
            {
                agilityAdded--;
                AgilityValueLabel.Content = StaticHelpers.MainCharacter.Agility + agilityAdded;
                StaticHelpers.MainCharacter.SkillPoints++;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }
        }

        private void LuckPlusButton_Click(object sender, RoutedEventArgs e)
        {
            if (StaticHelpers.MainCharacter.SkillPoints > 0)
            {
                luckAdded++;
                LuckValueLabel.Content = StaticHelpers.MainCharacter.Luck + luckAdded;
                StaticHelpers.MainCharacter.SkillPoints--;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }
        }

        private void LuckMinusButton_Click(object sender, RoutedEventArgs e)
        {
            if (luckAdded > 0)
            {
                luckAdded--;
                LuckValueLabel.Content = StaticHelpers.MainCharacter.Luck + luckAdded;
                StaticHelpers.MainCharacter.SkillPoints++;
                AvailablePointsLabel.Content = StaticHelpers.MainCharacter.SkillPoints;
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            StaticHelpers.MainCharacter.Agility += agilityAdded;
            StaticHelpers.MainCharacter.Strength += strengthAdded;
            StaticHelpers.MainCharacter.Stamina += staminaAdded;
            StaticHelpers.MainCharacter.Luck += luckAdded;
            //StaticHelpers.MainCharacter.Health += healthAdded;
            MainGameScreen mainGameScreen = new MainGameScreen();
            Application.Current.MainWindow.Content = mainGameScreen;
        }
    }
}
