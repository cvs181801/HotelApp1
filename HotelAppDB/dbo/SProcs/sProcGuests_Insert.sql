CREATE PROCEDURE [dbo].[sProcGuests_Insert]
	@firstName nvarchar(50),
	@lastName nvarchar(50)
AS
begin
	SET NOCOUNT ON;

	if NOT EXISTS (SELECT 1 FROM dbo.Guests where FirstName = @firstName AND LastName = @lastName)
	begin
		INSERT INTO dbo.Guests (FirstName, LastName) 
		VALUES (@firstName, @lastName)
        
	end
	SELECT TOP 1 [Id], [FirstName], [Lastname] 
	FROM dbo.Guests
	WHERE FirstName = @firstName AND lastName = @lastName;
end
