using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivitiesController : MonoBehaviour
{
    public float gazeTime = 2f;
    private float timer;
    private RaycastHit hit;
    private GameObject viewedObject;
    private GameObject lastObject;
    private GameObject menu;
    private bool panel;
    private bool interactableObject;
    private bool esfera;

    void Start()
    {
        menu = new GameObject();
    }

    void Update()
    {
        try
        {

            progress();

        }
        catch 
        { }
    }

    void progress()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.8f))
        {
            panel = hit.collider.CompareTag("panel");
            interactableObject = hit.collider.CompareTag("Interactable");
            esfera = hit.collider.CompareTag("esfera");
           


            if (interactableObject || panel || esfera)
            {
                timer += Time.deltaTime;
                if (timer >= gazeTime)
                {
                    menu = hit.collider.gameObject.transform.Find("Panel").gameObject;
                    menu.SetActive(true);


                }
            }


            else
            {
                StartCoroutine(corrutina(menu));
             
                timer = 0f;

            }

        }
        else
        {
            timer = 0f;
        }
    }
    IEnumerator corrutina(GameObject progressMenu) 
    {
        yield return new WaitForSeconds(0.1f);

        try
        {
            if (hit.collider.CompareTag("panel"))
            {
                progressMenu.SetActive(true);
            }
            else
            {
                progressMenu.SetActive(false);
                timer = 0f;
            }
        }
        catch (System.Exception)
        {
            
            
        }

    }
}
