using UnityEngine;

public class Bullet : MonoBehaviour, IPoolObject {

    public float speed;
    public int dmg = 1;

    Vector3 movement;

    private void Awake() {
        gameObject.SetActive(false);
        movement = new Vector3();
    }

	void Update () {
        movement = transform.position + transform.forward * speed * Time.deltaTime;
        movement.z = 0;
        transform.position = movement;
	}
    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.GetComponent<Enemy>())
        {
            c.transform.GetComponent<Enemy>().lifeController.TakeDamage(dmg);
        }
        else if (c.transform.GetComponent<IPowerUp>()!= null)
        {
            Destroy(c.gameObject);
        }
        Weapon.poolObject.Release(this);
    }

    public void OnAdquiere() {
        gameObject.SetActive(true);
    }

    public void OnRelease() {
        gameObject.SetActive(false);
    }
}
