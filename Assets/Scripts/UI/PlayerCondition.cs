using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition special { get { return uiCondition.special; } }
    private void Update()
    {
        health.Add(health.passiveValue * Time.deltaTime);
    }
}
