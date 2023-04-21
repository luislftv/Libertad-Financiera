using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GymController : MonoBehaviour
{
    public ProgressController progressInst;
    [SerializeField] public Image fillBar;
    [SerializeField] private TimeController scriptMonth;
    
    public Text imagen;
     [HideInInspector] public  float month;
    
     

    // Start is called before the first frame update
    void Start()
    {
        month=0f;
       fillBar.fillAmount = 0f;
        
    }

    // Update is called once per frame
    void Update()
    {
         MostrarPuntaje();
         if(month <scriptMonth.month)
         {
            
            fillBar.color= new Color(255,0,0,255);
         }
         else
         {
            fillBar.color= new Color(255,255,255,255);
         }
    }

    void MostrarPuntaje()
    {
      
        imagen.text =  month + "/12";
    }
    public void OnPointerClickXR()
    {
        if (month < 12f)
        {
            fillBar.fillAmount += (1/12f)/2f;
       
            progressInst.Gym += 1/2f;
            progressInst.Money -=25/2f;
            month += 1/2f;
        }
        
    }
    
}
