using UnityEngine;
using TMPro;

public class Energy : MonoBehaviour
{

    private float timeDuration = 1f * 1f;

    private float timer;

    [SerializeField]
    private TextMeshProUGUI TextEnergy;

    void Start()
    {
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer += Time.deltaTime;
            UpdateTimer(timer);
        }
 
    }

    private void Timer()
    {
        timer = timeDuration;
    }

    private void UpdateTimer(float time)
    {
        float temporary = Mathf.FloorToInt(time / 5);
        string temporarytest = string.Format("{00:00}",temporary);
        TextEnergy.text = temporarytest;
       // string currentTime = string.Format("{00:00} {1:00}", hours, minutes);
      //  TextEnergy.text = currentTime;

    }
}
