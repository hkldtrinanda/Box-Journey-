using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    // The start and end points of the zipline
    public Transform startPoint;
    public Transform endPoint;

    // The speed at which the character will move along the zipline
    public float ziplineSpeed = 5.0f;

    // A reference to the character's rigidbody
    private Rigidbody2D characterRigidbody;

    // A flag to track whether the character is currently using the zipline
    private bool isUsingZipline = false;

    // The current progress along the zipline, from 0 (start) to 1 (end)
    private float ziplineProgress = 0.0f;

    private void Start()
    {
        // Get a reference to the character's rigidbody
        characterRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // If the character is using the zipline, update their position
        if (isUsingZipline)
        {
            // Increment the zipline progress
            ziplineProgress += Time.deltaTime * ziplineSpeed;

            // Clamp the progress between 0 and 1
            ziplineProgress = Mathf.Clamp01(ziplineProgress);

            // Get the character's new position along the zipline
            Vector2 newPosition = Vector2.Lerp(startPoint.position, endPoint.position, ziplineProgress);

            // Set the character's position to the new position
            characterRigidbody.MovePosition(newPosition);

            // If the character has reached the end of the zipline, stop using it
            if (ziplineProgress == 1.0f)
            {
                isUsingZipline = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // If the character collides with the zipline, start using it
        /*if (col.)
        {
            isUsingZipline = true;
        }*/

        if (col.gameObject.tag == "Player")
        {
            isUsingZipline = true;
        }
    }
}