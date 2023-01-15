using System.IO;
using System.Xml.Serialization;

namespace GenericSerializer
{
    static class Utils
    {
        public static string Serialize<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new(toSerialize.GetType());

            using StringWriter textWriter = new();
            xmlSerializer.Serialize(textWriter, toSerialize);
            return textWriter.ToString();
        }

        public static T Deserialize<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new(typeof(T));

            using TextReader textReader = new StringReader(toDeserialize);
            return (T)xmlSerializer.Deserialize(textReader);
        }
    }
}