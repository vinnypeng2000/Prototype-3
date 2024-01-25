using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    public float speed;
    public float rotationSpeed;
    public float health;
    public float iFrameCounter = 0f; //the one that counts up
    public float iFrameDuration; //how long they are invicinble after being attacked
    // public float lastDash = 0f;
    // public float dashCD = 1f;
    // public float stamina = 10.0f;
    public AudioSource hurt;
    public Rigidbody rb;
    public Animator animator;
    public GameManager gm;

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
        iFrameCounter += Time.deltaTime;

        if (health <= 0)
        {
            gm.Die();
        }

        // Vector3 forward = cam.transform.forward;
        // Vector3 right = cam.transform.right;
        // forward.y = 0;
        // forward = forward.normalized;
        // right.y = 0;
        // right = right.normalized;

        // Getting camera-normalized directional vectors
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Creating direction-relative input vectors
        // Vector3 forwardRelativeVerticalInput = verticalInput * forward;
        // Vector3 rightRelativeVerticalInput = horizontalInput * right;

        // Vector3 movement = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);

        rb.AddForce(movement * speed, ForceMode.Impulse);

        if (movement != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            // float targetAngle = Mathf.Atan2()
            // Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isRunning", true);
                speed = 0.25f;
            }
            else
            {
                animator.SetBool("isRunning", false);
                speed = 0.2f;
            }
            if (horizontalInput > 0)
            {
                // transform.rotation = cam.transform.rotation * new Quaternion(0f, 90f, 0f, 0f);
                // transform.rotation = Quaternion.RotateTowards(transform.rotation, cam.transform.rotation * new Quaternion(0f, 90f, 0f, 0f), rotationSpeed * Time.deltaTime);
                // Debug.Log("RIGHT");
            }
            if (horizontalInput < 0)
            {
                // transform.rotation = cam.transform.rotation * new Quaternion(0f, -90f, 0f, 0f);
                // transform.rotation = Quaternion.RotateTowards(transform.rotation, cam.transform.rotation * new Quaternion(0f, -190f, 0f, 0f), rotationSpeed * Time.deltaTime);
                // Debug.Log("LEFT");
            }
            // transform.Rotate(0.0f, 90.0f, 0.0f);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    // IEnumerator Fast()
    // {
    //     while (stamina > 0) {
    //         stamina -= 1.0f;
    //         animator.SetBool("isRunning", true);
    //         speed = 0.5f;
    //     }
    //     yield return new WaitForSeconds(5);
    //     InvokeRepeating("RegenerateStamina", 0f, .5f);
    // }

    public void TakeDamage(float damage)
    {
        if(iFrameCounter > iFrameDuration){
            hurt.Play();
            iFrameCounter = 0f;
            health -= damage;
            gm.UpdateHealth(health);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            hurt.Stop();
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            gm.Win();
        }
    }

    // void RegenerateStamina()
    // {
    //     gm.UpdateStamina(10.0f);
    // }
}
