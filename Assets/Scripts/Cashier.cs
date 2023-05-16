using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cashier : MonoBehaviour
{
    private int activeChildCount;
    private List<GameObject> customersReadyToPay = new List<GameObject>();
  
    void OnTriggerStay(Collider other)
    {
       var meshRenderer = gameObject.GetComponent<MeshRenderer>();

       if (other.CompareTag("Customer")  && meshRenderer.enabled )
       {
            customersReadyToPay.Add(other.gameObject);
       }
       else if(other.CompareTag ("Player") && meshRenderer.enabled)
       {
           for (int i=0;i<customersReadyToPay.Count;i++)
           {
                var customerController = customersReadyToPay[i].GetComponent<CustomerController>();
                var customer = customersReadyToPay[i].GetComponent<Customer>();

                activeChildCount = 0;
                ChildCount(customersReadyToPay[i]);
                
                if (!customerController.onCashier )
                {
                    customerController.onCashier  = true;
                }
                if (customer.hasPaid)
                {
                   LevelManager.Instance.UpdateMoney(activeChildCount);
                   customer.hasPaid = false;
                }
           }
       } 
    }

    void ChildCount(GameObject  other)
    {
        int length = other.transform.childCount;
        for (int i = 2; i < length; i++)
        {
            GameObject otherObj = other.transform.GetChild(i).gameObject;
            if (otherObj.activeInHierarchy)
            {
                activeChildCount++;
            }
        }
        
    }
}
