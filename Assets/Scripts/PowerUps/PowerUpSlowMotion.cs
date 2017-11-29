using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlowMotion : MonoBehaviour, IPowerUp {
    public float slowPorcent;
    public float timeDurationEffect;
    private Image slowImage;
    private bool pickUp;
    public void OnTakePowerUP(Player player)
    {
        slowImage = GameObject.Find("SlowMotionImage").GetComponent<Image>();
        slowImage.GetComponentInParent<Image>().enabled = true;
        StartCoroutine(SlowMotion());
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
        t = timeDurationEffect;
        slowImage.fillAmount = 1;
        pickUp = true;
    }
    IEnumerator SlowMotion()
    {
        float corretTimeDelta = Time.timeScale;
        Time.timeScale = slowPorcent;
        yield return new WaitForSeconds(timeDurationEffect);
        Time.timeScale = corretTimeDelta;
        RemovePowerUp();
    }
    private float t;
    void ImageTiled()
    {
        if (pickUp)
        {
            slowImage.fillAmount -= 1.0f / timeDurationEffect * Time.deltaTime;
        }

    }
    private void Update()
    {
        Displacement();
        ImageTiled();
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
        slowImage.GetComponentInParent<Image>().enabled = false;

        Destroy(this.gameObject);
    }
    public void Displacement()
    {
        transform.position += Vector3.down * Time.deltaTime;

    }
}
