using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class ColllisionButton : MonoBehaviour
{
    [SerializeField] private TilemapCollider2D _collider;
    [SerializeField] private List<GameObject> _objectList;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _objectList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _objectList.RemoveAt(1);
        }
    }

    private void Update()
    {
        if (_objectList.Count != 0)
        {
            _collider.isTrigger = true;
        }
        else
        {
            _collider.isTrigger = false;
        }
    }
}
