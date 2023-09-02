using System.Collections.Generic;

namespace SPICA.Formats.CtrH3D.Animation
{
    public class H3DLightAnim : H3DAnimation
    {
        public uint Unknown1;
        public uint Unknown2;
        public uint Unknown3;
        public uint Unknown4;

        public H3DLightAnim()
        {
        }

        public H3DLightAnim(H3DAnimation Anim) : this()
        {
            Name = Anim.Name;

            AnimationFlags = Anim.AnimationFlags;
            AnimationType  = Anim.AnimationType;

            CurvesCount = Anim.CurvesCount;

            FramesCount = Anim.FramesCount;

            Elements.AddRange(Anim.Elements);

            MetaData = Anim.MetaData;
        }
    }
}
