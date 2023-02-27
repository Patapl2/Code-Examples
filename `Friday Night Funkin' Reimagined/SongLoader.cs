using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SongLoader : MonoBehaviour
{
    public static SongLoader SL;
    public int songBPM;
    public float[] arrowSpeed;

    public CameraFocusScript.enumCameraFocus[] CameraFocus;

    public int[] playerArrowDir;
    public int[] playerSpawnBeat;
    public bool[] arrowSpawnedPlayer;
    public int[] arrowHoldPlayer;

    public int[] enemyArrowDir;
    public int[] enemySpawnBeat;
    public bool[] arrowSpawnedEnemy;
    public int[] arrowHoldEnemy;

    public string fileName;

    private string filePath;

    void Start()
    {
        SL = this;

        //This code looks at a Excel file formated in a specific way to tell the game when and what type of arrows should spawn during a level.
        try
        {
            filePath = Application.streamingAssetsPath + "/" + fileName + ".csv";
            int totalLines = TotalLines(filePath);

            CameraFocus = new CameraFocusScript.enumCameraFocus[totalLines - 2];

            playerArrowDir = new int[totalLines - 2];
            playerSpawnBeat = new int[totalLines - 2];
            arrowSpawnedPlayer = new bool[totalLines - 2];
            arrowHoldPlayer = new int[totalLines - 2];

            enemyArrowDir = new int[totalLines - 2];
            enemySpawnBeat = new int[totalLines - 2];
            arrowSpawnedEnemy = new bool[totalLines - 2];
            arrowHoldEnemy = new int[totalLines - 2];

            arrowSpeed = new float[3];
            using (var reader = new StreamReader(filePath))

            {
                //Get Song BPM
                string line = reader.ReadLine();
                string[] values = line.Split(',');
                songBPM = Int32.Parse(values[1]);
                arrowSpeed[0] = float.Parse(values[3]);
                arrowSpeed[1] = float.Parse(values[5]);
                arrowSpeed[2] = float.Parse(values[7]);

                // Skip 2nd line
                reader.ReadLine();
                
                    // loop through rest
                    int i = 0;
                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        values = line.Split(',');

                        switch (values[0])
                        {
                        case "E":
                            CameraFocus[i] = CameraFocusScript.enumCameraFocus.Enemy;
                            break;
                        case "B":
                            CameraFocus[i] = CameraFocusScript.enumCameraFocus.Both;
                            break;
                        default:
                            CameraFocus[i] = CameraFocusScript.enumCameraFocus.Player;
                            break;
                        }

                        switch (values[2])
                        {
                        case "1":
                            playerArrowDir[i] = 1; // left
                            break;
                        case "2":
                            playerArrowDir[i] = 2; // down
                            break;
                        case "3":
                            playerArrowDir[i] = 3; // up
                            break;
                        case "4":
                            playerArrowDir[i] = 4; // right
                            break;
                        }
                        
                        if (values[6] != "")
                        {
                            arrowHoldPlayer[i] = Int32.Parse(values[6]);
                        }
                        playerSpawnBeat[i] = Int32.Parse(values[1]);
                        arrowSpawnedPlayer[i] = false;

                        switch (values[9])
                        {
                        case "1":
                            enemyArrowDir[i] = 1; // left
                            break;
                        case "2":
                            enemyArrowDir[i] = 2; // down
                            break;
                        case "3":
                            enemyArrowDir[i] = 3; // up
                            break;
                        case "4":
                            enemyArrowDir[i] = 4; // right
                            break;
                        }
                        if (values[13] != "")
                        {
                            arrowHoldEnemy[i] = Int32.Parse(values[13]);
                        }
                        enemySpawnBeat[i] = Int32.Parse(values[1]);
                        arrowSpawnedEnemy[i] = false;
                        i++;
                    }
            }
        }

        //If not formated correctly, give out an error message.
        catch (Exception e)
        {
            print("unable to read song data file, error: " + e.ToString());
        }
        
        //This part of the code determines which line of the Excel file should be read.
        int TotalLines(string filePath)
        {
            using (StreamReader r = new StreamReader(filePath))
            {
                int i = 0;
                while (!r.EndOfStream)
                {
                    if (r.ReadLine().ToString() != ",,,,,,,,,,,,,")
                        i++;
                }
                r.Dispose();
                return i;
            }
        }
    }
}
