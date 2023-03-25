using SPICA.Formats.Common;

using System;

namespace SPICA.Formats.CtrGfx.Fog
{
    public class GfxFog : GfxNodeTransform
    {
        public float ColorR;
        public float ColorG;
        public float ColorB;

        public float Density; //Unsure

        public uint Near;
        public uint Far;
    }
}
