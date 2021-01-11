using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballDestroy : MonoBehaviour
{
    public bool hit;
    public EnemyUIScript EnemyHurt;
    public BossUIScript BossHurt;
    
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
        if (collision.gameObject.tag == "Enemy")        
            EnemyHurt.EnemyTakeDamage(10);
            Destroy(this.gameObject);        

        if (collision.gameObject.tag == "Boss")
            BossHurt.BossTakeDamage(10);           
            Destroy(this.gameObject);
       
    }

}
