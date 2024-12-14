using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _time;
    [SerializeField] public Vector2 CurrentMovement { get; set; }
    [SerializeField] public bool IsMoving { get; set; } = true;

    public void OnMovement(InputAction.CallbackContext context)
    {
        CurrentMovement = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 mouvement = new Vector2(CurrentMovement.x, CurrentMovement.y);
        mouvement.Normalize();
        //transform.Translate(_speed * mouvement * Time.fixedDeltaTime, Space.World);

        if (!IsMoving) return;

        if (mouvement.x > 0)
        {
            transform.position += new Vector3(1, 0, 0);
            StartCoroutine(Wait());
            return;
        }
        else if (mouvement.x < 0)
        {
            transform.position += new Vector3(-1, 0, 0);
            StartCoroutine(Wait());
            return;
        }

        if (mouvement.y > 0)
        {
            transform.position += new Vector3(0, 1, 0);
            StartCoroutine(Wait());
            return;
        }
        else if (mouvement.y < 0)
        {
            transform.position += new Vector3(0, -1, 0);
            StartCoroutine(Wait());
            return;
        }
    }

    IEnumerator Wait()
    {
        IsMoving = false;
        yield return new WaitForSeconds(_time);
        IsMoving = true;
    }
}
