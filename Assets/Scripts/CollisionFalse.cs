using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionFalse : MonoBehaviour
{
    [SerializeField] private TilemapCollider2D _gameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _gameObject.isTrigger = true;
        }
    }
}