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
        List<ItemModel> handItemList { get; set; }
        List<ItemModel> fingerItemList { get; set; }
        List<ItemModel> headItemList { get; set; }

        public T Data
        {
            get { return bindingData; }
            set {
                var data = bindingData;
                SetProperty(ref data, value);
                bindingData = data;
            }
        }

        public List<ItemModel> HandItemList
        {
            get { return handItemList; }
            set
            {
                var data = handItemList;
                SetProperty(ref data, value);
                handItemList = data;
            }
        }

        public List<ItemModel> FingerItemList
        {
            get { return fingerItemList; }
            set
            {
                var data = fingerItemList;
                SetProperty(ref data, value);
                fingerItemList = data;
            }
        }

        public List<ItemModel> HeadItemList
        {
            get { return headItemList; }
            set
            {
                var data = headItemList;
                SetProperty(ref data, value);
                headItemList = data;
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
