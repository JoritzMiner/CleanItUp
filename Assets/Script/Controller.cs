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
        Menu,
        Playing,
        Death
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
       
        if (input.isPressed && MIzquierda && gameState==GameState.Playing)
        {
            StartCoroutine(MovimientoSmooth(0f, MovementHorizontal));
        }
        else {
        }

    }
    public void OnRigth(InputValue input)
    {

        if (input.isPressed && MDerecha && gameState == GameState.Playing)
        {
            StartCoroutine(MovimientoSmooth(0f, -MovementHorizontal));
        }
        else
        {
        }
 

    }
    public void OnFordward(InputValue input)
    {
        if (input.isPressed && MAdelante && gameState == GameState.Playing)
        {
            StartCoroutine(MovimientoSmooth(MovementVertical, 0));
        }
        else
        {
        }
    }
    public void OnBackwards(InputValue input)
    {

        if (input.isPressed && MAtras && gameState == GameState.Playing)
        {
            StartCoroutine(MovimientoSmooth(-MovementVertical, 0));
        }
        else
        {
        }

    }

    private IEnumerator MovimientoSmooth(float moverX, float moverZ) 
    {
       if(!enMovimiento)
        {
            enMovimiento = true;
            Vector3 Gotoposition = new Vector3(transform.position.x + moverX, transform.position.y, transform.position.z + moverZ);
            float elapsedTime = 0;
            float waitTime = 0.2f;
            Vector3 currentPos = transform.position;
            while (elapsedTime < waitTime)
            {
                transform.position = Vector3.Lerp(currentPos, Gotoposition, (elapsedTime / waitTime));
                elapsedTime += Time.deltaTime;

                // Yield here
                yield return null;
            }
            enMovimiento = false;
        }
                 
       
    }
}