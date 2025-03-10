using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damage;
    public float damageTime;

    List<IDamagable> damagethings  = new List<IDamagable>();

    void Start()
    {
        InvokeRepeating("DealDamage", 0f, damageTime);
    }

    void DealDamage()
    {
        for (int i = 0; i < damagethings.Count; i++)
        {
            damagethings[i].TakePhysicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out IDamagable damagable))
        {
            damagethings.Add(damagable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out IDamagable damagable))
        {
            damagethings.Remove(damagable);
        }
    }
}
