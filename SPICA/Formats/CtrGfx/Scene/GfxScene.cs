using SPICA.Formats.Common;

using System;

namespace SPICA.Formats.CtrGfx.Scene
{
    public class GfxScene : GfxObject
    {
        public List<GfxSceneContent> Cameras;
        public List<LightSet> Lights;
        public List<GfxSceneContent> Fog;

        public class LightSet
        {
            public uint ID;

            public List<GfxSceneContent> Lights;
        }

        public class GfxSceneContent
        {
            public uint ID;
            public string Name;
            public uint Padding; //always 0?
        }
    }
}
