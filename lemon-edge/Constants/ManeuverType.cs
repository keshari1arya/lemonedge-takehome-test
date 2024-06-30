// create Maneuver type

public static class ManeuverType
{
    public const string Rook = "Rook";
    public const string Bishop = "Bishop";
    public const string Queen = "Queen";
    public const string Knight = "Knight";

    /// <summary>
    /// Get all Maneuver types.
    /// </summary>
    /// <returns></returns>
    public static string[] All()
    {
        var t = typeof(ManeuverType);
        return t.GetFields().Select(x => x.Name).ToArray();
    }
}