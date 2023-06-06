using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MecanicaNueva : MonoBehaviour
{
     public Transform objectToMove;
    public Transform guide;
    public float movementSpeed = 5f;
    public float errorThreshold = 0.1f;

    private bool isMoving = false;

    private void Update()
    {
        // Check if the gaze pointer is over the panel
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // Check if the gaze pointer is over the guide
            if (IsGazeOnGuide())
            {
                // Start moving the object
                isMoving = true;
            }
            else if (isMoving)
            {
                // If the object was moving but the gaze is no longer on the guide, show an error message
                Debug.Log("Error: Gaze pointer moved outside the guide!");
                isMoving = false;
            }
        }

        // Move the object if it's currently being moved
        if (isMoving)
        {
            Vector3 targetPosition = guide.position;
            targetPosition.y = objectToMove.position.y; // Maintain the object's initial height

            // Move the object towards the guide
            objectToMove.position = Vector3.MoveTowards(objectToMove.position, targetPosition, movementSpeed * Time.deltaTime);

            // Check if the object has reached the guide
            if (Vector3.Distance(objectToMove.position, targetPosition) < errorThreshold)
            {
                // Object reached the guide, stop moving
                isMoving = false;
            }
        }
    }

    private bool IsGazeOnGuide()
    {
        RaycastResult raycastResult = new RaycastResult();
        List <RaycastResult> raycastResults = new List <RaycastResult>();
        raycastResults.Add(raycastResult);
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(Screen.width / 2, Screen.height / 2);
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResult.gameObject != null && raycastResult.gameObject.transform == guide;
    }
}
