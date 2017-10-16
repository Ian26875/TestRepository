using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWebNorthWind.Tests.NSubstitute
{
    public interface ICalculator
    {
        int Add(int paramA, int paramB);
        string Model { get; set; }
    }
}
