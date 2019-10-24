using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EcosystemeType
{
    FORET,
    DESERT,
    NEIGE,
    MONTAGNE,
    JUNGLE,
    PLAINE,
    VILLE,
    SAVANE,
    AUCUN
}

/// <summary>
/// Classe <c>Ecosysteme</c>
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
