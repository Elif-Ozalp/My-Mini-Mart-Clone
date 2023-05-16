using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producer : MonoBehaviour
{
  
    private int repeat;
    private MeshRenderer meshRenderer;
    IPickUp pickup;
    void Start()
    {
        repeat = transform.childCount;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        pickup = GetComponent<IPickUp>();
    }

    void Update()
    {
        StartCoroutine(CreateObject());
    }
    
    
    IEnumerator CreateObject()
    {    
        for (int i = 0; i < repeat; i++)
        {
            GameObject gObj = transform.GetChild(i).gameObject;
            if (!gObj.activeInHierarchy  && meshRenderer.enabled)
            {
                yield return new WaitForSeconds(1f);
                gObj.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && meshRenderer.enabled   )
        {
            pickup.MakeActiveObject(gameObject, other.gameObject);  
        }
    }
  

}
