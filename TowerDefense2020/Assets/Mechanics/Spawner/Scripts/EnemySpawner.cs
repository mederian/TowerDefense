using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {


	public float spawnBreak = 0.01f;
	public GameObject enemyController;
	GameObject go;




	public List<WaveComponent> waveComps;
	// Use this for initialization
	void Start () {

		//Loop every component:
		WaveComponent wc = waveComps[0];
		StartCoroutine(WaveRoutine());
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
			for(int i = 0; i < wc.num; i++){
				
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
				yield return new WaitForSeconds(wc.spawnCD);

			}
		}

	}

}
[System.Serializable]
public class WaveComponent
{
	public GameObject enemyPrefab;
	public int num = 25;
	public float spawnCD = 2f;
	[System.NonSerialized]
	public int spawned = 0;
}
