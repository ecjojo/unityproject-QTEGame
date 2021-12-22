using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleControl : MonoBehaviour
{
    public static int SetnumofBlock = 8;
    public GameObject HowtoplayPanel;
    //Numobject
    public GameObject Q24, Q36, Q48, Q60, Q72;
    public Text Optionnum;

    public AudioSource Clickssound;


    //Button
    public void _Button_Howtoplay()
    {
        Clickssound.Play();
        HowtoplayPanel.SetActive(true);
    }
    public void _Button_Startgame()
    {
        Clickssound.Play();
        SceneManager.LoadScene("GameScene");
    }
    public void _Button_HighestRecord()
    {
        Clickssound.Play();
    }
    public void _Button_Exitgame()
    {
        Clickssound.Play();
        Application.Quit();
        Debug.Log("Game Quit");
    }
    public void _Button_Closeallpanel()
    {
        Clickssound.Play();
        HowtoplayPanel.SetActive(false);
    }

    //NumButton
    public void _NumButton_24()
    {
        Clickssound.Play();
        SetnumofBlock = 24;
        Optionnum.text = "Number of Bubble : 24";
        Q24.SetActive(true);
        Q36.SetActive(false);
        Q48.SetActive(false);
        Q60.SetActive(false);
        Q72.SetActive(false);
    }
    public void _NumButton_36()
    {
        Clickssound.Play();
        SetnumofBlock = 36;
        Optionnum.text = "Number of Bubble : 36";
        Q24.SetActive(false);
        Q36.SetActive(true);
        Q48.SetActive(false);
        Q60.SetActive(false);
        Q72.SetActive(false);
    }
    public void _NumButton_48()
    {
        Clickssound.Play();
        SetnumofBlock = 48;
        Optionnum.text = "Number of Bubble : 48";
        Q24.SetActive(false);
        Q36.SetActive(false);
        Q48.SetActive(true);
        Q60.SetActive(false);
        Q72.SetActive(false);
    }
    public void _NumButton_60()
    {
        Clickssound.Play();
        SetnumofBlock = 60;
        Optionnum.text = "Number of Bubble : 60";
        Q24.SetActive(false);
        Q36.SetActive(false);
        Q48.SetActive(false);
        Q60.SetActive(true);
        Q72.SetActive(false);
    }
    public void _NumButton_72()
    {
        Clickssound.Play();
        SetnumofBlock = 72;
        Optionnum.text = "Number of Bubble : 72";
        Q24.SetActive(false);
        Q36.SetActive(false);
        Q48.SetActive(false);
        Q60.SetActive(false);
        Q72.SetActive(true);
    }
}
