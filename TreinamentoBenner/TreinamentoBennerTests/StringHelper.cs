namespace TreinamentoBennerTests
{
    public static class StringHelper
    {
        public static string ToPlural(this string str)
        {
            if (str.Equals("dois") || str.Equals("três") || str.Equals("seis") || str.Equals("dez"))
                return str;

            if (str.Equals("existe"))
                return "existem";

            if (str == "tem")
                return "têm";

            if (str.EndsWith("ol"))
                return str.Remove(str.Length - 2, 2) + "óis";

            if (str.EndsWith("z") || str.EndsWith("r") || str.Equals("canon"))
                return str + "es";

            if (str.EndsWith("ão"))
                return str.Remove(str.Length - 2, 2) + "ões";

            if (str.EndsWith("l"))
                return str.Remove(str.Length - 1, 1) + "is";

            if (str.EndsWith("ês"))
                return str.Remove(str.Length - 2, 2) + "eses";

            return str + "s";
        }
    }
}
