using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using AXExcelAddIn.AX.AIF;
using AXExcelAddIn.AX.AIF.QueryService;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using ExpansionType = AXExcelAddIn.AX.AIF.ExpansionType;
using FetchMode = AXExcelAddIn.AX.AIF.FetchMode;
using QueryDataSourceMetadata = AXExcelAddIn.AX.AIF.QueryDataSourceMetadata;
using QueryMetadata = AXExcelAddIn.AX.AIF.QueryMetadata;

namespace AXExcelAddIn
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            Application.WorkbookBeforeSave += new Microsoft.Office.Interop.Excel.AppEvents_WorkbookBeforeSaveEventHandler(Application_WorkbookBeforeSave);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        void Application_WorkbookBeforeSave(Microsoft.Office.Interop.Excel.Workbook wb, bool saveAsUi, ref bool cancel)
        {
            try
            {
                GenericDocumentService service = new GenericDocumentServiceClient();

                GenericDocumentServiceCacheQueryRequest genericDocumentServiceRequest = new GenericDocumentServiceCacheQueryRequest();

                AX.AIF.QueryService.QueryServiceClient queryServiceClient = new QueryServiceClient();

                //QueryService.QueryDataFieldMetadata queryDataFieldMetaData = new QueryDataSourceMetadata();


                QueryMetadata query = new QueryMetadata();
                query.AllowCrossCompany = false;
                query.AllowCheck = false;
                query.DataSources = new QueryDataSourceMetadata[]
                                    {
                                        new QueryDataSourceMetadata()
                                            {
                                                Table = "prodPool", Name = "ProdPool", Company = "CAD", ConcurrencyModelSpecified = false, DynamicFieldList = true, 
                                                DynamicFieldListSpecified = true, FetchMode = FetchMode.OneToOne,
                                                ExpansionType = ExpansionType.Original, HasRelations = false
                                            }
                                    };

                query.Name = "ProdPoolQuery";
                genericDocumentServiceRequest._axdQuery = query;
                //genericDocumentServiceRequest._documentXml = "";

                

                GenericDocumentServiceCacheQueryResponse response = service.cacheQuery(genericDocumentServiceRequest);

                GenericDocumentServiceCreateUsingCachedQueryRequest cachedQueryRequest = new GenericDocumentServiceCreateUsingCachedQueryRequest();

                cachedQueryRequest._cachedAxdQueryId = response.response;
                GenericDocumentServiceGetSchemasRequest schemasRequest = new GenericDocumentServiceGetSchemasRequest();
                
                schemasRequest._axdQuery = query;

                var schema = service.getSchemas(schemasRequest);
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            

            var activeWorksheet = ((Excel.Worksheet)Application.ActiveSheet);
            var firstRow = activeWorksheet.Range["A1", missing];
            firstRow.EntireRow.Insert(Excel.XlInsertShiftDirection.xlShiftDown, System.Type.Missing);
            var newFirstRow = activeWorksheet.Range["A1", missing];
            newFirstRow.Value2 = "This text was added by using code";
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
