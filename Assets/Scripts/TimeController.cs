using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    // Clase encargada de manejar el tiempo y la forma en que transcurre en el simulador

   
    [SerializeField] public float monthTime;
    [HideInInspector] public int month=1;
    public float dur;
    [HideInInspector] public bool asd;
 
    [SerializeField] public TextMeshProUGUI timeIndicator;
    [SerializeField] public TextMeshProUGUI money;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject messageGO;
    [SerializeField] private GameObject arrow1;
    [SerializeField] private GameObject arrow2;
    [SerializeField] private GameObject arrow3;
    
    [SerializeField] ProgressController progress;  

    [SerializeField] ArriendoController arriendo;  
    [SerializeField] EntretenimientoController entretenimiento;
    [SerializeField] FoodController food;
    [SerializeField]  GymController gym;
    [SerializeField]  RopaController ropa;
    [SerializeField]  ServicesController services;
    [SerializeField]  AudioSource gameOverSound;
    [SerializeField]  GazePointer gazePointer;
    Image img;
    bool go;
    bool sg;
    float timefade;
    public float fadeSpeed;
    bool fadebool;
    float alpha;
    bool secMonth;
    int monthAnt=1;
    public GameObject credits;

    private void Start() {

        timeIndicator.enabled = false;
        money.enabled = false;
        messageGO.SetActive(false);
        img = messageGO.GetComponent<Image>();
        

    }

    // Update is called once per frame
    void Update()
    {


        money.text = progress.Money.ToString();
        if (go)
        {
            
            timeIndicator.text="";
          
        }
        else if (sg)
        {
            gazePointer.maxDistancePointer=4.5f;
            gazePointer._maxDistance=4.5f;
            tutorial.SetActive(false);
            arrow1.SetActive(true);
            arrow2.SetActive(true);
            arrow3.SetActive(true);
            monthTime += Time.deltaTime;
            money.enabled = true;
            timeIndicator.enabled = true;
            timeIndicator.color=Color.white;
            
        }
       
        if(monthTime>=dur)
        {
        
            
            if(month > arriendo.month+1)
            {
               gameOver();
               StartCoroutine(restart());
            }
            if(month > entretenimiento.month+1)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month > food.month+1)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month > gym.month+1)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month > ropa.month+1)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month > services.month+1)
            {
                gameOver();
                StartCoroutine(restart());
            }
            asd=true;
            monthAnt++;
            month++;
            monthTime=0f;
            progress.Money+=200;
            
        }
        Debug.Log(monthAnt);
         if(monthAnt==2)
        {
            secMonth=true;
            monthAnt=1;
        }
        
        else if(monthTime>=(dur-10)&&secMonth)
        {
            
            timefade+=Time.deltaTime;
            if(timefade<=0.5)
            {
                fadebool=true;
            }
            else if (timefade>0.5f&&timefade<=1f)
            {
                fadebool=false;
            }
            else
            {
                timefade=0;
            }
          
            if(fadebool)
            {
                alpha+=Time.deltaTime*6;
                img.color = new Color(img.color.r, img.color.b, img.color.g, alpha);
                //Debug.Log(aaa);
                
                
            }
            else
            {
                alpha-=Time.deltaTime*6;
                img.color = new Color(img.color.r, img.color.b, img.color.g, alpha);
                //Debug.Log(aaa);
            }
            
            
            if(month > arriendo.month)
            {
                timeIndicator.color=Color.red;
                messageGO.SetActive(true);
                
            }
            if(month > entretenimiento.month)
            {
               timeIndicator.color=Color.red;
                messageGO.SetActive(true);
            }
            if(month > food.month)
            {
                timeIndicator.color=Color.red;
                messageGO.SetActive(true);
            }
            if(month > gym.month)
            {
               timeIndicator.color=Color.red;
                messageGO.SetActive(true);
            }
            if(month > ropa.month)
            {
                timeIndicator.color=Color.red;
                messageGO.SetActive(true);
            }
            if(month > services.month)
            {
               timeIndicator.color=Color.red;
                messageGO.SetActive(true);
            }
            
        }
        else{asd=false;}
        timeIndicator.text=(monthTime/2).ToString("00");
       
       
    }

    

    void gameOver()
    {
        go=true;
        gameOverSound.Play();
        
        
        
    }
    public void startgame()
    {
        sg=true;
        
    }

    IEnumerator restart()
    {

        
        yield return new WaitForSeconds(5f);
        
        
        credits.SetActive(true);
        
    }
}
