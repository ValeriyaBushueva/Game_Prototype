using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaveSystem
{
    [CreateAssetMenu(fileName = "BonusPrefabHub", menuName = "Data/Prefab hub", order = 0)]
    public class BonusPrefabHub : ScriptableObject
    {
        [SerializeField] private List<BonusPrefabByKey> bonusPrefabsByKey;

        public GameObject GetBonusPrefab(string bonusKey)
        {
            BonusPrefabByKey foundPrefabByKey = bonusPrefabsByKey.First(x => x.BonusName == bonusKey);
            
            return foundPrefabByKey.BonusPrefab;
        }
        
        
        [Serializable]
        public class BonusPrefabByKey
        {
            public string BonusName;
            public GameObject BonusPrefab;
        }
    }
}