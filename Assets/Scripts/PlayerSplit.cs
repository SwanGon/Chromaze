using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerSplit : MonoBehaviour
{
    [SerializeField] ColorPalette palette;
    [SerializeField] GameObject clonePrefab;

    public void OnSplit(InputAction.CallbackContext context)
    {
        if (context.performed) {
            OnSplitPerformed();
        }
    }

    private void OnSplitPerformed()
    {
        SceneManager.LoadScene("ColorMenu", LoadSceneMode.Additive);
    }

    public void splitUp()
    {
        if (!canSplitHorizontal()) {
            return;
        }
        createClone(palette.p.splitUp());
    }

    public void splitDown()
    {
        if (!canSplitHorizontal()) {
            return;
        }
        createClone(palette.p.splitDown());
    }

    public void splitRight()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.p.splitRight());
    }

    public void splitLeft()
    {
        if (!canSplitVeritcal()) {
            return;
        }
        createClone(palette.p.splitLeft());
    }

    private void createClone(ColorPaletteClass newPalette)
    {
        GameObject newObject = Instantiate(clonePrefab);
        ColorPalette clonePalette = newObject.GetComponent<ColorPalette>();

        if (clonePalette == null) {
            Debug.Log("createClone: Could split the player: clone doesn't have a palette");
            return;
        }

        newObject.transform.position = transform.position;
        clonePalette.p = newPalette;
    }

    public void fuseClone(GameObject clone)
    {
        if (clone.tag != "Clone") {
            Debug.Log("PlayerSplit:fuseClone: Invalid tag");
            return;
        }

        ColorPalette clonePalette = clone.GetComponent<ColorPalette>();
        if (clonePalette == null) {
            Debug.Log("PlayerSplit:fuseClone: clone has no palette");
            return;
        }

        palette.p.fusePalette(clonePalette.p);
        Object.Destroy(clone);
    }

    private bool canSplitHorizontal()
    {
        return (palette.p.downRight != "" && palette.p.downLeft != "")
            || (palette.p.upRight != "" && palette.p.upLeft != "");
    }

    private bool canSplitVeritcal()
    {
        return (palette.p.upRight != "" && palette.p.downRight != "")
            || (palette.p.upLeft != "" && palette.p.downLeft != "");
    }
}
