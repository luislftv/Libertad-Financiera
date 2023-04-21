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

    public void OnPointerClickXR()
    {
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler);
    }
    public void OnPointerEnterXR()
    {
        
        onXRPointerEnter?.Invoke();
        PointerEventData pointerEvent = PlacePointer();
        ExecuteEvents.Execute(this.gameObject, pointerEvent, ExecuteEvents.pointerEnterHandler);
    }
     public void OnPointerExitXR()
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
