using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public class Employee : IExpenseApprover
    {
        private readonly Decimal _approvalLimit;

        public Employee(string name, string jobTitle, decimal approvalLimit)
        {
            Name = name;
            JobTitle = jobTitle;
            _approvalLimit = approvalLimit;
        }

        public string Name { get; set; }

        public string JobTitle { get; set; }

        public ApprovalResponse ApproveExpense(IExpenseReport expenseReport)
        {
            return expenseReport.Total > _approvalLimit
                ? ApprovalResponse.BeyondApprovalLimit
                : ApprovalResponse.Approved;
        }
    }
}
