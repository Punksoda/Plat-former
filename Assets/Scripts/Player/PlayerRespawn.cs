using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPosition; // 리스폰 지점 지정

    private void Start()
    {
        respawnPosition = transform.position; // 시작 위치 지정
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.collider.CompareTag("Fallzone")) //fallzone 태그를 만나면 respawn 함수실행
        {
            Respawn();
        }
    }

    public void Respawn() // 플레이어 위치를 처음지점으로 반환해주는 함수
    {
        transform.position = respawnPosition;
    }
}
