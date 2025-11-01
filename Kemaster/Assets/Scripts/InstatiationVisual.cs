using UnityEngine;

public class InstatiationVisual : MonoBehaviour
{
    public SO_Monster _monster;
    public GameObject _monsterVisual;
    public GameObject _visualParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _monster = FindObjectOfType<ManagerInMap>()._monsterForFight;
        _monsterVisual = Instantiate(_monster._visual, this.transform.position, Quaternion.identity, _visualParent.transform);
        _monsterVisual.transform.localRotation = Quaternion.Euler(0, -90, 0);
        _monsterVisual.transform.SetSiblingIndex(transform.GetSiblingIndex() - 1);
        _monster._hasBeenEncountered = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
