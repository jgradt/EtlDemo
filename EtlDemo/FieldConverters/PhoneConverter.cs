using FileHelpers;

namespace EtlDemo.FieldConverters
{
    /// <summary>
    /// Class used by FileHelpers library to convert values
    /// </summary>
    public class PhoneConverter : ConverterBase
    {
        public override object StringToField(string from)
        {
            return from?.Replace("-", "");
        }
    }
}
