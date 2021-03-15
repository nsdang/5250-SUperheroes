using System.Collections.Generic;
using System.Diagnostics;

using Game.Models;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Engine.EngineBase;
using System.Linq;

namespace Game.Engine.EngineGame
{
    /* 
     * Need to decide who takes the next turn
     * Target to Attack
     * Should Move, or Stay put (can hit with weapon range?)
     * Death
     * Manage Round...
     * 
     */

    /// <summary>
    /// Engine controls the turns
    /// 
    /// A turn is when a Character takes an action or a Monster takes an action
    /// 
    /// </summary>
    public class TurnEngine : TurnEngineBase, ITurnEngineInterface
    {
        #region Algrorithm
        // Attack or Move
        // Roll To Hit
        // Decide Hit or Miss
        // Decide Damage
        // Death
        // Drop Items
        // Turn Over
        #endregion Algrorithm

        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        /// <summary>
        /// CharacterModel Attacks...
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override bool TakeTurn(PlayerInfoModel Attacker)
        {
            // Choose Action.  Such as Move, Attack etc.

            // INFO: Teams, if you have other actions they would go here.

            bool result = false;

            // If the action is not set, then try to set it or use Attact
            if (EngineSettings.CurrentAction == ActionEnum.Unknown)
            {
                // Set the action if one is not set
                EngineSettings.CurrentAction = DetermineActionChoice(Attacker);

                // When in doubt, attack...
                if (EngineSettings.CurrentAction == ActionEnum.Unknown)
                {
                    EngineSettings.CurrentAction = ActionEnum.Attack;
                }
            }

            switch (EngineSettings.CurrentAction)
            {
                //case ActionEnum.Unknown:
                //    // Action already happened
                //    break;

                case ActionEnum.Attack:
                    result = Attack(Attacker);
                    break;

                case ActionEnum.ModerateAttack:
                    result = Attack(Attacker);
                    break;

                case ActionEnum.SpecialAttack:
                    result = Attack(Attacker);
                    break;

                case ActionEnum.Ability:
                    result = UseAbility(Attacker);
                    break;

                case ActionEnum.Move:
                    result = MoveAsTurn(Attacker);
                    break;
            }

            EngineSettings.BattleScore.TurnCount++;

            // Save the Previous Action off
            EngineSettings.PreviousAction = EngineSettings.CurrentAction;

            // Reset the Action to unknown for next time
            EngineSettings.CurrentAction = ActionEnum.Unknown;

            return result;
        }

        /// <summary>
        /// Determine what Actions to do
        /// </summary>
        /// <param name="Attacker"></param>
        /// <returns></returns>
        public override ActionEnum DetermineActionChoice(PlayerInfoModel Attacker)
        {
            return base.DetermineActionChoice(Attacker);
        }

        /// <summary>
        /// Find a Desired Target
        /// Move close to them
        /// Get to move the number of Speed
        /// </summary>
        public override bool MoveAsTurn(PlayerInfoModel Attacker)
        {

            /*
             * TODO: TEAMS Work out your own move logic if you are implementing move
             * 
             * Mike's Logic
             * The monster or charcter will move to a different square if one is open
             * Find the Desired Target
             * Jump to the closest space near the target that is open
             * 
             * If no open spaces, return false
             * 
             */

            return base.MoveAsTurn(Attacker);
        }

        /// <summary>
        /// Decide to use an Ability or not
        /// 
        /// Set the Ability
        /// </summary>
        public override bool ChooseToUseAbility(PlayerInfoModel Attacker)
        {
            // INFO: Teams, consider if you have abilities
            return base.ChooseToUseAbility(Attacker);
        }

        /// <summary>
        /// Use the Ability
        /// </summary>
        public override bool UseAbility(PlayerInfoModel Attacker)
        {
            // INFO: Teams, consider if you have abilities
            return base.UseAbility(Attacker);
        }

        /// <summary>
        /// Attack as a Turn
        /// 
        /// Pick who to go after
        /// 
        /// Determine Attack Score
        /// Determine DefenseScore
        /// 
        /// Do the Attack
        /// 
        /// </summary>
        public override bool Attack(PlayerInfoModel Attacker)
        {
            // INFO: Teams, AttackChoice will auto pick the target, good for auto battle
            if (EngineSettings.BattleScore.AutoBattle)
            {
                // For Attack, Choose Who
                EngineSettings.CurrentDefender = AttackChoice(Attacker);

                if (EngineSettings.CurrentDefender == null)
                {
                    return false;
                }
            }

            // Do Attack
            if (EngineSettings.CurrentAction == ActionEnum.Attack)
            {
                TurnAsAttack(Attacker, EngineSettings.CurrentDefender);
            }
            else if (EngineSettings.CurrentAction == ActionEnum.ModerateAttack)
            {
                TurnAsModerateAttack(Attacker, EngineSettings.CurrentDefender);
            }
            else if (EngineSettings.CurrentAction == ActionEnum.SpecialAttack)
            {
                TurnAsSpecialAttack(Attacker, EngineSettings.CurrentDefender);
            }

            return true;
        }

