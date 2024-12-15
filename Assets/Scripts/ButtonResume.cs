using UnityEngine;

public class ButtonResume : MonoBehaviour
{
    public void OnResume()
    {
        Pause.Instance.PauseGame();
    }
}
