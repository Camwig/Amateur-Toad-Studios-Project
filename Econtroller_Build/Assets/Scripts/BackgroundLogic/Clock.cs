using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Clock : MonoBehaviour
{
    private float timeDuration = 9f * 60f;
    private float endHour = 0f;

    [SerializeField]
    private TextMeshProUGUI TextTimer;


    private float timer;

    // Start is called before the first frame update
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
            endHour += Time.deltaTime;
            UpdateTimer(timer);
        }
    }

    private void Timer()
    {
        timer = timeDuration;
    }

    private void UpdateTimer(float time)
    {
        if (endHour < 15f * 60f)
        {
            float hours = Mathf.FloorToInt(time / 60);
            float minutes = Mathf.FloorToInt(time % 60);
            string currentTime = string.Format("{00:00} {1:00}", hours, minutes);
            TextTimer.text = currentTime;
        }

    }
}
