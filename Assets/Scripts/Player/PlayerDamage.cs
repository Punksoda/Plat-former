using System.Collections;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public Renderer playerRenderer; // �÷��̾��� Renderer ������Ʈ
    public float flashSpeed = 1f;   // �����̴� �ӵ�
    public Color flashColor = Color.red; // ������ �� ����� ���� 

    private Material playerMaterial; // �÷��̾� ��Ƽ���� ����
    private Color originalColor;     // ���� ������ ����
    private Coroutine coroutine;    // �ڷ�ƾ ȣ��

    private void Start()
    {
        playerMaterial = playerRenderer.material; // �÷��̾� ���׸��� ��������
        originalColor = playerMaterial.color; // ���� ���� ����

        // ������ �̺�Ʈ�� Flash �޼��� ����
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash;
    }

    public void Flash()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine); // ���� �ڷ�ƾ ����
        }

        coroutine = StartCoroutine(FlashEffect());
    }

    private IEnumerator FlashEffect()
    {
        // ��Ƽ���� ������ �Ӱ� ����
        playerMaterial.color = flashColor;

        float elapsedTime = 0f;

        while (elapsedTime < flashSpeed)
        {
            elapsedTime += Time.deltaTime;
            playerMaterial.color = Color.Lerp(flashColor, originalColor, elapsedTime / flashSpeed); // lerp�� ����ؼ� ������ ������ õõ�� ���ƿ��� ��
            yield return null;
        }

        playerMaterial.color = originalColor; // ���� ������ ���ư�
    }
}
