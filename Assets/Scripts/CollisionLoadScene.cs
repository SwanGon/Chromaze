using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionLoadScene : MonoBehaviour
{
    [SerializeField] private string _name;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(_name);
        }
    }
}
