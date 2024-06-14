using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    [SerializeField] float DestroyTime = 0;
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,0,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {  
        Debug.Log("BRUH MOMENT!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package is picked up");
            hasPackage = true;
            Destroy(other.gameObject, DestroyTime);
            spriteRenderer.color = hasPackageColor;   
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package is delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;   
        }
            
    }
}
