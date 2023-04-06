using OpenTK;
using OpenTK.Graphics;
using SPICA.Formats.CtrH3D.Model.Material;
using SPICA.Rendering.SPICA_GL;

namespace SPICA.Rendering.Animation
{
    public class MaterialState
    {
        public bool IsAnimated = false;

        public Matrix4[] Transforms;

        public Color4 Emission;
        public Color4 Ambient;
        public Color4 Diffuse;
        public Color4 Specular0;
        public Color4 Specular1;
        public Color4 Constant0;
        public Color4 Constant1;
        public Color4 Constant2;
        public Color4 Constant3;
        public Color4 Constant4;
        public Color4 Constant5;

        public string Texture0Name;
        public string Texture1Name;
        public string Texture2Name;

        public MaterialState()
        {
            Transforms = new Matrix4[3];
        }

        public void Reset(H3DMaterial mat)
        {
            var Params = mat.MaterialParams;

            Transforms[0] = Params.TextureCoords[0].GetTransform().ToMatrix4();
            Transforms[1] = Params.TextureCoords[1].GetTransform().ToMatrix4();
            Transforms[2] = Params.TextureCoords[2].GetTransform().ToMatrix4();

            Emission = Params.EmissionColor.ToColor4();
            Ambient = Params.AmbientColor.ToColor4();
            Diffuse = Params.DiffuseColor.ToColor4();
            Specular0 = Params.Specular0Color.ToColor4();
            Specular1 = Params.Specular1Color.ToColor4();
            Constant0 = Params.Constant0Color.ToColor4();
            Constant1 = Params.Constant1Color.ToColor4();
            Constant2 = Params.Constant2Color.ToColor4();
            Constant3 = Params.Constant3Color.ToColor4();
            Constant4 = Params.Constant4Color.ToColor4();
            Constant5 = Params.Constant5Color.ToColor4();

            Texture0Name = mat.Texture0Name;
            Texture1Name = mat.Texture1Name;
            Texture2Name = mat.Texture2Name;
        }
    }
}
