using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewButtonData", menuName = "Button Data", order = 1)]

public class ButtonLoad : MonoBehaviour
{
    public string buttonText;

    // Art stuff
    public Sprite buttonImage;

    // Audio stuff 
    public AudioClip buttonSound;

    // Main event for the button press 
    public UnityEngine.Events.UnityEvent buttonEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
