using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using ClosedXML.Excel;
using System.Linq;
using Exceltodb_expenseentry.Data;
using Exceltodb_expenseentry.EFModels;
using System.Threading.Tasks;

namespace Exceltodb_expenseentry
{
    public class ExpenseEntryjournal
    {
        private readonly DataContext _ctx;

        public ExpenseEntryjournal(DataContext ctx)
        {
            _ctx = ctx;
        }

        [FunctionName("Function1")]
        public async Task Run([TimerTrigger("*/10 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");


            // Read the Excel file using ClosedXML
            using var workbook = new XLWorkbook(@"C:\Users\Christine.Israel\OneDrive - Inchcape\Documents\Development\Azure Task\Sprint 30\Expense Entry Analysis V3 for Journals.xlsx");
            try
            {

                var worksheet = workbook.Worksheet(1); // Assuming the data is in the first worksheet

                // Convert the worksheet data into a List 
                var myEntities = worksheet.RowsUsed()
                    .Skip(1) // Skip the header row
                    .Select(row => new ExpenseEntry //select rows and goes to EF models
                    {
                        employee = row.Cell(1).Value.ToString(), // used to get the value of a cell in a specific row of an Excel worksheet
                        employee_id = row.Cell(2).Value.ToString(),
                        employee_type = row.Cell(3).Value.ToString(),
                        expense_type_reason = row.Cell(4).Value.ToString(),
                        report_name = row.Cell(5).Value.ToString(),
                        report_id = row.Cell(6).Value.ToString(),
                        sent_for_payment_date = row.Cell(7).Value.ToString(),
                        report_legacy_key = row.Cell(8).Value.ToString(),
                        aproval_status = row.Cell(9).Value.ToString(),
                        payment_status = row.Cell(10).Value.ToString(),
                        transaction_date = row.Cell(11).Value.ToString(),
                        transaction_type = row.Cell(12).Value.ToString(),
                        vendor = row.Cell(13).Value.ToString(),
                        city = row.Cell(14).Value.ToString(),
                        country = row.Cell(15).Value.ToString(),
                        approved_amount = row.Cell(16).Value.ToString(),
                        total_tax_adjustment_amount = row.Cell(17).ToString(),
                        tax_amount = row.Cell(18).Value.ToString(),
                        net_tax_amount = row.Cell(19).Value.ToString(),
                        reimbursement_currency = row.Cell(20).Value.ToString(),
                        approved_amount_rpt = row.Cell(21).Value.ToString(),
                        reporting_currency = row.Cell(22).Value.ToString(),
                        region_header = row.Cell(23).Value.ToString(),
                        country_header = row.Cell(24).Value.ToString(),
                        franchise_business_header = row.Cell(25).Value.ToString(),
                        location_header = row.Cell(26).Value.ToString(),
                        department_header = row.Cell(27).Value.ToString(),
                        approved_amount_allocation = row.Cell(28).Value.ToString(),
                        reclaimable_tax_on_adjusted_amount = row.Cell(29).Value.ToString(),
                        tax_on_adjustmnet_amount = row.Cell(30).Value.ToString(),
                        approved_amount_rpt1 = row.Cell(31).Value.ToString(),
                        reporting_currency1 = row.Cell(32).Value.ToString(),
                        percentage_ = row.Cell(33).Value.ToString(),
                        region_allocation = row.Cell(34).Value.ToString(),
                        country_allocation = row.Cell(35).Value.ToString(),
                        franchise_allocation = row.Cell(36).Value.ToString(),
                        city_allocation = row.Cell(37).Value.ToString(),
                        department_allocation = row.Cell(38).Value.ToString(),
                        recharge_unit = row.Cell(39).Value.ToString(),
                        recharge_area = row.Cell(40).Value.ToString()
 
                    })

                    .ToList();

                await _ctx.BulkInsertAsync(myEntities);

                /*
                foreach (var entity in myEntities)
                {
                    _ctx.expense_entry.Add(entity);
                }
                */

                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString);
            }
        }
    }
}
