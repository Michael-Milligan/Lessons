using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Lessons
{
    public enum TypesOfAttack
    {
        Physical,
        Magical
    }

    [DataContract]
    public class Character
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int HP { get; set; }
        [DataMember]
        public TypesOfAttack TypeOfAttack { get; set; }
        [DataMember]
        private int Attack;

        [DataMember]
        public Class Class { get; set; }

        public Character(string name, int HP, TypesOfAttack typeOfAttack, int attack, Class Class)
        {
            //Check for invalid parameters

            Name = name;
            this.HP = HP;
            TypeOfAttack = typeOfAttack;
            Attack = attack;
            this.Class = Class;
        }
        public Character()
        {

        }
    }
}
