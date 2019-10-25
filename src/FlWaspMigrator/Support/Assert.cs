using System;

namespace FlWaspMigrator.Support
{
    internal static class Assert
    {
        public static void That(bool assertion, string because = null)
        {
            if (!assertion)
                throw new Exception(because == null
                    ? "Assertion failed."
                    : $"Assertion failed because ${because}");
        }
    }
}