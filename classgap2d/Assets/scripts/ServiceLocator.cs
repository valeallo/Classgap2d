using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServiceLocator 
{
    private static GameManager GM;
    public static void SetGameManager(GameManager gm) { GM = gm; }
    public static GameManager GetGameManager() { return GM; }
  
}



