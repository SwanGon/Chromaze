using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSplit : MonoBehaviour
{
    public void OnSplit(InputAction.CallbackContext context)
    {
        if (context.performed) {
            OnSplitPerformed();
        }
    }

    private void OnSplitPerformed()
    {
        // Code à exécuter lors de l'action "Split"
        Debug.Log("Split action performed!");
        // Ajoute ici ton comportement spécifique (par ex., séparer le joueur).
    }
}
