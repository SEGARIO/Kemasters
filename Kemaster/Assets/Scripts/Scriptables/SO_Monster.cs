using UnityEngine;

[CreateAssetMenu(fileName = "SO_Monster", menuName = "Scriptable Objects/SO_Monster")]
public class SO_Monster : ScriptableObject
{
    public int _index;

    [Header("Infos")]
    public GameObject _visual;
    public string _name;
    public string _description;
    public SO_Talent _talent;

    [Header("Attacks")]
    public Types _type;
    public bool _canLazer;
    public float _minTimeLazer;
    public float _maxTimeLazer;
    public bool _canJump;
    public float _maxJumpDuration;
    public float _minJumpDuration;
    public float _maxTimeBeforeJump;
    public float _minTimeBeforeJump;
    public float _timeBeforeFirstJump;



    [System.Serializable]

    public class ProjectileWave
    {
        public GameObject projectilePrefab;
        public float fireRate = 0.5f;
        public int projectileCount = 5;
        public float waveDelay = 2f;
        public float shootForce = 10f;
    }
    
    public ProjectileWave[] _projectiles;

    [Header("🌀 Rotation Settings")]
    public Vector2 rotationDurationRange = new Vector2(1f, 3f);   // Durée de la rotation
    public Vector2 rotationDelayRange = new Vector2(2f, 5f);      // Délai entre rotations
    public Vector2 rotationSpeedRange = new Vector2(30f, 120f);   // Vitesse de rotation


    

    [System.Flags]
    public enum Types
    {
        None = 0,
        Eau = 1 << 0,
        Feu = 1 << 1,
        Air = 1 << 2,
        Terre = 1 << 3,
        Metal = 1 << 4,
        Glace = 1 << 5,
        Magie = 1 << 6,
        Mort = 1 << 7,
        Plante = 1 << 8,
        Electric = 1 << 9
    }


    [Header("Sounds")]
    public AudioClip _battleCry;
    public AudioClip _attackCry;
    public AudioClip _deathCry;

   

    [Header("Stats")]
    [Range(1, 500)]public int _hp;
  
    [Range(1, 300)] public int _attack;
    public bool _hasBeenEncountered;
}
