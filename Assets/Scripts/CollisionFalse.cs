using UnityEngine;

public class CollisionFalse : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _gameObject.SetActive(false);
        }
    }
}
