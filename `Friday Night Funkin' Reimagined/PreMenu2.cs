using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreMenu2 : MonoBehaviour
{
    public int MenuInt;
    public float AlphaLevel = 1f;
    public bool rdy = false;
    public bool settingsOpened = false;
    public GameObject[] MenuElements;
    public GameObject BlackImage;
    public GameObject selectKeyNotif;
    public GameObject incKeyGO;
    public Image image;
    [SerializeField] private CanvasGroup keybindMenu;

    void Start()
    {
        image = BlackImage.GetComponent<Image>();
        MenuInt = 1;
        StartCoroutine(FadeAnimation());
    }

    
    void Update()
    {
        //Handles user input in the menu, allowing the player to cycle between menu elements using keyboard.
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (settingsOpened == false)
            {
                MenuInt = MenuInt - 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (settingsOpened == false)
            {
            MenuInt = MenuInt + 1;
            }
        }

        //Prevents the player from going out of all the of the menu elements index.
        if (MenuInt >= 4)
        {
            MenuInt = 1;
        }
        else if (MenuInt <= 0)
        {
            MenuInt = 3;
        }

        //Handles the behaviour of each selected menu element.
        if (Input.GetKeyDown(KeyCode.Return) && MenuInt == 1 && rdy)
        {
            StartCoroutine(TransitionToMenu());
        }
        if (Input.GetKeyDown(KeyCode.Return) && MenuInt == 2 && rdy)
        {
            settingsOpened = true;
            OpenCloseMenu();
        }
        if (settingsOpened && Input.GetKeyDown(KeyCode.Escape))
        {
            settingsOpened = false;
            OpenCloseMenu();
        }
        if(CustomKey.buttonSelected !=0)
        {
            selectKeyNotif.SetActive(true);
        }
        else
        {
            selectKeyNotif.SetActive(false);
        }
        if(CustomKey.incorrectKey == 1)
        {
            incKeyGO.SetActive(true);
        }
        if(CustomKey.incorrectKey == 0)
        {
            incKeyGO.SetActive(false);
        }
        SizeColorChange();
    }

    //This function changes the currently selected menu elements, changing its colour and size as a feedback to the player that this is the currently selected menu option.
    public void SizeColorChange()
    {
        for (int i = 0; i < MenuElements.Length; i++)
        {
            MenuElements[i].GetComponent<Image>().color = Color.white;
            MenuElements[i].transform.localScale = new Vector3(1, 1, 1);
        }
        MenuElements[MenuInt - 1].GetComponent<Image>().color = Color.magenta;
        MenuElements[MenuInt - 1].transform.localScale = new Vector3(1.15f, 1.15f, 1.15f);
    }

    //This function adds a fade in and animation between scenes for a smoother transition.
    IEnumerator TransitionToMenu()
    {
        for (int q = 0; q < 100; q++)
        {
            AlphaLevel = AlphaLevel + 0.01f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, AlphaLevel);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("Menu");
    }

    //This function adds a fade in and animation between scenes for a smoother transition.
    IEnumerator FadeAnimation()
    {
        for (int q = 0; q < 100; q++)
        {
            AlphaLevel = AlphaLevel - 0.01f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, AlphaLevel);
            yield return new WaitForSeconds(0.01f);
        }
        rdy = true;
    }

    IEnumerator Start3()
    {
        for (int q = 0; q < 100; q++)
        {
            AlphaLevel = AlphaLevel + 0.01f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, AlphaLevel);
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("PreMenu");
    }

    public void OpenCloseMenu()
    {
        keybindMenu.alpha = keybindMenu.alpha > 0 ? 0 : 1;
        keybindMenu.blocksRaycasts = keybindMenu.blocksRaycasts == true ? false : true;
    }
}
