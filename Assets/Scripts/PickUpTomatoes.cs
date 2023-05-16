using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpTomatoes : MonoBehaviour , IPickUp 
{
    private int activeChildCount = 0;
    public List<GameObject> tomatoes = new List<GameObject>();
    public List<GameObject> tomatoesInPlayer = new List<GameObject>();
   public void MakeActiveObject(GameObject gObject, GameObject other)
    {

        int hasCapacity = 0;
        FindCount(gameObject);
        int length = activeChildCount;
        int check = 0;

        for (int i = 0; i < tomatoesInPlayer.Count; i++)
        {
            GameObject otherObj = tomatoesInPlayer[i];
            if (hasCapacity == length)
            {
                break;
            }
            else if (!otherObj.activeInHierarchy)
            {
                otherObj.SetActive(true);
                hasCapacity++;
            }
        }

        for (int i = 0; i < tomatoes.Count; i++)
        {
            GameObject gObj = tomatoes[i];
            if (check == hasCapacity)
            {
                break;
            }
            else if (gObj.activeInHierarchy)
            {
                gObj.SetActive(false);
                check++;
            }
        }

        activeChildCount = 0;
    }
    public void FindCount(GameObject other)
    {
        int length = tomatoes.Count;
        for (int i = 0; i < length; i++)
        {
            GameObject otherObj = tomatoes[i];
            if (otherObj.activeInHierarchy)
            {
                activeChildCount++;

            }
        }
    }
}
