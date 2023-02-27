using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderTeleport : MonoBehaviour
{
    [SerializeField] private GameObject XRplayer;
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private int rotateByOnTeleport;
    private bool rdyToTeleport = true;

    //This section looks for collision to trigger the teleport event.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "XRRig" && rdyToTeleport)
        {
            rdyToTeleport = false;
            StartCoroutine(TeleportThePlayer());
        }
    }

    //Uppon colliding with the teleport area, it triggers the event.
    IEnumerator TeleportThePlayer()
    {   
        //sound
        FindObjectOfType<AudioManager>().Play("LadderClimbing");
        //blink
        BlinkManager.Instance.OnBlinkLadder(0.4f);
        yield return new WaitForSeconds(1f);
        //teleport + rotation
        XRplayer.transform.position = teleportTarget.transform.position;
        Vector3 rotationToAdd = new Vector3(0, rotateByOnTeleport, 0);
        XRplayer.transform.Rotate(rotationToAdd);
        rdyToTeleport = true;
        
    }
}
