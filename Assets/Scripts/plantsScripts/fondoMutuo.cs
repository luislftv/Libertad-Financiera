using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fondoMutuo : MonoBehaviour
{

    [SerializeField] private ProgressController progress;
    [SerializeField] private TimeController month;
    [SerializeField] private GameObject cosecha;
    private int monto = 0;
    private int mesAnterior;
    private float ganancia;
    int mesInversion = 1;
    bool yaInvirtio;
    float time;
    void Start()
    {
        cosecha.SetActive(false);

    }
    void Update()
    {

        if (yaInvirtio == true)
        {
            time += Time.deltaTime;

            if (month.month == mesAnterior)
            {
                cosecha.SetActive(false);


            }
            else
            {

                cosecha.SetActive(true);
                if (time >= month.dur)
                {
                    Ganancia();
                    time = 0f;

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


    }

    public void Invertir()
    {
        monto = 50;

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
        cosecha.SetActive(false);
    }
}
