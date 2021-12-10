using UnityEngine;

public class Drop : MonoBehaviour
{
    private static readonly int sSprintDirID = Shader.PropertyToID("_SpringDir");
    public Rigidbody Rigidbody;
    public Rigidbody SpringRigidbody;
    public GameObject FXPrefab;
    public float FXVelocityThreshold;

    private Material mMaterial;

    private void Awake()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        mMaterial = renderer.material;
        renderer.material = mMaterial;
    }

    void Update()
    {
        Vector3 springDir = SpringRigidbody.position - Rigidbody.position;
        mMaterial.SetVector(sSprintDirID, springDir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > FXVelocityThreshold)
        {
            GameObject.Instantiate(FXPrefab, collision.contacts[0].point, Quaternion.identity);
        }
    }
}
