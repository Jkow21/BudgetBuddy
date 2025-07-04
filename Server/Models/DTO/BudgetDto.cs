namespace BudgetBuddy.Models.DTO
{
    public class BudgetDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }

        public GoalDto[] Goals { get; set; } = [];
        public TransactionDto[] Transactions { get; set; } = [];
        public UserBudgetDto[] UserBudgets { get; set; } = [];
    }
}