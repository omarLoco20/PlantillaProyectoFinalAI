using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemFood : Item
{
    public float Food;
    // Start is called before the first frame update
    void Start()
    {
        base.LoadArrayRate();
    }

    // Update is called once per frame
    void Update()
    {
        if (FrameRate > Rate && !Infinity)
        {
            DestroyItem();
        }
        FrameRate += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == (int)Mathf.Log(layerCollider.value, 2))
        {
            healthHuman _healthHuman = other.gameObject.GetComponent<healthHuman>();
            if (_healthHuman != null)
            {
                _healthHuman.SetFood(Food);
            }
            DestroyItem();
        }
    }
}
