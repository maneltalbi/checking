CREATE procedure [dbo].[spAddNewLocation]  
(  
@Rating int,  
@Address nvarchar(100),  
@Lat nvarchar(50),  
@Long nvarchar(50)  
)  
as  
begin  
insert into [dbo].[GoogleMap](Rating,Address,Lat,Long)  
values(@Rating,@Address,@Lat,@Long)  
end  
CREATE procedure [dbo].[spGetMap]  
as  
begin  
select Rating,Address,Lat,Long from [dbo].[GoogleMap]  
end  