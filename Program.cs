using System;
using System.Threading.Tasks;

namespace ptmkBD
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Render script selection screen.
            await SelectScript.Execute();
        }
    }
}
