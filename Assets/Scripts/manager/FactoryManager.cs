using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum TypeObject { Cylindro, Esfera, Cubo }
[System.Serializable]
public class ObjectPrefab
{

    public GameObject prefab;
    public UnitGame type;
 
    public ObjectPrefab()
    { 
    
    }
        

}

public class FactoryManager : MonoBehaviour
{
    #region Singleton
    static FactoryManager _instance;
    static public bool isActive
    {
        get
        {
            return _instance != null;
        }
    }
    static public FactoryManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Object.FindObjectOfType(typeof(FactoryManager)) as FactoryManager;
                if (_instance == null)
                {
                    GameObject go = new GameObject("FactoryManager");
                    // DontDestroyOnLoad(go);
                    _instance = go.AddComponent<FactoryManager>();
                }
            }
            return _instance;
        }
    }
    #endregion
    // Start is called before the first frame update
    public List<ObjectPrefab> ItemPrefab = new List<ObjectPrefab>();
    public GameObject CreateObjectZombie(Transform spwan)
    {

        foreach (var item in ItemPrefab)
        {
            if (item.type == UnitGame.Zombie)
            {
                GameObject obj = GameObject.Instantiate(item.prefab, spwan.position, spwan.rotation);
                healthZombie h = obj.GetComponent<healthZombie>();
                ControlZombieManager.instance.AddZombie(h);
                return obj;
            }
        }
        return null;
    }

}