        /// <summary>
        /// Decide which to attack
        /// </summary>
        public override PlayerInfoModel AttackChoice(PlayerInfoModel data)
        {
            return base.AttackChoice(data);
        }

        /// <summary>
        /// Pick the Character to Attack
        /// </summary>
        public override PlayerInfoModel SelectCharacterToAttack()
        {
            // TODO: Teams, You need to implement your own Logic can not use mine.
            return base.SelectCharacterToAttack();
        }

        /// <summary>
        /// Pick the Monster to Attack
        /// </summary>
        public override PlayerInfoModel SelectMonsterToAttack()
        {
            // TODO: Teams, You need to implement your own Logic can not use mine.
            return base.SelectMonsterToAttack();
        }

        /// <summary>
        /// // MonsterModel Attacks CharacterModel
        /// </summary>
        public override bool TurnAsAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.TurnAsAttack(Attacker, Target);
        }

        /// <summary>
        /// // CharacterModel Moderate Attacks MonsterModel
        /// </summary>
        public bool TurnAsModerateAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            if (Attacker == null)
            {
                return false;
            }

            if (Target == null)
            {
                return false;
            }

            if (Attacker.PlayerType != PlayerTypeEnum.Monster)
            {
                return false;
            }

            // Set Messages to empty
            EngineSettings.BattleMessagesModel.ClearMessages();

            // Do the Attack
            EngineSettings.BattleMessagesModel.AttackStatus = " use Moderate Attack ";

            //Calculate Damage
            // TODO: Make a call to seperate function based on character job
            EngineSettings.BattleMessagesModel.DamageAmount = Attacker.GetDamageRollValue();

            // Apply the Damage
            ApplyDamage(Target);

            EngineSettings.BattleMessagesModel.TurnMessageSpecial = EngineSettings.BattleMessagesModel.GetCurrentHealthMessage();

            // Check if Dead and Remove
            RemoveIfDead(Target);

            // If it is a character apply the experience earned
            CalculateExperience(Attacker, Target);

            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + EngineSettings.BattleMessagesModel.AttackStatus + Target.Name + EngineSettings.BattleMessagesModel.TurnMessageSpecial + EngineSettings.BattleMessagesModel.ExperienceEarned;
            Debug.WriteLine(EngineSettings.BattleMessagesModel.TurnMessage);

