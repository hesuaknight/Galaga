using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
    public static List<GameObject > players = new List<GameObject>();
    public Transform currentTarget;
    private int timeChangeRandomTarget = 10;
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

    [HideInInspector]
    public Vector3 startRotation;
    private void Awake()
    {
        if(players.Count == 0)
        {
            var  pps = GameObject.FindGameObjectsWithTag("Player");
            players.AddRange(pps);
        }

        GameStatus.enemyAliveCount++;
        lifeController = new LifeController();
        lifeController.OnDeadCallBack += Die;
        startRotation = transform.eulerAngles;
        StartCoroutine(RandomTarget());
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
            //Debug.Log("Ship Mode : Attack");
        }
        if (iFormation != null)
        {
            iFormation.Action(this);
        }
        if (iFormation == new BackToGridPositionEnemy() && transform.position == cordGrid + GridFormationRoot.instance.transform.position)
        {
            iFormation = null;
        }

        if(transform.position.y < currentTarget.transform.position.y - 0.5f && iFormation != new BackToGridPositionEnemy())
        {
            iFormation = new BackToGridPositionEnemy();
            Debug.Log("Ship Mode : Back to grid position");
        }

    }

    
    IEnumerator RandomTarget()
    {
        while (true)
        {
            if (players.Count == 2)
            {
                currentTarget = players[Random.Range(0, 1)].transform;
            }
            else
            {
                currentTarget = players[0].transform;
            }
            yield return new WaitForSeconds(timeChangeRandomTarget);

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
        else if(c.transform.parent !=null && c.transform.parent.GetComponent<ShieldRoot>() != null)
        {
            c.gameObject.SetActive(false);
            Die();
        }
    }
}
