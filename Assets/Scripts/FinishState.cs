using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishState : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Ball"))//when came the black cube, open new level scene
        {
            string tempstring = SceneManager.GetActiveScene().name;
            string getNumberStr = Regex.Match(tempstring, @"\d+").Value;
            Int32.TryParse(getNumberStr, out int getNumberInt);
            getNumberInt += 1;
            SceneManager.LoadScene("Level " + getNumberInt);
        }
    }
}
