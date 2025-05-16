DELIMITER //
CREATE PROCEDURE proc_GetMemberOrders(IN memberId INT)
BEGIN
    SELECT o.OrderID, o.OrderDate, o.TotalAmount, o.Status, b.Title, o.Quantity
    FROM Orders o
    JOIN Books b ON o.BookID = b.BookID
    WHERE o.MemberID = memberId;
END //
DELIMITER ;