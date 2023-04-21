using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeController : MonoBehaviour
{
    public ProgressController progressInst;
    [SerializeField] private Image[] fillBar = new Image[3];
    [SerializeField] private GymController gym;
    [SerializeField] private FoodController food;
    [SerializeField] private ServicesController services;
    [SerializeField] private Text[] imagen = new Text[3];
    [SerializeField] private TimeController scriptMonth;
 
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<3;i++)
        {
         
            fillBar[i].fillAmount = 0f;
            imagen[i].text = "0";
        }
       
    }

 
    public void OnPointerEnterXR()
    {
        gameObject.transform.Find("dinero").GetComponent<Text>().text=progressInst.Money.ToString();        
          if(gym.month <scriptMonth.month)
         {
            
            fillBar[0].color= new Color(255,0,0,255);
         }
         else
         {
            fillBar[0].color= new Color(255,255,255,255);
         }
         if(food.month <scriptMonth.month)
         {
            
            fillBar[1].color= new Color(255,0,0,255);
         }
         else
         {
            fillBar[1].color= new Color(255,255,255,255);
         }
        
        if(services.month <scriptMonth.month)
         {
            
            fillBar[2].color= new Color(255,0,0,255);
         }
         else
         {
            fillBar[2].color= new Color(255,255,255,255);
         }
        
        
        fillBar[0].fillAmount = progressInst.Gym/12f;
        imagen[0].text =  progressInst.Gym + "/12";

        fillBar[1].fillAmount = progressInst.Food/12f;
        imagen[1].text =  progressInst.Food + "/12";

        fillBar[2].fillAmount = progressInst.Services/12f;
        imagen[2].text =  progressInst.Services + "/12";
       
       
        
        
    }
}
