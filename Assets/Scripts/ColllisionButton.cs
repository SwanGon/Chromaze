using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ColllisionButton : MonoBehaviour
{
    [SerializeField] private TilemapCollider2D _collider;
    [SerializeField] private int _player;
    private ColorPalette colorPalette;
    [SerializeField] private string _color;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Clone"))
        {
            colorPalette = collision.GetComponent<ColorPalette>();

            if (colorPalette.getColors().Contains(_color))
            {
                _player++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Clone"))
        {
            colorPalette = other.GetComponent<ColorPalette>();

            if (colorPalette.getColors().Contains(_color))
            {
                _player = 0;
            }
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
