using UnityEngine;

public class LerpScale : MonoBehaviour
{
    public Transform _target;
    public float _lerpSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null) return;

        transform.localScale = Vector3.Lerp(
          transform.localScale, _target.localScale, Time.deltaTime * _lerpSpeed
            
            );
    }
}
