using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }

    private void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);
    }
}
