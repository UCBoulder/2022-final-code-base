using System.Collections;
using System.Collections.Generic;
using UnityEngine

public class Timer : MonoBehaviour{

    bool timerActive = false;
    float currentTime;
    public int startMinutes;
    public Text currentTimeText;

    // start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60;
    }

    //Update is called once per frame
    void Update ()
    {
        if(timerActive == true){
            currentTime = currentTime - Time.deltaTime;
            if(currentTime<= 0){
                timerActive = false;
                Start();
                Debug.Log("Timer Finished!")
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.txt = time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
    public void StartTimer() {
        timerActive = true;
    }
    public void StopTimer(){
        timerActive = false;
    }
}
