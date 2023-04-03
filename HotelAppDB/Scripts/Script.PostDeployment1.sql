/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select 1 from dbo.RoomTypes)
begin
INSERT INTO RoomTypes(Type, Description, Price)
VALUES 
('Single King Room', 'Relax in a room containing a luxurious single king size bed!  Total occupants: 3.', 189.00),
('Double Queen Room', 'Relax in style in a room with two luxurious queen size beds!  Total occupants: 4.', 190.00),
('Suite', 'Enjoy the ultimate getaway in our 1 bedroom suite, outfitted with a single luxurious king size bed in the bedroom.  
In the front room, the couch opens up to reveal a pullout mattress.  Complete with a kitchenette, spa-stype tub in the bathroom, desk, dishwasher, and microwave.', 330.00)
end

if not exists (select 1 from dbo.Rooms)
begin
    declare @roomId1 int;
    declare @roomId2 int;
    declare @roomId3 int;

    select @roomId1 = Id from dbo.RoomTypes where Type = 'Single King Room';
    select @roomId2 = Id from dbo.RoomTypes where Type = 'Double Queen Room';
    select @roomId3 = Id from dbo.RoomTypes where Type = 'Suite';

    insert into dbo.Rooms (RoomNumber, RoomTypeId)
    values 
    ('100', @roomId1),
    ('101', @roomId1),
    ('102', @roomId1),
    ('103', @roomId1),
    ('104', @roomId2),
    ('105', @roomId2),
    ('106', @roomId2),
    ('107', @roomId2),
    ('108', @roomId2),
    ('109', @roomId3),
    ('110', @roomId3),
    ('200', @roomId2),
    ('201', @roomId1),
    ('202', @roomId2),
    ('203', @roomId1),
    ('204', @roomId2),
    ('205', @roomId2),
    ('206', @roomId2),
    ('207', @roomId1),
    ('208', @roomId1),
    ('209', @roomId3),
    ('210', @roomId3),
    ('300', @roomId2),
    ('301', @roomId2),
    ('302', @roomId2),
    ('303', @roomId3),
    ('304', @roomId1),
    ('305', @roomId2),
    ('306', @roomId2),
    ('307', @roomId2),
    ('308', @roomId3),
    ('309', @roomId3),
    ('310', @roomId3);
end
