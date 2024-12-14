using UnityEngine;
using UnityEngine.InputSystem;

public class Pause : MonoBehaviour
{
    public static Pause Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private int _status;
    [SerializeField] private GameObject _gameObjectPanel;
    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (_status == 0)
        {
            _gameObjectPanel.SetActive(true);
            Time.timeScale = 0f;
            _status = 1;
        }
        else if (_status == 1)
        {
            _gameObjectPanel.SetActive(false);
            Time.timeScale = 1f;
            _status = 0;
        }
    }
}
