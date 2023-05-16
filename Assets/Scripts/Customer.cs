using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    
    [HideInInspector] private int control = 0;
    [HideInInspector] private int hasEnoughChild;
    [HideInInspector] public  int length;
    [HideInInspector] public bool hasPaid = true;
    private  bool collectChechk = true;
   


    void OnTriggerStay(Collider other)
    {
        var meshRenderer = other.gameObject.GetComponent<MeshRenderer>();
        var customerController = gameObject.GetComponent<CustomerController>();
        var putToStand = other.gameObject.GetComponent<PutToTomatoStand>();
      

        hasEnoughChild = 0;
        length =Random.Range(3, 8);
        HasChild(other.gameObject );
       
        if (other.CompareTag("TomatoStand") && hasEnoughChild > length-2 && meshRenderer.enabled && collectChechk  )
        {
            collectChechk = false;
            customerController.onTheStand = true;
            LevelManager.Instance.AddOnCashierQueue(gameObject);

            for (int i = 2; i < length; i++)
            {
                GameObject obj = transform.GetChild(i).gameObject;
                obj.SetActive(true);
            }

            int size = other.transform.childCount;
            
            for (int i = 0; i < size; i++)
            {
                GameObject otherObj = other.transform.GetChild(i).gameObject;
                if (control == length-2)
                {
                    break;
                }
                else if (otherObj.activeInHierarchy)
                {
                   otherObj.SetActive(false);
                   control++;  
                }   
            }
            
            putToStand.childCount -= control;
            if (putToStand.childCount  < 0)
            {
                putToStand.childCount = 0;
            }
        }
    }

    void HasChild(GameObject other)
    {
        int size = other.transform.childCount;
        for (int i = 0; i < size; i++)
        {
            GameObject otherObj = other.transform.GetChild(i).gameObject;
            if (otherObj.activeInHierarchy)
            {
               hasEnoughChild ++;
            }
        }
    }
}
