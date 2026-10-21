using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public Transform player;
    public float MovementHorizontal = 1.2f;
    public float MovementVertical = 1.7f;

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
    public void OnLeft(InputValue input)
    {
        if (input.isPressed && MIzquierda)
        {
            StartCoroutine(MovimientoSmooth(0f, MovementHorizontal));
        }
        else {
        }

    }
    public void OnRigth(InputValue input)
    {

        if (input.isPressed && MDerecha)
        {
            StartCoroutine(MovimientoSmooth(0f, -MovementHorizontal));
        }
        else
        {
        }
 

    }
    public void OnFordward(InputValue input)
    {
        if (input.isPressed && MAdelante)
        {
            StartCoroutine(MovimientoSmooth(MovementVertical, 0));
        }
        else
        {
        }
    }
    public void OnBackwards(InputValue input)
    {

        if (input.isPressed && MAtras)
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