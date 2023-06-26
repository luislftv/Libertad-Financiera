using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bolsa : MonoBehaviour
{
   
    [SerializeField] private ProgressController progress;
    [SerializeField] private TimeController month;
    [SerializeField] private GameObject invertir;
    [SerializeField] private MecanicaNueva veri; 
    [SerializeField] private GameObject MiniJuego;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject planta;
    [SerializeField] private Text titulo;
    [SerializeField] private AudioSource win;
    [SerializeField] private AudioSource lose;
  
    private float riesgo;
    
    private int mesCosecha;
    private float ganancia;
    int mesInversion;
    bool yaInvirtio;
    bool yaCosecho;
    bool yaPuedeCosechar;
   
    void Start()
    {
        MiniJuego.SetActive(false);
        
        
        
    }
    void Update()
    {
      
        if (veri.meta)
        {
             
            Ganancia();
            GameOver();
            veri.meta=false;
        }
        if (veri.GaOv)
        {
             
            perdida();
            GameOver();
            veri.GaOv=false;
        }
        
 
    }

    
    void Ganancia()
    {
        
        progress.Money+=50;
        spheres();
        win.Play();
    }
    void perdida()
    {
        
        progress.Money-=50;
        lose.Play();
    }

    public void Invertir()
    {
        
      
    MiniJuego.SetActive(true);
    menu.SetActive(false);
    planta.SetActive(true);

    }
    public void GameOver()
    {
        
        this.enabled=true;  
        MiniJuego.SetActive(false);
        menu.SetActive(true);
        spheres();
        planta.SetActive(false);


    }

    void spheres()
    {
        MiniJuego.transform.Find("image").transform.Find("n1").gameObject.SetActive(true);
        MiniJuego.transform.Find("image").transform.Find("n2").gameObject.SetActive(true);
        MiniJuego.transform.Find("image").transform.Find("n3").gameObject.SetActive(true);
        MiniJuego.transform.Find("image").transform.Find("n4").gameObject.SetActive(true);
    }

}
