using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class CustomKey : MonoBehaviour
{
    public static string keyPressLEFTARROW = ("");
    public static KeyCode LEFTARROWKeyCode;

    public static string keyPressDOWNARROW = ("");
    public static KeyCode DOWNARROWKeyCode;

    public static string keyPressUPARROW = ("");
    public static KeyCode UPARROWKeyCode;

    public static string keyPressRIGHTARROW = ("");
    public static KeyCode RIGHTARROWKeyCode;

    public static string keyPressLEFTMOVE = ("");
    public static KeyCode LEFTMOVEKeyCode;

    public static string keyPressDOWNMOVE = ("");
    public static KeyCode DOWNMOVEKeyCode;

    public static string keyPressUPMOVE = ("");
    public static KeyCode UPMOVEKeyCode;

    public static string keyPressRIGHTMOVE = ("");
    public static KeyCode RIGHTMOVEKeyCode;

    public static int buttonSelected = 0;
    public static int incorrectKey;

    void Start()
    {
        buttonSelected = 0;
    }

    void Update()
    {
        //This script a custom key system, allowing the player to change their controll scheme to their liking. It also avoids duplicate keys and checks if the key is not blacklisted.
        if(buttonSelected != 0 && Input.GetKeyDown(KeyCode.Escape))
        {
            buttonSelected = 0;
        }

        if(buttonSelected == 1)
        {
            // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressLEFTARROW = key;

                    LEFTARROWKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressLEFTARROW);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressLEFTARROW = ("LeftArrow");
                    LEFTARROWKeyCode = KeyCode.LeftArrow;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }
                
                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        LEFTARROWKeyCode = KeyCode.LeftArrow;
                        keyPressLEFTARROW = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        LEFTARROWKeyCode = KeyCode.DownArrow;
                        keyPressLEFTARROW = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        LEFTARROWKeyCode = KeyCode.UpArrow;
                        keyPressLEFTARROW = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        LEFTARROWKeyCode = KeyCode.RightArrow;
                        keyPressLEFTARROW = ("RightArrow");
                    }
                    incorrectKey = 0;
                }

                buttonSelected = 0;
            }
        }

        if(buttonSelected == 2)
        {
         // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressDOWNARROW = key;

                    DOWNARROWKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressDOWNARROW);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressDOWNARROW = ("DownArrow");
                    DOWNARROWKeyCode = KeyCode.DownArrow;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }
                
                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        DOWNARROWKeyCode = KeyCode.LeftArrow;
                        keyPressDOWNARROW = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        DOWNARROWKeyCode = KeyCode.DownArrow;
                        keyPressDOWNARROW = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        DOWNARROWKeyCode = KeyCode.UpArrow;
                        keyPressDOWNARROW = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        DOWNARROWKeyCode = KeyCode.RightArrow;
                        keyPressDOWNARROW = ("RightArrow");
                    }
                    incorrectKey = 0;
                }

                buttonSelected = 0;
            }
        }

        if(buttonSelected == 3)
        {
         // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressUPARROW = key;

                    UPARROWKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressUPARROW);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressUPARROW = ("UpArrow");
                    UPARROWKeyCode = KeyCode.UpArrow;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }

                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        UPARROWKeyCode = KeyCode.LeftArrow;
                        keyPressUPARROW = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        UPARROWKeyCode = KeyCode.DownArrow;
                        keyPressUPARROW = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        UPARROWKeyCode = KeyCode.UpArrow;
                        keyPressUPARROW = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        UPARROWKeyCode = KeyCode.RightArrow;
                        keyPressUPARROW = ("RightArrow");
                    }
                    incorrectKey = 0;
                }

                buttonSelected = 0;
            }
        }

        if(buttonSelected == 4)
        {
         // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressRIGHTARROW = key;

                    RIGHTARROWKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressRIGHTARROW);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressRIGHTARROW = ("RightArrow");
                    RIGHTARROWKeyCode = KeyCode.RightArrow;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }

                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        RIGHTARROWKeyCode = KeyCode.LeftArrow;
                        keyPressRIGHTARROW = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        RIGHTARROWKeyCode = KeyCode.DownArrow;
                        keyPressRIGHTARROW = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        RIGHTARROWKeyCode = KeyCode.UpArrow;
                        keyPressRIGHTARROW = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        RIGHTARROWKeyCode = KeyCode.RightArrow;
                        keyPressRIGHTARROW = ("RightArrow");
                    }
                    incorrectKey = 0;
                }
                buttonSelected = 0;
            }
            
            
        }

        if(buttonSelected == 5)
        {
            // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressLEFTMOVE = key;

                    LEFTMOVEKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressLEFTMOVE);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressLEFTMOVE = ("A");
                    LEFTMOVEKeyCode = KeyCode.A;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }

                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        LEFTMOVEKeyCode = KeyCode.LeftArrow;
                        keyPressLEFTMOVE = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        LEFTMOVEKeyCode = KeyCode.DownArrow;
                        keyPressLEFTMOVE = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        LEFTMOVEKeyCode = KeyCode.UpArrow;
                        keyPressLEFTMOVE = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        LEFTMOVEKeyCode = KeyCode.RightArrow;
                        keyPressLEFTMOVE = ("RightArrow");
                    }
                    incorrectKey = 0;
                }

                buttonSelected = 0;
            }
        }

        if(buttonSelected == 6)
        {
            // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressDOWNMOVE = key;

                    DOWNMOVEKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressDOWNMOVE);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressDOWNMOVE = ("S");
                    DOWNMOVEKeyCode = KeyCode.S;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }

                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        DOWNMOVEKeyCode = KeyCode.LeftArrow;
                        keyPressDOWNMOVE = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        DOWNMOVEKeyCode = KeyCode.DownArrow;
                        keyPressDOWNMOVE = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        DOWNMOVEKeyCode = KeyCode.UpArrow;
                        keyPressDOWNMOVE = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        DOWNMOVEKeyCode = KeyCode.RightArrow;
                        keyPressDOWNMOVE = ("RightArrow");
                    }
                    incorrectKey = 0;
                }

                buttonSelected = 0;
            }
        }

        if(buttonSelected == 7)
        {
            // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressUPMOVE = key;

                    UPMOVEKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressUPMOVE);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressUPMOVE = ("W");
                    UPMOVEKeyCode = KeyCode.W;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }

                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        UPMOVEKeyCode = KeyCode.LeftArrow;
                        keyPressUPMOVE = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        UPMOVEKeyCode = KeyCode.DownArrow;
                        keyPressUPMOVE = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        UPMOVEKeyCode = KeyCode.UpArrow;
                        keyPressUPMOVE = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        UPMOVEKeyCode = KeyCode.RightArrow;
                        keyPressUPMOVE = ("RightArrow");
                    }
                    incorrectKey = 0;
                }

                buttonSelected = 0;
            }
        }

        if(buttonSelected == 8)
        {
        // Check if any key is pressed
            if (Input.anyKeyDown)
            {
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
                {
                // Get the key that was pressed
                string key = Input.inputString;
                if (Regex.IsMatch(key, @"^[a-zA-Z0-9]+$"))
                {
                    key = key.ToUpperInvariant();
                    // Update the keyPress variable with the key that was pressed
                    keyPressRIGHTMOVE = key;

                    RIGHTMOVEKeyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyPressRIGHTMOVE);
                    incorrectKey = 0;
                }
                else
                {
                    keyPressRIGHTMOVE = ("D");
                    RIGHTMOVEKeyCode = KeyCode.D;
                    buttonSelected = 0;
                    incorrectKey = 1;
                }
                }

                if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    if(Input.GetKey(KeyCode.LeftArrow))
                    {
                        RIGHTMOVEKeyCode = KeyCode.LeftArrow;
                        keyPressRIGHTMOVE = ("LeftArrow");
                    }

                    if(Input.GetKey(KeyCode.DownArrow))
                    {
                        RIGHTMOVEKeyCode = KeyCode.DownArrow;
                        keyPressRIGHTMOVE = ("DownArrow");
                    }

                    if(Input.GetKey(KeyCode.UpArrow))
                    {
                        RIGHTMOVEKeyCode = KeyCode.UpArrow;
                        keyPressRIGHTMOVE = ("UpArrow");
                    }

                    if(Input.GetKey(KeyCode.RightArrow))
                    {
                        RIGHTMOVEKeyCode = KeyCode.RightArrow;
                        keyPressRIGHTMOVE = ("RightArrow");
                    }
                    incorrectKey = 0;
                }

                buttonSelected = 0;
            }
        }

        //default values
        if(keyPressLEFTARROW.Length == 0)
        {
            keyPressLEFTARROW = ("LeftArrow");
            LEFTARROWKeyCode = KeyCode.LeftArrow;
        }

        if(keyPressDOWNARROW.Length == 0)
        {
            keyPressDOWNARROW = ("DownArrow");
            DOWNARROWKeyCode = KeyCode.DownArrow;
        }

        if(keyPressUPARROW.Length == 0)
        {
            keyPressUPARROW = ("UpArrow");
            UPARROWKeyCode = KeyCode.UpArrow;
        }

        if(keyPressRIGHTARROW.Length == 0)
        {
            keyPressRIGHTARROW = ("RightArrow");
            RIGHTARROWKeyCode = KeyCode.RightArrow;
        }

        if(keyPressLEFTMOVE.Length == 0)
        {
            keyPressLEFTMOVE = ("A");
            LEFTMOVEKeyCode = KeyCode.A;
        }

        if(keyPressDOWNMOVE.Length == 0)
        {
            keyPressDOWNMOVE = ("S");
            DOWNMOVEKeyCode = KeyCode.S;
        }

        if(keyPressUPMOVE.Length == 0)
        {
            keyPressUPMOVE = ("W");
            UPMOVEKeyCode = KeyCode.W;
        }

        if(keyPressRIGHTMOVE.Length == 0)
        {
            keyPressRIGHTMOVE = ("D");
            RIGHTMOVEKeyCode = KeyCode.D;
        }
    }
}
