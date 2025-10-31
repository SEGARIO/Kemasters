using UnityEngine;

public class RotationShoot : MonoBehaviour
{
    public GameObject _firepointVisual;

    private void Update()
    {
        if(_firepointVisual == null)
        {
            _firepointVisual = GameObject.FindWithTag("Body");
        }
        this.transform.position = _firepointVisual.transform.position;
    }
}
