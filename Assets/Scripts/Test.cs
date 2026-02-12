using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 enemypos = new Vector2(5,10);
        
        Vector2 playerpos = new Vector2(5,7);
        
        Vector2 enemyfacing = new Vector2(0,1);
        
        enemypos = Vector2.Normalize(enemypos);
        playerpos = Vector2.Normalize(playerpos);
        enemyfacing = Vector2.Normalize(enemyfacing);
        
        print(Vector2.Dot(playerpos-enemypos,enemyfacing));
        print(Vector2.Dot(enemypos-playerpos, enemyfacing));
        

    }

    
    
}
