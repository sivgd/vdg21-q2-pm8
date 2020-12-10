using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject snowball;
    public Transform Spawnpoint;
    public float ThrowSpeed;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = snowball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ThrowUp();
        }

    }
    
    void ThrowUp()
    {
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x + 5, Spawnpoint.transform.position.y, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(ThrowSpeed, 0);
    }
}
