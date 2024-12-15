using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Direction {
    Up,
    Down,
    Right,
    Left,
}

public class KeyboardNavigation : MonoBehaviour
{
    public Button upButton;
    public Button downButton;
    public Button leftButton;
    public Button rightButton;

    public Direction direction;
    public GameObject blue;
    public GameObject green;
    public GameObject red;
    public GameObject purple;

    private Button currentHoveredButton;

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Start()
    {
        ColorPalette palette = player.GetComponent<ColorPalette>();
        
        if (palette != null)
        {
            string[] playerPalette = palette.getColors();

            red.SetActive(false);
            green.SetActive(false);
            blue.SetActive(false);
            purple.SetActive(false);

            foreach (string color in playerPalette)
            {
                if (color == "Red") {
                    red.SetActive(true);
                }
                if (color == "Purple") {
                    purple.SetActive(true);
                }
                if (color == "Green") {
                    green.SetActive(true);
                }
                if (color == "Blue") {
                    blue.SetActive(true);
                }
            }
        }
        

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && upButton != null)
        {
            SetHover(upButton);
            direction = Direction.Up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && downButton != null)
        {
            SetHover(downButton);
            direction = Direction.Down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && leftButton != null)
        {
            SetHover(leftButton);
            direction = Direction.Left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && rightButton != null)
        {
            SetHover(rightButton);
            direction = Direction.Right;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            Unload();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (player == null) {
                Debug.Log("Color choice validate: did not find player");
                return;
            }

            PlayerSplit splitObject = player.GetComponent<PlayerSplit>();
            if (splitObject == null) {
                Debug.Log("Color choice validate: player cannot split");
            }

            switch (direction)
            {
                case Direction.Up:
                {
                    splitObject.splitUp();
                    break;
                }
                case Direction.Down:
                {
                    splitObject.splitDown();
                    break;
                }
                case Direction.Right:
                {
                    splitObject.splitRight();
                    break;
                }
                case Direction.Left:
                {
                    splitObject.splitLeft();
                    break;
                }
                default: break;
            }

            SceneManager.UnloadSceneAsync("ColorMenu");
        }
    }

    private void SetHover(Button button)
    {
        if (currentHoveredButton != null)
        {
            SimulateExit(currentHoveredButton);
        }
        currentHoveredButton = button;
        SimulateHover(currentHoveredButton);
    }

    private void SimulateHover(Button button)
    {
        ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
    }

    private void SimulateExit(Button button)
    {
        ExecuteEvents.Execute(button.gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerExitHandler);
    }

    public void Unload()
    {
        Debug.Log("test");
        SceneManager.UnloadSceneAsync("ColorMenu");
    }
}
