using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZombieManager : MonoBehaviour
{
    #region Singleton
    static ControlZombieManager _instance;
    static public bool isActive
    {
        get
        {
            return _instance != null;
        }
    }
    static public ControlZombieManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Object.FindObjectOfType(typeof(ControlZombieManager)) as ControlZombieManager;
                if (_instance == null)
                {
                    GameObject go = new GameObject("ControlZombieManager");
                    // DontDestroyOnLoad(go);
                    _instance = go.AddComponent<ControlZombieManager>();
                }
            }
            return _instance;
        }
    }
    #endregion
    public List<healthZombie> healthZombies = new List<healthZombie>();
 
    public int countMax;

    public bool CantAddZombie { get => (healthZombies.Count < countMax); }

    public void AddZombie(healthZombie h)
    {
        if (!FindZombie(h))
            healthZombies.Add(h);
    }
    public void DeleteZombie(healthZombie h)
    {
        if (FindZombie(h))
        {
            healthZombies.Remove(h);
           
        }
                    
    }
    
    public bool FindZombie(healthZombie h)
    {
        foreach (var item in healthZombies)
        {
            if (item.gameObject.GetInstanceID() == h.gameObject.GetInstanceID())
                return true;
        }
        return false;
    }
}
