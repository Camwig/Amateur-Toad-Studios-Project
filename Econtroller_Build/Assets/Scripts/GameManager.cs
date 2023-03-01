using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _startingscenetrasition;
    [SerializeField] private GameObject _endingscenetrasition;


    private void Start()
    {
        _startingscenetrasition.SetActive(true);
        
    }

    private void DisableStartingSceneTrasition()
    {
        _startingscenetrasition.SetActive(false);
    }

    
}
