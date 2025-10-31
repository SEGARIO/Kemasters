using UnityEngine;

public class BlockRotation : MonoBehaviour
{
    int _random;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Choisit al�atoirement entre 0, 90, 180 ou 270 degr�s
        float randomY = 90f * Random.Range(0, 4);

        // Applique la rotation � l�objet
        transform.rotation = Quaternion.Euler(0f, randomY, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
