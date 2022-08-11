using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;
    public bool loadNextQuestion;
    public bool IsAnweringQuestion = false;
    public float fillFraction;
    float timerValue;

    void Update() 
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue > 0)
        {
            fillFraction = timerValue / (IsAnweringQuestion ? timeToCompleteQuestion : timeToShowCorrectAnswer);
        }
        else
        {
            IsAnweringQuestion = !IsAnweringQuestion;
            timerValue = IsAnweringQuestion ? timeToCompleteQuestion : timeToShowCorrectAnswer;

            if(IsAnweringQuestion)
                loadNextQuestion = true;
        }
    }
}
