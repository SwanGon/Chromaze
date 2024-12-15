using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

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
        /*RaycastHit2D _hitUp = Physics2D.Raycast(transform.position, Vector2.up, 0.10f);
        RaycastHit2D _hitDown = Physics2D.Raycast(transform.position, Vector2.down, 0.10f);
        RaycastHit2D _hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.10f);
        RaycastHit2D _hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.10f);*/

        Vector2 mouvement = new Vector2(CurrentMovement.x, CurrentMovement.y);
        mouvement.Normalize();
        transform.Translate(_speed * mouvement * Time.fixedDeltaTime, Space.World);

        /*if (!IsMoving) return;

        if (mouvement.x > 0)
        {
            if (!_hitRight.collider.GetComponent<TilemapCollider2D>().isTrigger) return;
            transform.position += new Vector3(0.16f, 0, 0);
            StartCoroutine(Wait());
            return;
        }
        else if (mouvement.x < 0)
        {
            if (!_hitLeft.collider.GetComponent<TilemapCollider2D>().isTrigger) return;
            transform.position += new Vector3(-0.16f, 0, 0);
            StartCoroutine(Wait());
            return;
        }

        if (mouvement.y > 0)
        {
            if (!_hitUp.collider.GetComponent<TilemapCollider2D>().isTrigger) return;
            transform.position += new Vector3(0, 0.16f, 0);
            StartCoroutine(Wait());
            return;
        }
        else if (mouvement.y < 0)
        {
            if (!_hitDown.collider.GetComponent<TilemapCollider2D>().isTrigger) return;
            transform.position += new Vector3(0, -0.16f, 0);
            StartCoroutine(Wait());
            return;
        }*/
    }

    /*IEnumerator Wait()
    {
        IsMoving = false;
        yield return new WaitForSeconds(_time);
        IsMoving = true;
    }*/
}
