using UnityEngine;

public class ClassExample : MonoBehaviour
{

    public class Player
    {
        public string Name;
        public int score;

        public Player(string name, int score)
        {
            Name = name;
            this.score = score;
        }
        public void ShowInfo()
        {
            Debug.Log("Player Name : " + Name);
            Debug.Log("Player Score : " + score);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player player = new Player("Hero", 67);
        player.ShowInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
