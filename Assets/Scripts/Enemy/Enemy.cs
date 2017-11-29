using UnityEngine;

public class Enemy : MonoBehaviour {
    public static Transform player;

    //Comportamiento
    public IFormationComponent iFormation;
    //vida
    public LifeController lifeController;
    //movimiento
    [Header("Movement")]
    public float speedDisplacement;
    public Vector3 cordGrid;

    [Header("Attack")]
    public EnemyWeapon weapon;
    public float chanceAttack;
    public int Damage = 1;

    [Header("Drop")]
    public float chanceDrop;
    private void Awake()
    {
        if(!player)
            player = GameObject.Find("Player").transform;
        GameStatus.enemyAliveCount++;
        lifeController = new LifeController();
        lifeController.OnDeadCallBack += Die;
    }

    void GetRandomPowerUp()
    {
        float chance = Random.value;
        if (chance <= chanceDrop)
        {
           int r = Random.Range(0, GameManager.instance.powerUps.Length);
           GameObject powerUpGo = Instantiate(GameManager.instance.powerUps[r], transform.position, Quaternion.identity);
        }
    }
    public void Die()
    {
        GetRandomPowerUp();
        GameStatus.enemyAliveCount--;
        Destroy(gameObject);
    }

    public void Logic()
    {
        if (Random.value <= chanceAttack)
        {
            iFormation = new EnemyAttack();
            Debug.Log("Ship Mode : Attack");
        }
        if (iFormation != null)
        {
            iFormation.Action(this);
        }
        if (iFormation == new BackToGridPositionEnemy() && transform.position == cordGrid + GridFormationRoot.instance.transform.position)
        {
            iFormation = null;
        }
        if(transform.position.y < player.transform.position.y - 1f && iFormation != new BackToGridPositionEnemy())
        {
            iFormation = new BackToGridPositionEnemy();
            Debug.Log("Ship Mode : Back to grid position");
        }

    }

    void Update ()
    {
        Logic();

    }
    private void OnTriggerEnter(Collider c)
    {
        if (c.transform.tag =="Player")
        {
            c.GetComponent<Player>().lifeController.TakeDamage(Damage);
        }
    }
}
