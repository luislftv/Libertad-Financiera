using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    // Clase encargada de manejar el tiempo y la forma en que transcurre en el simulador

   
    [SerializeField] public float monthTime;
    [HideInInspector] public int month=1;
    public float dur;
    [HideInInspector] public bool asd;
 
    [SerializeField] public TextMeshProUGUI timeIndicator;
    [SerializeField] public TextMeshProUGUI message;
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
    bool go;
    bool sg;


    private void Start() {
        messageGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            
            timeIndicator.text="";
            message.text="El juego se reiniciará en 5 segundos";
        }else if (sg)
        {
            tutorial.SetActive(false);
            arrow1.SetActive(true);
            arrow2.SetActive(true);
            arrow3.SetActive(true);
            monthTime += Time.deltaTime;
            timeIndicator.color=Color.white;
            message.color=Color.white;
            message.text="";
        }
        
        if(monthTime>=dur)
        {
        
            
            if(month != arriendo.month)
            {
               gameOver();
               StartCoroutine(restart());
            }
            if(month != entretenimiento.month)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month != food.month)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month != gym.month)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month != ropa.month)
            {
                gameOver();
                StartCoroutine(restart());
            }
            if(month != services.month)
            {
                gameOver();
                StartCoroutine(restart());
            }
            asd=true;
            month++;
            monthTime=0f;
            progress.Money+=200;
            
        }
        else if(monthTime>=(dur-10))
        {
            
            timeIndicator.color=Color.red;
            if(month != arriendo.month)
            {
                message.color=Color.red;
                message.text="Tienes facturas pendientes por pagar, si no pagas pronto perderas";
                messageGO.SetActive(true);
            }
            if(month != entretenimiento.month)
            {
                message.color=Color.red;
                message.text="Tienes facturas pendientes por pagar, si no pagas pronto perderas";
                messageGO.SetActive(true);
            }
            if(month != food.month)
            {
                message.color=Color.red;
                message.text="Tienes facturas pendientes por pagar, si no pagas pronto perderas";
                messageGO.SetActive(true);
            }
            if(month != gym.month)
            {
                message.color=Color.red;
                message.text="Tienes facturas pendientes por pagar, si no pagas pronto perderas";
                messageGO.SetActive(true);
            }
            if(month != ropa.month)
            {
                message.color=Color.red;
                message.text="Tienes facturas pendientes por pagar, si no pagas pronto perderas";
                messageGO.SetActive(true);
            }
            if(month != services.month)
            {
                message.color=Color.red;
                message.text="Tienes facturas pendientes por pagar, si no pagas pronto perderas";
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
        
        
        SceneManager.LoadScene("Sala");
        
    }
}
