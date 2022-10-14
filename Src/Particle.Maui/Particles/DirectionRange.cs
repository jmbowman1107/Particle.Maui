namespace Particle.Maui.Particles
{
    public class DirectionRange
    {
        public DirectionRange(float minAngle, float maxAngle)
        {
            MinAngle = minAngle;
            MaxAngle = maxAngle;
        }

        public float MinAngle { get; set; }
        public float MaxAngle { get; set; }
    }
}