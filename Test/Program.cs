
using SPICA.Formats.CtrH3D;
using SPICA.Formats.CtrGfx;

var h3d = H3D.Open(File.ReadAllBytes("dec_0004.bin"));
H3D.Save("dec_0004RB.bin", h3d);