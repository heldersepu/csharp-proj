USE [contacttest]
GO

Sp_configure 'clr enable',1
GO
RECONFIGURE
GO

CREATE ASSEMBLY CLRAssembly
FROM 'C:\CLRAssembly\CLRAssembly.dll'
WITH PERMISSION_SET = SAFE
GO

EXEC sp_dbcmptlevel 'contacttest', 100
GO


CREATE FUNCTION [dbo].[CleanIntersections](@STRING [nvarchar](MAX))
RETURNS [nvarchar](MAX) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [CLRAssembly].[CLRAssembly.Geom].[CleanIntersections]
GO


CREATE FUNCTION [dbo].[Encrypt](@STRING [nvarchar](100), @KEY [nvarchar](100))
RETURNS [nvarchar](100) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [CLRAssembly].[CLRAssembly.Cryptography].[Encrypt]
GO

CREATE FUNCTION [dbo].[Decrypt](@STRING [nvarchar](100), @KEY [nvarchar](100))
RETURNS [nvarchar](100) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [CLRAssembly].[CLRAssembly.Cryptography].[Decrypt]
GO


CREATE FUNCTION [dbo].[RandomDate]()
RETURNS [nvarchar](100) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [CLRAssembly].[CLRAssembly.Randomness].[Date]
GO

CREATE FUNCTION [dbo].[RandomTime]()
RETURNS [nvarchar](100) WITH EXECUTE AS CALLER
AS
EXTERNAL NAME [CLRAssembly].[CLRAssembly.Randomness].[Time]
GO
