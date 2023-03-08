using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{


    private float timeDuration = 9f * 60f;
    private float timer;

    private bool holder = true;

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
        if (holder == true)
        {
            timer = timeDuration;
            holder = false;
        }
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
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
