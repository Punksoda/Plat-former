using Unity.VisualScripting;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    public int healAmount = 20; // ȹ��� �߰��Ǵ� ȸ����
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)  // �ش� Ÿ���� ������Ʈ�� ã��, IHealable�� ������ �ִ� ������Ʈ�� ����Ʈ�� �߰��ϰ�, �ߵ� ���� �ı���
    {
        if (other.TryGetComponent(out IHealable healable))
        {
            healable.Heal(healAmount);
            audioSource.Play();
            Destroy(gameObject, audioSource.clip.length); // ����� �ҽ��� �÷��̵� �ð��� �ص�, ������ Destory �޼��� ����
        }
    }
}
