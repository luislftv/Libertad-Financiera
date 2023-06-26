using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ServicesController : MonoBehaviour
{
   
    public ProgressController progressInst;
    [SerializeField] private Image fillBar;
     [SerializeField] private TimeController scriptMonth;
     [SerializeField] private Image progressBar;
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
          if(month !=scriptMonth.month)
         {
            if(fillBar.fillAmount ==0f)
            {
                progressBar.color = new Color(255f/255,127f/255,0,255);
                Debug.Log("asd");
            }
            else{progressBar.color=new Color(1,1,1,1);}
            fillBar.color= new Color(255,0,0,255);
         }
         else
         {
            progressBar.color=new Color(1,1,1,1);
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
            fillBar.fillAmount += 1/12f;
       
            progressInst.Services += 1f;
            progressInst.Money -=25f;
            month += 1f;
        }
        
    }
}
