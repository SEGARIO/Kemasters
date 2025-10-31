using UnityEngine;

public class ViewerController : MonoBehaviour
{
    public Material[] _randomMat;
    public Renderer _renderer;
    public float _randomSize;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _randomSize = Random.Range(1f, 2);
        transform.localScale = new Vector3(_randomSize, _randomSize, _randomSize);
        _renderer.material = _randomMat[Random.Range(0, _randomMat.Length)];
        GetComponentInChildren<Animator>().speed = Random.Range(0.8f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
