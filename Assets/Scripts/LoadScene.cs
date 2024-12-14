using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public static LoadScene Instance;
    [SerializeField] private string initialScene;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    /*private void Start()
    {
        SceneManager.LoadScene(initialScene);
    }*/

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Additive);
    }

    public void UnloadLevel(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }
}
