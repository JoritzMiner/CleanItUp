using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;
using JetBrains.Annotations;

public class GameManagerPuntuacion : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TMP_Text pointsText;
    public float points = 20;
    public GameObject Player;
    public float newPoints = 0;

    private void Start()
    {
        Player = FindFirstObjectByType<Controller>().gameObject;
        pointsText.text = "Puntuacion: " + points.ToString();

    }
    void Update()
    {
        if (Player.transform.position.x >= newPoints)
        {
            AnadirPuntos();

        }
    }
        

    public void AnadirPuntos()
    {
        points = (Player.transform.position.x)/* / 1.5f) * 20*/;
        pointsText.text = "Puntuacion: " + points.ToString();
        newPoints = points;

    }
}

