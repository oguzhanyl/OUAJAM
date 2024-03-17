using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectKeyandRescue : MonoBehaviour
{
    private int keyCount = 0;

    [SerializeField]TextMeshProUGUI keyCountText;

    [SerializeField] GameObject infoPanel;
    [SerializeField]TextMeshProUGUI infoText;
    [SerializeField]Image animalImage;

    public Sprite[] animalImages;
    [TextArea]public string[] infoAnimal;

    GameObject cage;
    S_Cage scriptCage;
    [SerializeField] TextMeshProUGUI animalRescued;
    [SerializeField] Canvas mainCanvas;
    private GameObject pressRPanel;

    [SerializeField] AudioClip keyCollectSound, rescueSound;
    [SerializeField] AudioSource auSource1;
    private AudioSource auSource;
    private void Start()
    {
        auSource = gameObject.GetComponent<AudioSource>();
        infoPanel.SetActive(false);
    }
    private void Update()
    {
        keyCountText.SetText(""+keyCount);
        if (Input.GetKey(KeyCode.R) && cage != null)
        {
            Time.timeScale = 0;
            scriptCage = cage.GetComponent<S_Cage>();
            infoPanel.SetActive(true);
            int whichAnim = scriptCage.whichAnimal;
            animalImage.sprite = animalImages[whichAnim];
            infoText.SetText(infoAnimal[whichAnim]);
        }
    }

    public void AdoptAnimalButton()
    {
        Time.timeScale = 1;
        if (keyCount <= 0)
        {
            return;
        }
        keyCount--;
        infoPanel.SetActive(false);
        Instantiate(animalRescued, mainCanvas.transform);
        auSource1.PlayOneShot(rescueSound);
        Destroy(cage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            auSource.PlayOneShot(keyCollectSound);
            keyCount++;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RescueAnimal"))
        {
            cage = collision.gameObject;
            pressRPanel = cage.GetComponent<S_Cage>().pressR_Panel;
            pressRPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RescueAnimal"))
        {
            pressRPanel.SetActive(false);
            cage = null;
        }
    }
}
