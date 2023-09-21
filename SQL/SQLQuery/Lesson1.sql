SELECT top 10 CustomerName, COUNT(*) 
FROM Sales.Customers
GROUP BY CustomerName;