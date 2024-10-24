using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinanceManagerBackend.Migrations
{
    /// <inheritdoc />
    public partial class UserDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_Budget_BudgetId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_ExpenseIncomeCategory_CategoryId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_RecurringIncomeExpense_RecurringIncomeExpenseId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_Budget_BudgetId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_ExpenseIncomeCategory_CategoryId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_RecurringIncomeExpense_RecurringIncomeExpenseId",
                table: "Income");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringIncomeExpense",
                table: "RecurringIncomeExpense");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Income",
                table: "Income");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseIncomeCategory",
                table: "ExpenseIncomeCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "RecurringIncomeExpense",
                newName: "RecurringIncomeExpenses");

            migrationBuilder.RenameTable(
                name: "Income",
                newName: "Incomes");

            migrationBuilder.RenameTable(
                name: "ExpenseIncomeCategory",
                newName: "ExpenseIncomeCategorys");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameIndex(
                name: "IX_Income_RecurringIncomeExpenseId",
                table: "Incomes",
                newName: "IX_Incomes_RecurringIncomeExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Income_CategoryId",
                table: "Incomes",
                newName: "IX_Incomes_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Income_BudgetId",
                table: "Incomes",
                newName: "IX_Incomes_BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_RecurringIncomeExpenseId",
                table: "Expenses",
                newName: "IX_Expenses_RecurringIncomeExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_CategoryId",
                table: "Expenses",
                newName: "IX_Expenses_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_BudgetId",
                table: "Expenses",
                newName: "IX_Expenses_BudgetId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Users",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringIncomeExpenses",
                table: "RecurringIncomeExpenses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseIncomeCategorys",
                table: "ExpenseIncomeCategorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Budget_BudgetId",
                table: "Expenses",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseIncomeCategorys_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "ExpenseIncomeCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_RecurringIncomeExpenses_RecurringIncomeExpenseId",
                table: "Expenses",
                column: "RecurringIncomeExpenseId",
                principalTable: "RecurringIncomeExpenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Budget_BudgetId",
                table: "Incomes",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_ExpenseIncomeCategorys_CategoryId",
                table: "Incomes",
                column: "CategoryId",
                principalTable: "ExpenseIncomeCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_RecurringIncomeExpenses_RecurringIncomeExpenseId",
                table: "Incomes",
                column: "RecurringIncomeExpenseId",
                principalTable: "RecurringIncomeExpenses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Budget_BudgetId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseIncomeCategorys_CategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_RecurringIncomeExpenses_RecurringIncomeExpenseId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Budget_BudgetId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_ExpenseIncomeCategorys_CategoryId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_RecurringIncomeExpenses_RecurringIncomeExpenseId",
                table: "Incomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RecurringIncomeExpenses",
                table: "RecurringIncomeExpenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseIncomeCategorys",
                table: "ExpenseIncomeCategorys");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "RecurringIncomeExpenses",
                newName: "RecurringIncomeExpense");

            migrationBuilder.RenameTable(
                name: "Incomes",
                newName: "Income");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameTable(
                name: "ExpenseIncomeCategorys",
                newName: "ExpenseIncomeCategory");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_RecurringIncomeExpenseId",
                table: "Income",
                newName: "IX_Income_RecurringIncomeExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_CategoryId",
                table: "Income",
                newName: "IX_Income_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_BudgetId",
                table: "Income",
                newName: "IX_Income_BudgetId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_RecurringIncomeExpenseId",
                table: "Expense",
                newName: "IX_Expense_RecurringIncomeExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expense",
                newName: "IX_Expense_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_BudgetId",
                table: "Expense",
                newName: "IX_Expense_BudgetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RecurringIncomeExpense",
                table: "RecurringIncomeExpense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Income",
                table: "Income",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseIncomeCategory",
                table: "ExpenseIncomeCategory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_Budget_BudgetId",
                table: "Expense",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_ExpenseIncomeCategory_CategoryId",
                table: "Expense",
                column: "CategoryId",
                principalTable: "ExpenseIncomeCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_RecurringIncomeExpense_RecurringIncomeExpenseId",
                table: "Expense",
                column: "RecurringIncomeExpenseId",
                principalTable: "RecurringIncomeExpense",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_Budget_BudgetId",
                table: "Income",
                column: "BudgetId",
                principalTable: "Budget",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_ExpenseIncomeCategory_CategoryId",
                table: "Income",
                column: "CategoryId",
                principalTable: "ExpenseIncomeCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_RecurringIncomeExpense_RecurringIncomeExpenseId",
                table: "Income",
                column: "RecurringIncomeExpenseId",
                principalTable: "RecurringIncomeExpense",
                principalColumn: "Id");
        }
    }
}
