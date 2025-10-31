using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class MonsterSpawnChance
{
    
    public SO_Monster monster;     // Le ScriptableObject du monstre
    [Range(0f, 100f)]
    public float spawnChance;      // Pourcentage de chance d'apparition
}

public class GrassController : MonoBehaviour
{
    public SO_Monster _nullMonster;
    [Header("Liste des monstres et leurs chances")]
    public MonsterSpawnChance[] monsters;
    public Transform _grasses;
    public bool _canInstantiate;
    SO_Monster _monster;

    /// <summary>
    /// Retourne un monstre aléatoire en fonction des chances définies
    /// </summary>
    public SO_Monster GetRandomMonster()
    {
        float total = 0f;

        // Somme des chances pour la normalisation
        foreach (var entry in monsters)
        {
            total += entry.spawnChance;
        }

        float roll = Random.Range(0f, total);

        foreach (var entry in monsters)
        {
            if (roll <= entry.spawnChance)
                return entry.monster;
            roll -= entry.spawnChance;
        }

        return null; // Aucun monstre sélectionné (rare si les chances > 0)
    }

    /// <summary>
    /// Exemple pour instancier un monstre
    /// </summary>
    public void SpawnMonster(Vector3 position)
    {

        SO_Monster monsterToSpawn = GetRandomMonster();

        if (monsterToSpawn != _nullMonster)
        {
            _canInstantiate = true;
        }
        else
        {
            _canInstantiate = false;
        }

        Debug.Log(monsterToSpawn);
        _monster = monsterToSpawn;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player on it");
        if(other.gameObject.tag == "Player")
        {
            _grasses.transform.localPosition = new Vector3(0, -0.5f, 0);

            
            SpawnMonster(this.transform.position);
            Fight();
        }
    }

    void Fight()
    {
        if(_canInstantiate)
        {
            Debug.Log("Fight!");
            ManagerInMap _man = FindObjectOfType<ManagerInMap>();
            PlayerMovement _payer = FindObjectOfType<PlayerMovement>();
            _payer.enabled = false;
            Rigidbody _rb = _payer.gameObject.GetComponent<Rigidbody>();
            _rb.isKinematic = true;
            _man._monsterForFight = _monster;
            _man._transitionAnimator.SetTrigger("Activate");
            Invoke("ChangeScene", 2);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("CombatScene");
    }
    private void OnTriggerExit(Collider other)
    {
         if (other.gameObject.tag == "Player")
        {
            _grasses.transform.localPosition = new Vector3(0, 0, 0);
            
        }
    }
}
