using UnityEngine;

public class ManagerInMap : MonoBehaviour
{
    public SO_Monster _monsterForFight;
    public Animator _transitionAnimator;
     void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

   
}
