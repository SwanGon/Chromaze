using UnityEngine;

public class ColllisionButton : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

        }
    }
}
