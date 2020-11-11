using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementPlayer : MonoBehaviour
{
    Animator playerAnin;
    float speed = 5.0f;
    float runspeed = 15f;
    float hitcounter = 0f;
    public GameObject enemy;
    bool incontact = false;
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
            playerAnin.SetBool("isStrafe", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            playerAnin.SetBool("isStrafe", false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerAnin.SetTrigger("Attack");
            if (incontact == true)
            {
                    hitcounter++;
                if (hitcounter == 5)
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
     void OnTriggerEnter(Collider enemy)
    {
        incontact = true;
    }
    void OnTriggerExit(Collider enemy)
    {
        incontact = false;
    }  
}
