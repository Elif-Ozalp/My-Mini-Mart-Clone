using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickUp 
{
    public void MakeActiveObject(GameObject gObject , GameObject other);
    public void FindCount(GameObject other);
}
