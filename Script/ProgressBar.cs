using Script;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Scrollbar progress;
    public PlayerMovement player;
    public GameManager total;
    public Text Scoretext1;
    void Update()
    {
        float pbar = player.score/(float)total.totalScore ;
        // progress.value = pbar;
        progress.size = pbar;
        Scoretext1.text=(player.score).ToString();
    }
}
