using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutToStand : MonoBehaviour
{

   
    private MeshRenderer meshRenderer;
    IPutToStand puttostand;

    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        puttostand = GetComponent<IPutToStand>();
    }


    void OnTriggerStay(Collider other)
    {
      
        if (other.CompareTag("Player")  && meshRenderer.enabled   )
        {   
            puttostand.Put(gameObject, other.gameObject);  
        }
    }

  
}
