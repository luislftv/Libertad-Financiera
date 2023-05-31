using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GazePointer : MonoBehaviour {

    [SerializeField] private GameObject pointer;
    [SerializeField] private float maxDistancePointer = 9.0f;
    [Range(0, 1)][SerializeField] private float disPointerObj = 0.95f;
    private readonly string interactableTag = "Interactable";
    private float scaleSize = 0.025f;
    [SerializeField] private float _maxDistance = 4;   
    private GameObject _gazedAtObject = null;

    public static GazePointer Instance;
    [HideInInspector] public Vector3 hitPoint;
    
    private void Awake() 
    {
        if (Instance!= null && Instance != this)
        {
            Destroy(gameObject);
        }
        else{Instance = this;}
    }

    private void Start() 
    {
        GazeManager.Instance.OnGazeSelection += GazeSelection;
    }

    private void GazeSelection()
    {
        _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
    }

    public void Update()
    {
        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            hitPoint=hit.point;
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnterXR", null, SendMessageOptions.DontRequireReceiver);
                GazeManager.Instance.StartGazeSelection();
            }
            if(/*hit.transform.TryGetComponent<IInteractable>(out var interactableObject)*/hit.transform.CompareTag(interactableTag)||hit.transform.CompareTag("arrow"))
            {
                //Activar puntero
                //pointer.GetComponent<MeshRenderer>().enabled = true;
                PointerOnGaze(hit.point);
            }
            else
            {
                //Desactivar puntero
                //pointer.GetComponent<MeshRenderer>().enabled = false;
                PointerOutGaze();
                //Ejecutar Gaze por defecto
                PointerOnGazeDefault(hit.point);
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExitXR", null, SendMessageOptions.DontRequireReceiver);
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClickXR", null, SendMessageOptions.DontRequireReceiver);
        }
    }

    private void PointerOnGazeDefault(Vector3 hitPoint)
    {
        GazeManager.Instance.CancelGazeSelection();
        float scaleFactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scaleFactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position,
                                    hitPoint,
                                    disPointerObj);
    }

    private void PointerOnGaze(Vector3 hitPoint)
    {
        float scaleFactor = scaleSize * Vector3.Distance(transform.position, hitPoint);
        pointer.transform.localScale = Vector3.one * scaleFactor;
        pointer.transform.parent.position = CalculatePointerPosition(transform.position,
                                    hitPoint,
                                    disPointerObj);
    }

    private Vector3 CalculatePointerPosition(Vector3 p0, Vector3 p1, float t)
    {
        float x = p0.x + t * (p1.x - p0.x);
        float y = p0.y + t * (p1.y - p0.y);
        float z = p0.z + t * (p1.z - p0.z);

        return new Vector3(x, y, z);
    }

    public void PointerOutGaze()
    {
        pointer.transform.localScale = Vector3.one * 0.1f;
        pointer.transform.parent.transform.localPosition 
            = new Vector3(0,0, maxDistancePointer);
        pointer.transform.parent.transform.rotation = transform.rotation;
        GazeManager.Instance.CancelGazeSelection();
    }
}
