using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public AudioSource sounds;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    public float maxDistance = 100f;
    private LineRenderer lineRenderer;
    private Vector3 grapplePoint;
    private SpringJoint joint;

    //Script responsible for the grappling hook tool and the physics behind it.
    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        sounds = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Starts/Stops the grapple upon clicking the mouse button
        if (Input.GetMouseButtonDown(0) && PlayerMovement.Equiped == true)
        {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0) && PlayerMovement.Equiped == true)
        {
            StopGrapple();
        }
    }

    private void LateUpdate()
    {
        //Draws the Hook rope when needed
        DrawRope();
    }
    
    //Starts the grapple
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //the distance the grapple will try to keep from grapple point
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.05f;

            //Physics of the grapple
            joint.spring = 30f;
            joint.damper = 7f;
            joint.massScale = 4.5f;
            lineRenderer.positionCount = 2;
 
            //plays the grapple sound
            sounds.Play();
        }
    }

    //Stops the grapple
    void StopGrapple()
    {
        lineRenderer.positionCount = 0;
        Destroy(joint);
    }

    //Draws the rope of the hook
    void DrawRope()
    {
        //if not grapphling, don't draw the rope
        if (!joint) 
        {
            return;
        }
        lineRenderer.SetPosition(0, gunTip.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }

    //checks if the joint exists or not
    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
