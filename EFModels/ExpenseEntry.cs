using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exceltodb_expenseentry.EFModels
{
    public class ExpenseEntry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string employee { get; set; }
        public string employee_id { get; set; }
        public string employee_type { get; set; }
        public string expense_type_reason { get; set; }
        public string report_name { get; set; }
        public string report_id { get; set; }
        public string sent_for_payment_date { get; set; }
        public string report_legacy_key { get; set; }
        public string aproval_status { get; set; }
        public string payment_status { get; set; }
        public string transaction_date { get; set; }
        public string transaction_type { get; set; }
        public string vendor { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string approved_amount { get; set; }
        public string total_tax_adjustment_amount { get; set; }
        public string tax_amount { get; set; }
        public string net_tax_amount { get; set; }
        public string reimbursement_currency { get; set; }
        public string approved_amount_rpt { get; set; }
        public string reporting_currency { get; set; }
        public string region_header { get; set; }
        public string country_header { get; set; }
        public string franchise_business_header { get; set; }
        public string location_header { get; set; }
        public string department_header { get; set; }
        public string approved_amount_allocation { get; set; }
        public string reclaimable_tax_on_adjusted_amount { get; set; }

        public string tax_on_adjustmnet_amount { get; set; }
        public string approved_amount_rpt1 { get; set; }
        public string reporting_currency1 { get; set; }
        public string percentage_ { get; set; }
        public string region_allocation { get; set; }
        public string country_allocation { get; set; }
        public string franchise_allocation { get; set; }
        public string city_allocation { get; set; }
        public string department_allocation { get; set; }
        public string recharge_unit { get; set; }
        public string recharge_area { get; set; }
    }
}
