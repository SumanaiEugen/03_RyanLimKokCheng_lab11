using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    Animator playerAnin;
    float speed = 5.0f;
    float hitcounter = 0f;
    bool incontact = false;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        playerAnin = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnin.SetBool("isStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnin.SetBool("isStrafe", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnin.SetBool("isStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerAnin.SetBool("isStrafe", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnin.SetBool("isStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            playerAnin.SetBool("isStrafe", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnin.SetBool("isStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            playerAnin.SetBool("isStrafe", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnin.SetTrigger("Attack");
            if (incontact == true)
            {
                    hitcounter++;
                if (hitcounter > 5)
                {
                    Destroy(enemy);
                }
            }
            
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("cube"))
        {
            playerAnin.SetTrigger("Death");
        }
    }
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            incontact = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            incontact = false;
        }
    }  
}
