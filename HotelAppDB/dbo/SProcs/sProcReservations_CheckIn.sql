CREATE PROCEDURE [dbo].[sProcReservations_CheckIn]
	@todayDate Date,
	@confirmationNumber uniqueidentifier
AS
	set @todayDate = GETDATE();
begin
	set nocount on;

	UPDATE Reservations
	SET CheckedIn = 1
	WHERE (ConfimationNumber = @confirmationNumber AND StartDate = @todayDate);

end
