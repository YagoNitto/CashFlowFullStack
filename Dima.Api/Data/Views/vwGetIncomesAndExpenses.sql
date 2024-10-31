CREATE OR ALTER VIEW [vwGetIncomesAndExpenses] AS
SELECT
    [transactions].[UserId],
    MONTH([transactions].[PaidOrReceivedAt]) AS [Month],
    YEAR([transactions].[PaidOrReceivedAt]) AS [Year],
    SUM(CASE WHEN [transactions].[Type] = 1 THEN [transactions].[Amount] ELSE 0 END) AS [Incomes],
    SUM(CASE WHEN [transactions].[Type] = 2 THEN [transactions].[Amount] ELSE 0 END) AS [Expenses]
FROM
    [transactions]
WHERE
    [transactions].[PaidOrReceivedAt]
    >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
  AND [transactions].[PaidOrReceivedAt]
    < DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
GROUP BY
    [transactions].[UserId],
    MONTH([transactions].[PaidOrReceivedAt]),
    YEAR([transactions].[PaidOrReceivedAt])