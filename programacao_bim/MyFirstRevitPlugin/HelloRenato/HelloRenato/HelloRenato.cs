using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace HelloRenato // NameSpace.
{
    public class HelloRenato : IExternalCommand // Classe que irá dar origem à dll para uso no Revit
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements) // Método de entrada que implementa a interface necessária da API
        {
            try
            {
                TaskDialog.Show("Revit", "Hello Renato");
                return Result.Succeeded;
            } catch (Exception ex)
            {
                message = ex.Message;
                TaskDialog.Show("Error!", message);
                return Result.Failed; // Retorno de erro.
                                      //throw;
                                      // Código a ser comentado.
            }

            //throw new NotImplementedException(); // Código a ser comentado
        }
    }
}
