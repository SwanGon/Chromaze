using UnityEngine;
using UnityEngine.Tilemaps;

public class ColllisionButton : MonoBehaviour
{
    [SerializeField] private TilemapCollider2D _collider;
    [SerializeField] private int _player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _player++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _player--;
        }
    }

    private void Update()
    {
        if (_player > 0)
        {
            _collider.gameObject.SetActive(false);
        }
        else
        {
            _collider.gameObject.SetActive(true);
        }
    }
}
