CREATE OR ALTER VIEW [vwGetIncomesByCategory] AS
SELECT
    [transactions].[UserId],
    [categories].[Title] AS [Category],
    YEAR([transactions].[PaidOrReceivedAt]) AS [Year],
    SUM([transactions].[Amount]) AS [Incomes]
FROM
    [transactions]
    INNER JOIN [categories]
ON [transactions].[CategoryId] = [categories].[Id]
WHERE
    [transactions].[PaidOrReceivedAt]
    >= DATEADD(MONTH, -11, CAST(GETDATE() AS DATE))
  AND [transactions].[PaidOrReceivedAt]
    < DATEADD(MONTH, 1, CAST(GETDATE() AS DATE))
  AND [transactions].[Type] = 1
GROUP BY
    [transactions].[UserId],
    [categories].[Title],
    YEAR([transactions].[PaidOrReceivedAt])