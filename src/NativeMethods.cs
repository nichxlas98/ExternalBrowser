using System.Runtime.InteropServices;

namespace ExternalBrowser 
{
    // NativeMethods class to import user32.dll for GetAsyncKeyState function
    class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
    }
}