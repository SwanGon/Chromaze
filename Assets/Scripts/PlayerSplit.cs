using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSplit : MonoBehaviour
{
    [SerializeField] ColorPalette palette;

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

    private void splitUp()
    {
        if (!canSplitHorizontal()) {
            return;
        }
        createClone(palette.splitUp());
    }

    private void splitDown()
    {
        if (!canSplitHorizontal()) {
            return;
        }
        createClone(palette.splitDown());
    }

    private void splitRight()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.splitRight());
    }

    private void splitLeft()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.splitLeft());
    }

    private void createClone(ColorPalette newPalette)
    {
        PlayerSplit newObject = Instantiate(this, this.transform, false);

        newObject.palette = newPalette;
        newObject.tag = "Clone";
    }

    private bool canSplitHorizontal()
    {
        return (palette.downRight != "" && palette.downLeft != "")
            || (palette.upRight != "" && palette.upLeft != "");
    }

    private bool canSplitVeritcal()
    {
        return (palette.upRight != "" && palette.downRight != "")
            || (palette.upLeft != "" && palette.downLeft != "");
    }
}
