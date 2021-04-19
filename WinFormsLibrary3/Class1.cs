using System;
using Autodesk.AutoCAD.Runtime;

namespace WinFormsLibrary3
{
    public class Class1
    {
        [CommandMethod("Commit")]
        public void Commit()
        {
            Form1 fm = new Form1();
            fm.Show();
        }
    }
}
