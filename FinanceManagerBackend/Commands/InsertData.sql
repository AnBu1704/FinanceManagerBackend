INSERT INTO [dbo].[Accounts] ([Name], [Description], [EMail]) VALUES
('Primary Account', 'Main account for daily transactions', 'primary@example.com'),
('Savings Account', 'Account for savings and future expenses', 'savings@example.com'),
('Investment Account', 'Account for long-term investments', 'investment@example.com');


  -- Insert data into Users table
INSERT INTO [dbo].[Users] ([Name], [AccountId], [Color], [UserPassword]) VALUES
('Alice', 1, 16711680, 'password1'),  -- Red color
('Bob', 2, 65280, 'password2'),        -- Green color
('Charlie', 3, 255, 'password3'),      -- Blue color
('David', 1, 16776960, 'password4'),   -- Yellow color
('Eva', 2, 16711935, 'password5'),     -- Magenta color
('Frank', 3, 65535, 'password6'),      -- Cyan color
('Grace', 1, 8421504, 'password7'),    -- Gray color
('Hannah', 2, 12632256, 'password8'),  -- Light gray color
('Isaac', 3, 128, 'password9'),        -- Dark green color
('Jack', 1, 8388608, 'password10');    -- Dark red color


-- Insert data into Budget table
INSERT INTO [dbo].[Budget] ([Name], [Description], [UserId], [StartingCapital], [PaymentMethod], [Currency]) VALUES
('Daily Expenses', 'Budget for daily expenses', 1, 1000, 'Cash', 'USD'),    -- Alice
('Vacation Fund', 'Savings for vacation', 1, 2000, 'Credit Card', 'EUR'),

('Household', 'Household expenses', 2, 1500, 'Bank Transfer', 'USD'),       -- Bob
('Emergency Fund', 'Emergency savings', 2, 5000, 'Cash', 'EUR'),

('Car Maintenance', 'Car-related expenses', 3, 1200, 'Credit Card', 'USD'), -- Charlie
('Health Insurance', 'Insurance for health', 3, 1800, 'Direct Debit', 'USD'),

('Education', 'Education fund for children', 4, 3000, 'Cash', 'EUR'),       -- David
('Retirement Fund', 'Retirement savings', 4, 7000, 'Bank Transfer', 'USD'),

('Shopping', 'Budget for shopping', 5, 800, 'Credit Card', 'EUR'),          -- Eva
('Travel', 'Travel and leisure', 5, 2500, 'Cash', 'USD'),

('Groceries', 'Monthly groceries budget', 6, 600, 'Bank Transfer', 'USD'),  -- Frank
('Utilities', 'Budget for utilities', 6, 1200, 'Cash', 'EUR'),

('Fitness', 'Gym membership and fitness', 7, 400, 'Credit Card', 'USD'),    -- Grace
('Gadgets', 'Tech gadgets and devices', 7, 1500, 'Bank Transfer', 'EUR'),

('Dining Out', 'Dining at restaurants', 8, 900, 'Cash', 'USD'),             -- Hannah
('Entertainment', 'Movies, concerts, etc.', 8, 1100, 'Credit Card', 'EUR'),

('Home Renovation', 'Budget for home improvements', 9, 4000, 'Cash', 'USD'),-- Isaac
('Furniture', 'Furniture purchases', 9, 3500, 'Bank Transfer', 'EUR'),

('Savings Account', 'Long-term savings', 10, 8000, 'Direct Debit', 'USD'),  -- Jack
('Investment Portfolio', 'Stocks and bonds', 10, 10000, 'Bank Transfer', 'EUR');


-- Insert data into ExpenseIncomeCategory table with Google Fonts Icons (Material Icons)
INSERT INTO [dbo].[ExpenseIncomeCategory] ([Name], [Symbol], [Color]) VALUES
('Food', 'fastfood', 16711680),           -- Red
('Transport', 'directions_car', 65280),    -- Green
('Rent', 'home', 255),                    -- Blue
('Utilities', 'lightbulb', 16776960),      -- Yellow
('Entertainment', 'theaters', 16711935),   -- Magenta
('Health', 'medical_services', 65535),     -- Cyan
('Education', 'school', 8421504),          -- Gray
('Savings', 'savings', 12632256),          -- Light gray
('Investment', 'trending_up', 128),        -- Dark green
('Miscellaneous', 'miscellaneous_services', 8388608); -- Dark red


-- Insert data into RecurringIncomeExpense table
INSERT INTO [dbo].[RecurringIncomeExpense] ([IsExpense], [Name], [Amount], [StartDate], [RecurringPeriod], [IsActive]) VALUES
(1, 'Monthly Rent', 1000, '2024-01-01', 30, 1),  -- Ausgaben
(1, 'Electricity Bill', 150, '2024-02-01', 30, 1),
(0, 'Salary', 5000, '2024-01-01', 30, 1),  -- Einkommen
(1, 'Internet Subscription', 50, '2024-03-01', 30, 1),
(1, 'Car Insurance', 200, '2024-01-15', 360, 1),
(0, 'Freelance Income', 1500, '2024-04-01', 30, 1),
(1, 'Health Insurance', 250, '2024-05-01', 360, 1),
(0, 'Rental Income', 800, '2024-06-01', 30, 1),
(1, 'Gym Membership', 100, '2024-02-15', 30, 1),
(0, 'Investment Returns', 400, '2024-03-01', 90, 1);


