using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompletionScreen : MonoBehaviour
{
    public GameObject completionPanel; // Panelis, kas tiek rādīts pēc spēles pabeigšanas
    public Image[] stars;              // Zvaigžņu attēli, kas tiek parādīti atkarībā no izpildes laika
    public Text timeText;              // Teksts, kurā parādīts spēles izpildes laiks
    public TimerDisplay timer;         // Atsauce uz taimera skriptu (ja nepieciešams izmantot citur)
    public Button playAgainButton;     // Poga, lai spēlētu vēlreiz

    void Start()
    {
        // Kad sākas skripts, pievieno funkciju RestartGame pogas notikumam
        playAgainButton.onClick.AddListener(RestartGame);
    }

    // Funkcija, kas tiek izsaukta, kad spēle ir pabeigta
    public void ShowCompletion(float finalTime)
    {
        // Aktivizē spēles pabeigšanas paneli
        completionPanel.SetActive(true);

        // Aprēķina stundas, minūtes un sekundes no kopējā laika
        int hours = (int)(finalTime / 3600);
        int minutes = (int)((finalTime % 3600) / 60);
        int seconds = (int)(finalTime % 60);

        // Iestata un attēlo izpildes laiku teksta laukā
        timeText.text = $"Time: {hours:00}:{minutes:00}:{seconds:00}";

        // Nosaka zvaigžņu skaitu atkarībā no izpildes laika
        int starCount = 1;
        if (finalTime <= 45f) starCount = 3;
        else if (finalTime <= 70f) starCount = 2;

        // Parāda tikai atbilstošo zvaigžņu skaitu
        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = i < starCount;
        }
    }

    // Funkcija, lai restartētu spēli
    void RestartGame()
    {
        // Ielādē pašreizējo ainu (restartē līmeni)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
