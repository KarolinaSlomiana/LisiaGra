using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxyGame
{
    public class Character
    {
        public Character()
        {
            CurrentHealthPoints = MaxHealthPoints;
        }

        private const int width = 30, height = 30;
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public string name;
        public int positionX, positionY;
        public bool IsDead;
        public bool IsBlocking;

        public int Level;

        public int SkillPoints;

        public int Strength = 1;
        public int Agility = 1;
        public int Stamina = 1;
        public int Health = 1;
        public int Luck = 1;
        public int CurrentHealthPoints;

        private Bitmap fightImage;
        private Bitmap headIcon;

        public Bitmap FightImage
        {
            get
            {
                if(fightImage == null)
                {
                    Fox fox = this as Fox;
                    Chicken chicken = this as Chicken;
                    Grasshopper grasshopper = this as Grasshopper;
                    Bunny bunny = this as Bunny;
                    if (fox != null)
                    {
                        Bitmap foxImage = new Bitmap(Image.FromFile("Graphics\\Foxes.png"));
                        Rectangle rectangle = new Rectangle(300 * (int)fox.FoxType, 300, 300, 300);
                        fightImage = foxImage.Clone(rectangle, foxImage.PixelFormat);
                    }
                    else if(chicken != null)
                    {
                        Bitmap villainsImage = new Bitmap(Image.FromFile("Graphics\\Villains.png"));
                        Rectangle rectangle = new Rectangle(900, 0, 300, 300);
                        fightImage = villainsImage.Clone(rectangle, villainsImage.PixelFormat);
                    }
                    else if(grasshopper != null)
                    {
                        Bitmap villainsImage = new Bitmap(Image.FromFile("Graphics\\Villains.png"));
                        Rectangle rectangle = new Rectangle(0, 0, 300, 300);
                        fightImage = villainsImage.Clone(rectangle, villainsImage.PixelFormat);
                    }
                    else if(bunny != null)
                    {
                        Bitmap villainsImage = new Bitmap(Image.FromFile("Graphics\\Villains.png"));
                        Rectangle rectangle = new Rectangle(600, 0, 300, 300);
                        fightImage = villainsImage.Clone(rectangle, villainsImage.PixelFormat);
                    }
                }
                return fightImage;
            }
        }

        public Bitmap HeadIcon
        {
            get
            {
                if(headIcon == null)
                {
                    Fox fox = this as Fox;
                    Chicken chicken = this as Chicken;
                    Grasshopper grasshopper = this as Grasshopper;
                    Bunny bunny = this as Bunny;
                    Bitmap headIconsImage = new Bitmap(Image.FromFile("Graphics\\HeadIcons.png"));
                    if (fox != null)
                    {
                        Rectangle rectangle = new Rectangle(200 * (int)fox.FoxType, 0, 200, 200);
                        headIcon = headIconsImage.Clone(rectangle, headIconsImage.PixelFormat);
                    }
                    else if(chicken != null)
                    {
                        Rectangle rectangle = new Rectangle(600, 0, 200, 200);
                        headIcon = headIconsImage.Clone(rectangle, headIconsImage.PixelFormat);
                    }
                    else if(grasshopper != null)
                    {
                        Rectangle rectangle = new Rectangle(1000, 0, 200, 200);
                        headIcon = headIconsImage.Clone(rectangle, headIconsImage.PixelFormat);
                    }
                    else if(bunny != null)
                    {
                        Rectangle rectangle = new Rectangle(800, 0, 200, 200);
                        headIcon = headIconsImage.Clone(rectangle, headIconsImage.PixelFormat);
                    }
                }
                return headIcon;
            }
        }

        public int Attack
        {
            get
            {
                return Level + Strength;
            }
        }

        public int Speed
        {
            get
            {
                return Level + Agility;
            }
        }

        public int Defense
        {
            get
            {
                return IsBlocking ? Level + Stamina * 2 : Level + Stamina;
            }
        }

        public int MaxHealthPoints
        {
            get
            {
                return (Level + Health) * 5;
            }
        }

        public void FillHealth()
        {
            CurrentHealthPoints = MaxHealthPoints;
        }

        public void LevelUp()
        {
            Level++;
            SkillPoints += 5;
            FillHealth();
        }

        public void Heal()
        {
            CurrentHealthPoints += (int)(0.1 * MaxHealthPoints);
            if (CurrentHealthPoints > MaxHealthPoints) CurrentHealthPoints = MaxHealthPoints;
        }

        public void GetDamage(int damage)
        {
            CurrentHealthPoints -= damage;
            if (CurrentHealthPoints <= 0) IsDead = true;
        }

        public Character Move(Direction direction)
        {
            Character colidedCharacter = null;
            switch (direction)
            {
                case Direction.Up:
                    positionY--;
                    colidedCharacter = CheckForCharacterCollision();
                    if (colidedCharacter != null)
                    {
                        positionY++;
                    }
                    break;
                case Direction.Down:
                    positionY++;
                    colidedCharacter = CheckForCharacterCollision();
                    if (colidedCharacter != null)
                    {
                        positionY--;
                    }
                    break;
                case Direction.Left:
                    positionX--;
                    colidedCharacter = CheckForCharacterCollision();
                    if (colidedCharacter != null)
                    {
                        positionX++;
                    }
                    break;
                case Direction.Right:
                    positionX++;
                    colidedCharacter = CheckForCharacterCollision();
                    if (colidedCharacter != null)
                    {
                        positionX--;
                    }
                    break;
            }

            if (positionX < 0)
                positionX = 0;
            if (positionX > 500)
                positionX = 500;
            if (positionY < 0)
                positionY = 0;
            if (positionY > 500)
                positionY = 500;

            return colidedCharacter;
        }

        private Character CheckForCharacterCollision()
        {
            return StaticHelpers.Characters.Where(x => x != this
                && (x.positionX <= positionX && x.positionX + width >= positionX
                    || x.positionX >= positionX && x.positionX <= positionX + width)
                && (x.positionY <= positionY && x.positionY + height >= positionY
                    || x.positionY >= positionY && x.positionY <= positionY + height)).FirstOrDefault();
        }

        private Character CheckForMapCollision()
        {
            //TODO:Map Collision
            return StaticHelpers.Characters.Where(x => x != this
                && (x.positionX <= positionX && x.positionX + width >= positionX
                    || x.positionX >= positionX && x.positionX <= positionX + width)
                && (x.positionY <= positionY && x.positionY + height >= positionY
                    || x.positionY >= positionY && x.positionY <= positionY + height)).FirstOrDefault();
        }


    }
}
