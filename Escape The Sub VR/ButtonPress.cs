//This script handles the buttons in VR, The player has to push them with a motion of their hands.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class ButtonPress : MonoBehaviour
{
    public enum ButtonColor
    {
        Green =1,
        Red =2,
        Orange =3,
        Blue =4,
    }
    public UnityEvent onPressed, onReleased;
    public ButtonColor buttonColor;

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;
    [SerializeField] private float threshold = .1f;
    [SerializeField] private float deadZone = .025f;

    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
    }

    //If pushed enough triggers/untriggers an event bound to the button
    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }
        if (_isPressed && GetValue() - threshold <= 0)
        {
            Released();
        }
    }

    //The logic behind the buttoms, giving them deadzones and points where they are triggered.
    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed?.Invoke();
        PuzzleLogic.playerCode += (int)buttonColor;
        PuzzleLogic.totalDigits += 1;
    }
    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
    }
}
