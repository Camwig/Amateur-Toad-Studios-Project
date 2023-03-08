using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{


    private float timeDuration = 9f * 60f;
    private float timer;


    [SerializeField]
    private TextMeshProUGUI TextTimer;

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

            UpdateTimer(timer);
        }
        else if (timer > 60)
            Flash();
    }

    private void Timer()
    {
        timer = timeDuration;
    }

    private void UpdateTimer(float time)
    {
        if(timeDuration < 10f * 60f)
        {
            float hours = Mathf.FloorToInt(time / 60);
            float minutes = Mathf.FloorToInt(time % 60);
            string currentTime = string.Format("{00:00} {1:00}", hours, minutes);
            TextTimer.text = currentTime;
        }

        else if (timeDuration > 11f * 60f)
        {
            Debug.Log("Time reached test");
        }
    }

    private void Flash()
    {
        Debug.Log("Time reached test");
    }
}
