using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDestroy : MonoBehaviour
{
    public bool hit;
    
    
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject)
            Destroy(this.gameObject);
    }

}
