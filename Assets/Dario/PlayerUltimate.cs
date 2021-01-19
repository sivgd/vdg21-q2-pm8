using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUltimate : MonoBehaviour
{
    public float scaler;
    public Rigidbody2D rb;
    public Rigidbody2D playerrb;
    public Animator animator;
    public GameObject snowball;
    public GameObject player;

    public Transform Spawnpoint;
    public float ThrowSpeed;
    public bool IsShooting;
    public float waittime;
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb = snowball.GetComponent<Rigidbody2D>();
        playerrb = player.GetComponent<Rigidbody2D>();

        IsShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");
        float inY = Time.deltaTime * scaler * Input.GetAxis("Vertical");
        transform.position += new Vector3(inX, inY, 0);
        if (IsShooting == false)
        {
            if (Input.GetKeyDown("i"))
            {
                IsShooting = true;
                StartCoroutine(UpCoroutine());
            }
            if (Input.GetKeyDown("j"))
            {
                IsShooting = true;
                StartCoroutine(LeftCoroutine());
            }
            if (Input.GetKeyDown("l"))
            {
                IsShooting = true;
                StartCoroutine(RightCoroutine());
            }
            if (Input.GetKeyDown("k"))
            {
                IsShooting = true;
                StartCoroutine(DownCoroutine());
            }
        }
    }


    IEnumerator UpCoroutine()
    {
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x, Spawnpoint.transform.position.y + 1, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(scaler * Input.GetAxis("Horizontal"), ThrowSpeed);
        yield return new WaitForSeconds(waittime);

        IsShooting = false;
    }
    IEnumerator DownCoroutine()
    {
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x, Spawnpoint.transform.position.y - 1, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(scaler * Input.GetAxis("Horizontal"), -ThrowSpeed);
        yield return new WaitForSeconds(waittime);

        IsShooting = false;
    }
    IEnumerator RightCoroutine()
    {
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x + 1, Spawnpoint.transform.position.y, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(ThrowSpeed, scaler * Input.GetAxis("Vertical"));
        yield return new WaitForSeconds(waittime);

        IsShooting = false;
    }
    IEnumerator LeftCoroutine()
    {
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x - 1, Spawnpoint.transform.position.y, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-ThrowSpeed, scaler * Input.GetAxis("Vertical"));
        yield return new WaitForSeconds(waittime);
        IsShooting = false;
    }

}
