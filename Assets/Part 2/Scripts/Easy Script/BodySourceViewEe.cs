using UnityEngine;
using System.Collections.Generic;
using Joint = Windows.Kinect.Joint;
using Windows.Kinect;
using UnityEngine.SceneManagement;

public class BodySourceViewEe : MonoBehaviour
{
    public BodySourceManager bodySourceManager;
    public GameObject JointObject;
    private Dictionary<ulong, GameObject> mBodies = new Dictionary<ulong, GameObject>();
    public GameObject wash;

    private List<JointType> joints = new List<JointType> {
    JointType.HandLeft,
    JointType.HandRight,
    };

    public Game_Manager []game_Manager;

    private void Update()
    {
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
        Invoke("handMouse", 2);
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

        Invoke("handMouse", 0.2f);
        if (Game_Manager.count >= -1)
        {
            try
            {
                if (GameObject.Find("HandRight").transform.position.y <= 2.97 && GameObject.Find("HandRight").transform.position.y >= 2.37)
                {

                    if (GameObject.Find("HandRight").transform.position.x >= -1.439 && GameObject.Find("HandRight").transform.position.x <= -0.306)
                    {
                        game_Manager[0].clickShapeT1();

                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 0.304 && GameObject.Find("HandRight").transform.position.x <= 0.833)
                    {
                        game_Manager[1].clickShapeR1();

                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 1.838 && GameObject.Find("HandRight").transform.position.x <= 2.441)
                    {
                        game_Manager[2].clickShapeC1();

                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 3.183 && GameObject.Find("HandRight").transform.position.x <= 4.406)
                    {
                        game_Manager[3].clickShapeS1();

                    }


                }
                else if (GameObject.Find("HandRight").transform.position.y <= 1.352 && GameObject.Find("HandRight").transform.position.y >= 0.738)
                {
                    if (GameObject.Find("HandRight").transform.position.x >= -1.439 && GameObject.Find("HandRight").transform.position.x <= -0.306)
                    {
                        game_Manager[4].clickShapeT2();


                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 0.304 && GameObject.Find("HandRight").transform.position.x <= 0.833)
                    {
                        game_Manager[5].clickShapeR2();

                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 1.838 && GameObject.Find("HandRight").transform.position.x <= 2.441)
                    {
                        game_Manager[6].clickShapeC2();

                    }
                    else if (GameObject.Find("HandRight").transform.position.x >= 3.183 && GameObject.Find("HandRight").transform.position.x <= 4.406)
                    {
                        game_Manager[7].clickShapeS2();

                    }

                }
                else if (GameObject.Find("HandRight").transform.position.y <= -3.379 && GameObject.Find("HandRight").transform.position.y >= -4.378 && Game_Manager.count >= 2)
                {
                    if (GameObject.Find("HandRight").transform.position.x >= 5.597 && GameObject.Find("HandRight").transform.position.x <= 7.41)
                    {
                        game_Manager[7].fly();

                        Invoke("wait", 7);

                    }
                }
            }
            catch { }
        }
        
    }

    
    void wait()
    {
        SceneManager.LoadScene("2.Normal");
    }

}

