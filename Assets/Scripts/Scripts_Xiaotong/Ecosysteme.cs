using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EcosystemeType
{
    FORET,
    DESERT,
    NEIGE,
    PLAINE,
    SAVANE
}

/// <summary>
/// Classe <c>Ecosysteme</c> represents ecosysteme of an island.
/// </summary>
public class Ecosysteme
{
    private EcosystemeType ecosystemeType;
    private bool isEcosystemeViable;

    public EcosystemeType EcosystemeType { get => ecosystemeType; set => ecosystemeType = value; }

    public bool IsEcosystemeViable { get => isEcosystemeViable; set => isEcosystemeViable = value; }

    public Ecosysteme(EcosystemeType type)
    {
        EcosystemeType = type;
    }


}
