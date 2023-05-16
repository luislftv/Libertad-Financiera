using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIXR : MonoBehaviour
{
    public UnityEvent onXRPointerEnter;
    public UnityEvent onXRPointerExit;
    private Camera xRcamera;
    // Start is called before the first frame update
    void Start()
    {
        xRcamera = GazePointer.Instance.gameObject.GetComponent<Camera>();
    }

    public void OnPointerClickXR() //Metodo que se ejecuta cuando pasa el tiempo de seleccion del gaze en un objeto con tag "Interactable"
    {
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler);
    }
    public void OnPointerEnterXR()//Metodo que se ejecuta cuando pasa el gaze por encima de en un objeto con tag "Interactable"
    {
        
        onXRPointerEnter?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerEnterHandler);
    }
     public void OnPointerExitXR()//Metodo que se ejecuta cuando sale el gaze de en un objeto con tag "Interactable"
    {
        
        onXRPointerEnter?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerExitHandler);
    }

    private PointerEventData PlacePointer()
    {
        Vector3 screePos = xRcamera.WorldToScreenPoint(GazePointer.Instance.hitPoint);
        var pointer = new PointerEventData(EventSystem.current);
        pointer.position = new Vector2(screePos.x, screePos.y);
        return pointer;
    }

}
