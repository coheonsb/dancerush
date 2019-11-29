using UnityEngine;

namespace Trickstorm
{
    [RequireComponent(typeof(LineRenderer))]
    public class LaserBeam : MonoBehaviour
    {
        [Header("Laser Properties")]
        public bool LaserOn = true;
        public Color LaserColor;
        public float StartLightIntensity = 0.5f;
        public float EndLightIntensity = 1f;
        public float MaxBeamLength = 1000;
        public float BeamWidth = 0.02f;
        public LayerMask Mask;

        [Space(10)][Header("Laser Lights")]
        public GameObject LaserStartLight;
        public GameObject LaserEndLight;


        private LineRenderer _lineRenderer;
        private Light _laserStartLight;
        private Light _laserEndLight;
        private Renderer _renderer;
        private MaterialPropertyBlock _propertyBlock;


        private void Awake()
        {
            _laserStartLight = LaserStartLight.GetComponent<Light>();
            _laserEndLight = LaserEndLight.GetComponent<Light>();
            _lineRenderer = GetComponent<LineRenderer>();
            _propertyBlock = new MaterialPropertyBlock();
            _renderer = GetComponent<Renderer>();
        }

        private void FixedUpdate()
        {
            //Check to see if the laser is enabled
            if (!LaserOn)
            {
                //Disable the laser
                _lineRenderer.enabled = false;
                _laserStartLight.enabled = false;
                _laserEndLight.enabled = false;
                return;
            }

            //Enable the laser
            _laserStartLight.enabled = true;
            _laserEndLight.enabled = true;
            _lineRenderer.enabled = true;

            //Set laser color
            _renderer.GetPropertyBlock(_propertyBlock);
            _propertyBlock.SetColor("_Color", LaserColor);          
            _renderer.SetPropertyBlock(_propertyBlock);
            _laserStartLight.color = LaserColor;
            _laserEndLight.color = LaserColor;

            //Set laser light intensity
            _laserStartLight.intensity = StartLightIntensity;
            _laserEndLight.intensity = EndLightIntensity;

            //Set beam Width
            _lineRenderer.startWidth = BeamWidth;
            _lineRenderer.endWidth = BeamWidth;
          
            //Raycast check to see if the laser has hit something (depending on 'Mask' values)
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, MaxBeamLength, Mask.value))
            {
                //Laser has hit something
                var endPoint = new Vector3
                {
                    z = Vector3.Distance(hit.point, transform.position)
                };

                _lineRenderer.SetPosition(1, endPoint);          
                _laserEndLight.transform.position = hit.point;
                _laserEndLight.transform.localPosition -= Vector3.forward / 10;
            }
            else
            {
                //Laser hasn't hit anything
                _laserEndLight.enabled = false;
                var endPoint = new Vector3
                {
                    z = MaxBeamLength
                };

                _laserEndLight.transform.localPosition = Vector3.zero;
                _lineRenderer.SetPosition(1, endPoint);
            }
        }
    }
}
