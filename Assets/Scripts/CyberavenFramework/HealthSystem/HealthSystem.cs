using System.Collections;
public class HealthSystem
{
    private readonly IHaveHealth obj;
    private int startHealth = 0;
    private int maxHealth = 0;
    private int minHealth = 0;
    private int currentHealth = 0;

    public HealthSystem(IHaveHealth obj, int startHealth = 3, int maxHealth = 3, int minHealth = 0)
    {
        this.obj = obj;
        this.startHealth = startHealth;
        this.maxHealth = maxHealth;
        this.minHealth = minHealth;
        currentHealth = startHealth;
    }

    public delegate void HealthChangeDel(IHaveHealth haveHealth);
    public static event HealthChangeDel HealthChangeEve;

    public void ChangeHealth(int value)
    {
        currentHealth += value;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth < minHealth)
        {
            obj.Die();
        }

        HealthChangeEve?.Invoke(obj);
    }
    public int GetHealth()
    {
        return currentHealth;
    }
}