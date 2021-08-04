using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SaveSystem
{
    public class BonusPrefabHub : MonoBehaviour
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