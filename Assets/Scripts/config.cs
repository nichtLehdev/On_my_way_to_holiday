using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class config : MonoBehaviour
{
    private const string GLOBALSTATS_API_ID = "mRm53LRSMwx7o8Fqp6G4MyyWoUW7abcx2zC6ltZ7";
    private const string GLOBALSTATS_API_SECRET = "wepFUP40w8N4GKtAGALSNiVmV1Hp0Ppx3OcXEgYb";

    public static string getId()
    {
        return GLOBALSTATS_API_ID;
    }

    public static string getSecret()
    {
        return GLOBALSTATS_API_SECRET;
    }
}
