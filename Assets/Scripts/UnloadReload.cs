using UnityEngine;

public class UnloadReload : MonoBehaviour
{
    public void OnUnloadReload(string nameUnload)
    {
        LoadScene LS = FindObjectOfType<LoadScene>();

        //LS.LoadLevel(nameReload);
        //LS.UnloadLevel(nameUnload);
    }
}
