using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update

   
    [SerializeField] public float monthTime;
    [HideInInspector] public int month=1;
    public float dur;
    [HideInInspector] public bool asd;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        monthTime += Time.deltaTime;
        if(monthTime>=dur)
        {
            asd=true;
            month++;
            monthTime=0f;
        }else{asd=false;}
       
       
    }
}
