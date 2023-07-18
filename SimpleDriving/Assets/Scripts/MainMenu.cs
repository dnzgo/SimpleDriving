using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text energyText;
    [SerializeField] private int maxEnergy;
    [SerializeField] private int energyRechargeDuration;
    [SerializeField] AndroidNotificationHandler androidNotificationHandler;

    private int energy;

    private const string energyKey = "Energy";
    private const string energyReadyKey = "EnergyReady";

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt(ScoreSystem.highScoreKey, 0);
        highScoreText.text = $"High Score: {highScore}";

        energy = PlayerPrefs.GetInt(energyKey, maxEnergy);

        

    }

    private void Update()
    {
        if (energy == 0)
        {
            string energyReadyString = PlayerPrefs.GetString(energyReadyKey, string.Empty);

            if (energyReadyString == string.Empty) { return; }

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if (DateTime.Now > energyReady)
            {
                energy = maxEnergy;

                PlayerPrefs.SetInt(energyKey, energy);
            }

        }
        energyText.text = $"Energy: {energy}";

    }

    public void Play()
    {
        if (energy < 1) { return; }

        energy--;
        PlayerPrefs.SetInt(energyKey, energy);

        if (energy == 0)
        {
            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(energyReadyKey, energyReady.ToString());
#if UNITY_ANDROID
            androidNotificationHandler.ScheduleNotification(energyReady);
#endif

        }

        SceneManager.LoadScene(1);

    }
}
