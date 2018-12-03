using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour {

    public static BossManager instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject particles;
    public Transform spawnTransform;

    public GameObject boss;

    public void Die()
    {
        Destroy(boss);
        Instantiate(particles, spawnTransform.position, spawnTransform.rotation);
        StartCoroutine(Wait());

    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.EndLevel();
    }


}
