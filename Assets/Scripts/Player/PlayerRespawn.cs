using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPosition; // ������ ���� ����

    private void Start()
    {
        respawnPosition = transform.position; // ���� ��ġ ����
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.CompareTag("Fallzone")) //fallzone �±׸� ������ respawn �Լ�����
        {
            Respawn();
        }
    }

    public void Respawn() // �÷��̾� ��ġ�� ó���������� ��ȯ���ִ� �Լ�
    {
        transform.position = respawnPosition;
    }
}
