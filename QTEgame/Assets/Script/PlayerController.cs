using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int ChoosednumofBlock = 24;
    public int  PlayerIndex;
    public GameObject BlockStack;
    public List<BlockController> BlockList;
    public Animator CompleteAnim;
    public Animator FailAnim;//BgAnim
    public Vector3 BlockStackTarPos;
    public float PenaltyTimer;
    public float GameTimer = 0;
    public bool GameCompleted = false;

    public AudioSource wrong;
    public AudioSource correct;

    public TextMesh TimerText;

    void Start()
    {
        if(TitleControl.SetnumofBlock != 24)
        {
            ChoosednumofBlock = TitleControl.SetnumofBlock;
        }
        else
        {
            ChoosednumofBlock = 24;
        }

        BlockStackTarPos = BlockStack.transform.position;
        // CreateBlock();
    }

    void Update()
    {
        if (GameControl.instance.CurGameState == GameControl.GameState.Started)
        {
            if (BlockList.Count == 0)
            {
                Completed();
            }

            if (PenaltyTimer > 0)
            {
                PenaltyTimer -= Time.deltaTime;
                if (PenaltyTimer <= 0)
                {
                    FailAnim.Play("PanelIdel");
                }
            }
            if (!GameCompleted)
            {
                GameTimer += Time.deltaTime;
                //sss.ms //6.234 => 6234...(int) =%1000 =>234
                int sec = (int)GameTimer;
                int ms = ((int)(GameTimer * 100)) % 100;

                //TimerText.text = string.Format(sec.ToString() + ":" + ms.ToString());
                TimerText.text = string.Format("{0:00}:{1:00}", sec, ms);
            }
            BlockStack.transform.position = Vector3.Lerp(BlockStack.transform.position, BlockStackTarPos, 10 * Time.deltaTime);
        }
    }

    public void CreateBlock()
    {
        for (int i = 0; i < ChoosednumofBlock; i++)
        {
            //i =0 y=0//i =1 y=1// i = 2 y = 2
            int rand = Random.Range(0, GameControl.instance.blocks.Count);
            GameObject b = Instantiate(GameControl.instance.blocks[rand], BlockStack.transform);
            b.transform.localPosition = new Vector3(0,i*1.5f,0);
            BlockList.Add(b.GetComponent<BlockController>());
        }
    }

    public void ButtonPressed(string s)
    {
        if (BlockList.Count > 0 && PenaltyTimer <= 0)
        {
            if (BlockList[0].BlockColor == s)
            {
                BlockList[0].BlockDestroy();
                BlockList.RemoveAt(0);

                //BlockStack.transform.position = BlockStack.transform.position - new Vector3(0, 1, 0);
                //Vector3 tarPos = BlockStack.transform.position - new Vector3(0, 1, 0);

                BlockStackTarPos = BlockStack.transform.position - new Vector3(0, 1.5f, 0);
                //BlockStackTarPos = BlockStack.transform.position + new Vector3(0, -1, 0);
                correct.Play();
            }
            else
            {
                PenaltyTimer = 2; //if player enter error button
                FailAnim.Play("PanelFailAnim");
                wrong.Play();
            }
        }
    }
    public void Completed()
    {
        GameCompleted = true;
        CompleteAnim.Play("ShowStar");
    }
}
