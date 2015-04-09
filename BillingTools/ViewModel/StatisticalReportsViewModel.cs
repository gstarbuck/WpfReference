using BillingTools.DataService;
using BillingTools.Excel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rair.BillingTools.ViewModel
{
    public class StatisticalReportsViewModel
    {
        public string Info { get; set; }

        private IBillingToolsDataService _dataService;
        public StatisticalReportsViewModel(IBillingToolsDataService dataService)
        {
            Info = "Statistical Reports";

            _dataService = dataService;

            //Initialize the relay command
            GenerateExcelDocumentCommand = new RelayCommand(GenerateExcelDocument);
        }

        public RelayCommand GenerateExcelDocumentCommand { get; private set; }

        // Command method, run when the command is executed
        public void GenerateExcelDocument()
        {
            ExcelGenerationService xlSvc = new ExcelGenerationService();

            xlSvc.GenerateExcelDocument();
        }
    }
}