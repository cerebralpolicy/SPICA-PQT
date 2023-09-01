using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SPICA.Formats.Common;
using SPICA.Serialization.Attributes;

namespace SPICA.Formats.CtrGfx.AnimGroup
{
    [TypeChoice(0x00080000u, typeof(GfxAnimGroupMeshNodeVis))]
    [TypeChoice(0x01000000u, typeof(GfxAnimGroupMesh))]
    [TypeChoice(0x02000000u, typeof(GfxAnimGroupTexSampler))]
    [TypeChoice(0x04000000u, typeof(GfxAnimGroupBlendOp))]
    [TypeChoice(0x08000000u, typeof(GfxAnimGroupMaterialColor))]
    [TypeChoice(0x10000000u, typeof(GfxAnimGroupModel))]
    [TypeChoice(0x20000000u, typeof(GfxAnimGroupTexMapper))]
    [TypeChoice(0x40000000u, typeof(GfxAnimGroupBone))]
    [TypeChoice(0x80000000u, typeof(GfxAnimGroupTexCoord))]

    [TypeChoice(0x00100000u, typeof(GfxAnimGroup001000))] 
    [TypeChoice(0x00200000u, typeof(GfxAnimGroup002000))] //Camera near/far/fov/aspect
    [TypeChoice(0x00400000u, typeof(GfxAnimGroup004000))] //Camera target pos/up vec
    [TypeChoice(0x00800000u, typeof(GfxAnimGroup008000))] //Transform
    [TypeChoice(0x00040000u, typeof(GfxAnimGroup00040000))] //Fog color
    public class GfxAnimGroupElement : INamed
    {
        private string _Name;

        public string Name
        {
            get => _Name;
            set => _Name = value ?? throw Exceptions.GetNullException("Name");
        }

        public int MemberOffset;

        public int BlendOpIndex;

        [JsonConverter(typeof(StringEnumConverter))]
        public GfxAnimGroupObjType ObjType;

        public uint MemberType;

        private uint MaterialPtr;
    }

    public class GfxAnimGroup001000 : GfxAnimGroupElement
    {
        private GfxAnimGroupObjType ObjType2;

        public GfxAnimGroup001000()
        {
            ObjType2 = (GfxAnimGroupObjType)10;
        }
    }

    public class GfxAnimGroup002000 : GfxAnimGroupElement
    {
        private GfxAnimGroupObjType ObjType2;

        public GfxAnimGroup002000()
        {
            ObjType2 = (GfxAnimGroupObjType)10;
        }
    }

    public class GfxAnimGroup004000 : GfxAnimGroupElement
    {
        private GfxAnimGroupObjType ObjType2;

        public GfxAnimGroup004000()
        {
            ObjType2 = (GfxAnimGroupObjType)10;
        }
    }

    public class GfxAnimGroup008000 : GfxAnimGroupElement
    {
        private GfxAnimGroupObjType ObjType2;

        public GfxAnimGroup008000()
        {
            ObjType2 = (GfxAnimGroupObjType)10;
        }
    }

    public class GfxAnimGroup00040000 : GfxAnimGroupElement
    {
        private GfxAnimGroupObjType ObjType2;

        public GfxAnimGroup00040000()
        {
            ObjType2 = (GfxAnimGroupObjType)10;
        }
    }
}
