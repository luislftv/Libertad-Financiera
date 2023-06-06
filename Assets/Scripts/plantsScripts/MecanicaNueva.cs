using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MecanicaNueva : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject guide;
    public float movementSpeed = 5f;
    public float errorThreshold = 0.1f;
    private RaycastHit hit;

    private bool isMoving = false;

    private void Update()
    {
        // Check if the gaze pointer is over the panel
         if (Physics.Raycast(transform.position, transform.forward, out hit, 3.5f))
        {
            if (hit.collider.CompareTag("esfera"))
            {

                timer += Time.deltaTime;
                targetPosition = hit.collider.gameObject.transform.position;
                if (timer >= gazeTime.timeForSelection)
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

    private Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t * (p1.x - p0.x);
        float y = p0.y + t * (p1.y - p0.y);
        float z = p0.z + t * (p1.z - p0.z);

        return new Vector3(x, y, z);
    }
}
