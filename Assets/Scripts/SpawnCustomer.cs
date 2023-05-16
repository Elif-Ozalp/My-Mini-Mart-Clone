using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCustomer : MonoBehaviour
{
   
    void Start()
    {
        StartCoroutine(SpawnObject());
      
    }
   
    IEnumerator SpawnObject()
    {
        int length = 20;
        for (int i = 0; i < length; i++)
        {
            GameObject gObject = ObjectPool.Instance.GetFromPool();
            gObject.transform.position = transform.position;
            gObject.SetActive(true);
            yield return new WaitForSeconds(10);
        }

    }
    
}
