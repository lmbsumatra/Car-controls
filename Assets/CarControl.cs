using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControlScript : MonoBehaviour
{
    private int counter = 0;
    [SerializeField]
    private float WalkSpeed = 5f;
    [SerializeField]
    private float TurnSpeed = 60f; // Adjust the turn speed as needed.

    // Update is called once per frame
    void Update()
    {

        float xAxisInput = Input.GetAxis("Horizontal");
        float yAxisInput = Input.GetAxis("Vertical");

        Vector3 dirInput = new Vector3(xAxisInput, yAxisInput, 0);
        if (dirInput.magnitude > 1f)
        {
            dirInput = dirInput.normalized;
        }

        Vector3 movement = dirInput * (WalkSpeed * Time.deltaTime);

        transform.localPosition += movement;
    }
}
