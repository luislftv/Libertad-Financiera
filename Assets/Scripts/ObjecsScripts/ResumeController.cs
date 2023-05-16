using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeController : MonoBehaviour
{
    public ProgressController progressInst;
    [SerializeField] private Image[] fillBar = new Image[6];
    [SerializeField] private GymController gym;
    [SerializeField] private FoodController food;
    [SerializeField] private ServicesController services;
    [SerializeField] private RopaController clothes;
    [SerializeField] private ArriendoController rent;
    [SerializeField] private EntretenimientoController enter;
    [SerializeField] private Text[] imagen = new Text[6];
    [SerializeField] private TimeController scriptMonth;
 
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<6;i++)
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



         if(clothes.month <scriptMonth.month)
         {
            
            fillBar[3].color= new Color(255,0,0,255);
         }
         else
         {
            fillBar[3].color= new Color(255,255,255,255);
         }



         if(rent.month <scriptMonth.month)
         {
            
            fillBar[4].color= new Color(255,0,0,255);
         }
         else
         {
            fillBar[4].color= new Color(255,255,255,255);
         }
        

        
        if(enter.month <scriptMonth.month)
         {
            
            fillBar[5].color= new Color(255,0,0,255);
         }
         else
         {
            fillBar[5].color= new Color(255,255,255,255);
         }
        
        
        fillBar[0].fillAmount = progressInst.Gym/12f;
        imagen[0].text =  progressInst.Gym + "/12  Gimnasio";

        fillBar[1].fillAmount = progressInst.Food/12f;
        imagen[1].text =  progressInst.Food + "/12  Mercado";

        fillBar[2].fillAmount = progressInst.Services/12f;
        imagen[2].text =  progressInst.Services + "/12  Servicios";


        fillBar[3].fillAmount = progressInst.Clothes/12f;
        imagen[3].text =  progressInst.Clothes + "/12  Ropa";

        fillBar[4].fillAmount = progressInst.Rent/12f;
        imagen[4].text =  progressInst.Rent + "/12  Arriendo";

        fillBar[5].fillAmount = progressInst.Enter/12f;
        imagen[5].text =  progressInst.Enter + "/12  Entretenimiento";
       
       
       
        
        
    }
}
