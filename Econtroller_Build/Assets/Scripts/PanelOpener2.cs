using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener2 : MonoBehaviour
{
    public GameObject Panel;

    //  public Animator Flash;

    public void OpenPanel()
    {
      if (Panel != null)
            {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
            }
    }

}
