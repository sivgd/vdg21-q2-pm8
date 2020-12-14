using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject snowball;
    public Transform Spawnpoint;
    public float ThrowSpeed;
    public Rigidbody2D rb;
    public bool IsShooting;
    public float waittime;
    public float scaler;


    // Start is called before the first frame update
    void Start()
    {
        rb = snowball.GetComponent<Rigidbody2D>();
        IsShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
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
            float inX = Time.deltaTime * scaler * Input.GetAxis("Horizontal");
            float inY = Time.deltaTime * scaler * Input.GetAxis("Vertical");
            transform.position += new Vector3(inX, inY, 0);
            Debug.Log(inX + " , " + inY);
        }
    }


    IEnumerator UpCoroutine()
    {
        yield return new WaitForSeconds(waittime);
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x, Spawnpoint.transform.position.y + 1, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ThrowSpeed);
        IsShooting = false;
    }
    IEnumerator DownCoroutine()
    {
        yield return new WaitForSeconds(waittime);
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x, Spawnpoint.transform.position.y - 1, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -ThrowSpeed);
        IsShooting = false;
    }
    IEnumerator RightCoroutine()
    {
        yield return new WaitForSeconds(waittime);
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x + 1, Spawnpoint.transform.position.y, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(ThrowSpeed, 0);
        IsShooting = false;
    }
    IEnumerator LeftCoroutine()
    {
        yield return new WaitForSeconds(waittime);
        GameObject clone = (GameObject)Instantiate(snowball, new Vector3(Spawnpoint.transform.position.x - 1, Spawnpoint.transform.position.y, Spawnpoint.transform.position.z), Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2(-ThrowSpeed, 0);
        IsShooting = false;
    }

}
