using UnityEngine;
using TMPro;

public class Temperature : MonoBehaviour
{

    private float timeDuration = 1f * 1f;

    // Start is called before the first frame update
    private float timer;

    [SerializeField]
    private TextMeshProUGUI TextTemperature;

    void Start()
    {
        Timer();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 20)
        {
            timer += Time.deltaTime;
            UpdateTimer(timer);
        }
        else if (timer > 20)
        {
            string TooHot = "TOO HOT MOFO";
            TextTemperature.text = TooHot;
        }

    }

    private void Timer()
    {
        timer = timeDuration;
    }

    private void UpdateTimer(float time)
    {
        float temporary = Mathf.FloorToInt(time / 1);
        string temporarytest = string.Format("{00:00}", temporary);
        TextTemperature.text = temporarytest;
        // string currentTime = string.Format("{00:00} {1:00}", hours, minutes);
        //  TextEnergy.text = currentTime;

    }
}
