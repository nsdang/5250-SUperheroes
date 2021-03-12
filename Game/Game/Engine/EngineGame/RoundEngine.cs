using System;
using System.Collections.Generic;
using System.Linq;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.Models;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// Manages the Rounds
    /// </summary>
    public class RoundEngine : RoundEngineBase, IRoundEngineInterface
    {
        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        public RoundEngine()
        {
            Turn = new TurnEngine();
        }

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        public override bool ClearLists()
        {
            return base.ClearLists();
        }

        /// <summary>
        /// Call to make a new set of monsters..
        /// </summary>
        public override bool NewRound()
        {
            return base.NewRound();
        }

        /// <summary>
        /// Add Monsters to the Round
        /// 
        /// Because Monsters can be duplicated, will add 1, 2, 3 to their name
        ///   
        /*
            * Hint: 
            * I don't have crudi monsters yet so will add 6 new ones..
            * If you have crudi monsters, then pick from the list

            * Consdier how you will scale the monsters up to be appropriate for the characters to fight
            * 
            */
        /// </summary>
        /// <returns></returns>
        public override int AddMonstersToRound()
        {
            
            // INFO: Teams, work out your logic
            int currentRound = 1 + EngineSettings.BattleScore.RoundCount;
            List<MonsterModel> monsters = Game.GameRules.DefaultData.LoadData(new MonsterModel());
            List<MonsterModel> temp = new List<MonsterModel>();
            int count = 0;

            if (currentRound % 2 == 0)
            {   // Randomize between caro yin and anais
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.McDonaldsEmployee)));
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.Accountant)));
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.Vet)));

                while (count < EngineSettings.MaxNumberPartyMonsters)
                {
                    int index = Game.Helpers.DiceHelper.RollDice(1, 3);

                    PlayerInfoModel chosen = new PlayerInfoModel(temp[index - 1]);
                    chosen.MaxHealth = Game.Helpers.DiceHelper.RollDice(1, 20);

                    chosen.CurrentHealth = chosen.MaxHealth;
                    EngineSettings.MonsterList.Add(chosen);
                    count++;
                }
            }
            else if (currentRound % 3 == 0)
            { // at least one steve
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.Boss)));
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.Vet)));

                while (count < EngineSettings.MaxNumberPartyMonsters - 1)
                {
                    int index = Game.Helpers.DiceHelper.RollDice(1, 2);

                    PlayerInfoModel chosen = new PlayerInfoModel(temp[index - 1]);
                    chosen.MaxHealth = Game.Helpers.DiceHelper.RollDice(1, 20);
                    chosen.CurrentHealth = chosen.MaxHealth;

                    EngineSettings.MonsterList.Add(chosen);
                    count++;
                }

                // make sure there is at least one steve
                EngineSettings.MonsterList.Add(new PlayerInfoModel(monsters.Find(m => m.Job.Equals(CharacterJobEnum.Boss))));
            }
            else
            {
                // randomize between bob caro yin
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.McDonaldsEmployee)));
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.Accountant)));
                temp.Add(monsters.Find(m => m.Job.Equals(CharacterJobEnum.Carpenter)));

                while (count < EngineSettings.MaxNumberPartyMonsters)
                {
                    int index = Game.Helpers.DiceHelper.RollDice(1, 3);

                    PlayerInfoModel chosen = new PlayerInfoModel(temp[index - 1]);
                    chosen.MaxHealth = Game.Helpers.DiceHelper.RollDice(1, 20);
                    chosen.CurrentHealth = chosen.MaxHealth;

                    EngineSettings.MonsterList.Add(chosen);
                    count++;
                }
            }

            return EngineSettings.MonsterList.Count();
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List
        /// Clear the MonsterModel List
        /// </summary>
        public override bool EndRound()
        {
            return base.EndRound();
        }

        /// <summary>
        /// For each character pickup the items
        /// </summary>
        public override bool PickupItemsForAllCharacters()
        {
            // INFO: Teams, work out your turn logic
            return base.PickupItemsForAllCharacters();
        }

        /// <summary>
        /// Manage Next Turn
        /// 
        /// Decides Who's Turn
        /// Remembers Current Player
        /// 
        /// Starts the Turn
        /// 
        /// </summary>
        public override RoundEnum RoundNextTurn()
        {
            return base.RoundNextTurn();
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        public override PlayerInfoModel GetNextPlayerTurn()
        {
            return base.GetNextPlayerInList();
        }

        /// <summary>
        /// Remove Dead Players from the List
        /// </summary>
        public override List<PlayerInfoModel> RemoveDeadPlayersFromList()
        {
            return base.RemoveDeadPlayersFromList();
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public override List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            return base.OrderPlayerListByTurnOrder();
        }

        /// <summary>
        /// Who is Playing this round?
        /// </summary>
        public override List<PlayerInfoModel> MakePlayerList()
        {
            return base.MakePlayerList();
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        public override PlayerInfoModel GetNextPlayerInList()
        {
            return base.GetNextPlayerInList();
        }

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        public override bool PickupItemsFromPool(PlayerInfoModel character)
        {
            // INFO: Teams, work out your turn logic
            return base.PickupItemsFromPool(character);
        }

        /// <summary>
        /// Swap out the item if it is better
        /// 
        /// Uses Value to determine
        /// </summary>
        public override bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            // INFO: Teams, work out your turn logic
            return base.GetItemFromPoolIfBetter(character, setLocation);
        }

        /// <summary>
        /// Swap the Item the character has for one from the pool
        /// 
        /// Drop the current item back into the Pool
        /// </summary>
        public override ItemModel SwapCharacterItem(PlayerInfoModel character, ItemLocationEnum setLocation, ItemModel PoolItem)
        {
            return base.SwapCharacterItem(character, setLocation, PoolItem);
        }

        /// <summary>
        /// For all characters in player list, remove their buffs
        /// </summary>
        public override bool RemoveCharacterBuffs()
        {
            return base.RemoveCharacterBuffs();
        }
    }
}