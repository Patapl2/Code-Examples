using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonDoor : MonoBehaviour
{
    [SerializeField] private bool Pushing = false, AudioPlaying = true;
    [SerializeField] private float MaxPush;
    [SerializeField] private GameObject ghostPipe, rayWall;
    
    void Start()
    {
        AudioPlaying = true;
    }

    //this function is the logic for the first puzzle in the game.
    void FixedUpdate()
    {
        if (Pushing && MaxPush < 1f)
        {
            transform.Translate(new Vector3(0.01f, 0, 0));
            MaxPush = MaxPush + 0.025f;
            PlayDoorOpenAudio();
            if (MaxPush >= 1f)
            {
                ghostPipe.SetActive(false);
                rayWall.SetActive(false);
                this.enabled = false;
            }
        }
    }

    //Looks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pipe")
        {
            Pushing = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Pushing = false;
    }

    //Plays an audio clip
    private void PlayDoorOpenAudio()
    {
        if (AudioPlaying == true)
        {
            AudioPlaying = false;
            FindObjectOfType<AudioManager>().Play("PrisonDoorOpen");
        }
    }
}
