using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update

   
    [SerializeField] private float monthTime;
    [HideInInspector] public int month=1;
     [SerializeField] private float dur;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        monthTime += Time.deltaTime;
        if(monthTime>dur)
        {
            month++;
            monthTime=0f;
        }
       
       
    }
}
