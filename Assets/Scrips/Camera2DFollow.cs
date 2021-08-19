using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{
    private Transform player;
    public float speed;
    private Rigidbody rb;
    public float verticalDistance;
    public float distance;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        Vector3 target = new Vector3(player.position.x, verticalDistance, player.position.z - distance);
        Vector3 newPos = Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        rb.MovePosition(newPos);
    }
}
