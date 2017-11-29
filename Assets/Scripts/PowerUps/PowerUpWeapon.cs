using UnityEngine;

public class PowerUpWeapon : MonoBehaviour, IPowerUp {

    public void OnTakePowerUP(Player player)
    {

        float r = Random.value;
        float a = 0.25f;
        float b = 0.50f;
        float c = 0.75f;
        if (r <= a)
        {
            player.weapon =  new WeaponStandard(KeyCode.Space, player.shootPoint, 1);
        }
        if (r > a && r <= b)
        {
            player.weapon = new WeaponSemiAuto(KeyCode.Space, player.shootPoint, 0.25f);
        }
        if (r > b && r <= c)
        {
            player.weapon = new WeaponSpread3x(KeyCode.Space, player.shootPoint, 0.5f);
        }
        else if(r >=c)
        {
            player.weapon = new WeaponComplex(new WeaponSemiAuto(KeyCode.Space, player.shootPoint, 0.3f), new WeaponSpread3x(KeyCode.Space, player.shootPoint, 0.8f));
        }

        Debug.Log("POWERUP -- Player weap : " + player.weapon);
        RemovePowerUp();
    }
    private void Update()
    {
        Displacement();
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag == "Player")
        {
            OnTakePowerUP(c.gameObject.GetComponent<Player>());
        }
    }

    private void RemovePowerUp()
    {
        Destroy(this.gameObject);
    }
    public void Displacement()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }
}
