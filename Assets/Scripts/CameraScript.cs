using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float Damping = 5f;
    [SerializeField] float Offset = -10;

    Vector3 newPosition;
     
     void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(mousePos);

        newPosition = new Vector3((player.position.x + cursorPosition.x) / 3, (player.position.y + cursorPosition.y) / 3, Offset);

        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * Damping);
    }
}
