using System;
using UnityEngine;

public interface IDamagable
{
    void TakePhysicalDamage(int damageAmount);
}

public class PlayerCondition : MonoBehaviour , IDamagable
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }
    Condition hungry { get { return uiCondition.hungry; } }
    Condition thirst { get { return uiCondition.thirst; } }
    

    public float noHungryHealthDecay;
    public float noHungryStaminaDecay;
    public float noThirstStaminaDecay;
    public event Action onTakeDamage;

    private void Update()
    {
        hungry.Subtract(hungry.passiveValue * Time.deltaTime);
        thirst.Subtract(thirst.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hungry.curValue == 0.0f)
        {
            health.Subtract(noHungryHealthDecay * Time.deltaTime);
            stamina.Subtract(noHungryStaminaDecay * Time.deltaTime);
        }
        else
        {
            stamina.Add(stamina.curValue * Time.deltaTime * 100f);
        }

        if (thirst.curValue == 0.0f)
        {
            stamina.Subtract(noThirstStaminaDecay * Time.deltaTime);
        }
        else
        {
            stamina.Add(stamina.curValue * Time.deltaTime);
        }

        if (health.curValue == 0.0f)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hungry.Add(amount);
    }

    public void Drink(float amount)
    {
        thirst.Add(amount);   
    }

    public void Die()
    {
        // »ç¸Á ÄûÁî ÆÐ³Î ¿ÀÇÂ
    }

    public void TakePhysicalDamage(int damageAmount)
    {
        health.Subtract(damageAmount);
        onTakeDamage?.Invoke();
    }
    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0)
        {
            return false;
        }
        stamina.Subtract(amount);
        return true;
    }
}