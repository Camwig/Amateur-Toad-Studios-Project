using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionScript : MonoBehaviour
{

    [SerializeField] private ScriptablePositionScaleAudioAsset positionChanger;
   // [SerializeField] private string spriteObjectName;

    private SpriteRenderer spriteRenderer;
   // private AudioSource audioSource;

    // [SerializeField] private Sprite normalSprite; // the normal sprite to display on the button
    // [SerializeField] private Sprite hoverSprite; // the sprite to display when the button is hovered over
    // [SerializeField] private Sprite clickSprite;

    // Start is called before the first frame update


    private void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
       // audioSource = GetComponent<AudioSource>();

        // Set the initial sprite and sound values
        spriteRenderer.sprite = positionChanger.ButtonSprite;
       // audioSource.clip = buttonData.ButtonSound;



        // spriteRenderer = GetComponent<SpriteRenderer>();
        // if (positionChanger != null)
        // {
        //     spriteRenderer.sprite = positionChanger.ButtonSprite;
        //  }


        //  Transform spriteObjectTransform = transform.Find(spriteObjectName);
        //  spriteRenderer = spriteObjectTransform.GetComponent<SpriteRenderer>();
        //  spriteRenderer.sprite = positionChanger.ButtonSprite;
        //  spriteRenderer = GetComponent<SpriteRenderer>();
        //  audioSource = GetComponent<AudioSource>();

        //spriteRenderer.sprite = positionChanger.ButtonSprite;
        //  audioSource.clip = positionChanger.ButtonSound;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            positionChanger.ChangePosition(transform); // change the position of the object to the new position
           // spriteRenderer.sprite = positionChanger.ButtonSprite;

           // audioSource.PlayOneShot(positionChanger.ButtonSound);
        }
    }

    private void OnMouseDown()
    {
        // Change the sprite and play the button sound
        spriteRenderer.sprite = positionChanger.ClickSprite;
        // audioSource.PlayOneShot(positionChanger.ButtonSound);

        // Change the position of the GameObject using the Scriptable Object's method
        positionChanger.ChangePosition(transform);
    }
}
