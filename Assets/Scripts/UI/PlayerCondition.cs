using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }

    private void Update()
    {
        health.Decrease(health.passiveValue * Time.deltaTime);
    }
}
