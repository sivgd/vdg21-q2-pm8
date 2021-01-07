using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUIMovementScript : MonoBehaviour
{
    public float scaler;
    private Rigidbody2D rb2;



    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");
        float inY = Time.deltaTime * scaler * Input.GetAxis("Vertical");
        rb2.AddForce(new Vector2(inX, inY));
    }
}
