using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableNoti : MonoBehaviour
{
    public GameObject circle;

   public void whenButtonClicked()
    {
        if (circle.activeInHierarchy == true)
        {
            circle.SetActive(false);
        }
    }
}
