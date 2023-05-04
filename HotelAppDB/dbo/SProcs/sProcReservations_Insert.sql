CREATE PROCEDURE [dbo].[sProcReservations_Insert]
	@roomId int,
	@guestId int,
	@startDate date,
	@endDate date,
	@totalCost money,
	@affectedRow int
AS
begin

	begin tran
	--set nocount on; 
	
	--So the reason that Execute() returns -1 is because your sproc has SET NOCOUNT ON; which 
	--"suppresses the "xx rows affected" message after any DML" according to this question.
	--Whether you want to disable that or not is another question also discussed in that link.
	--https://stackoverflow.com/questions/12343660/using-dapper-net-to-call-stored-procedure-always-return-1-back#21544261
	--but even when I turned set nocount off , I am still seeing a -1 return value...

	INSERT INTO dbo.Reservations(StartDate, EndDate, GuestId, RoomId, TotalCost)
	VALUES (@startDate, @endDate, @guestId, @roomId, @totalCost);
	SET @affectedRow = SCOPE_IDENTITY();
	commit tran
	
	SELECT g.[FirstName], g.[LastName], resv.[StartDate], resv.[EndDate], resv.[TotalCost], resv.[ConfimationNumber] 
	FROM dbo.Reservations resv
	INNER JOIN Guests g ON g.Id = resv.GuestId 
	WHERE resv.[Id] = @affectedRow;
end
