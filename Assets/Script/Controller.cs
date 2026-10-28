using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public Transform player;
    public float MovementHorizontal = 1f;
    public float MovementVertical = 1.5f;

    private GameManager gameManager;
    public enum GameState
    {
        Ready,
        Moving,
        Dead
    }
    private GameState gameState;
    public bool MAdelante = true;
    public bool MAtras = true;
    public bool MDerecha = true;
    public bool MIzquierda = true;
    public Rigidbody rb;

    private bool noHayPared = true; //si hay pared = false, si no hay pared = true
    private bool enMovimiento = false; //si se mueve el player = true , si no se mueve = false
    private void Start()
    {
        MIzquierda = true;
        MAdelante = true;
        MAtras = true;
        MDerecha = true;
    }
    private void FixedUpdate()
    {

    }
    public void CheckState(GameState gameState)
    {
        this.gameState = gameState;
    }
    public void OnLeft(InputValue input)
    {

        if (input.isPressed && MIzquierda && gameState == GameState.Ready)
        {
            StartCoroutine(MovimientoSmooth(0f, MovementHorizontal));
        }
        else
        {
        }

    }
    public void OnRigth(InputValue input)
    {

        if (input.isPressed && MDerecha && gameState == GameState.Ready)
        {
            StartCoroutine(MovimientoSmooth(0f, -MovementHorizontal));
        }
        else
        {
        }


    }
    public void OnFordward(InputValue input)
    {
        if (input.isPressed && MAdelante && gameState == GameState.Ready)
        {
            StartCoroutine(MovimientoSmooth(MovementVertical, 0));
        }
        else
        {
        }
    }
    public void OnBackwards(InputValue input)
    {

        if (input.isPressed && MAtras && gameState == GameState.Ready)
        {
            StartCoroutine(MovimientoSmooth(-MovementVertical, 0));
        }
        else
        {
        }

    }


    private IEnumerator MovimientoSmooth(float moverX, float moverZ)
    {
        if (enMovimiento)
            yield break;

        enMovimiento = true;

        Vector3 currentPos = transform.position;

        Vector3 GoToPosition = currentPos + new Vector3(
            moverX, 0f, moverZ
        );

        float elapsedTime = 0f;
        float waitTime = 0.2f;

        while (elapsedTime < waitTime)
        {
            float t = elapsedTime / waitTime;

            transform.position = Vector3.Lerp(
                currentPos,
                GoToPosition,
                t
            );

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        
        transform.position = GoToPosition;

        Debug.Log("Posición final: " +
            transform.position.ToString("F5"));

        enMovimiento = false;
    }
}
