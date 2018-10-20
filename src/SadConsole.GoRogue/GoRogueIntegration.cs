﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadConsole
{
    public static class GoRogueIntegration
    {
        public static Troschuetz.Random.IGenerator Random { get; set; } = new SadConsoleRandomGenerator(0);

        /// <summary>
        /// Simple implementation of the random generator used by GoRogue. This one is mapped to the <see cref="SadConsole.Global.Random"/> instance.
        /// </summary>
        private class SadConsoleRandomGenerator: Troschuetz.Random.Generators.AbstractGenerator
        {
            private byte[] _uintBuffer;

            public SadConsoleRandomGenerator(uint seed) : base(seed)
            {
                _uintBuffer = new byte[4];
            }

            public override int NextInclusiveMaxValue()
            {
                return SadConsole.Global.Random.Next();
            }

            public override double NextDouble()
            {
                return SadConsole.Global.Random.NextDouble();
            }

            public override uint NextUIntInclusiveMaxValue()
            {
                SadConsole.Global.Random.NextBytes(_uintBuffer);
                return BitConverter.ToUInt32(_uintBuffer, 0);
            }

            public override bool CanReset { get; } = false;
        }

    }
}