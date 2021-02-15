using System.Collections.Generic;
using Game.Models;

namespace Game.ViewModels
{
    public class GenericViewModel<T> : BaseViewModel<DefaultModel> where T: class
    {
        /// <summary>
        /// The Item Model
        /// </summary>
        T bindingData { get; set; }

        /// <summary>
        /// List of available Items for equip
        /// </summary>
        List<ItemModel> weaponItemList { get; set; }
        List<ItemModel> shieldItemList { get; set; }
        List<ItemModel> armorItemList { get; set; }
        List<ItemModel> accessoryItemList { get; set; }

        public T Data
        {
            get { return bindingData; }
            set {
                var data = bindingData;
                SetProperty(ref data, value);
                bindingData = data;
            }
        }

        public List<ItemModel> WeaponItemList
        {
            get { return weaponItemList; }
            set
            {
                var data = weaponItemList;
                SetProperty(ref data, value);
                weaponItemList = data;
            }
        }

        public List<ItemModel> ShieldItemList
        {
            get { return shieldItemList; }
            set
            {
                var data = shieldItemList;
                SetProperty(ref data, value);
                shieldItemList = data;
            }
        }

        public List<ItemModel> ArmorItemList
        {
            get { return armorItemList; }
            set
            {
                var data = armorItemList;
                SetProperty(ref data, value);
                armorItemList = data;
            }
        }

        public List<ItemModel> AccessoryItemList
        {
            get { return accessoryItemList; }
            set
            {
                var data = accessoryItemList;
                SetProperty(ref data, value);
                accessoryItemList = data;
            }
        }

        /// <summary>
        /// Constructor takes an existing item and sets
        /// The Title for the page to match the text of data
        /// The Data to be the passed in data
        /// </summary>
        /// <param name="data"></param>
        public GenericViewModel(T data)
        {
            if (data != null)
            {
                Title = (data as BaseModel<T>).Name;
            }
            Data = data;
        }

        // Generic Constructor
        public GenericViewModel()
        {
        }
    }
}
