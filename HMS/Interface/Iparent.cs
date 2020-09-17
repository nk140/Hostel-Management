using System;
using System.Collections.Generic;
using System.Text;

namespace HMS.Interface
{
    public interface Iparent
    {
        void Success(string result);
        void servicefailed(string result);
    }
}
