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

                        if (values[0] == "E")
                        {
                            CameraFocus[i] = CameraFocusScript.enumCameraFocus.Enemy;
                        }
                        else if (values[0] == "B")
                        {
                            CameraFocus[i] = CameraFocusScript.enumCameraFocus.Both;
                        }
                        else
                        {
                            CameraFocus[i] = CameraFocusScript.enumCameraFocus.Player;
                        }

                        if (values[2] == "1")
                        {
                            playerArrowDir[i] = 1; // left
                        }
                        else if (values[3] == "1")
                        {
                            playerArrowDir[i] = 2; // down
                        }
                        else if (values[4] == "1")
                        {
                            playerArrowDir[i] = 3; // up
                        }
                        else if (values[5] == "1")
                        {
                            playerArrowDir[i] = 4; // right
                        }
                        if (values[6] != "")
                        {
                            arrowHoldPlayer[i] = Int32.Parse(values[6]);
                        }
                        playerSpawnBeat[i] = Int32.Parse(values[1]);
                        arrowSpawnedPlayer[i] = false;

                        if (values[9] == "1")
                        {
                            enemyArrowDir[i] = 1; // left
                        }
                        else if (values[10] == "1")
                        {
                            enemyArrowDir[i] = 2; // down
                        }
                        else if (values[11] == "1")
                        {
                            enemyArrowDir[i] = 3; // up
                        }
                        else if (values[12] == "1")
                        {
                            enemyArrowDir[i] = 4; // right
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
