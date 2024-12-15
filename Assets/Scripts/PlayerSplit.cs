using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerSplit : MonoBehaviour
{
    [SerializeField] ColorPalette palette;
    [SerializeField] GameObject clonePrefab;
    public Sprite[] sprites;

    private SoundController soundControllerInstance;

    private void Awake()
    {
        soundControllerInstance = SoundController.Instance;
    }

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
        soundControllerInstance.updateMusics(palette.getColors());
        GameObject newObject = Instantiate(clonePrefab);
        ColorPalette clonePalette = newObject.GetComponent<ColorPalette>();

        if (clonePalette == null) {
            Debug.Log("createClone: Could split the player: clone doesn't have a palette");
            return;
        }

        newObject.transform.position = transform.position;
        clonePalette.p = newPalette;
        if (newPalette.upRight != "" && newPalette.upLeft != "") {
            newObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        } else if (newPalette.upLeft != "" && newPalette.downLeft != "") {
            newObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        } else if (newPalette.downRight != "" && newPalette.downLeft != "") {
            newObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        } else if (newPalette.downRight != "" && newPalette.upRight != "") {
            newObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
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

        soundControllerInstance.updateMusics(palette.getColors());
    }

    private bool canSplitHorizontal()
    {
        if (palette.p.downRight == "" && palette.p.downLeft == "") {
            return false;
        }
        if (palette.p.upRight == "" && palette.p.upLeft == "") {
            return false;
        }
        return true;
    }

    private bool canSplitVeritcal()
    {
        if (palette.p.upRight == "" && palette.p.downRight == "") {
            return false;
        }
        if (palette.p.upLeft == "" && palette.p.downLeft == "") {
            return false;
        }
        return true;
    }
}
