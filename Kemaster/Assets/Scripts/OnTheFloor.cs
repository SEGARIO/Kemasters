using UnityEngine;

public class OnTheFloor : MonoBehaviour
{
    public Vector3 _pos;
    public Transform _parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _pos = new Vector3(_pos.x, -_parent.position.y /2, _pos.z);
        this.transform.localPosition = _pos; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
