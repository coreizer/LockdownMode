namespace TestProject
{
   using LockdownMode;
   using NUnit.Framework;

   public class CursorManagerUnitTest
   {
      private CursorManager _cursorManager;

      [SetUp]
      public void Setup()
      {
         this._cursorManager = new CursorManager();
      }

      [Test]
      public void PositionTest()
      {
         this._cursorManager.Position = new System.Drawing.Point(0, 100);

         Assert.AreEqual(this._cursorManager.Position, new System.Drawing.Point(0, 100));
      }

      [Test]
      public void SetCursorPositionTest()
      {
         this._cursorManager.SetCursorPosition = new System.Drawing.Point(50, 25);

         Assert.AreEqual(this._cursorManager.Point, new System.Drawing.Point(50, 25));
      }
   }
}