using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

namespace oneone2
{
    public class GameCharacter
    {
        private string _name;
        private int _health;
        private int _strength;
        private int _stamina;
        private bool _isEvil;


        public GameCharacter(string name, int health, int strength, int stamina, bool morality)
        {
            _name = name;
            _health = health;
            _strength = strength;
            _stamina = stamina;
            _isEvil = morality;
        }

        public string Name()
        {
            return _name;
        }

        public int Health()
        {
            return _health;
        }

        public int Strength
        {
            get => _strength;
            set => _strength = value;
        }

        public int Stamina()
        {
            return _stamina;
        }

        public void Fight(GameCharacter opponent)
        {
            if (this._stamina > 0)
            {
                opponent._health -= this._strength;
                this._stamina -= 10;
                Console.WriteLine($"{this._name} takes a swing at {opponent._name}...");
                Thread.Sleep(450);
                Console.WriteLine(
                    $"                              @@\r\n                             @@ \r\n                           @@@  \r\n                         @@@@   \r\n                       @@@@     \r\n                    @@@@@       \r\n                  @@@@          \r\n               @@@@@            \r\n             @@@@               \r\n        @@@@@@@                 \r\n@@@@@@@@@@@                     ");
                Thread.Sleep(450);
                if (this._isEvil == false && this._strength >= 50)
                {
                    Console.WriteLine(
                        $"CRITICAL HIT! Grievous damage dealt!\n{opponent._name} reels, taking {this._strength} damage!");
                }
                else if (this._isEvil == false && this._strength >= 35)
                {
                    Console.WriteLine(
                        $"CRUSHING BLOW! Extra damage dealt!\n{opponent._name} reels, taking {this._strength} damage!");
                }
                else
                {
                    Console.WriteLine($"\nThe hit connects! {opponent._name} reels, taking {this._strength} damage!");
                }
            }
            else
            {
                Console.WriteLine($"{this._name} is too tired to attack!");
                Thread.Sleep(450);
                Console.WriteLine($"{this._name} recharges instead.");
                this.Recharge();
            }
        }
        public void Recharge()
        {
            if (_isEvil)
            {
                _stamina = 10;
            }
            else
            {
                _stamina = 40;
            }
        }
    }
}



