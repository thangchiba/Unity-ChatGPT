/**
 * *********************************************************************
 * © 2023 ThangChiba. All rights reserved.
 * 
 * This code is licensed under the MIT License.
 * 
 * Homepage: https://thangchiba.com
 * Email: thangchiba@gmail.com
 * *********************************************************************
 */

using UnityEngine;

namespace ThangChibaGPT
{
    public class CharacterMovement : MonoBehaviour
    {
        public float speed = 5.0f;

        private void Update()
        {
            // Get the horizontal and vertical input axes
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            // Calculate the movement direction
            var direction = new Vector3(horizontalInput, 0, verticalInput);

            // Normalize the direction vector to avoid faster diagonal movement
            if (direction.magnitude > 1.0f) direction.Normalize();

            // Move the character based on the input and speed
            transform.position += direction * (speed * Time.deltaTime);
        }
    }
}