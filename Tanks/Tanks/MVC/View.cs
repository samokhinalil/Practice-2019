using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.MVC
{
    public abstract class View<P> where P:new()
    {
        private P model = new P();

        public P Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                Update();
            }
        }

        protected abstract void Update();
    }
}
