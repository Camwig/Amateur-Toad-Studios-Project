using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public void MoveToScene(int SceneID)
    {
       // transition.SetTrigger("Start");

      //  new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneID);
    }

}