-- Insert data into Income table
INSERT INTO [dbo].[Income] ([Name], [Description], [Amount], [CategoryId], [Date], [RecurringIncomeExpenseId], [BudgetId]) VALUES
('Salary Payment', 'Monthly salary', 5000, 3, '2024-09-01', 3, 1),  -- Referenz auf RecurringIncomeExpense und Budget
('Freelance Project', 'Income from freelance work', 1500, 9, '2024-09-15', 6, 2),
('Rental Payment', 'Income from rented property', 800, 9, '2024-10-01', 8, 3),
('Bonus', 'Performance bonus', 1200, 6, '2024-10-15', NULL, 4),
('Investment Return', 'Stock market gains', 400, 10, '2024-11-01', 10, 5),
('Gift Money', 'Received as a gift', 300, 8, '2024-12-25', NULL, 6),
('Sale of Goods', 'Sold old items online', 500, 10, '2024-11-20', NULL, 7),
('Dividend', 'Dividend from stocks', 600, 10, '2024-10-31', NULL, 8),
('Interest Income', 'Bank interest on savings', 50, 7, '2024-09-30', NULL, 9),
('Consulting', 'Consulting fee', 2000, 9, '2024-09-01', 6, 10),
('Commission', 'Sales commission', 250, 8, '2024-10-05', NULL, 1),
('Referral Bonus', 'Bonus for referring a friend', 100, 7, '2024-08-01', NULL, 2),
('Cashback', 'Cashback from credit card', 75, 10, '2024-08-10', NULL, 3),
('Inheritance', 'Received inheritance', 10000, 8, '2024-06-15', NULL, 4),
('Refund', 'Tax refund', 800, 6, '2024-07-01', NULL, 5),
('Investment Sale', 'Sold stocks', 2000, 10, '2024-07-15', NULL, 6),
('Rental Income', 'Second property rental', 1000, 9, '2024-08-01', 8, 7),
('Side Job', 'Part-time income', 600, 9, '2024-09-20', 6, 8),
('Profit Share', 'Share of company profits', 5000, 10, '2024-10-01', NULL, 9),
('Prize Money', 'Won in a competition', 1200, 8, '2024-12-01', NULL, 10);


-- Insert data into Expense table
INSERT INTO [dbo].[Expense] ([Name], [Description], [Amount], [CategoryId], [Date], [RecurringIncomeExpenseId], [BudgetId]) VALUES
('Rent Payment', 'Monthly rent for apartment', 1000, 3, '2024-09-01', 19, 1),  -- Referenz auf RecurringIncomeExpense und Budget
('Grocery Shopping', 'Weekly groceries', 150, 1, '2024-09-05', NULL, 19),
('Electricity Bill', 'Monthly electricity bill', 150, 4, '2024-09-10', 19, 3),
('Gym Membership', 'Monthly gym fee', 100, 7, '2024-09-15', 20, 4),
('Car Insurance', 'Annual car insurance payment', 200, 2, '2024-09-20', 15, 5),
('Phone Bill', 'Monthly phone service', 50, 4, '2024-09-25', NULL, 6),
('Fuel', 'Fuel for car', 75, 2, '2024-09-30', NULL, 7),
('Dining Out', 'Dinner at restaurant', 80, 5, '2024-10-01', NULL, 8),
('Movie Tickets', 'Cinema tickets', 30, 5, '2024-10-05', NULL, 9),
('Health Insurance', 'Monthly health insurance', 250, 6, '2024-10-10', 17, 10),
('Clothing', 'New clothes for fall', 300, 10, '2024-10-15', NULL, 1),
('Household Supplies', 'Cleaning supplies', 100, 4, '2024-10-20', NULL, 2),
('Insurance Premium', 'Annual life insurance', 500, 6, '2024-10-25', NULL, 3),
('Concert Tickets', 'Tickets for a concert', 150, 5, '2024-11-01', NULL, 4),
('Vacation', 'Expenses for a vacation', 2000, 5, '2024-11-10', NULL, 5),
('Medical Bills', 'Doctor appointment and medicine', 200, 6, '2024-11-15', NULL, 6),
('Home Repair', 'Fixing plumbing issue', 300, 3, '2024-11-20', NULL, 7),
('Subscription', 'Streaming service subscription', 15, 5, '2024-11-25', NULL, 8),
('Property Tax', 'Annual property tax payment', 1000, 3, '2024-12-01', NULL, 9),
('Tuition Fees', 'University tuition payment', 5000, 7, '2024-12-10', NULL, 10);
