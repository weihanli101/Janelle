using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour {
	public GameObject appleGameObject;
    public GameObject bananaGameObject;
    public GameObject pineappleGameObject;
    public GameObject grapeGameObject;

    private int randNumFloorPos;
    private int randFruit;
    private float randNumX;
    private float randNumY;
    private Vector3 spawnPos;
    private GameObject dropClone;


	void Start () {
		StartCoroutine(SpawnCollectables());
	}
	
	void Update () {

	}

	IEnumerator SpawnCollectables() {
		while (Time.realtimeSinceStartup < 100) {
            randFruit = Random.Range(0,4);
            switch (randFruit){
                //spawn apple
                case 0:
                    dropClone = Instantiate(appleGameObject, getRandDropFloorPos(), Quaternion.identity);
                    Destroy(dropClone, 5f);
                    break;
                //spawn banana
                case 1:
                    dropClone = Instantiate(bananaGameObject, getRandDropFloorPos(), Quaternion.identity);
                    Destroy(dropClone, 5f);
                    break;
                //spawn pineapple
                case 2:
                    dropClone = Instantiate(pineappleGameObject, getRandDropFloorPos(), Quaternion.identity);
                    Destroy(dropClone, 5f);
                    break;
                //spawn grape
                default:
                    dropClone = Instantiate(grapeGameObject, getRandDropFloorPos(), Quaternion.identity);
                    Destroy(dropClone, 5f);
                    break;
            }

			yield return new WaitForSeconds (0.5f);
		}		
	}

    private Vector3 getRandDropFloorPos(){
        randNumFloorPos = Random.Range(0,4);
        randNumX = Random.Range(-3.57f, 3.43f);

        switch(randNumFloorPos){
            //spawn top floor
            case 0:
                randNumY = 2.01f;
                break;
            case 1:
                randNumY = -0.48f;
                break;
            case 2:
                randNumY = -3.27f;
                break;
            //spawn basement
            default:
                randNumY = -6.64f;
                break;
        }

        spawnPos = new Vector3(randNumX, randNumY, 0f);
        return spawnPos;
    }
}
