using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //Currently unused
    [SerializeField] GameObject _enemies;
    
    private static EnemyManager _instance;
    public static EnemyManager Instance { get => _instance; private set => _instance = value; }

    public delegate void OnUnitDeath(int damageAmount);
    public static event OnUnitDeath callForHelp;

    public Material activatedMaterial;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
    }

    public void UnitDied()
    {
        callForHelp?.Invoke(damageAmount : 0);
    }
}
