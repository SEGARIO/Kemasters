using UnityEngine;

public class RandomColor : MonoBehaviour
{
    public Renderer[] _rend;
    public Color[] _colors;
    public Color color;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        color = _colors[Random.Range(0, _colors.Length)];
        for (int i = 0; i < _rend.Length; i++)
        {
            _rend[i].material.color = color;    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