            return true;
        }

        /// <summary>
        /// // CharacterModel Special Attacks MonsterModel
        /// </summary>
        public bool TurnAsSpecialAttack(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            if (Attacker == null)
            {
                return false;
            }

            if (Target == null)
            {
                return false;
            }


            if (Attacker.PlayerType != PlayerTypeEnum.Monster)
            {
                return false;
            }

            // Set Messages to empty
            EngineSettings.BattleMessagesModel.ClearMessages();

            // Do the Attack
            EngineSettings.BattleMessagesModel.AttackStatus = " use Moderate Attack ";

            //Calculate Damage
            // TODO: Make a call to seperate function based on character job
            EngineSettings.BattleMessagesModel.DamageAmount = Attacker.GetDamageRollValue();

            // Apply the Damage
            ApplyDamage(Target);

            EngineSettings.BattleMessagesModel.TurnMessageSpecial = EngineSettings.BattleMessagesModel.GetCurrentHealthMessage();

            // Check if Dead and Remove
            RemoveIfDead(Target);

            // If it is a character apply the experience earned
            CalculateExperience(Attacker, Target);

            EngineSettings.BattleMessagesModel.TurnMessage = Attacker.Name + EngineSettings.BattleMessagesModel.AttackStatus + Target.Name + EngineSettings.BattleMessagesModel.TurnMessageSpecial + EngineSettings.BattleMessagesModel.ExperienceEarned;
            Debug.WriteLine(EngineSettings.BattleMessagesModel.TurnMessage);

            return true;
        }

        /// <summary>
        /// See if the Battle Settings will Override the Hit
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverride(PlayerInfoModel Attacker)
        {
            return base.BattleSettingsOverride(Attacker);
        }

        /// <summary>
        /// Return the Override for the HitStatus
        /// </summary>
        public override HitStatusEnum BattleSettingsOverrideHitStatusEnum(HitStatusEnum myEnum)
        {
            return base.BattleSettingsOverrideHitStatusEnum(myEnum);
        }

        /// <summary>
        /// Apply the Damage to the Target
        /// </summary>
        public override int ApplyDamage(PlayerInfoModel Target)
        {
            return base.ApplyDamage(Target);
        }

        /// <summary>
        /// Calculate the Attack, return if it hit or missed.
        /// </summary>
        public override HitStatusEnum CalculateAttackStatus(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateAttackStatus(Attacker, Target);
        }

        /// <summary>
        /// Calculate Experience
        /// Level up if needed
        /// </summary>
        public override bool CalculateExperience(PlayerInfoModel Attacker, PlayerInfoModel Target)
        {
            return base.CalculateExperience(Attacker, Target);
        }

        /// <summary>
        /// If Dead process Target Died
        /// </summary>
        public override bool RemoveIfDead(PlayerInfoModel Target)
        {
            return base.RemoveIfDead(Target);
        }

        /// <summary>
        /// Target Died
        /// 
        /// Process for death...
        /// 
        /// Returns the count of items dropped at death
        /// </summary>
        public override bool TargetDied(PlayerInfoModel Target)
        {
            // INFO: Teams, Hookup your Boss if you have one...
            return base.TargetDied(Target);
        }

        /// <summary>
        /// Drop Items
        /// </summary>
        public override int DropItems(PlayerInfoModel Target)
        {
            // INFO: Teams, work out how you want to drop items.
            var DroppedMessage = "\nItems Dropped : \n";

            // Drop Items to ItemModel Pool
            var myItemList = Target.DropAllItems();

            if (!Target.Alive)
            {

                if (Target.PlayerType == PlayerTypeEnum.Monster)
                {
                    if (Target.Job == CharacterJobEnum.Vet)
                    {
                        List<ItemModel> dataList = new List<ItemModel>()
                        {
                            new ItemModel
                            {
                                Name = "Arthur's Ring",
                                Description = "A ring worn by king Arthur\nhimself and can be dropped\nby Anais after her defeat.",
                                Range = 10,
                                Value = 20,
                                Location = ItemLocationEnum.Finger,
                                Attribute = AttributeEnum.Defense,
                                ImageURI = "arthursring.png"
                            },
                            new ItemModel {
                                Name = "Arthur's Helmet",
                                Description = "Helmet worn by king Arthur\nhimself and can be dropped by\nAnais after her defeat.",
                                ImageURI = "arthurshelmet.png",
                                Value = 15,
                                Location = ItemLocationEnum.Head,
                                Attribute = AttributeEnum.Defense
                            },
                            new ItemModel {
                                Name = "Arthur's Sword",
                                Description = "Sword swung by king Arthur\nhimself and can be dropped by\nAnais after her defeat.",
                                ImageURI = "arthurssword.png",
                                Range = 10,
                                Damage = 5,
                                Value = 20,
                                Location = ItemLocationEnum.PrimaryHand,
                                Attribute = AttributeEnum.Attack
                            },
                        };
                        myItemList.AddRange(dataList);
                    }
                    else if (Target.Job == CharacterJobEnum.Accountant)
                    {
                        List<ItemModel> dataList = new List<ItemModel>()
                        {
                            new ItemModel {
                                Name = "Cash",
                                Description = "Yinying might drop cash that\ncan be equipped on a character,\ngiving them more reason to\nlive which gives them higher\ndefense.",
                                ImageURI = "cash.png",
                                Value = 10,
                                Location = ItemLocationEnum.PrimaryHand,
                                Attribute = AttributeEnum.Defense
                            },
                        };
                        myItemList.AddRange(dataList);
                    }
                    else if (Target.Job == CharacterJobEnum.Boss)
                    {
                        List<ItemModel> dataList = new List<ItemModel>()
                        {
                            new ItemModel {
                                Name = "Steve's Controller",
                                Description = "After defeating Steve, you\nacquire his controller which\ncan be equipped on a character\nso they can have their special\nattacks ready at the beginning\nof every Round.",
                                ImageURI = "stevescontroller.png",
                                Value = 50,
                                Location = ItemLocationEnum.PrimaryHand,
                                Attribute = AttributeEnum.MaxHealth
                            },
                        };
                        myItemList.AddRange(dataList);
                    }
                }
                else if(Target.PlayerType == PlayerTypeEnum.Character)
                    myItemList.AddRange(GetRandomMonsterItemDrops(EngineSettings.BattleScore.RoundCount));
            }
            // Add to ScoreModel
            foreach (var ItemModel in myItemList)
            {
                EngineSettings.BattleScore.ItemsDroppedList += ItemModel.FormatOutput() + "\n";
                DroppedMessage += ItemModel.Name + "\n";
            }

            EngineSettings.ItemPool.AddRange(myItemList);

            if (myItemList.Count == 0)
            {
                DroppedMessage = " Nothing dropped. ";
            }

            EngineSettings.BattleMessagesModel.DroppedMessage = DroppedMessage;

            EngineSettings.BattleScore.ItemModelDropList.AddRange(myItemList);

            return myItemList.Count();
        }            

        /// <summary>
        /// Roll To Hit
        /// </summary>
        /// <param name="AttackScore"></param>
        /// <param name="DefenseScore"></param>
        public override HitStatusEnum RollToHitTarget(int AttackScore, int DefenseScore)
        {
            return base.RollToHitTarget(AttackScore, DefenseScore);
        }

        /// <summary>
        /// Will drop between 1 and 4 items from the ItemModel set...
        /// </summary>
        public override List<ItemModel> GetRandomMonsterItemDrops(int round)
        {
            // TODO: Teams, You need to implement your own modification to the Logic cannot use mine as is.
            return base.GetRandomMonsterItemDrops(round);
        }

        /// <summary>
        /// Critical Miss Problem
        /// </summary>
        public override bool DetermineCriticalMissProblem(PlayerInfoModel attacker)
        {
            return base.DetermineCriticalMissProblem(attacker);
        }
    }
}