using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private static PrefabManager instance;
    public static PrefabManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }

    [Serializable]
    public class PrefabMap
    {
        public GameObject prefab;
        public string name;
    }

    [SerializeField]
    public List<PrefabMap> maps = new List<PrefabMap>();

    public GameObject GetPrefab(string name)
    {
        foreach (PrefabMap map in maps)
        {
            if (map.name.Equals(name)) return map.prefab;
        }
        return null;
    }
}
