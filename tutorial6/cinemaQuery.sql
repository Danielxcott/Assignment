SELECT fullname as FULLNAME, address as ADDRESS, MoviesRented as MOVIERENTED, salutation as SALUTATION FROM [CinemaDB].[dbo].[Members] INNER JOIN [CinemaDB].[dbo].[Movies] ON [CinemaDB].[dbo].[Members].[MemberId] = [CinemaDB].[dbo].[Movies].[MemberId] INNER JOIN [CinemaDB].[dbo].[Salutations] ON [CinemaDB].[dbo].[Members].[SalutationId] = [CinemaDB].[dbo].[Salutations].[SalutationId]