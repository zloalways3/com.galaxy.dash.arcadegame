using UnityEngine;

public class PointsTracker : MonoBehaviour
{ 
    private int points = 0;
    
    public void IncreaseScore(int amount)
    {
        points += amount;
    }
}
