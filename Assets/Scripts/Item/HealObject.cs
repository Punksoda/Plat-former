using UnityEngine;

public class HealObject : MonoBehaviour
{
    public int healAmount = 20;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IHealable healable))
        {
            healable.Heal(healAmount);
            Destroy(gameObject); // 아이템 사용 후 삭제
        }
    }
}
