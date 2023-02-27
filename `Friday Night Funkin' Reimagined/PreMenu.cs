//Handles the functions responsible for the intro sequences.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreMenu : MonoBehaviour
{
    public float AlphaLevel = 1f;
    public bool Playable = false;
    public bool SecondMenuOpened = false;
    public IEnumerator coroutine;
    public GameObject[] MenuItems;
    public GameObject[] MenuItems2;
    public GameObject[] SelectionMenu;
    public GameObject Background;
    public GameObject Music;
    public GameObject ConfSound;
    public Image image;

    void Start()
    {
        Music.SetActive(false);
        ConfSound.SetActive(false);
        for (int i = 0; i < MenuItems.Length; i++)
        {
            MenuItems[0].SetActive(true);
        }
        for (int i = 0; i < MenuItems2.Length; i++)
        {
            MenuItems2[0].SetActive(false);
        }
        image = MenuItems2[0].GetComponent<Image>();
        MenuItems2[1].SetActive(false);
        MenuItems2[2].SetActive(false);
    }

    void Update()
    {
        //Player Input Controll.
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(NextImage());
            if (Playable)
            {
                StartCoroutine(Continue2());
            }
        }
        
        if (SecondMenuOpened == true)
        {
            MenuItems2[2].SetActive(true);
        }
    }

    //This section handles the intro sequence when opening the game, displaying images for a set amount of time to match the music.
    IEnumerator NextImage()
    {
        Music.SetActive(true);
        for (int i = 0; i < MenuItems.Length; i++)
        {
            if (i == 3 || i == 6)
            {
                yield return new WaitForSeconds(0.25f); //0.25
            }
            if (i == 9)
            {
                yield return new WaitForSeconds(1f); //1
            }
            yield return new WaitForSeconds(0.8f);
            Background.SetActive(false);
            MenuItems[i].SetActive(false);
        }
        MenuItems2[0].SetActive(true);
        if (MenuItems2[0].activeSelf)
        {
            for (int q = 0; q < 100; q++)
            {
                AlphaLevel = AlphaLevel - 0.01f;
                image.color = new Color(image.color.r, image.color.g, image.color.b, AlphaLevel);
                yield return new WaitForSeconds(0.01f);
            }
            Playable = true;
        }
    }

    //This is a second part of the intro animation, it uses fade in and out animations to transition between scenes.
    IEnumerator Continue2()
    {
        MenuItems2[1].SetActive(true);
        ConfSound.SetActive(true);
        Playable = false;
        for (int q = 0; q < 20; q++)
        {
            AlphaLevel = AlphaLevel + 0.04f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, AlphaLevel);
            yield return new WaitForSeconds(0.01f);
        }
        for (int q = 0; q < 20; q++)
        {
            AlphaLevel = AlphaLevel - 0.04f;
            image.color = new Color(image.color.r, image.color.g, image.color.b, AlphaLevel);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.5f);
        
        for (int q = 0; q < 100; q++)
        {
            AlphaLevel = AlphaLevel + 0.01f;
            image.color = new Color(0f, 0f, 0f, AlphaLevel);
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene("PreMenu2");
        SecondMenuOpened = true;
        for (int q = 0; q < 100; q++)
        {
            AlphaLevel = AlphaLevel - 0.01f;
            image.color = new Color(0f, 0f, 0f, AlphaLevel);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
