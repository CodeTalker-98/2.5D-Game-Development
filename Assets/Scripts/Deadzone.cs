using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deadzone : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 0.5f;
    [SerializeField] private GameObject _respawn;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            CharacterController cc = other.GetComponent<CharacterController>();

            if (cc != null)
            {
                cc.enabled = false;
            }

            other.transform.position = _respawn.transform.position;
            StartCoroutine(CCDelay(cc, _spawnTime));
        }
    }

    IEnumerator CCDelay(CharacterController controller, float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        controller.enabled = true;
    }
}
