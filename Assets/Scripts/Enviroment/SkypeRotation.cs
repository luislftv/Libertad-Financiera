using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkypeRotation : MonoBehaviour
{
    public float _velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, _velocity, 0);
    }
}
