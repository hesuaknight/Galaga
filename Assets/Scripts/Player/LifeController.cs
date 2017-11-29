using UnityEngine;

public class LifeController {

    public delegate void OnDead();
    public event OnDead OnDeadCallBack;
    public int maxLife = 3;
    public int currentLife;

    public void TakeDamage(int dmg) {
        if (currentLife - dmg <= 0) {
            currentLife = 0;
            OnDeadCallBack.Invoke();
            Debug.Log("Dead");
        } else {
            currentLife -= dmg;
            Debug.Log("Take damaged :" + currentLife);

        }
    }

    public void RestoreLife() {
        currentLife = maxLife;
    }
}
