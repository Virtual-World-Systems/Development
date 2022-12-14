using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSimulator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    public class PropertiesWrapper : CustomTypeDescriptor
    {
        public object WrappedObject { get; private set; }
        public List<string> NotBrowsableProperties { get; private set; }
        public PropertiesWrapper(object o, List<string> hidden)
            : base(TypeDescriptor.GetProvider(o).GetTypeDescriptor(o))
        {
            WrappedObject = o;
            NotBrowsableProperties = hidden;
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetProperties(new Attribute[] { });
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = base.GetProperties(attributes).Cast<PropertyDescriptor>()
                                 .Where(p => !NotBrowsableProperties.Contains(p.Name))
                                 .Select(p => TypeDescriptor.CreateProperty(
                                     WrappedObject.GetType(),
                                     p,
                                     p.Attributes.Cast<Attribute>().ToArray()))
                                 .ToArray();
            return new PropertyDescriptorCollection(properties);
        }
    }
}
