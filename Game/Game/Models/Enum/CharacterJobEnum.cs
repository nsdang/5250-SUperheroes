namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum CharacterJobEnum
    {
        // Not specified
        Unknown = -1,

        // Fighters hit hard and have fight abilities
        Fighter = 10,

        // Clerics defend well and have buff abilities
        Cleric = 12,

        // New Heroes' Jobs
        Flying = 0,

        Psychic = 1,

        Physical = 2,

        Light = 3,

        Dark = 4,

        // New Monsters' Jobs
        Carpenter = 5,

        Accountant = 6,

        McDonaldsEmployee = 7,

        Vet = 8,

        Boss = 9,
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
                //case CharacterJobEnum.Fighter:
                //    Message = "Fighter";
                //    break;

                //case CharacterJobEnum.Cleric:
                //    Message = "Cleric";
                //    break;

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
}