
namespace LockdownMode
{
   using System.Runtime.InteropServices;

   [StructLayout(LayoutKind.Sequential)]
   public class LPPOINT
   {
      public int X;
      public int Y;

      public LPPOINT() { }

      public LPPOINT(int x, int y)
      {
         X = x;
         Y = y;
      }
   }
}
