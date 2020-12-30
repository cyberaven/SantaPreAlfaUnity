using UnityEngine;

public interface IHaveHealth : IGameObj
{
    void ChangeHealth(int value);
    void Die();
    int GetCurrentHealth();
    GameObject GetGameObject();
}