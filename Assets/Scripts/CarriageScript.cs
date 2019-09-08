using UnityEngine;

namespace Assets.Scripts
{
    public class CarriageScript : MonoBehaviour
    {
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                GameObject go = GameObject.Find("HeadCarriage");
                if(go!=null)
                    go.GetComponent<TestScriptTrain>().RemoveCarriage(gameObject);
            }
        }
    }
}
