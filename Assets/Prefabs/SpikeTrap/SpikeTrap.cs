using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    public string color;
    private ColorPalette colorPalette;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        colorPalette = other.GetComponent<ColorPalette>();
        
        Debug.Log("Player hit by spike trap");

        if (!colorPalette.getColors().Contains(color))
        {
            Debug.Log("Player hit by spike trap of wrong color");   
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
