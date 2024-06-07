using UnityEngine;

public class UICondition : MonoBehaviour
{
    public Condition health;
    public Condition stamina;
    public Condition hungry;
    public Condition thirst;

    private void Start()
    {
        CharacterManager.Instance.Player.condition.uiCondition = this;
    }
}