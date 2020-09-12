using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    private WaitForSeconds waveWait;
	[SerializeField] private float spawnBreak = 0.01f;
    [SerializeField] private float waveBreak;
	[SerializeField] private GameObject waveDisplay;
	public GameObject enemyController;
	GameObject go;

	public List<WaveComponent> waveComps;
	void Start () {
		WaveComponent wc = waveComps[0];
		StartCoroutine(WaveRoutine());
        waveWait = new WaitForSeconds(waveBreak);

	}

	public void AddWave()
	{
		waveComps.Add(new WaveComponent());
	}
	public GameObject GetPreview()
	{
		return waveComps[0].enemyPrefab;
	}

	IEnumerator WaveRoutine(){
		yield return new WaitForSeconds(spawnBreak);
		foreach(WaveComponent wc in waveComps){
			waveDisplay.GetComponent<WaveDisplay>().InitNewWave();
			for (int i = 0; i < wc.numberOfMobs; i++){
				
				wc.spawned++;
				go = Instantiate(wc.enemyPrefab, this.transform.position, this.transform.rotation) as GameObject;
				go.name = go.name + ": " + i.ToString();
				//If enemyController is set, then set this enemy as child of enemyController, and register enemy
				if(enemyController != null)
				{
					go.transform.parent = enemyController.transform;
					enemyController.GetComponent<EnemyController>().RegisterEnemy(go);
				}	
				else{
					Debug.LogWarning("EnemyController is missing, spawned enemies is placed outside gameobject");	
				}
				yield return new WaitForSeconds(wc.SpawnCooldown);

			}
			
			yield return waveWait;
        }
        

    }

}
[System.Serializable]
public class WaveComponent
{
	public GameObject enemyPrefab;
	public int numberOfMobs = 25;
	public float SpawnCooldown = 2f;
	[System.NonSerialized]
	public int spawned = 0;
}
