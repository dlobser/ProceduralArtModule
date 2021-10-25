using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Art;

public class GlobArtMaker : ArtMakerTemplate
{
    public GlobManager globManager;

    public override void MakeArt()
    {
        base.MakeArt();
        GlobManager manager = Instantiate(globManager);
        manager.Rebuild();
        AddToRoot(manager.transform);
    }
}
