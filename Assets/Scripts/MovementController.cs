using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class MovementController : MonoBehaviour
{
    public float gazeTime = 2f;
    public float moveSpeed = 5f;
    private bool moving = false;
    public GameObject player;

    private float timer;

    private RaycastHit hit;

    Vector3 targetPosition;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider.CompareTag("arrow"))
            {

                timer += Time.deltaTime;
                targetPosition = hit.collider.gameObject.transform.position;
                if (timer >= gazeTime)
                {
                    moving = true;
                    MoveTowardsObject();
                }
            }
            else
            {

                timer = 0f;
            }
        }
        else
        {

            timer = 0f;
        }

        if (moving)
        {
            MoveTowardsObject();

            // Comprobar si se ha llegado al objeto y detener el movimiento
            if (player.transform.position == targetPosition)
            {
                moving = false;
            }
        }
    }
    void MoveTowardsObject()
    {

        targetPosition.y = player.transform.position.y;
        float step = moveSpeed * Time.deltaTime;
        player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);

    }

}
