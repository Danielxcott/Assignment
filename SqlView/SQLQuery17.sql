USE CinemaDB ;   
GO  
CREATE VIEW [CinemaView]
AS  
SELECT dbo.Members.FullName, dbo.Members.Address, dbo.Movies.MoviesRented, dbo.Salutations.Salutation
FROM dbo.Members INNER JOIN dbo.Movies ON dbo.Members.MovieId = dbo.Movies.MovieId INNER JOIN
dbo.Salutations ON dbo.Members.SalutationId = dbo.Salutations.SalutationId
GO  
-- Query the view  
SELECT [FullName]
      ,[Address]
      ,[MoviesRented]
      ,[Salutation]
  FROM [CinemaDB].[dbo].[CinemaView]