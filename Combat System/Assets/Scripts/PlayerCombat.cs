using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] InputAction _attack;
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _attackRange = 1f;
    [SerializeField] private int _attackDamage = 40;
    [SerializeField] LayerMask _enemyLayers;

    void OnEnable() => _attack.Enable();

    void OnDisable() => _attack.Disable();

    private void Start()
    {
        _attack.performed += _ => Attack();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void Attack()
    {
        //Attack animation

        //Detect enemies in range of attack
        Collider[] hitEnemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayers);

        //Damage
        foreach(var enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(_attackDamage);
        }
    }

}
