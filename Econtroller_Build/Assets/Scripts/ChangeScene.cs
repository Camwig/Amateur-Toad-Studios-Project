using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 1f;

    public LevelLoader new_loader;

   // public WorkingButtonScript buttonAction;
    public ButtonLoad buttonData;

    public int SceneID;


    public void MoveToScene()
    {
      //  buttonAction.buttonEvent.Invoke();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(SceneID);
    }

}
