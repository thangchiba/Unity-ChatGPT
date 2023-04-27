using UnityEngine;

namespace ThangChiba.GameCore{
public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        // Get the horizontal and vertical input axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

        // Normalize the direction vector to avoid faster diagonal movement
        if (direction.magnitude > 1.0f)
        {
            direction.Normalize();
        }

        // Move the character based on the input and speed
        transform.position += direction * (speed * Time.deltaTime);
    }
}}