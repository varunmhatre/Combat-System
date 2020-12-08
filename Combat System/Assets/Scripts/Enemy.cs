using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;

    int _currentHealth;

    public delegate void ClickedOn(int damage);
    public ClickedOn TakeDamage;

    private void Awake()
    {
        EnemyManager.callForHelp += Activate;
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
        TakeDamage += Activate;
    }

    public void Activate(int damage)
    {
        GetComponent<Renderer>().material = EnemyManager.Instance.activatedMaterial;
        Hurt(damage);

        EnemyManager.callForHelp -= Activate;
        TakeDamage -= Activate;
        TakeDamage += Hurt;

        //Coroutine to position Enemy attack arm/block
        //Create a function to damage which is called when enemy within attack range

        //Follow player with A*
    }

    public void Hurt(int damage)
    {
        //Play hurt animation (change color coroutine)
        if (damage > 0)
        {
            _currentHealth -= damage;
            StartCoroutine(ApplyDamageColor(new Color(1f, 0.5f, 0f)));
        }

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator ApplyDamageColor(Color damageColor)
    {
        var mat = GetComponent<Renderer>().material;
        var originalColor = mat.color;
        mat.SetColor("_Color", damageColor);
        yield return new WaitForSeconds(0.1f);
        mat.SetColor("_Color", originalColor);
    }

    void Die()
    {
        //Death (look like one of random blocks) animation instead of setactive false
        //Box collider = false
        //enabled = false;
        EnemyManager.callForHelp -= Activate;
        EnemyManager.Instance.UnitDied();

        gameObject.SetActive(false);

    }
        
}
