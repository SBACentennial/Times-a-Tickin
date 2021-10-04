//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Globalization;
//using UnityEngine;
//using UnityEngine.UI;


//public class Timer : MonoBehaviour 
//{
//    //Time is set at the begining of each level. 
//    //This is set in the Unity Scene window
//    [SerializeField] private float totalTime;



//    //current time
//    private float currentTime;

//    //timer text to be displayed on screen
//    [SerializeField] private Text timerText;


//    void Start()
//    {
//        currentTime = totalTime;
//    }

//    void Update()
//    {


//        float seconds = Mathf.FloorToInt(currentTime % 60);
//        float minutes = currentTime / 60;

//        if (currentTime >= 0.00f)
//        {
//            NumberFormatInfo decimalReplacement = new NumberFormatInfo();
//            decimalReplacement.NumberDecimalSeparator = ":";

//            currentTime -= 1f * Time.deltaTime;

//            timerText.text = seconds.ToString("00") +  minutes.ToString(".00", decimalReplacement);
//        }

//        if (currentTime <= 0)
//            timerText.text = "0:00";
//    }

//    //public override string ToString()
//    //{
//    //    NumberFormatInfo decimalReplacement = new NumberFormatInfo();
//    //    decimalReplacement.NumberDecimalSeparator = ":";
//    //    return currentTime.ToString(decimalReplacement);
//    //}
//}
