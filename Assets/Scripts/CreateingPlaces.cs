using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CreateingPlaces : MonoBehaviour
{
    [SerializeField] private TMP_Text costText;
    [SerializeField] private int unlockCost;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        costText.text = unlockCost.ToString();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void OnTriggerStay(Collider other)
    {    
        if (other.CompareTag("Player") && !meshRenderer.enabled )
        { 
            GetPaid(gameObject ,other.gameObject );
            Invoke("CreatePlace", 1);
        }
    }

    void CreatePlace()
    {
        if((unlockCost  == 0))
        {
            meshRenderer.enabled = true;
        } 
    }

    void GetPaid(GameObject gameObject, GameObject other)
    {
          if (unlockCost > 0)
            {
                unlockCost -= 1;
                costText.text = unlockCost.ToString();
                if (costText .text == "0")
                {
                    costText.transform.parent.gameObject.SetActive(false);
                }
                LevelManager.Instance.UpdateMoney(-1);
              
            }
        
    }
}
