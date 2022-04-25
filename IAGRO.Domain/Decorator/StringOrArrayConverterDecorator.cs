using System.Collections.Generic;

namespace IAGRO.Domain.Decorator
{
    public class StringOrArrayConverterDecorator<TItem> : StringOrArrayConverter<List<TItem>, TItem>
    {
        public StringOrArrayConverterDecorator() : this(true) { }
        public StringOrArrayConverterDecorator(bool canWrite) : base(canWrite) { }
    }
}
