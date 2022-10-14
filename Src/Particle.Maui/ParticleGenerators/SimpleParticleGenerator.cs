using System;
using Particle.Maui.Particles;
using SkiaSharp;

namespace Particle.Maui.ParticleGenerators
{
    public class SimpleParticleGenerator : IParticleGenerator
    {
        private readonly RandomParticleGenerator _randomParticleGenerator = new RandomParticleGenerator();
        private readonly Random _rand;

        public SimpleParticleGenerator()
        {
            _rand = new Random();
        }

        public ParticleBase[] Generate(SKPoint[] startPositions, int amount = 25, SKColor[] colors = null)
        {
            var particles = new ParticleBase[amount];
            for (int i = 0; i < amount; i++)
            {
                particles[i] = _randomParticleGenerator.GetRandomParticle(startPositions,
                    new[]
                    {
                        new DirectionRange(0, 360),
                    }, amount,
                    _rand,
                    i,
                    colors ?? RandomParticleGenerator.DefaultColors);
            };

            return particles;
        }
    }
}