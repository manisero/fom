using System;
using AutoMapper;

namespace ClientAPI.AutoMapper.Converters
{
    public class StringToDateTimeConverter : ITypeConverter<string, DateTime>, ITypeConverter<string, DateTime?>
    {
        DateTime ITypeConverter<string, DateTime>.Convert(ResolutionContext context)
        {
            DateTime result;

            return DateTime.TryParse((string)context.SourceValue, out result) ? result : new DateTime();
        }

        DateTime? ITypeConverter<string, DateTime?>.Convert(ResolutionContext context)
        {
            DateTime result;

            return DateTime.TryParse((string)context.SourceValue, out result) ? result : (DateTime?)null;
        }
    }
}