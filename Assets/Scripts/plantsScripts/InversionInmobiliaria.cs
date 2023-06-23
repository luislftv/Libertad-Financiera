using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InversionInmobiliaria : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] float housePrice;
    [SerializeField] bool houseBought;
    [SerializeField] float alquiler;
    [SerializeField] private GameObject cosecha;
    [SerializeField] private GameObject compra;
    private int mesAnterior;
    [SerializeField] private Text inver;
    [SerializeField] private Text gan;

    [SerializeField] ProgressController PG;
    [SerializeField] TimeController TC;

    [SerializeField] private GameObject regadera;
    [SerializeField] private GameObject planta;
    [SerializeField] private platsAnimatorScript plantaAnim;
    private float ganancia;
  public void BuyHouse()
  {
    if (!houseBought)
    {
        if(housePrice <= PG.Money)
        {
            PG.Money -= housePrice;
            houseBought = true;
            
            inver.text = housePrice.ToString();
            compra.SetActive(false);
            StartCoroutine(desRegadera());
            plantaAnim.fase4();
        }
        else {Debug.Log("Dinero insuficiente");}
    }

  }
  
  void Ganancia()
    {
        ganancia += alquiler;
        gan.text="Ganancia: "+ganancia.ToString();
        //time = 0f;

    }
    public void Cosechar()
    {
        PG.Money += ganancia;
        mesAnterior = TC.month;
        ganancia = 0f;
        gan.text="Ganancia: "+ganancia.ToString();
        StartCoroutine(desRegadera());
        cosecha.SetActive(false);
    }

    void Start()
    {
        inver.text="Inversion: "+housePrice.ToString();
    }

  void Update() 
  {
     if (houseBought)
        {
            

            if (TC.month == mesAnterior)
            {
                cosecha.SetActive(false);


            }
            else
            {

                cosecha.SetActive(true);
                if (TC.asd)
                {
                    
                    Ganancia();
                    

                }

            }
        }
  }

  IEnumerator desRegadera()
    {   regadera.SetActive(true);
        yield return new WaitForSeconds(3f);
        regadera.SetActive(false);

    }
}
