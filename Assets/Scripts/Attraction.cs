using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attraction : MonoBehaviour
{
    // Direction at start
    public Vector2 startDirection;

    // Player GameObject
    private GameObject player;
    private Rigidbody2D playerRb;
    private CircleCollider2D playerCc;
    
    // Private own components
    private Rigidbody2D rb;
    private CircleCollider2D cc;

    // Work Variables
    private Vector2 gravityEcart;
    private Vector2 gravityDirection;
    private float gravityDistance;
    private float gravityStrength;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        cc = this.GetComponent<CircleCollider2D>();


        player = GameObject.Find("Character");
        playerRb = player.GetComponent<Rigidbody2D>();
        playerCc = player.GetComponent<CircleCollider2D>();

        rb.AddForce(startDirection * rb.mass);

    }

    // Update is called once per frame
    void Update()
    {
        gravityEcart = player.transform.position - this.transform.position;
        //gravityDistance = Mathf.Max((Mathf.Abs(gravityDirection.x) + Mathf.Abs(gravityDirection.y)) * 0.78f, Mathf.Abs(gravityDirection.x), Mathf.Abs(gravityDirection.y));
        //gravityStrength = playerRb.mass / (Mathf.Pow(gravityDistance),4);
        //rb.AddForce(gravityDirection * Mathf.Abs(gravityStrength));

        gravityDistance = Mathf.Max((Mathf.Abs(gravityEcart.x) + Mathf.Abs(gravityEcart.y)) * 0.78f, Mathf.Abs(gravityEcart.x), Mathf.Abs(gravityEcart.y));

        gravityDirection = gravityEcart / Mathf.Max(gravityEcart.x, gravityEcart.y);

        gravityStrength = playerRb.mass / Mathf.Pow(gravityDistance, 3);

        rb.AddForce(gravityDirection * gravityStrength);


    }
}
