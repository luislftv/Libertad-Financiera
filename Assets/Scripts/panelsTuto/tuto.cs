using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject panelTuto;
    public void exit()
    {
        Debug.Log("asd");
        panelTuto.SetActive(false);
    }

    
}
