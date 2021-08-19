using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerNapoleon : MonoBehaviour
{
     float horizontal;
     float vertical;

    public float speed;

    private CharacterController controller;
    public float smoothing = 0.1f;
    private float turnSmooth;

    public float gravity = -9.8f;

    Vector3 velocity;

    public float jumpHeight; 

    public Transform groundCheck;
    public float radius;
    public LayerMask groundMask;
    bool isgrounded;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, radius, groundMask);

        if(isgrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal,0,vertical).normalized;

        if(direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmooth, smoothing);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            controller.Move(direction * speed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }


}
