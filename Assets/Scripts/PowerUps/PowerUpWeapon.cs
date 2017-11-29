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
            player.weapon = new WeaponStandard(() => { return Input.GetKeyDown(player.controller.fireKey); }, player.shootPoint, Constants.layerPlayer, 1f);
        }
        if (r > a && r <= b)
        {
            player.weapon = new WeaponSemiAuto(() => { return Input.GetKey(player.controller.fireKey); }, player.shootPoint, Constants.layerPlayer, 0.25f);
        }
        if (r > b && r <= c)
        {
            player.weapon = new WeaponSpread3x(() => { return Input.GetKeyDown(player.controller.fireKey); }, player.shootPoint, Constants.layerPlayer, 0.5f);

        } else if(r >=c)
        {
            player.weapon = new WeaponComplex(new WeaponSemiAuto(() => { return Input.GetKey(player.controller.fireKey); }, player.shootPoint, Constants.layerPlayer, 0.25f),
                                              new WeaponSpread3x(() => { return Input.GetKey(player.controller.fireKey); }, player.shootPoint, Constants.layerPlayer, 0.5f));
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
        } else if (c.gameObject.tag == "Wall")
            Destroy(gameObject);
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
