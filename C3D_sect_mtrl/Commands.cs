using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Autodesk
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
#endregion

[assembly: CommandClass(typeof(C3D_sect_mtrl.Commands))]

namespace C3D_sect_mtrl
{
    class Commands
    {
        [CommandMethod("command1")]
        public void Command1()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Editor ed = acDoc.Editor;

            SelectionSet ss = Sset.Aecc_Material("\nSelect Section Solids: ");
            List<Datas> solids = Sset.Aecc_Material_ids(ss);
            if(solids.Count > 0)
            {
                ed.WriteMessage("\n--- Area results of selected Solids --- ");
                for(int i = 0; i < solids.Count; i++)
                {
                    ed.WriteMessage("\n" + solids[i].Material + ": " + solids[i].Area + "m2");
                }
                ed.WriteMessage("\n--------------------------------------- ");
            }
        }
    }


    public class C3D_sect_mtrl : IExtensionApplication
    {
        [CommandMethod("info")]
        public void Initialize()
        {
            Document acDoc = Application.DocumentManager.MdiActiveDocument;
            Database acCurDb = acDoc.Database;
            Editor ed = acDoc.Editor;

            ed.WriteMessage("\n-> Get Area OF Material Solids: command1");

        }

        public void Terminate()
        {
        }
    }
}
