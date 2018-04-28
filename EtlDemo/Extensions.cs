using Rhino.Etl.Core;

namespace EtlDemo
{
    internal static class Extensions
    {
        public static bool IsValid(this Row row)
        {
            if((bool)row[Globals.FieldNameIsValid] == true)
            {
                return true;
            }

            return false;
        }

        public static void SetValid(this Row row, bool value = true)
        {
            row[Globals.FieldNameIsValid] = value;            
        }

        public static string GetErrors(this Row row)
        {
            return (string)row[Globals.FieldNameValidationErrors];
        }

        public static void SetErrors(this Row row, string value)
        {
            row[Globals.FieldNameValidationErrors] = value;
        }
    }
}
