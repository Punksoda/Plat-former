using UnityEngine;

public class JumpObject : MonoBehaviour
{
    public PlayerController player;
    public float jumpF = 5f;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpF, ForceMode.Impulse); // ���� �� ��ŭ ���ؼ� ���������� �� ����
            audioSource.Play();
        }
        else
        {
            Debug.Log("�÷��̾�� ������ٵ� �Ҵ�Ǿ� ���� �ʽ��ϴ�!");
        }
    }
}
