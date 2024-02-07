// Sumatra, Love Missy B.
// BSIT NS 3B
// 

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class CarController : MonoBehaviour
{
    [SerializeField] float acceleration = 0; // acceleration, decceleration while moving
    [SerializeField] float driftFactor = 1f;
    Rigidbody2D carRB2d;
    float carAcceleration;
    float steeringWheel;
    float newCarAngle;

    public TextMeshProUGUI text;

    void Awake() {
        carRB2d = GetComponent<Rigidbody2D>();
        carRB2d.mass = 10;
    }

    void Update() {

        carAcceleration = Input.GetAxis("Vertical"); // new position when 'w' 's' key, acceleration of car
        steeringWheel = Input.GetAxis("Horizontal"); // new position when 'a' 'd' key, angle of steering wheel

        ApplyEngineForce();

        ApplySteering();

        GearShift();
    }


    void ApplyEngineForce() {

        // apply movement to the car, w the help of transform.up
        Vector2 engineForceVector = transform.up * acceleration * carAcceleration;

        // update, apply acceleration
        carRB2d.AddForce(engineForceVector, ForceMode2D.Force);

        // removing unnecessary movements, keeping desired acceleration
        carRB2d.velocity = Vector2.Dot(carRB2d.velocity, transform.up) * transform.up * driftFactor;

    }

    void ApplySteering() {

        // formula for getting new car rotation angle, 'a', 'd' keys
        newCarAngle -= steeringWheel;

        // update, apply new rotation
        carRB2d.MoveRotation(newCarAngle);
    }

    void GearShift() {

        // when any of the number keys (1, 2, 3) is pressed,set the text and acceleration to their coresponding values
        if (Input.anyKeyDown)
        {
            KeyCode key = PressedKey();

            switch (key)
            {
                case KeyCode.Alpha1:
                    acceleration = 10;
                    text.text = "10";
                    break;
                case KeyCode.Alpha2:
                    acceleration = 30;
                    text.text = "30";
                    break;
                case KeyCode.Alpha3:
                    acceleration = 60;
                    text.text = "60";
                    break;
            }
        }

        else if (Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Alpha3))
        {
            // when any of the number keys (1, 2, 3) is released, set acceleration and text to 0
            acceleration = 0;
            text.text = "0";
        }

        KeyCode PressedKey()
        {
            foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    return key;
                }
            }
            return KeyCode.None;
        }

    }
}
