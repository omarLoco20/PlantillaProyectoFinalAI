using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerCamera : MonoBehaviour
{
    public GameObject camTop, camBase, camNpc;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeCameras();
    }

    void changeCameras()
    {
        if (Input.GetKeyDown("1"))
        {
            camBase.gameObject.SetActive(true);
            camNpc.gameObject.SetActive(false);
            camTop.gameObject.SetActive(false);
        }else if(Input.GetKeyDown("2"))
        {
            camBase.gameObject.SetActive(false);
            camNpc.gameObject.SetActive(true);
            camTop.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("3"))
        {
            camBase.gameObject.SetActive(false);
            camNpc.gameObject.SetActive(false);
            camTop.gameObject.SetActive(true);
        }
    }

}
