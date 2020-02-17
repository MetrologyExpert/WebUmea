using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUmea.Models
{
    public class DemoGroup<K,T>
    {
        public K Key;
        public IEnumerable<T> Values;
    }
}