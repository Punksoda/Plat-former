using System;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public interface IHealable
{
    void Heal(int healAmount);
}

public class PlayerCondition : MonoBehaviour, IDamagable, IHealable
{

    public UICondition uiCondition;
    public event Action onTakeDamage;
    Condition health { get { return uiCondition.health; } }
    Condition special { get { return uiCondition.special; } }
 
  public void Heal(int healAmount)
    {
        health.Add(healAmount);
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Decrease(damageAmount);
        onTakeDamage?.Invoke();
    }

}
