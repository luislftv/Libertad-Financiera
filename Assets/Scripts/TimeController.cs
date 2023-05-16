using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    // Clase encargada de manejar el tiempo y la forma en que transcurre en el simulador

   
    [SerializeField] public float monthTime;
    [HideInInspector] public int month=1;
    public float dur;
    [HideInInspector] public bool asd;
 

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
