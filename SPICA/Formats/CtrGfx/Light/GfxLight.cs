using SPICA.Formats.CtrH3D.Light;
using SPICA.Serialization.Attributes;

namespace SPICA.Formats.CtrGfx.Light
{
    [TypeChoice(0x400000a2, typeof(GfxFragmentLight))]
    [TypeChoice(0x40000122, typeof(GfxHemisphereLight))]
    [TypeChoice(0x40000222, typeof(GfxVertexLight))]
    [TypeChoice(0x40000422, typeof(GfxAmbientLight))]
    public class GfxLight : GfxNodeTransform
    {
        public bool IsEnabled;

        public H3DLight ToH3DLight()
        {
            H3DLight Output = new H3DLight() { Name = Name };

            Output.IsEnabled = IsEnabled;

            Output.TransformScale       = TransformScale;
            Output.TransformRotation    = TransformRotation;
            Output.TransformTranslation = TransformTranslation;

            if (this is GfxHemisphereLight HemisphereLight)
            {
                Output.Type = H3DLightType.Hemisphere;

                Output.Content = new H3DHemisphereLight()
                {
                    SkyColor    = HemisphereLight.SkyColor,
                    GroundColor = HemisphereLight.GroundColor,
                    Direction   = HemisphereLight.Direction,
                    LerpFactor  = HemisphereLight.LerpFactor
                };
            }
            else if (this is GfxAmbientLight AmbientLight)
            {
                Output.Type = H3DLightType.Ambient;

                Output.Content = new H3DAmbientLight()
                {
                    Color = AmbientLight.Color
                };
            }
            else if (this is GfxVertexLight VertexLight)
            {
                Output.Type = H3DLightType.Vertex | (H3DLightType)VertexLight.Type;

                Output.Content = new H3DVertexLight()
                {
                    AmbientColor         = VertexLight.AmbientColor,
                    DiffuseColor         = VertexLight.DiffuseColor,
                    Direction            = VertexLight.Direction,
                    AttenuationConstant  = VertexLight.AttenuationConstant,
                    AttenuationLinear    = VertexLight.AttenuationLinear,
                    AttenuationQuadratic = VertexLight.AttenuationQuadratic,
                    SpotExponent         = VertexLight.SpotExponent,
                    SpotCutOffAngle      = VertexLight.SpotCutOffAngle
                };
            }
            else if (this is GfxFragmentLight FragmentLight)
            {
                Output.Type = H3DLightType.Fragment | (H3DLightType)FragmentLight.Type;

                Output.LUTInput = FragmentLight.AngleSampler?.Input ?? 0;
                Output.LUTScale = FragmentLight.AngleSampler?.Scale ?? 0;

                if (FragmentLight.Flags.HasFlag(GfxFragmentLightFlags.IsDistanceAttenuationEnabled))
                    Output.Flags |= H3DLightFlags.HasDistanceAttenuation;
                if (FragmentLight.Flags.HasFlag(GfxFragmentLightFlags.IsTwoSidedDiffuse))
                    Output.Flags |= H3DLightFlags.IsTwoSidedDiffuse;

                Output.Content = new H3DFragmentLight()
                {
                    AmbientColor           = FragmentLight.AmbientColor,
                    DiffuseColor           = FragmentLight.DiffuseColor,
                    Specular0Color         = FragmentLight.Specular0Color,
                    Specular1Color         = FragmentLight.Specular1Color,
                    Direction              = FragmentLight.Direction,
                    AttenuationStart       = FragmentLight.AttenuationStart,
                    AttenuationEnd         = FragmentLight.AttenuationEnd,
                    DistanceLUTTableName   = FragmentLight.DistanceSampler?.TableName,
                    DistanceLUTSamplerName = FragmentLight.DistanceSampler?.SamplerName,
                    AngleLUTTableName      = FragmentLight.AngleSampler?.Sampler.TableName,
                    AngleLUTSamplerName    = FragmentLight.AngleSampler?.Sampler.SamplerName
                };
            }

            return Output;
        }

        public static GfxLight FromH3D(H3DLight light)
        {
            GfxLight gfxlight = new GfxLight();
            if (light.Content is H3DHemisphereLight HemisphereLight)
            {
                gfxlight = new GfxHemisphereLight()
                {
                    SkyColor = HemisphereLight.SkyColor,
                    GroundColor = HemisphereLight.GroundColor,
                    Direction = HemisphereLight.Direction,
                    LerpFactor = HemisphereLight.LerpFactor
                };
            }
            else if (light.Content is H3DAmbientLight AmbientLight)
            {
                gfxlight = new GfxAmbientLight()
                {
                    Color = AmbientLight.Color
                };
            }
            else if (light.Content is H3DVertexLight VertexLight)
            {
                gfxlight = new GfxVertexLight()
                {
                    AmbientColor = VertexLight.AmbientColor,
                    DiffuseColor = VertexLight.DiffuseColor,
                    Direction = VertexLight.Direction,
                    AttenuationConstant = VertexLight.AttenuationConstant,
                    AttenuationLinear = VertexLight.AttenuationLinear,
                    AttenuationQuadratic = VertexLight.AttenuationQuadratic,
                    SpotExponent = VertexLight.SpotExponent,
                    SpotCutOffAngle = VertexLight.SpotCutOffAngle
                };
            }
            else if (light.Content is H3DFragmentLight FragmentLight)
            {
                gfxlight = new GfxFragmentLight()
                {
                    AmbientColor = FragmentLight.AmbientColor,
                    DiffuseColor = FragmentLight.DiffuseColor,
                    Specular0Color = FragmentLight.Specular0Color,
                    Specular1Color = FragmentLight.Specular1Color,
                    Direction = FragmentLight.Direction,
                    AttenuationStart = FragmentLight.AttenuationStart,
                    AttenuationEnd = FragmentLight.AttenuationEnd,
                };

                if (!string.IsNullOrEmpty(FragmentLight.DistanceLUTSamplerName))
                {
                    ((GfxFragmentLight)gfxlight).DistanceSampler = new GfxLUTReference()
                    {
                        SamplerName = FragmentLight.DistanceLUTSamplerName,
                        TableName = FragmentLight.DistanceLUTTableName,
                    };
                }
                if (!string.IsNullOrEmpty(FragmentLight.AngleLUTSamplerName))
                {
                    ((GfxFragmentLight)gfxlight).AngleSampler = new GfxFragLightLUT()
                    {
                        Scale = light.LUTScale,
                        Input = light.LUTInput,
                        Sampler = new GfxLUTReference()
                        {
                            SamplerName = FragmentLight.AngleLUTSamplerName,
                            TableName = FragmentLight.AngleLUTTableName,
                        },
                    };
                }
                if (light.Flags.HasFlag(H3DLightFlags.HasDistanceAttenuation))
                    ((GfxFragmentLight)gfxlight).Flags |= GfxFragmentLightFlags.IsDistanceAttenuationEnabled;
                if (light.Flags.HasFlag(H3DLightFlags.IsTwoSidedDiffuse))
                    ((GfxFragmentLight)gfxlight).Flags |= GfxFragmentLightFlags.IsTwoSidedDiffuse;
            }


            gfxlight.IsEnabled = light.IsEnabled;
            gfxlight.TransformScale = light.TransformScale;
            gfxlight.TransformRotation = light.TransformRotation;
            gfxlight.TransformTranslation = light.TransformTranslation;
            gfxlight.Name = light.Name;

            return gfxlight;
        }
    }
}
