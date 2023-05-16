using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutToTomatoStand : MonoBehaviour , IPutToStand 
{
    [HideInInspector] public float childCount = 0;
    private int activeChildCount = 0;
    private MeshRenderer meshRenderer;
    public List<GameObject> tomatoes = new List<GameObject>();
    public List<GameObject> tomatoesInPlayer = new List<GameObject>();

    void Start()
    {
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }
    public void Put(GameObject gameObject, GameObject other)
    {
        int check = 0;
        FindCount(other);
        int length = activeChildCount;

        for (int i = 0; i < tomatoes.Count; i++)
        {
            GameObject gObj = tomatoes[i];
            if (check == length)
            {
                break;
            }
            else if (!gObj.activeInHierarchy)
            {
                gObj.SetActive(true);
                check++;
                childCount++;
            }
        }

        int inactiveChildCount = 0;

        if (childCount == 6)
        {
            for (int j = 0; j < tomatoesInPlayer.Count; j++)
            {
                GameObject otherObj = tomatoesInPlayer[j];
                if (check == inactiveChildCount)
                {
                    break;
                }
                else if (otherObj.activeInHierarchy)
                {
                    otherObj.SetActive(false);
                    inactiveChildCount++;
                }
            }
        }
        else if (childCount < 6)
        {
            for (int i = 0; i < tomatoesInPlayer.Count; i++)
            {
                GameObject otherObj = tomatoesInPlayer[i];
                if (otherObj.activeInHierarchy)
                {
                    otherObj.SetActive(false);
                }
            }
        }

        activeChildCount = 0;
    }


   public void FindCount(GameObject other)
    {
        int length = tomatoesInPlayer.Count;
        for (int i = 0; i < length; i++)
        {
            GameObject otherObj = tomatoesInPlayer[i];
            if (otherObj.activeInHierarchy)
            {
                activeChildCount++;

            }
        }
    }
}
