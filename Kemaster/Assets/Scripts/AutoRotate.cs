using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 rotationSpeed = new Vector3(0, 100, 0); // degrés par seconde
    public bool isActive = true; // toggle on/off

    void Update()
    {
        if (isActive)
            transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
