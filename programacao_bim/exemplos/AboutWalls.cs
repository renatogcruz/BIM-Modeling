/*
 * Created by SharpDevelop.
 * User: Renato
 * Date: 8/30/2020
 * Time: 12:53 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;

namespace AboutWalls
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("C8AA1E6B-5704-40A9-8641-8B0A435BCB45")]
	public partial class ThisDocument
	{
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		#region Revit Macros generated code
		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
		public void WallInfo()
		{
			//Configure o Revit UI (uiDoc) e o modelo atual (CurrentDoc)!
			UIDocument uiDoc = this.ActiveUIDocument;	
			Document currentDoc = uiDoc.Document;
			
			try
			{
				// Encontre todas as instâncias de paredes no documento usando o filtro de categoria!
				ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_Walls);
				// Aplique o filtro aos elementos do documento ativo!
				// Use o atalho whereElementIsNotElementType () para encontrar apenas instâncias de parede
				FilteredElementCollector collector = new FilteredElementCollector(currentDoc);

				IList<Element> walls = collector.WherePasses(filter).WhereElementIsNotElementType().ToElements();

				
				String prompt = "As paredes do documento atual são: \n";
				foreach (Element e in walls)
				{
					prompt = prompt + e.Name + "\n";
				}
				TaskDialog.Show("Revit", prompt);				
			
			}			
			catch (Exception)
			{
				throw;
			}
		}
	}
}