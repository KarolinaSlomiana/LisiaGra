using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for ChoosingCharacterScreen.xaml
    /// </summary>
    public partial class ChoosingCharacterScreen : UserControl
    {
        private FoxType foxTypeSelected = FoxType.Athletic;
        private Bitmap characterSelectionImage;

        public ChoosingCharacterScreen()
        {
            InitializeComponent();
            characterSelectionImage = new Bitmap(System.Drawing.Image.FromFile("Graphics\\Foxes.png"));
            ChangefoxType();
        }

        public void ChangefoxType()
        {
            TypeLabel2.Content = TypeLabel1.Content = foxTypeSelected;
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle();
            switch (foxTypeSelected)
            {
                case FoxType.Athletic:
                    DescTextBlock.Text = "Athletic desc.";
                    rectangle = new System.Drawing.Rectangle(0, 0, 300, 300);
                    break;
                case FoxType.Nerd:
                    DescTextBlock.Text = "Nerd desc.";
                    rectangle = new System.Drawing.Rectangle(300, 0, 300, 300);
                    break;
                case FoxType.Cunning:
                    DescTextBlock.Text = "Cunning desc.";
                    rectangle = new System.Drawing.Rectangle(600, 0, 300, 300);
                    break;
            }
            FoxImage.Source = StaticHelpers.BitmapToImageSource(characterSelectionImage.Clone(rectangle, characterSelectionImage.PixelFormat));
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            foxTypeSelected++;
            if ((int)foxTypeSelected > 2) foxTypeSelected = (FoxType)0;
            ChangefoxType();
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            foxTypeSelected--;
            if ((int)foxTypeSelected < 0) foxTypeSelected = (FoxType)2;
            ChangefoxType();
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            StaticHelpers.MainCharacter = new Fox() { FoxType = foxTypeSelected, name = NameInputTextBox.Text, Level = 1, SkillPoints = 5 };
            switch(foxTypeSelected)
            {
                case FoxType.Athletic:
                    StaticHelpers.MainCharacter.Strength += 3;
                    break;
                case FoxType.Cunning:
                    StaticHelpers.MainCharacter.Agility += 3;
                    break;
                case FoxType.Nerd:
                    StaticHelpers.MainCharacter.Luck += 3;
                    break;
            }
            StatsScreen statsScreen = new StatsScreen();
            Application.Current.MainWindow.Content = statsScreen;
        }
    }
}
