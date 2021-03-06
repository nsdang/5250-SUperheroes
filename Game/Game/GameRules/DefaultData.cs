﻿using System.Collections.Generic;

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
                    ImageURI = "bronzering.png",
                    Range = 10,
                    Value = 5,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Bronze Helmet",
                    Description = "A helmet provided to every\nSUperhero and SUbsidized\nby the government.",
                    ImageURI = "bronzehelmet.png",
                    Value = 5,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "Brass Knuckles",
                    Description = "A set of fist loaded weapons\nprovided to every SUperhero\nand SUbsidized by the\ngovernment.",
                    ImageURI = "brassknuckles.png",
                    Range = 10,
                    Damage = 5,
                    Value = 5,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "Cookie",
                    Description = "Can increase moderate\namount of health.",
                    ImageURI = "cookie.png",
                    Value = 25,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.CurrentHealth
                },
                new ItemModel {
                    Name = "Bag of cookies",
                    Description = "Can recover minor amount\nof health for entire\nteam.",
                    ImageURI = "bagofcookies.png",
                    Value = 10,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.CurrentHealth
                },
                new ItemModel {
                    Name = "Midi-chlorians",
                    Description = "An injection of midi-chlorians\nor m-cells grants a hero\n" +
                    "temporary access to a mystical\nability known as the force\nfor the rest of the battle.",
                    ImageURI = "midichlorian.png",
                    Value = 10,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Speed
                },
            };
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
                    Name = "Riot 1",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Riot 2",
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
                    MaxHealth = 15,
                    ImageURI = "flying.png",
                    Head = ItemIndexViewModel.Instance.GetItem(HeadString).Name,
                    PrimaryHand = ItemIndexViewModel.Instance.GetItem(PrimaryHandString).Name,
                    RightFinger = ItemIndexViewModel.Instance.GetItem(RightFingerString).Name,
                    Necklass = NecklassString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "ConnectSU",
                    Job = (CharacterJobEnum)2,
                    Description = "C2",
                    Level = 1,
                    MaxHealth = 7,
                    ImageURI = "psychic.png",
                    Head = ItemIndexViewModel.Instance.GetItem(HeadString).Name,
                    PrimaryHand = ItemIndexViewModel.Instance.GetItem(PrimaryHandString).Name,
                    RightFinger = ItemIndexViewModel.Instance.GetItem(RightFingerString).Name,
                    Necklass = NecklassString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "EngageSU",
                    Job = (CharacterJobEnum)3,
                    Description = "C3",
                    Level = 1,
                    MaxHealth = 10,
                    ImageURI = "physical.png",
                    Head = ItemIndexViewModel.Instance.GetItem(HeadString).Name,
                    PrimaryHand = ItemIndexViewModel.Instance.GetItem(PrimaryHandString).Name,
                    RightFinger = ItemIndexViewModel.Instance.GetItem(RightFingerString).Name,
                    Necklass = NecklassString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "InformSU",
                    Job = (CharacterJobEnum)4,
                    Description = "C4",
                    Level = 1,
                    MaxHealth = 7,
                    ImageURI = "light.png",
                    Head = ItemIndexViewModel.Instance.GetItem(HeadString).Name,
                    PrimaryHand = ItemIndexViewModel.Instance.GetItem(PrimaryHandString).Name,
                    RightFinger = ItemIndexViewModel.Instance.GetItem(RightFingerString).Name,
                    Necklass = NecklassString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "ProcureSU",
                    Job = (CharacterJobEnum)5,
                    Description = "C5",
                    Level = 1,
                    MaxHealth = 7,
                    ImageURI = "dark.png",
                    Head = ItemIndexViewModel.Instance.GetItem(HeadString).Name,
                    PrimaryHand = ItemIndexViewModel.Instance.GetItem(PrimaryHandString).Name,
                    RightFinger = ItemIndexViewModel.Instance.GetItem(RightFingerString).Name,
                    Necklass = NecklassString,
                    OffHand = OffHandString,
                    Feet = FeetString,
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
                    ImageURI = "carpenter.png",
                    MaxHealth = 2,
                    CurrentHealth = 2
                },

                new MonsterModel {
                    Name = "Yinying",
                    Job = (CharacterJobEnum)7,
                    Description = "Accountant that can throw cash with sharp accuracy",
                    ImageURI = "accountant.png",
                    MaxHealth = 5,
                    CurrentHealth = 5
                },

                new MonsterModel {
                    Name = "Carolina",
                    Job = (CharacterJobEnum)8,
                    Description = "Mc Donald's worker that throws fries",
                    ImageURI = "mcdonaldsemployee.png",
                    MaxHealth = 3,
                    CurrentHealth = 3
                },

                new MonsterModel {
                    Name = "Anais",
                    Job = (CharacterJobEnum)9,
                    Description = "A vet who was obsessed with the cats in the clinic and loved eating fish." +
                    " One day, she got bitten by a cat while eating some salmon. This turned her into a fish-cat. ",
                    ImageURI = "vet.png",
                    MaxHealth = 7,
                    CurrentHealth = 7
                },

                new MonsterModel {
                    Name = "Steve",
                    Job = (CharacterJobEnum)10,
                    Description = "Plays video games soo much that his head transformed into a game controller",
                    ImageURI = "boss.png",
                    MaxHealth = 15,
                    CurrentHealth = 15
                },

            };

        return datalist;
    }
}
}