using System;
using AutoMapper;

namespace ClientAPI.AutoMapper.Converters
{
    public class StringToTimeSpanConverter : ITypeConverter<string, TimeSpan>, ITypeConverter<string, TimeSpan?>
    {
        TimeSpan ITypeConverter<string, TimeSpan>.Convert(ResolutionContext context)
        {
            TimeSpan result;

            return TimeSpan.TryParse((string)context.SourceValue, out result) ? result : new TimeSpan();
        }

        TimeSpan? ITypeConverter<string, TimeSpan?>.Convert(ResolutionContext context)
        {
            TimeSpan result;

            return TimeSpan.TryParse((string)context.SourceValue, out result) ? result : (TimeSpan?)null;
        }
    }
}