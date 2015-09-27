using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject[] phaseObjects;
    public float[] phaseTimes;
    private float currentPhaseTimePassed;
    [SerializeField]
    private int activePhase;

    // Use this for initialization
    void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
        currentPhaseTimePassed += Time.deltaTime;
        if (currentPhaseTimePassed > phaseTimes [activePhase])
        {

            if (activePhase < phaseObjects.Length - 1)
            {
                phaseObjects [activePhase].SetActive(false);
                activePhase += 1;
                phaseObjects [activePhase].SetActive(true);
            }
            currentPhaseTimePassed = 0f;
        }
    }
}
