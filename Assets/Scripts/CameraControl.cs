using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public float sensitivity;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        mouseX = Mathf.Clamp(mouseX, -90f, 90f);
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);
    }
}
