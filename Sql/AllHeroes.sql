SELECT [Id]
      ,[OriginCounty]
      ,[OriginState]
      ,[TreeSite]
	  ,[Rank]
      ,[FirstName]
      ,[MiddleName]
      ,[LastName]
      ,[MilitaryBranch]
      ,[FirstResponderType]
	  ,[BirthMonth]
      ,[BirthDay]
      ,[BirthYear]
	  ,CONVERT(DATETIME, [DateOfDeath]) as DateOfDeath
	  ,[CauseOfDeath]
	  ,[LocationOfDeath]
	  ,[OriginCity]
      ,[FlagStatus]
      ,[FlagReceiveStatus]
      ,[FlagReceivedDate]
      ,[FlagSponsor]
	  ,[War]
      ,[Notes]
	  ,[Deleted]
  FROM [dbo].[Heroes]
  where OriginCountyName = 'lancaster'