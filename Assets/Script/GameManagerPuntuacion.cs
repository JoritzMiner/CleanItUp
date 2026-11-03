using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerPuntuacion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text pointsText;
    public int points = 0;
    public GameObject Player;


    private void Start()
    {
        Player = FindFirstObjectByType<Controller>().gameObject;
        pointsText.text = "Puntuacion: " + points;

    }
    void Update()
    {
        if(Player.transform.position.x >= 0)
        {
            AnadirPuntos();
        }
    }

    public void AnadirPuntos()
    {
       
        double puntos = Player.transform.position.x / 1.44083;

        Debug.Log(puntos);
    }
}
    //IEnumerator CountScore()
    //{
    //    isCounting = true;

    //    int targetPoints = points + 5;

    //    while (points < targetPoints)
    //    {
    //        points++;
    //        pointsText.text = "Puntuacion: " + points;
            
    //        yield return new WaitForSeconds(0.05f);
    //    }

    //    isCounting &= false;
    //}

