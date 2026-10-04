using System.Collections;
using UnityEngine;

public class CoinWork : MonoBehaviour
{
    [SerializeField] bool collectedCoin;

    void Update()
    {
        transform.Rotate(0, 2, 0, Space.World);
        if (collectedCoin == true)
            transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        collectedCoin = true;
        StartControll.coinCount += 1;
        StartControll.coinDingSound.Play();
        this.gameObject.GetComponent<Animator>().Play("Shrink");
        StartCoroutine(DeleteCoin());
    }

    IEnumerator DeleteCoin()
    {
        yield return new WaitForSeconds(0.5f);
        this.gameObject.SetActive(false);
    }
}