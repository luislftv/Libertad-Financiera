using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fondoMutuo : MonoBehaviour
{

    [SerializeField] private ProgressController progress;
    [SerializeField] private TimeController month;
    [SerializeField] private GameObject cosecha;
    [SerializeField] private Text inver;
    [SerializeField] private Text gan;
    private int monto = 0;
    private int mesAnterior;
    private float ganancia;
    int mesInversion = 1;
    bool yaInvirtio;
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
            

            if (month.month == mesAnterior)
            {
                cosecha.SetActive(false);


            }
            else
            {

                cosecha.SetActive(true);
                if (month.asd)
                {
                    
                    Ganancia();
                    

                }

            }
        }




    }

    // Update is called once per frame
    public void OnPointerClickXR()
    {
        // panel.SetActive(true);
    }
    void Ganancia()
    {
        ganancia += monto * 0.15f;
        gan.text="Ganancia: "+ganancia.ToString();
        //time = 0f;


    }

    public void Invertir()
    {
        monto = 50;
        inver.text = monto.ToString();

        if (yaInvirtio == false)
        {
            progress.Money -= monto;
            mesInversion = month.month;
            yaInvirtio = true;
            mesAnterior = month.month;

        }
        else if (month.month >= mesInversion + 3)
        {
            progress.Money -= monto;
            mesInversion = month.month;
            mesAnterior = month.month;

        }
        else
        {
            Debug.Log("ya invirtio hace poco");
        }




    }
    public void Cosechar()
    {
        mesAnterior = month.month;
        progress.Money += ganancia;
        ganancia = 0f;
        gan.text="Ganancia: "+ganancia.ToString();
        cosecha.SetActive(false);
    }
}
