using UnityEngine;
using System.Collections.Generic;
using Joint = Windows.Kinect.Joint;
using Windows.Kinect;
using UnityEngine.SceneManagement;

public class BodySourceViewELast : MonoBehaviour
{
    public BodySourceManager bodySourceManager;
    public GameObject JointObject;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    public GameObject wash;

    public cardEasy[] card;
    public cardEasyPick[] card1;



    private List<JointType> joints = new List<JointType> {
    JointType.HandLeft,
    JointType.HandRight,
    };


    public GameObject[] obj;

    public static bool a;
    public static bool b;
    public static bool c;
    public static bool d;
    public static bool e;
    public static bool f;

    public static bool one;

    public static int state;

    private void Start()
    {
        a = false;
        b = false;
        c = false;
        d = false;
        e = false;
        f = false;
        one = false;
    }


    private void Update()
    {
        handMouse();


        Body[] data = bodySourceManager.GetData();
        if (data == null)
            return;

        List<ulong> trackedIds = new List<ulong>();

        foreach (var body in data)
        {
            if (body == null)
                continue;

            if (body.IsTracked)
            {
                trackedIds.Add(body.TrackingId);
            }
        }

        List<ulong> knownIds = new List<ulong>(mBodies.Keys);

        foreach (ulong trackingId in knownIds)
        {
            if (!trackedIds.Contains(trackingId))
            {
                Destroy(mBodies[trackingId]);
                mBodies.Remove(trackingId);
            }
        }

        foreach (var body in data)
        {
            if (body == null)
                continue;

            if (body.IsTracked)
            {
                if (!mBodies.ContainsKey(body.TrackingId))
                {
                    mBodies[body.TrackingId] = CreateBodyObject(body.TrackingId);
                }

                UpdateBodyObject(body, mBodies[body.TrackingId]);
            }
        }

    }

    private GameObject CreateBodyObject(ulong id)
    {

        GameObject body = new GameObject("Body:" + id);
        body.transform.localScale = new Vector3(1, 1f, 1);
        body.transform.localPosition = new Vector3(0, 0, 0);

        foreach (JointType joint in joints)
        {
            GameObject newJoint = Instantiate(JointObject);
            newJoint.name = joint.ToString();
            newJoint.transform.parent = body.transform;
        }

        if (body.transform.GetChild(0).gameObject.name == "HandLeft") { body.transform.GetChild(0).gameObject.SetActive(false); }
        if (body.transform.GetChild(1).gameObject.name == "HandLeft") { body.transform.GetChild(1).gameObject.SetActive(false); }

        return body;
    }

    private void UpdateBodyObject(Body body, GameObject bodyObject)
    {
        foreach (JointType joint in joints)
        {
            Joint sourceJoint = body.Joints[joint];
            Vector3 targetPosition = GetVector3FromJoint(sourceJoint);

            Transform jointObject = bodyObject.transform.Find(joint.ToString());
            jointObject.position = targetPosition;
        }
    }

    private Vector3 GetVector3FromJoint(Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, 0);
    }

    void handMouse()
    {
        try
        {
            if (GameObject.Find("HandRight").transform.position.y >= 0.6 && GameObject.Find("HandRight").transform.position.y <= 2.82)
            {
                if (GameObject.Find("HandRight").transform.position.x <= 0.3 && GameObject.Find("HandRight").transform.position.x >= -1.37)
                {
                    card[0].OnMouseDown();
                }
                if (GameObject.Find("HandRight").transform.position.x >= 2.26 && GameObject.Find("HandRight").transform.position.x <= 3.95)
                {

                    card[1].OnMouseDown();
                }
                if (GameObject.Find("HandRight").transform.position.x >= 5.85 && GameObject.Find("HandRight").transform.position.x <= 7.55)
                {

                    card[2].OnMouseDown();
                }
            }

            else if (GameObject.Find("HandRight").transform.position.y <= -0.51 && GameObject.Find("HandRight").transform.position.y >= -2.82)
            {
                if (GameObject.Find("HandRight").transform.position.x <= 0.3 && GameObject.Find("HandRight").transform.position.x >= -1.37)
                {

                    card[3].OnMouseDown();

                }
                if (GameObject.Find("HandRight").transform.position.x >= 2.26 && GameObject.Find("HandRight").transform.position.x <= 3.95)
                {
                    card[4].OnMouseDown();
                  
                  


                }
                if (GameObject.Find("HandRight").transform.position.x >= 5.85 && GameObject.Find("HandRight").transform.position.x <= 7.55)
                {
                    card[5].OnMouseDown();


                }
            }


            if (cardEasy.pairsFound == 3 )
            {
               
                  
                    obj[0].gameObject.SetActive(true);
                    obj[1].gameObject.SetActive(false);
                
            }

            if (cardEasy.pairsFound == 3&&GameObject.Find("HandRight").transform.position.y >= -1.03 && GameObject.Find("HandRight").transform.position.y <= 0.7)
            {
                if (GameObject.Find("HandRight").transform.position.x >= -1.42 && GameObject.Find("HandRight").transform.position.x <= -0.3)
                {
                    state = 2;
                    card1[0].pick();
                }
                if (GameObject.Find("HandRight").transform.position.x >= 1.92 && GameObject.Find("HandRight").transform.position.x <= 3.05)
                {
                    state = 2;
                    card1[1].pick();
                }
                if (GameObject.Find("HandRight").transform.position.x >= 5.2 && GameObject.Find("HandRight").transform.position.x <= 6.3)
                {
                    state = 1;
                    card1[2].pick();
                }
            }

            if (state == 1)
            {

                Invoke("wait", 2);
                
            }
            else { }
        }
        catch { }


    }


    void wait()
    {
        SceneManager.LoadScene("1.Normal");
    }

}

