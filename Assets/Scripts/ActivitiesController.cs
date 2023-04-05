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
    private GameObject progressMenu;

    void Update()
    {
        try
        {
            progress();
        }
        catch (System.Exception)
        {}
    }

    void progress()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                lastObject = viewedObject;
                viewedObject = hit.collider.gameObject;
                progressMenu = lastObject.transform.Find("image").gameObject;

                if (lastObject == viewedObject)
                {
                    timer += Time.deltaTime;
                    if (timer >= gazeTime)
                    {
                        progressMenu.SetActive(true);

                    }
                }
                else
                {
                    progressMenu.SetActive(false);
                    timer = 0f;
                }
            }
            else
            {
                timer = 0f;
            }
    }
}
