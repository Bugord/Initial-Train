using UnityEngine;

namespace Assets
{
    public class TrainController : MonoBehaviour
    {

        public GameObject Train;
        public GameObject TrainPrefab;
        public Vector3 StartPosition;
        public GameObject Map;

        public void Restart()
        {
            if(Train!=null)
                Destroy(Train);


            Train = Instantiate(TrainPrefab, StartPosition, Quaternion.identity);
            Train.GetComponent<TestScriptTrain>().Restart(); 
            while (Map.transform.childCount!=0)
            {
                Destroy(Map.transform.GetChild(0));
            }
            Map.GetComponent<GenerationScript>().currentZ = 0;
            Map.GetComponent<GenerationScript>().listOfMapParts.Clear();
        }

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }
    }
}
