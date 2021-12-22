using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    //1. Ready 2.Count Down 3.Game Started4.Game Completed
    public enum GameState
    {
        Ready,
        CountDown,
        Started,
        Completed
    }
    public static GameControl instance;
    public List<GameObject> blocks;    

    public GameState CurGameState = GameState.Ready;     //public bool GameStarted = false;
    public Animator CountDownAnim;

    public List<PlayerController> players;

    //UI
    public GameObject ResultMenu;
    public List<Text> ResultTexts;
    public List<Text> ResultTimeTexts;

    public Text BlockNumTitle;
    public GameObject SpacebarTip;

    public AudioSource Clicksound;
    public AudioSource Spacesound;

    void Awake()
    {
        instance = this;
        if (TitleControl.SetnumofBlock != 24)
        {
            BlockNumTitle.text = "Bubble Level : " + TitleControl.SetnumofBlock;
        }
        else
        {
            BlockNumTitle.text = "Bubble Level : 24";
        }
    }
    void Update()
    {

        if(CurGameState == GameState.Ready &&  Input.GetKeyDown(KeyCode.Space))
        {
            StartCountDown();
            SpacebarTip.SetActive(false);
            Spacesound.Play();
        }

        if(CurGameState == GameState.Started)
        {
            bool allPlayerCompleted = true;
            for(int i= 0; i < players.Count;i++)
            {
                if(!players[i].GameCompleted)
                {
                    allPlayerCompleted = false;
                }
            }
            if(allPlayerCompleted)
            {
                GameCompleted();
            }
        }
        if(CurGameState ==GameState.Completed && Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    void StartCountDown()
    {
        Clicksound.Play();
        CountDownAnim.Play("CountDownAnim");
        CurGameState = GameState.CountDown;
    }

    public void GameStart()
    {
        CurGameState = GameState.Started;
        for(int i = 0; i < players.Count ; i++)
        {
            players[i].CreateBlock();
        }
    }
    public void GameCompleted()
    {
        CurGameState = GameState.Completed;
        players.Sort(ComparePlayer);

        for(int i =0; i<ResultTexts.Count; i++)
        {
            if(i==0)
            {
                ResultTexts[i].text = "1st Player" + players[i].PlayerIndex.ToString() ;
                ResultTimeTexts[i].text = "(" + players[i].TimerText.text + ")";
            }
            if (i == 1)
            {
                ResultTexts[i].text = "2nd Player" + players[i].PlayerIndex.ToString() ;
                ResultTimeTexts[i].text = "(" + players[i].TimerText.text + ")";
            }
            if (i == 2)
            {
                ResultTexts[i].text = "3rd Player" + players[i].PlayerIndex.ToString();
                ResultTimeTexts[i].text = "(" + players[i].TimerText.text + ")";
            }
        }
        ResultMenu.SetActive(true);
    }

    public static int ComparePlayer(PlayerController p1,PlayerController p2)
    {
        if (p1.GameTimer > p2.GameTimer)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
    //Button
    public void _Button_backtitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
