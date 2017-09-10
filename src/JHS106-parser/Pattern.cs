namespace JHS106.Parser
{
    internal static class Pattern
    {
        internal const string CAPITAL_A_WITH_DIARESIS = "Ä"; // Ä
        internal const string SMALL_A_WITH_DIARESIS = "\u00E4";// ä
        internal const string CAPITAL_A_WITH_RING_ABOVE = "\u00C5";// Å
        internal const string SMALL_A_WITH_RING_ABOVE = "\u00E5";// å
        internal const string CAPITAL_O_WITH_DIARESIS = "\u00D6";// Ö
        internal const string SMALL_O_WITH_DIARESIS = "\u00F6";// ö
        internal const string CAPITAL_E_WITH_ACUTE = "\u00C9";// É
        internal const string SMALL_E_WITH_ACUTE = "\u00E9";// é
        internal const string CAPITAL_U_WITH_UMLAUT = "\u00DC";// Ü
        internal const string SMALL_U_WITH_UMLAUT = "\u00FC";// ü
        internal const string CAPITAL_S_WITH_CARON = "\u0160";// Š
        internal const string SMALL_S_WITH_CARON = "\u0161";// š
        internal const string CAPITAL_Z_WITH_CARON = "\u017D";// Ž
        internal const string SMALL_Z_WITH_CARON = "\u017E";// ž
        internal const string ACUTE_ACCENT = "\u00B4";// ´
        internal const string APOSTROPHE = "\u0027";// '
        internal const string SMALL_LETTERS = "a-z";
        internal const string CAPITAL_LETTERS = "A-Z";

        internal const string SMALL_LATIN_LETTERS = SMALL_O_WITH_DIARESIS + SMALL_A_WITH_DIARESIS +
                                                   SMALL_A_WITH_RING_ABOVE + SMALL_E_WITH_ACUTE + SMALL_U_WITH_UMLAUT +
                                                   SMALL_S_WITH_CARON + SMALL_Z_WITH_CARON;

        internal const string CAPITAL_LATIN_LETTERS =
            CAPITAL_O_WITH_DIARESIS + CAPITAL_A_WITH_DIARESIS + CAPITAL_A_WITH_RING_ABOVE +
            CAPITAL_E_WITH_ACUTE +
            CAPITAL_U_WITH_UMLAUT +
            CAPITAL_S_WITH_CARON +
            CAPITAL_Z_WITH_CARON;

        internal const string LATIN_LETTERS = SMALL_LATIN_LETTERS +
                                             CAPITAL_LATIN_LETTERS;

        internal const string OTHER = APOSTROPHE +
                                     "-/\\.:" +
                                     ACUTE_ACCENT;

        internal const string ALL_LETTERS = SMALL_LETTERS + CAPITAL_LETTERS +
            LATIN_LETTERS;

        internal const string ALL_SMALL_CHARACTERS = SMALL_LETTERS +
                                                    SMALL_LATIN_LETTERS +
                                                    OTHER;

        internal const string ALL_CHARACTERS = ALL_LETTERS +
                                              OTHER;
    }
}
