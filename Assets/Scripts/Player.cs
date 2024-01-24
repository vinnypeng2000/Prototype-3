using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public Rigidbody rb;
    public Animator animator;

    public CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        // isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;
        forward.y = 0;
        forward = forward.normalized;
        right.y = 0;
        right = right.normalized;

        // Getting camera-normalized directional vectors
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Creating direction-relative input vectors
        Vector3 forwardRelativeVerticalInput = verticalInput * forward;
        Vector3 rightRelativeVerticalInput = horizontalInput * right;

        Vector3 movement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        // Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        rb.AddForce(movement * speed, ForceMode.Impulse);

        if (movement != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            // Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            if (horizontalInput > 0)
            {
                // transform.rotation = cam.transform.rotation * new Quaternion(0f, 90f, 0f, 0f);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, cam.transform.rotation * new Quaternion(0f, 90f, 0f, 0f), rotationSpeed * Time.deltaTime);
                Debug.Log("RIGHT");
            }
            if (horizontalInput < 0)
            {
                // transform.rotation = cam.transform.rotation * new Quaternion(0f, -90f, 0f, 0f);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, cam.transform.rotation * new Quaternion(0f, -190f, 0f, 0f), rotationSpeed * Time.deltaTime);
                Debug.Log("LEFT");
            }
            // transform.Rotate(0.0f, 90.0f, 0.0f);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
