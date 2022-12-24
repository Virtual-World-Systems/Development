using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ernsoft.Transducer
{
	abstract internal partial class Transducer : Interface
    {
		internal Transducer() { }

        public string Name { get; set; }

        static internal Transducer Create(string args)
        {
            string[] ss = args.Split(',');
            Type t = Assembly.GetExecutingAssembly().GetType("ernsoft.Transducer.TransducerBase+" + ss[0]);
            return (t == null) ? null : (Transducer) t.GetConstructor(
                new Type[] { typeof(string) }).Invoke(new object[] { args });
        }
    }
}
