﻿using System;
using System.Linq;
using System.Collections.Generic;

using Xamarin.Forms;

using Game.Models;
using Game.Views;
using Game.GameRules;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Game.ViewModels
{
    /// <summary>
    /// Index View Model
    /// Manages the list of data records
    /// </summary>
    public class CharacterIndexViewModel : BaseViewModel<CharacterModel>
    {
        public ObservableCollection<CharacterModel> DataSet { get; set; }
        #region Singleton

        // Make this a singleton so it only exist one time because holds all the data records in memory
        private static volatile CharacterIndexViewModel instance;
        private static readonly object syncRoot = new Object();

        public static CharacterIndexViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new CharacterIndexViewModel();
                            instance.Initialize();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion Singleton

        #region Constructor

        /// <summary>
        /// Constructor
        /// 
        /// The constructor subscribes message listeners for crudi operations
        /// </summary>
        public CharacterIndexViewModel()
        {
            Title = "Characters";
            DataSet = new ObservableCollection<CharacterModel>();

            #region Messages

            // Register the Create Message
            MessagingCenter.Subscribe<CharacterCreatePage, CharacterModel>(this, "Create", async (obj, data) =>
            {
                await CreateAsync(data as CharacterModel);
            });

            // Register the Update Message
            MessagingCenter.Subscribe<ItemUpdatePage, CharacterModel>(this, "Update", async (obj, data) =>
            {
                // Have the item update itself
                data.Update(data);

                await UpdateAsync(data as CharacterModel);
            });

            // Register the Delete Message
            MessagingCenter.Subscribe<CharacterDeletePage, CharacterModel>(this, "Delete", async (obj, data) =>
            {
                await DeleteAsync(data as CharacterModel);
            });

            // Register the Set Data Source Message
            MessagingCenter.Subscribe<AboutPage, int>(this, "SetDataSource", async (obj, data) =>
            {
                await SetDataSource(data);
            });

            // Register the Wipe Data List Message
            MessagingCenter.Subscribe<AboutPage, bool>(this, "WipeDataList", async (obj, data) =>
            {
                await WipeDataListAsync();
            });

            #endregion Messages
        }

        #endregion Constructor

        #region DataOperations_CRUDi

        /// <summary>
        /// Read an item from the datastore
        /// </summary>
        /// <param name="id">ID of the Record</param>
        /// <returns>The Record from ReadAsync</returns>
        public new async Task<CharacterModel> ReadAsync(string id)
        {
            var result = await DataStore.ReadAsync(id);

            return result;
        }

        /// Delete the record from the system
        /// </summary>
        /// <param name="data">The Record to Delete</param>
        /// <returns>True if Deleted</returns>
        public new async Task<bool> DeleteAsync(CharacterModel data)
        {
            // Check if the record exists, if it does not, then null is returned
            var record = await ReadAsync(data.Id);
            if (record == null)
            {
                return false;
            }

            // Remove from the local data set cache
            DataSet.Remove(data);

            // Call to remove it from the Data Store
            var result = await DataStore.DeleteAsync(data.Id);

            return result;
        }

        /// <summary>
        /// Returns the item passed in
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public override CharacterModel CheckIfExists(CharacterModel data)
        {
            if (data == null)
            {
                return null;
            }

            // This will walk the items and find if there is one that is the same.
            // If so, it returns the item...

            var myList = Dataset.Where(a =>
                                        a.Name == data.Name &&
                                        a.Description == data.Description &&
                                        a.Level == data.Level &&
                                        a.Range == data.Range 
                                        )
                                        .FirstOrDefault();

            if (myList == null)
            {
                // it's not a match, return false;
                return null;
            }

            return myList;
        }

        /// <summary>
        /// Load the Default Data
        /// </summary>
        /// <returns></returns>
        public override List<CharacterModel> GetDefaultData() 
        {
            return DefaultData.LoadData(new CharacterModel());
        }

        #endregion DataOperations_CRUDi

        #region SortDataSet

        /// <summary>
        /// The Sort Order for the CharacterModel
        /// </summary>
        /// <param name="dataset"></param>
        /// <returns></returns>
        public override List<CharacterModel> SortDataset(List<CharacterModel> dataset)
        {
            return dataset
                    .OrderBy(a => a.Name)
                    .ThenBy(a => a.Description)
                    .ToList();
        }

        #endregion SortDataSet

        /// <summary>
        /// Takes an item string ID and looks it up and returns the item
        /// This is because the Items on a character are stores as strings of the GUID.  That way it can be saved to the DB.
        /// </summary>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        public CharacterModel GetItem(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            // Item myData = DataStore.GetAsync_Item(ItemID).GetAwaiter().GetResult();
            CharacterModel myData = Dataset.Where(a => a.Id.Equals(id)).FirstOrDefault();
            if (myData == null)
            {
                return null;
            }

            return myData;
        }
    }
}