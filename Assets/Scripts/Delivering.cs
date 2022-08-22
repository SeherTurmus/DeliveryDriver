using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivering : MonoBehaviour
{
    [SerializeField] Color32 hasRedPackageColor = new Color32(120, 38, 34, 255);
    [SerializeField] Color32 hasGreenPackageColor = new Color32(22, 30, 115, 255);
    [SerializeField] Color32 hasBrownPackageColor = new Color32(140, 92, 55, 255);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] private float destroyTime = 0.2f;
    bool hasRedPackage = false;
    bool hasGreenPackage = false;
    bool hasBrownPackage = false;
    
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private Delivering()
    {
        
    }
    /* void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bana Dokundu!!");
    } */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "green")
        {
            Debug.Log("GREEN package is picked up.");
            hasGreenPackage = true;
            spriteRenderer.color = hasGreenPackageColor;
            Destroy(other.gameObject, destroyTime);
        }
        if (other.tag == "greenCustomer")
        {
            if (hasGreenPackage)
            {
                Debug.Log("Delivered GREEN package!");
                hasGreenPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("GREEN package needs not other packages!");
            }
        }

        if (other.tag == "red")
        {
            Debug.Log("RED package is picked up.");
            hasRedPackage = true;
            spriteRenderer.color = hasRedPackageColor;
            Destroy(other.gameObject, destroyTime);
        }
        if (other.tag == "redCustomer")
        {
            if (hasRedPackage)
            {
                Debug.Log("Delivered RED package!");
                hasRedPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("RED package needs not other packages!");
            }
        }

        if (other.tag == "brown")
        {
            Debug.Log("BROWN package is picked up.");
            hasBrownPackage = true;
            spriteRenderer.color = hasBrownPackageColor;
            Destroy(other.gameObject, destroyTime);
        }
        if (other.tag == "brownCustomer")
        {
            if (hasBrownPackage)
            {
                Debug.Log("Delivered BROWN package!");
                hasBrownPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("BROWN package needs not other packages!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
