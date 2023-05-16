using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bolsa : MonoBehaviour
{
   
    [SerializeField] private ProgressController progress;
    [SerializeField] private TimeController month;
    [SerializeField] private GameObject cosecha;
    [SerializeField] private GameObject invertir;
    [SerializeField] private Text inver;
    [SerializeField] private Text gan;
    [SerializeField] private int plazo;
    [SerializeField] private int monto;
    private float riesgo;
    
    private int mesCosecha;
    private float ganancia;
    int mesInversion;
    bool yaInvirtio;
    bool yaCosecho;
    bool yaPuedeCosechar;
   // public float time;
    void Start()
    {
        cosecha.SetActive(false);

    }
    void Update()
    {
        
        //time += Time.deltaTime;
        if (yaInvirtio == true)
        {
            if (month.month < mesCosecha)
            {
                cosecha.SetActive(false);
            }
            else if (yaCosecho == false)
            {
                cosecha.SetActive(true);
                if(!yaPuedeCosechar)
                {
                    Ganancia();
                }
            }
            else{cosecha.SetActive(false);}
        }
    }

    // Update is called once per frame
    public void OnPointerClickXR()
    {
        // panel.SetActive(true);
    }
    void Ganancia()
    {
        var num = Random.Range(0,101);

        if(plazo >0 && plazo <= 3)
        {
            riesgo = 50;
        }
        else if (plazo >3 && plazo <= 6)
        {
            riesgo = 40;
        }
        else if(plazo >6 && plazo <= 9)
        {
            riesgo = 30;
        }
        else{Debug.Log("Valor incorrecto");}

         if (num < riesgo)
        {
            // Si el número es menor que la probabilidad de perder, se pierde
            ganancia = 0f;
        
        }
        else
        {
            // Si el número es mayor o igual que la probabilidad de perder, se gana
            ganancia = monto * (1.75f);
        }        
        gan.text="Ganancia: "+ganancia.ToString();
        yaPuedeCosechar = true;
        Debug.Log(ganancia);


    }

    public void Invertir()
    {
        
        inver.text = monto.ToString();

        progress.Money -= monto;
        mesInversion = month.month;
        mesCosecha = month.month+plazo;
        yaInvirtio = true;
        yaCosecho = false;
        yaPuedeCosechar = false;
        invertir.SetActive(false);




    }
    public void Cosechar()
    {
        mesCosecha = month.month;
        inver.text ="";
        progress.Money += ganancia;
        ganancia = 0f;
        gan.text="Ganancia: "+ganancia.ToString();
        cosecha.SetActive(false);
        invertir.SetActive(true);
        yaCosecho = true;
    }
}
