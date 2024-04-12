using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Tests
{
    public abstract class BaseTest
    {
        public ITestOutputHelper output { get; set; }

        public BaseTest(ITestOutputHelper output)
        {
            this.output = output;
        }
    }
}
