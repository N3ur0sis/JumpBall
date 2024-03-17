


using UnityEngine;

public class CoinPickUp : MonoBehaviour
{
    public ParticleSystem DestroyEffect;
    private SpriteRenderer rdr;
    public GameObject floatingpoints;
    private AudioSource audio;

    private void Start()
    {
        rdr = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    [System.Obsolete]
    private void Update()
    {
        if (!DestroyEffect.gameObject.active)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (!DestroyEffect.isEmitting)
        {
            
            int CurrentCoin = PlayerPrefs.GetInt("Coin", 0);
            CurrentCoin++;
            PlayerPrefs.SetInt("Coin", CurrentCoin);
            DestroyEffect.Play();
            GameObject point = Instantiate(floatingpoints, transform.position, Quaternion.identity);
            point.transform.parent = gameObject.transform.parent;
            Destroy(point, 1);
            rdr.enabled = false;
            audio.Play();
        }
    }
}
