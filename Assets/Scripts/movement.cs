using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 10f; // Adjust the speed as needed

    void Update()
    {
        // Get the horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Move the object based on the input and speed
        transform.Translate(movement * speed * Time.deltaTime);
    }


}
