using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
namespace Core
{
    public enum GameResource
    {
        Humans,
        Food,
        Wood,
        Stone,
        Gold,
        HumansProdLvl,
        FoodProdLvl,
        WoodProdLvl,
        StoneProdLvl,
        GoldProdLvl
    }
    public class ResourceBank
    {
        public event System.Action OnValueChanged;
        
        
        private Dictionary<GameResource, ObservableCollection<int>> _dictionary=new Dictionary<GameResource, ObservableCollection<int>>();
        
        
        public ResourceBank(int humans,int food,
            int wood,int stone,int gold)
        {
            _dictionary.Add(GameResource.Humans, new ObservableCollection<int> { humans });
            _dictionary.Add(GameResource.Food, new ObservableCollection<int> { food });
            _dictionary.Add(GameResource.Wood, new ObservableCollection<int> { wood });
            _dictionary.Add(GameResource.Stone, new ObservableCollection<int> { stone });
            _dictionary.Add(GameResource.Gold, new ObservableCollection<int> { gold });
            _dictionary.Add(GameResource.HumansProdLvl, new ObservableCollection<int> { 1 });
            _dictionary.Add(GameResource.FoodProdLvl, new ObservableCollection<int> { 1 });
            _dictionary.Add(GameResource.WoodProdLvl, new ObservableCollection<int> { 1 });
            _dictionary.Add(GameResource.StoneProdLvl, new ObservableCollection<int> { 1 });
            _dictionary.Add(GameResource.GoldProdLvl, new ObservableCollection<int> { 1 });
        }
        
        public void ChangeResource(GameResource r,int v)
        {
            _dictionary[r][0] += v;
            OnValueChanged?.Invoke();
        }

        public int GetResource(GameResource r)
        {
            return _dictionary[r][0];
        }

        
    }
}