using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class collisionSystem : MonoBehaviour
{
    soundSystem ss;
    GameManager gm;

    void Start()
    {
        ss = gameObject.GetComponent<soundSystem>();
        gm = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Grass")
        {
            Debug.Log("Grass");
            Destroy(other.gameObject);
            gm.incScore();
            ss.playPick();
            //sound

        }
        else if (other.tag == "Obstacle")
        {
            Debug.Log("Obstacle");
            gm.damage();
            ss.playDamage();
        }
    }

    public ContactPoint2D[] contacts = new ContactPoint2D[10];

    //public GameObject particles;
    //public AudioSource explodeAndHitNoise;

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Hit! " + collision.gameObject.name);
    //    if (collision.gameObject.name == "Tilemap_grass")
    //    {
    //        int contactCount = collision.contactCount;
    //        if (contactCount > contacts.Length)
    //        {
    //            contacts = new ContactPoint2D[contactCount];
    //        }
    //        collision.GetContacts(contacts);

    //        UnityEngine.Vector3 hitPosition = UnityEngine.Vector3.zero;
    //        for (int i = 0; i != contactCount; ++i)
    //        {
    //            hitPosition.x = contacts[i].point.x;
    //            hitPosition.y = contacts[i].point.y;
    //            collision.gameObject.GetComponent<Tilemap>().SetTile(collision.gameObject.GetComponent<Tilemap>().WorldToCell(hitPosition), null);
    //            //var newParticles = Instantiate(particles, hitPosition, UnityEngine.Quaternion.identity);
    //            //var newSoundEffect = Instantiate(explodeAndHitNoise, this.transform.position, this.transform.rotation);
    //           // StartCoroutine(DestroyParticles(newParticles));
    //        }
    //    }
    //}






    public IEnumerator DestroyParticles(GameObject particles)
    {
        yield return new WaitForSeconds(3f);
        Destroy(particles);
    }
}
