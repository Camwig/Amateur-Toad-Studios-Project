using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPositionChanger", menuName = "ScriptableObjects/PositionChanger")]

public class ScriptablePositionScaleAudioAsset : ScriptableObject
{
    [SerializeField] private Vector3 newPosition;
    [SerializeField] private Sprite buttonSprite;
    [SerializeField] private Sprite clickSprite;
    //[SerializeField] private AudioClip buttonSound;
    public Sprite ButtonSprite;
    public Sprite ClickSprite;
   // public AudioClip ButtonSound;

    public void ChangePosition(Transform objectTransform)
    {
        objectTransform.position = newPosition; // set the object's position to the new position
    }

    //public void SetSprite()
    //{

    //}
  //  public Vector3 NewPosition { get => newPosition; set => newPosition = value; }
   // public Sprite ButtonSprite { get => buttonSprite; }
  //  public AudioClip ButtonSound { get => buttonSound; }
}
