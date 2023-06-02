using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class fondu : MonoBehaviour
{
    public string sceneName; // Le nom de la sc�ne � charger
    public float fadeDuration = 1f; // La dur�e du fondu en secondes
    [SerializeField] Image fadeImage; // L'image utilis�e pour le fondu (assure-toi qu'elle remplit l'�cran)

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ChangeSceneWithFade());
            Debug.Log("contact");
        }
    }

    private IEnumerator ChangeSceneWithFade()
    {
        // Affichage du fondu en fondu
        fadeImage.color = Color.clear;
        float timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = Color.black;

        // Chargement de la nouvelle sc�ne
        SceneManager.LoadScene(sceneName);

        // Fondu en fondu de la nouvelle sc�ne
        timer = 0f;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        fadeImage.color = Color.clear;
    }
}