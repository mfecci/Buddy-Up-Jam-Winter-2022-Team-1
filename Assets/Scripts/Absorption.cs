using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorption : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject dustNumber;
    private GenerateDust gd;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        dustNumber = GameObject.Find("DustNumber");
        gd = dustNumber.GetComponent<GenerateDust>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with " + collision.gameObject.tag);

        float massAbsorbed = collision.gameObject.GetComponent<Rigidbody2D>().mass;

        if (collision.gameObject.tag == "SpaceObject")
        {
            rb.mass += massAbsorbed;
            gd.Absorb(massAbsorbed);

            Destroy(collision.gameObject);
        }
    }
}
