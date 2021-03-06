USE [PInfos]
GO
/****** Object:  Table [dbo].[Infos]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Infos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](77) NOT NULL,
	[Info] [varbinary](max) NOT NULL,
	[Extencion] [char](4) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Correo] [nvarchar](77) NOT NULL,
	[Pass] [nvarchar](10) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_getUsuarioID]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_getUsuarioID] 
	@id int
AS
BEGIN
	select Id, nombre, correo, pass from Usuario where Id = @id
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_Login] 
	@correo  nvarchar(77),
	@pass  nvarchar(10)
AS
BEGIN
	select Id, nombre, correo, pass from Usuario where Correo = @correo and Pass = @pass
END
GO
/****** Object:  StoredProcedure [dbo].[usp_eliminar]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_eliminar](
@id int
)
as
begin

delete from Usuario where Id = @id

end
GO
/****** Object:  StoredProcedure [dbo].[usp_modificar]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[usp_modificar](
@Id int,
@Nombre nvarchar(50),
@Correo nvarchar(77),
@Pass nvarchar(10)
)
as
begin
update Usuario set
Nombre= @nombre,
Correo=@correo,
Pass=@pass
where Id=@id
end

GO
/****** Object:  StoredProcedure [dbo].[usp_Obtener]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[usp_Obtener]
as
begin
select Id, Nombre, Correo, REPLACE( Pass, Pass, '*****') from Usuario 
end
GO
/****** Object:  StoredProcedure [dbo].[usp_registrar]    Script Date: 13/11/2021 22:41:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_registrar](
@nombre nvarchar(50),
@Correo nvarchar(77),
@Pass nvarchar(10)
)
as
begin
insert into Usuario(Nombre, Correo, Pass)
values
(
@nombre,
@Correo,
@Pass
)
end

GO
