using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusScript : MonoBehaviour
{
    public static CameraFocusScript CF;
    public Transform player;
    public Transform enemy;
    public Transform both;
    public enum enumCameraFocus { Player, Enemy, Both };
    public enumCameraFocus CameraFocus;
    public AnimationCurve moveCurve;
    public float smoothSpeed;

    void Start()
    {
        CF = this;
    }

    void LateUpdate()
    {
        //This script moves the camera focus on the designeted spot in a smooth manner using a formula.
        Vector3 desiredPosition = new Vector3();
        switch (CameraFocus)
        {
        case enumCameraFocus.Player:
        desiredPosition = player.position;
        break;
    
        case enumCameraFocus.Enemy:
        desiredPosition = enemy.position;
        break;
    
        case enumCameraFocus.Both:
        desiredPosition = both.position;
        break;
    
        default:
        // Handle an invalid value for CameraFocus
        break;
}
        smoothSpeed = moveCurve.Evaluate(Vector2.Distance(new Vector2(desiredPosition.x, desiredPosition.y), new Vector2(transform.position.x, transform.position.y)) / 1000f);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(desiredPosition.x, desiredPosition.y, -10f), smoothSpeed * 10f);
        transform.position = smoothedPosition;
    }

}
