using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.MVC
{
    public class Model<P> where P:new()
    {
        private P property = new P();

        public virtual P Property
        {
            get
            {
                return property;
            }
            set
            {
                property = value;
            }
        }
    }
}
