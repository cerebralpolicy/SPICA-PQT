
using SPICA.Formats.CtrH3D;
using SPICA.Formats.CtrGfx;
using SPICA.Formats.Xml;

var h3d = H3D.Open(File.ReadAllBytes("SceneEnvironment1.bch"));
foreach (var scene in h3d.Scenes)
{
    foreach (var f in scene.Fogs)
    {
        Console.WriteLine(f.Name);
    }
    foreach (var c in scene.Cameras)
    {
        Console.WriteLine(c.Name);
    }
    foreach (var set in scene.LightSets)
    {
        foreach (var l in set.Names)
            Console.WriteLine(l);
    }
}

return;

var gfx = Gfx.Open("bcres.bcmdl");

foreach (var cam in gfx.Cameras)
{
    foreach (var anim in cam.AnimationsGroup[0].Elements)
    {
        Console.WriteLine(anim.Name);
    }
}
/*Gfx gfx = new Gfx();
var cam = new SPICA.Formats.CtrGfx.Camera.GfxCamera();
cam.Name = "NEWC";
gfx.Cameras.Add(cam);
*/
Gfx.Save("bcresRB.bcmdl", gfx);

var gfx2 = Gfx.Open("bcresRB.bcmdl");

