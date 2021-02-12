using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum CharacterJobEnum
    {
        // Not specified
        Unknown = 0,

        // Fighters hit hard and have fight abilities
        Fighter = 14,

        // Clerics defend well and have buff abilities
        Cleric = 12,

        // New Heroes' Jobs
        Flying = 1,

        Psychic = 2,

        Physical = 3,

        Light = 4,

        Dark = 5,

        // New Monsters' Jobs
        Carpenter = 6,

        Accountant = 7,

        McDonaldsEmployee = 8,

        Vet = 9,

        Boss = 10,
    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class CharacterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this CharacterJobEnum value)
        {
            // Default String
            var Message = "Player";

            switch (value)
            {

                case CharacterJobEnum.Flying:
                    Message = "Flying";
                    break;

                case CharacterJobEnum.Psychic:
                    Message = "Psychic";
                    break;
                case CharacterJobEnum.Physical:
                    Message = "Physical";
                    break;

                case CharacterJobEnum.Light:
                    Message = "Light";
                    break;
                case CharacterJobEnum.Dark:
                    Message = "Dark";
                    break;

                case CharacterJobEnum.Carpenter:
                    Message = "Carpenter";
                    break;

                case CharacterJobEnum.Accountant:
                    Message = "Accountant";
                    break;

                case CharacterJobEnum.Vet:
                    Message = "Vet";
                    break;

                case CharacterJobEnum.McDonaldsEmployee:
                    Message = "McDonaldsEmployee";
                    break;

                case CharacterJobEnum.Boss:
                    Message = "Boss";
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for Character Jobs
    /// </summary>
    public static class CharacterJobEnumHelper
    {
        /// <summary>
        /// Gets the list of jobs that an hero can be in.
        /// </summary>
        public static List<string> GetListHeroJob
        {
            get
            {
                var myList = Enum.GetNames(typeof(CharacterJobEnum)).ToList();
                var myReturn = myList.Where(a =>
                                            a.ToString() != CharacterJobEnum.Fighter.ToString() &&
                                            a.ToString() != CharacterJobEnum.Cleric.ToString() &&
                                            a.ToString() != CharacterJobEnum.Unknown.ToString() &&
                                            a.ToString() != CharacterJobEnum.Carpenter.ToString() &&
                                            a.ToString() != CharacterJobEnum.Accountant.ToString() &&
                                            a.ToString() != CharacterJobEnum.Vet.ToString() &&
                                            a.ToString() != CharacterJobEnum.McDonaldsEmployee.ToString() &&
                                            a.ToString() != CharacterJobEnum.Boss.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();
                return myReturn;
            }
        }

        /// <summary>
        /// Gets the list of jobs that an monster can be in.
        /// </summary>
        public static List<string> GetListMonsterJob
        {
            get
            {
                var myList = Enum.GetNames(typeof(CharacterJobEnum)).ToList();
                var myReturn = myList.Where(a =>
                                            a.ToString() != CharacterJobEnum.Fighter.ToString() &&
                                            a.ToString() != CharacterJobEnum.Cleric.ToString() &&
                                            a.ToString() != CharacterJobEnum.Unknown.ToString() &&
                                            a.ToString() != CharacterJobEnum.Flying.ToString() &&
                                            a.ToString() != CharacterJobEnum.Psychic.ToString() &&
                                            a.ToString() != CharacterJobEnum.Physical.ToString() &&
                                            a.ToString() != CharacterJobEnum.Light.ToString() &&
                                            a.ToString() != CharacterJobEnum.Dark.ToString()
                                            )
                                            .OrderBy(a => a)
                                            .ToList();
                return myReturn;
            }
        }

        /// <summary>
        /// Given the String for an enum, return its value.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static CharacterJobEnum ConvertStringToEnum(string value)
        {
            return (CharacterJobEnum)Enum.Parse(typeof(CharacterJobEnum), value);
        }
    }
}