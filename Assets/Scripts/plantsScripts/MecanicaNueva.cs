using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MecanicaNueva : MonoBehaviour
{
    public float gazeTime = 2f; // Tiempo requerido de mirada para seleccionar el objeto
    public float movementSpeed = 100f; // Velocidad de movimiento del objeto
    private float timer;
    private bool gazedAt;
    private bool isSelected;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Comprobar si la mirada está sobre el objeto
        if (gazedAt && !isSelected)
        {
            timer += Time.deltaTime;

            // Comprobar si el tiempo requerido de mirada ha sido alcanzado
            if (timer >= gazeTime)
            {
                // Seleccionar el objeto
                isSelected = true;
                OnObjectSelected();
            }
        }

        // Mover el objeto si está seleccionado
        if (isSelected)
        {
            
            // Obtener la posición del centro de la cámara
            Vector3 cameraCenter = Camera.main.transform.position + Camera.main.transform.forward * 1.7f;

            // Calcular la dirección del movimiento
            Vector3 direction = cameraCenter - transform.position;
            direction.z = 0f; // Opcionalmente, puedes bloquear el movimiento en el eje Y para que el objeto no suba o baje.

            // Mover el objeto en la dirección calculada
            transform.position += direction * movementSpeed * Time.deltaTime;
        }
    }

    // Método que se llama cuando la mirada entra en contacto con el objeto
    public void OnPointerEnterXR()
    {
        gazedAt = true;
      
    }

    // Método que se llama cuando la mirada sale de contacto con el objeto
    public void OnPointerExitXR()
    {
        gazedAt = false;
        timer = 0f;
    }

    // Método que se llama cuando el objeto es seleccionado
    public void OnObjectSelected()
    {
        // Aquí puedes agregar cualquier código adicional que desees ejecutar cuando el objeto es seleccionado
        Debug.Log("Objeto seleccionado");
    }


    // Método que se llama cuando el objeto es deseleccionado
    public void DeselectObject()
    {
        isSelected = false;
        transform.position = initialPosition; // Restaurar la posición inicial del objeto
    }
}
