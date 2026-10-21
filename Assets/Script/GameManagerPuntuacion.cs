using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerPuntuacion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text pointsText;
    public int points = 100;
    public bool isCounting = false;

    private void Start()
    {
        pointsText.text = "Puntuacion: " + points;

    }
    public void AddPoints()
    {
        if(!isCounting)
        {
            StartCoroutine(CountScore());
        }
    }

    IEnumerator CountScore()
    {
        isCounting = true;

        int targetPoints = points + 5;

        while (points < targetPoints)
        {
            points++;
            pointsText.text = "Puntuacion: " + points;
            
            yield return new WaitForSeconds(0.05f);
        }

        isCounting &= false;
    }
}
