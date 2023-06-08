using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProgram
{
    abstract class Character
    {
        public static int CalculateHP(int bravery)
        {
            return bravery * 3;
        }

        private string name;
        public string Name { get => name; set => name = value; }

        private int level;
        public int Level { get => level; set => level = value; }

        private int hp;
        protected int Hp { get => hp; }

        protected int mp;
        private int bravery;
        private int faith;

        public Character(string name, int level,
                         int mp, int bravery, int faith)
        {
            this.name = name;
            this.level = level;
            this.mp = mp;
            this.bravery = bravery;
            this.faith = faith;
            this.hp = Character.CalculateHP(this.bravery);
        }

        public abstract void Attack(Character opponent);
        public void Move() { }
        public virtual void Die() { Console.WriteLine(this.Name + " is dead!"); }
        public void ReceiveDamage(int damage) => hp = hp - damage;
    }

    class OnionKnight : Character
    {
        public OnionKnight(string name, int level,
                         int mp, int bravery, int faith) :
                        base(name, level, mp, bravery, faith)
        { }

        public override void Die() { Console.WriteLine(this.Name + " is rotten!"); }
        public override void Attack(Character opponent)
        {
            Console.WriteLine(this.Name + " attacks with an onion sword!");
            opponent.ReceiveDamage(4);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            Character ramza = new OnionKnight("Ramza", 34,
                                            37, 74, 70);

            OnionKnight luna = new OnionKnight("Luna", 26,
                                                70, 73, 57);

            List<Character> characters = new List<Character>();
            characters.Add(ramza);
            characters.Add(luna);

            IEnumerable<Character> ramzaChar = from chara in characters
                                               where chara.Name == "Ramza" select chara;
            foreach (Character character in ramzaChar)
            {
                character.Die();
            }
        }
    }
}



