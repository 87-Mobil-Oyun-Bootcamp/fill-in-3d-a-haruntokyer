using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    
    private Slider slider;
   
   
    //public void IncrementProgress( float targetProgress, float newProgress){targetProgress = slider.value + newProgress;}

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        
    }
    private void Start()
    {
        LevelManager.Instance.ProgressBarUpdate += TargetValue;
        LevelManager.Instance.ProgressBarTotal += IncrementProgress;
    }
    public void IncrementProgress()
    {
        slider.maxValue += 1f;
        

    }

    public void TargetValue()
    {
        slider.value +=1f;
        Debug.Log(slider.value);
        if(slider.value == slider.maxValue)
        {
            slider.value = 0f;
            slider.maxValue = 0f;
        }
        
    }
}
