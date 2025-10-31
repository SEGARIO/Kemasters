using UnityEngine;

public class PivotPlayer : MonoBehaviour
{
    public float rotationSpeed = 100f; // Vitesse de rotation

    void Update()
    {
        float rotationY = 0f;

        
        if (Input.GetKey(KeyCode.LeftArrow))
            rotationY = -2f; // Tourne encore plus fort dans une direction différente
        else if (Input.GetKey(KeyCode.RightArrow))
            rotationY = 2f; // Tourne dans la direction opposée

        if (rotationY != 0f)
            transform.Rotate(Vector3.up * rotationY * rotationSpeed * Time.deltaTime);
    }
}
