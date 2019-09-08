using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class TestScriptTrain : MonoBehaviour
{
    public GameObject Train;
    public GameObject CarriageFirstPrefab;
    public GameObject CarriagePrefab;
    public int CarriageCount;
    public float RotationSpeed;
    public float TrainSpeed;
    public float TrainSpeedFast;
    public float HeadSpeed;

    private AudioSource audioSource;

    private Rigidbody rgbdHead;

    private List<GameObject> listOfCarriages = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        Train = GameObject.Find("Train");
        Restart();
        audioSource = GetComponent<AudioSource>();
    }
    public void Restart()
    {
        listOfCarriages.Add(gameObject);

        for (int i = 0; i < CarriageCount; i++)
        {
            AddCarriage();
        }

        rgbdHead = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(Input.GetAxis("GamepadRight")+" : "+ Input.GetAxis("Horizontal"));

        if(tag=="NotAlive")
            return;

        if(Vector3.Angle(-transform.up,Vector3.down)>60)
            StartCoroutine("Dead");

        float speed = TrainSpeed;

        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.Joystick1Button5))
            speed = TrainSpeedFast;

        for (int i = 0; i < listOfCarriages.Count; i++)
        {
            
            listOfCarriages[i].GetComponent<Rigidbody>().velocity = Vector3.forward * -speed;
        }

        float x = Input.GetAxis("Horizontal");
        float x2 = Input.GetAxis("GamepadRight");

        if (x != 0)
        {
            listOfCarriages.First().GetComponent<Rigidbody>().velocity += Vector3.right * RotationSpeed * -x;
        }
        else
        {

            if (Input.GetKey(KeyCode.A))
            {
                listOfCarriages.First().GetComponent<Rigidbody>().velocity += Vector3.right * RotationSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                listOfCarriages.First().GetComponent<Rigidbody>().velocity += -Vector3.right * RotationSpeed;
            }
        }

        if (x2 != 0)
        {
            listOfCarriages.Last().GetComponent<Rigidbody>().velocity += Vector3.right * RotationSpeed * -x2;
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                listOfCarriages.Last().GetComponent<Rigidbody>().velocity += Vector3.right * RotationSpeed ;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                listOfCarriages.Last().GetComponent<Rigidbody>().velocity += -Vector3.right * RotationSpeed;
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            for (int i = 0; i < listOfCarriages.Count; i++)
            {
                //float offet = listOfCarriages.First().transform.position.x -
                //              listOfCarriages[i].transform.position.x;
                float temp = Mathf.Lerp(listOfCarriages[i].transform.position.z,
                    listOfCarriages.First().transform.position.z, 0.25f);
                listOfCarriages[i].GetComponent<Rigidbody>().velocity += new Vector3(0,0, temp);
            }
            
        }
        //    rgbdHead.velocity += transform.right * -HeadSpeed + Vector3.down;

        //float max = 1;
        //Vector3 newVelocityHead = Vector3.zero;

        //newVelocityHead += transform.right * -HeadSpeed + Vector3.down;


        //for (int i = 0; i < listOfCarriages.Count; i++)
        //{
        //    listOfCarriages[i].GetComponent<Rigidbody>().AddForce(Vector3.right * -TrainSpeed);
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    //rgbdHead.AddForceAtPosition(-transform.forward * RotationSpeed,transform.position + new Vector3(0,0, -0.4f));
        //    for (int i = 0; i < listOfCarriages.Count; i++)
        //    {
        //        listOfCarriages[i].GetComponent<Rigidbody>().AddForce(Vector3.forward * RotationSpeed / (1 + i));

        //    }
        //   // rgbdHead.AddForce(-transform.forward * RotationSpeed );

        //    //   newVelocityHead += -transform.forward * RotationSpeed;
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    for (int i = 0; i < listOfCarriages.Count; i++)
        //    {
        //        listOfCarriages[i].GetComponent<Rigidbody>().AddForce(-Vector3.forward * RotationSpeed / (1+i));

        //    }
        //    //newVelocityHead += transform.forward * RotationSpeed;
        //    //rgbdHead.AddForceAtPosition(transform.forward * RotationSpeed, transform.position + new Vector3(0, 0, 0.4f));
        // //   rgbdHead.AddForce(transform.forward * RotationSpeed);
        //}

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    //rgbdHead.AddForceAtPosition(-transform.forward * RotationSpeed,transform.position + new Vector3(0,0, -0.4f));
        //    listOfCarriages.Last().GetComponent<Rigidbody>().AddForce(-transform.forward * RotationSpeed / 6);

        //    //   newVelocityHead += -transform.forward * RotationSpeed;
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    //newVelocityHead += transform.forward * RotationSpeed;
        //    //rgbdHead.AddForceAtPosition(transform.forward * RotationSpeed, transform.position + new Vector3(0, 0, 0.4f));
        //    listOfCarriages.Last().GetComponent<Rigidbody>().AddForce(transform.forward * RotationSpeed / 6);
        //}

        //if(!drift)
        //rgbdHead.velocity =  new Vector3(newVelocityHead.x, 0, newVelocityHead.z);

        //else
        //{
        //    //for (int i = 0; i < listOfCarriages.Count; i++)
        //    //{
        //    //    listOfCarriages[i].GetComponent<Rigidbody>().velocity = -Vector3.forward * TrainSpeed;
        //    //}
        //    listOfCarriages.First().GetComponent<Rigidbody>().velocity = -Vector3.forward * TrainSpeed;

        //    listOfCarriages.Last().GetComponent<Rigidbody>().velocity = -Vector3.forward * TrainSpeed;
        //}

        float angle = Vector3.Angle(transform.right, Vector3.forward);

        //Debug.Log(angle);
        if (angle < 90)
        {
            for (int i = 0; i < listOfCarriages.Count; i++)
            {
                listOfCarriages[i].GetComponent<Rigidbody>().AddForce(Vector3.forward * TrainSpeed * Mathf.Cos(angle * Mathf.Rad2Deg));   
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (tag == "NotAlive")
            return;
        if (collision.gameObject.tag == "Obstacle")
        {
            StartCoroutine("Dead");
        }
    }

    IEnumerator Dead()
    {


        tag = "NotAlive";
        for (int i = listOfCarriages.Count - 1; i >= 0; i--)
        {
            Destroy(listOfCarriages[i].GetComponent<HingeJoint>());

        }
        audioSource.Play();

        yield return new WaitForSeconds(3f);
        GameObject.Find("Text").GetComponent<Score>().Reset();

        var temp = new List<GameObject>(GameObject.FindGameObjectsWithTag("Wagon"));
        temp.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("NotAlive")));



        for (int i = 0; i < temp.Count; i++)
        {
            Destroy(temp[i]);
        }

        GameObject.Find("TRAINGENERATOR").GetComponent<Test>().Generate();

    }
    public void AddCarriage()
    {
        Vector3 offset;
        if(listOfCarriages.Count==1)
            offset = new Vector3(0,0,5f);
        else if (listOfCarriages.Count == 2) offset = new Vector3(0, 0, 5.5f);
        else offset = new Vector3(0, 0, 7f);

        var newCarriage =
            Instantiate(listOfCarriages.Count == 1? CarriageFirstPrefab:CarriagePrefab, listOfCarriages.Last().transform.position +
           offset, Quaternion.identity, Train.transform);

        Vector3 AnchorOffset;
        if (listOfCarriages.Count == 1)
            AnchorOffset = new Vector3(5.81f, -1.33f, 0);
        else if (listOfCarriages.Count == 2) AnchorOffset = new Vector3(0, -0.25f, 4.29f);
        else AnchorOffset = new Vector3(0, -0.25f, 6.78f);

        listOfCarriages.Add(newCarriage);

        HingeJoint hingeJoint = listOfCarriages[listOfCarriages.Count - 2].AddComponent<HingeJoint>();
        hingeJoint.anchor = AnchorOffset;
        hingeJoint.connectedBody = listOfCarriages.Last().GetComponent<Rigidbody>();
        hingeJoint.enableCollision = true;
        hingeJoint.useLimits = true;
        JointLimits limits = hingeJoint.limits;
        limits.min = -15;
        limits.bounciness = 0;
        limits.bounceMinVelocity = 0;
        limits.max = 15;
        hingeJoint.limits = limits;
        hingeJoint.axis = new Vector3(0,1,0);
    }

    public void RemoveCarriage(GameObject carriage)
    {
        for (int i = listOfCarriages.IndexOf(carriage); i < listOfCarriages.Count; i++)
        {
            Destroy(listOfCarriages[i-1].GetComponent<HingeJoint>());
        }       
        listOfCarriages.RemoveRange(listOfCarriages.IndexOf(carriage), listOfCarriages.Count - listOfCarriages.IndexOf(carriage));
    }
    
}
