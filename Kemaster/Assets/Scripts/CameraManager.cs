using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] _allCameras;
    public int _maxTimer;

    float _timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _timer = _maxTimer;
    }

    // Update is called once per frame
    void Update()
    {
        _timer -= Time.deltaTime;

        if(_timer < 0)
        {
            int _randomCam =  Random.Range(0, _allCameras.Length);
            for(int i = 0; i < _allCameras.Length; i++)
            {
                if(i == _randomCam)
                {
                    _allCameras[i].SetActive(true);
                }
                else
                {
                    _allCameras[i].SetActive(false);
                }
            }
            _timer = Random.Range(2, _maxTimer);

        }
    }
}
