using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float waitTime;
    private float speed;

    Rigidbody2D rb;      
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = moveSpeed;
    }


    void Update()
    {
        float steering = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moving = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steering);
        transform.Translate(0, moving, 0);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "obstacle")
        {
            Debug.Log("Çarpti.");
            
            StartCoroutine(DecreaseSpeed());
            
        }
        /* if (col.gameObject.tag == "green")
        {
            Debug.Log("Yeşillendik.");

            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Debug.Log("OnTrigger");

            gameObject.GetComponent<Renderer>().material.color =  new Color(0, 175, 255, 255);

            StartCoroutine(OnTrigger());
            Destroy(col.gameObject);
        } */
        if (col.gameObject.tag == "blue")
        {
            Debug.Log("Hizlan bakalim.");
            
            // Debug.Log("OnTrigger");

            StartCoroutine(IncreaseSpeed()) ;
        }
    }
    /* IEnumerator OnTrigger()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        yield return new WaitForSeconds(0.2f);
         gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        
    } */
    IEnumerator IncreaseSpeed()
    {
        Debug.Log("Boosterr!!");
        moveSpeed = 25.0f;
        yield return new WaitForSeconds(waitTime);

        moveSpeed = speed;
        Debug.Log("Hizi düzeldi.");

        // gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        Debug.Log("OfTrigger");
    }
    
    IEnumerator DecreaseSpeed()
    {
        Debug.Log("Hizi azaldi.");
        moveSpeed = 5.0f;
        yield return new WaitForSeconds(waitTime);
        moveSpeed = speed;
        Debug.Log("Hiz düzeldi.");
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        Debug.Log("OfTrigger");
        
    }
}
