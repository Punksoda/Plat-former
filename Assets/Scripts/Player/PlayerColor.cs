using System.Collections;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    public Renderer playerRenderer; // �÷��̾��� Renderer ������Ʈ
    public float flashSpeed = 1f;   // �����̴� �ӵ�
 
    private Material playerMaterial; // �÷��̾� ��Ƽ���� ����
    private Color originalColor;     // ���� ������ ����
    private Coroutine coroutine;    // �ڷ�ƾ ȣ��

    

    private void Start()
    {
        playerMaterial = playerRenderer.material; // �÷��̾� ���׸��� ��������
        originalColor = playerMaterial.color; // ���� ���� ����


        // ������ �̺�Ʈ�� Flash �޼��� ����
        CharacterManager.Instance.Player.condition.onTakeDamage += FlashRed;
        CharacterManager.Instance.Player.condition.onHeal += FlashGreen;
    }

    public void Flash(Color flashColor)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine); // ���� �ڷ�ƾ ����
        }

        coroutine = StartCoroutine(ColorEffect(flashColor));
    }

    private void FlashRed()
    {
        Flash(Color.red);  
    }

    private void FlashGreen()
    {
        Flash(Color.green);
    }


    private IEnumerator ColorEffect(Color flashColor)
    { 
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
