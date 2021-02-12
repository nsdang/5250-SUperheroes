using System.Collections.Generic;

using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Bronze Ring",
                    Description = "A ring provided to every\nSUperhero and SUbsidized\nby the government.",
                    ImageURI = "item.png",
                    Range = 10,
                    Value = 5,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Bronze Helmet",
                    Description = "A helmet provided to every\nSUperhero and SUbsidized\nby the government.",
                    ImageURI = "item.png",
                    Value = 5,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Brass Knuckles",
                    Description = "A set of fist loaded weapons\nprovided to every SUperhero\nand SUbsidized by the\ngovernment.",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 5,
                    Value = 5,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Cookie",
                    Description = "Can increase moderate\namount of health.",
                    ImageURI = "item.png",
                    Value = 25,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.CurrentHealth
                },
                new ItemModel {
                    Name = "Bag of cookies",
                    Description = "Can recover minor amount\nof health for entire\nteam.",
                    ImageURI = "item.png",
                    Value = 10,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.CurrentHealth
                },
                new ItemModel {
                    Name = "Midi-chlorians",
                    Description = "An injection of midi-chlorians\nor m-cells grants a hero\n" +
                    "temporary access to a mystical\nability known as the force\nfor the rest of the battle.",
                    ImageURI = "item.png",
                    Value = 10,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Speed
                },
            };

            for (int i = 0; i < 20; i++)
            {
                var item = new ItemModel
                {
                    ImageURI = "item.png",
                    Range = 2,
                    Damage = 10,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                };
                item.Name = "I" + (datalist.Count+1).ToString();
                item.Description = item.Name;

                datalist.Add(item);
            }

            return datalist;
        }

    /// <summary>
    /// Load Example Scores
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<ScoreModel> LoadData(ScoreModel temp)
    {
        var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

        return datalist;
    }

    /// <summary>
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<CharacterModel> LoadData(CharacterModel temp)
    {
        var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);
        var NecklassString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Necklass);
        var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);
        var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.OffHand);
        var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Feet);
        var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
        var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);

        var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "CaptainSU",
                    Job = (CharacterJobEnum)1,
                    Description = "C1",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "CaptainSU.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "ConnectSU",
                    Job = (CharacterJobEnum)2,
                    Description = "C2",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "EngageSU",
                    Job = (CharacterJobEnum)3,
                    Description = "C3",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "InformSU",
                    Job = (CharacterJobEnum)4,
                    Description = "C4",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "ProcureSU",
                    Job = (CharacterJobEnum)5,
                    Description = "C5",
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "item.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },
            };

        return datalist;
    }

    /// <summary>
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<MonsterModel> LoadData(MonsterModel temp)
    {
        var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Bob",
                    Job = (CharacterJobEnum)6,
                    Description = "Carpenter that fights with a wrench",
                    ImageURI = "icon_bob.png",
                },

                new MonsterModel {
                    Name = "Yinying",
                    Job = (CharacterJobEnum)7,
                    Description = "Accountant that can throw cash with sharp accuracy",
                    ImageURI = "icon_yinying.png",
                },

                new MonsterModel {
                    Name = "Carolina",
                    Job = (CharacterJobEnum)8,
                    Description = "Mc Donald's worker that throws fries",
                    ImageURI = "icon_carolina.png",
                },

                new MonsterModel {
                    Name = "Anais",
                    Job = (CharacterJobEnum)9,
                    Description = "A vet who was obsessed with the cats in the clinic and loved eating fish." +
                    " One day, she got bitten by a cat while eating some salmon. This turned her into a fish-cat. ",
                    ImageURI = "icon_anais.png",
                },

                new MonsterModel {
                    Name = "Steve",
                    Job = (CharacterJobEnum)9,
                    Description = "Plays video games soo much that his head transformed into a game controller",
                    ImageURI = "icon_steve.png",
                },

            };

        return datalist;
    }
}
}