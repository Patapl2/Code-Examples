using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongPlayer : MonoBehaviour
{
    public enum enumDifficulty 
    { 
        Easy, 
        Medium, 
        Hard 
    }

    public static SongPlayer SP;
    public static float beat = 0;
    public static int songBMP;
    public enumDifficulty  gameDifficulty;

    [SerializeField] private GameObject leftArrowPlayer, downArrowPlayer, upArrowPlayer, rightArrowPlayer;
    [SerializeField] private GameObject leftArrowEnemy, downArrowEnemy, upArrowEnemy, rightArrowEnemy;
    [SerializeField] private GameObject leftTail, downTail, upTail, rightTail;

    private int ID = 0;

    void Start()
    {
        SP = this;
        songBMP = SongLoader.SL.songBPM;
    }

    void FixedUpdate()
    {
        //This section handles the speed of the song.
        OnAwake.Timer += Time.deltaTime;
        beat = OnAwake.Timer * (songBMP / 60);

        //This section handles the function responsible for spawning the correct arrows.
        for (int i = 0; i < SongLoader.SL.playerSpawnBeat.Length; i++)
        {
            if (beat >= SongLoader.SL.playerSpawnBeat[i] && SongLoader.SL.arrowSpawnedPlayer[i] == false)
            {
                SongLoader.SL.arrowSpawnedPlayer[i] = true;
                SpawnArrowPlayer(SongLoader.SL.playerArrowDir[i], SongLoader.SL.arrowHoldPlayer[i]);
            }
        }
        for (int i = 0; i < SongLoader.SL.enemySpawnBeat.Length; i++)
        {
            if (beat >= SongLoader.SL.enemySpawnBeat[i] && SongLoader.SL.arrowSpawnedEnemy[i] == false)
            {
                SongLoader.SL.arrowSpawnedEnemy[i] = true;
                SpawnArrowPlayer(SongLoader.SL.enemyArrowDir[i], SongLoader.SL.arrowHoldEnemy[i]);
            }
        }
        //This section changes the camera focus depending on the section of the song.
        for (int i = 0; i < SongLoader.SL.playerSpawnBeat.Length; i++)
        {
            if (Mathf.Round(beat) == SongLoader.SL.playerSpawnBeat[i])
            {
                CameraFocusScript.CF.CameraFocus = SongLoader.SL.CameraFocus[i];
            }
        }
    }

    private void SpawnArrowPlayer(int dir, float holdTime)
    {
        GameObject arrow;
        GameObject tail;

        //This section sets the speed of the arrows to match the selected difficulty level
        float moveSpeed = 0;
        switch (SongPlayer.SP.gameDifficulty)
        {
            case SongPlayer.enumDifficulty.Easy:
                moveSpeed = SongLoader.SL.arrowSpeed[0];
                break;
            case SongPlayer.enumDifficulty.Medium:
                moveSpeed = SongLoader.SL.arrowSpeed[1];
                break;
            case SongPlayer.enumDifficulty.Hard:
                moveSpeed = SongLoader.SL.arrowSpeed[2];
                break;
        }
        holdTime = (moveSpeed / (SongLoader.SL.songBPM / 60)) * holdTime * 2.12f;

        //This section checks the direction of the arrow to match either Left,Right,Up,Down
        switch (dir)
        {
            case 1: // left
                ID++;
                arrow = Instantiate(leftArrowPlayer, new Vector3(), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("LeftSpawnPlayer").transform;
                GameController.GC.AddArrowToGame(ID, GameController.enumArrowDir.Left);

                PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(leftTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;

                    PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;
                }
                break;
            case 2: // down
                ID++;
                arrow = Instantiate(downArrowPlayer, new Vector3(0, 0, 0), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("DownSpawnPlayer").transform;
                GameController.GC.AddArrowToGame(ID, GameController.enumArrowDir.Down);

                PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(downTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;

                    PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;
                }
                break;
            case 3: // up
                ID++;
                arrow = Instantiate(upArrowPlayer, new Vector3(0, 0, 0), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("UpSpawnPlayer").transform;
                GameController.GC.AddArrowToGame(ID, GameController.enumArrowDir.Up);

                PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(upTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;

                    PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;
                }
                break;
            case 4: // right
                ID++;
                arrow = Instantiate(rightArrowPlayer, new Vector3(0, 0, 0), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("RightSpawnPlayer").transform;
                GameController.GC.AddArrowToGame(ID, GameController.enumArrowDir.Right);

                PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(rightTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;

                    PlayerStats.TotalScore = PlayerStats.TotalScore + 350f;
                }
                break;
        }
    }
    private void SpawnArrowEnemy(int dir, float holdTime)
    {
        GameObject arrow;
        GameObject tail;
        float moveSpeed = 0;

        //Just like the player section, this part of the code handles the enemy arrows
        switch (SongPlayer.SP.gameDifficulty)
        {
            case SongPlayer.enumDifficulty.Easy:
                moveSpeed = SongLoader.SL.arrowSpeed[0];
                break;
            case SongPlayer.enumDifficulty.Medium:
                moveSpeed = SongLoader.SL.arrowSpeed[1];
                break;
            case SongPlayer.enumDifficulty.Hard:
                moveSpeed = SongLoader.SL.arrowSpeed[2];
                break;
        }
        holdTime = (moveSpeed / (SongLoader.SL.songBPM / 60)) * holdTime * 2.12f;

        switch (dir)
        {
            case 1: // left
                ID++;
                arrow = Instantiate(leftArrowEnemy, new Vector3(0, 0, 0), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("LeftSpawnEnemy").transform;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(leftTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;
                }
                break;
            case 2: // down
                ID++;
                arrow = Instantiate(downArrowEnemy, new Vector3(0, 0, 0), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("DownSpawnEnemy").transform;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(downTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;
                }
                break;
            case 3: // up
                ID++;
                arrow = Instantiate(upArrowEnemy, new Vector3(0, 0, 0), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("UpSpawnEnemy").transform;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(upTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;
                }
                break;
            case 4: // right
                ID++;
                arrow = Instantiate(rightArrowEnemy, new Vector3(0, 0, 0), transform.rotation);
                arrow.GetComponent<ArrowScript>().ID = ID;
                arrow.transform.parent = GameObject.Find("RightSpawnEnemy").transform;

                if (holdTime > 0)
                {
                    arrow.GetComponent<ArrowScript>().arrowType = ArrowScript.enumArrowType.Hold;
                    tail = Instantiate(rightTail, new Vector3(), transform.rotation);
                    tail.GetComponent<HoldTail>().arrowHead = arrow.gameObject;
                    tail.GetComponent<HoldTail>().tailLength = holdTime;
                }
                break;
        }
    }
}
