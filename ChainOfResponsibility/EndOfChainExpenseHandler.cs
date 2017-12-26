using System;

namespace ChainOfResponsibility
{
    public class EndOfChainExpenseHandler : IExpenseHandler
    {
        private EndOfChainExpenseHandler() { }

        public static EndOfChainExpenseHandler Instance { get; } = new EndOfChainExpenseHandler();

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            // if end of chain is reached, approval is denied
            return ApprovalResponse.Denied;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            throw new InvalidOperationException("The end of chain handler must be the end of the chain. It can't be in the middle of the chain");
        }
    }
}