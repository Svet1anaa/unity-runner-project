using UnityEngine;

public class StartControll : MonoBehaviour
{
    public static int coinCount;
    public static AudioSource coinDingSound;
    public static AudioSource crashSound;

    [SerializeField] GameObject textBox;
    [SerializeField] AudioSource coinDing;   // перетащи сюда AudioSource монетки
    [SerializeField] AudioSource crashFX;    // перетащи сюда AudioSource краша
    [SerializeField] int internalCoinCount;

    void Awake()
    {
        coinCount = 0;
        coinDingSound = coinDing;
        crashSound = crashFX;
    }

    void Update()
    {
        internalCoinCount = coinCount;
        textBox.GetComponent<TMPro.TMP_Text>().text = "" + coinCount;
    }
}
