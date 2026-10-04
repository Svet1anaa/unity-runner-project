using UnityEngine;

public class CollisionReset : MonoBehaviour
{
    [SerializeField] float gameOverDelay = 1.2f;

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.FindWithTag("Player");
        Camera mainCam = Camera.main;

        if (mainCam != null)
            mainCam.GetComponent<FollowCamera>().enabled = false;

        if (player != null)
        {
            player.GetComponent<Player>().enabled = false;
            Animator anim = player.GetComponentInChildren<Animator>();
            
            if (anim != null)
                anim.Play("Falling Back Death");
        }

        StartControll.crashSound.Play();

        Invoke(nameof(TriggerGameOver), gameOverDelay);
    }

    void TriggerGameOver()
    {
        GameManager.Instance.GameOver(StartControll.coinCount);
    }
}