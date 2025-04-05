using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 5;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject enemySpaner;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUi;

    [SerializeField] private GameObject red;

    [SerializeField] private CinemachineCamera cam;
    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);

        cam.Lens.OrthographicSize = 5f;
        red.SetActive(false);
    }

    void Update()
    {
        
    }
    public void AddEnergy()
    {
        if(bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        UpdateEnergyBar();
        if(currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }
    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        enemySpaner.SetActive(false);
        gameUi.SetActive(false);
        
        cam.Lens.OrthographicSize = 10f;
        red.SetActive(true);
    }
    private void UpdateEnergyBar()
    {
        if(energyBar != null)
        {
            float fillAmount=Mathf.Clamp01((float)currentEnergy/(float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
}
