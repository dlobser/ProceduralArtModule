using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Art;

public class NoiseGlobArtMaker : ArtMakerTemplate
{
    public NoiseGlobManager globManager;

    public override void MakeArt()
    {
        base.MakeArt();
        NoiseGlobManager manager = Instantiate(globManager);
        manager.Rebuild();

        //do one of these
        manager.transform.parent = root.transform;
        // AddToRoot(manager.transform);
    }
}
