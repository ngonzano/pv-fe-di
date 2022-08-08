USE [DI_ZEUS_FE]
GO
/****** Object:  UserDefinedFunction [dbo].[Auto_Genera_Doc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----=============================================================
---- FUNCION QUE GENERA CODIGO DE DOCUMENTOS
----=============================================================
CREATE FUNCTION [dbo].[Auto_Genera_Doc](@Id_Tipo int)
Returns Char(7)
Begin 
	Declare @Nro as varchar(10)
	Select @Nro=RIGHT('0000000' + convert(varchar,Cast(Numero AS INT)+1),7)  From Tipo_Doc  
	Where Id_Tipo=@Id_tipo
	
	Return(@Nro)
End
GO
/****** Object:  UserDefinedFunction [dbo].[Auto_Genera_Prodcto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[Auto_Genera_Prodcto](@Id_Tipo int)
Returns Char(5)
Begin 
	Declare @Nro as varchar(5)
	Select @Nro=RIGHT('000000' + convert(varchar,Cast(Numero AS INT)+1),6)  From Tipo_Doc  
	Where Id_Tipo=@Id_tipo
	
	Return(@Nro)
End
GO
/****** Object:  Table [dbo].[Detalle_Kardex]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Kardex](
	[Id_krdx] [nvarchar](15) NOT NULL,
	[Item] [int] NOT NULL,
	[Fecha_Krdx] [datetime] NOT NULL,
	[Doc_Soporte] [nchar](20) NULL,
	[Det_Operacion] [varchar](180) NULL,
	[Cantidad_In] [real] NULL,
	[Precio_In] [real] NULL,
	[Total_In] [real] NULL,
	[Cantidad_Out] [real] NULL,
	[Precio_Out] [real] NULL,
	[Total_Out] [real] NULL,
	[Cantidad_Saldo] [real] NULL,
	[Promedio] [real] NULL,
	[Costo_Total_Saldo] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[Id_Pro] [nvarchar](15) NOT NULL,
	[IDPROVEE] [char](9) NOT NULL,
	[Descripcion_Larga] [nvarchar](150) NOT NULL,
	[Frank] [real] NULL,
	[Pre_CompraS] [real] NOT NULL,
	[Pre_Compra$] [real] NOT NULL,
	[Stock_Actual] [real] NOT NULL,
	[Id_Cat] [int] NOT NULL,
	[Id_Marca] [int] NOT NULL,
	[Foto] [varchar](180) NULL,
	[Pre_vntaxMenor] [real] NOT NULL,
	[Pre_vntaxMayor] [real] NOT NULL,
	[Pre_Vntadolar] [real] NOT NULL,
	[UndMedida] [char](6) NOT NULL,
	[PesoUnit] [real] NULL,
	[UtilidadUnit] [real] NULL,
	[TipoProdcto] [varchar](12) NULL,
	[Valor_porCant] [real] NULL,
	[Estado_Pro] [varchar](15) NULL,
	[FechaCreaProServ] [datetime] NULL,
 CONSTRAINT [PK__Producto__51E35AC99BBD3AF9] PRIMARY KEY CLUSTERED 
(
	[Id_Pro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KardexProducto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KardexProducto](
	[Id_krdx] [nvarchar](15) NOT NULL,
	[Id_Pro] [nvarchar](15) NOT NULL,
	[IDPROVEE] [char](9) NOT NULL,
	[FechaCre] [date] NULL,
	[EstadoKrdx] [varchar](12) NULL,
 CONSTRAINT [PK__KardexPr__92FC038E63AD5DF1] PRIMARY KEY CLUSTERED 
(
	[Id_krdx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Kardex_Detalle_Print]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE View [dbo].[V_Kardex_Detalle_Print]
As
select --dk.Item as item,
	   --CONVERT(date, FECHA_KRDX, 103) as fecha,
	   --dk.Doc_Soporte as docSoporte,
	   --dk.Det_Operacion as detMovimiento,
	   sum(dk.Cantidad_In) as entrada,
	   sum(dk.Cantidad_Out) as salida,
	   (sum(dk.Cantidad_In)-sum(dk.Cantidad_Out)) as saldo,
	   p.Descripcion_Larga as Descripcion_Larga,
	   p.UndMedida as UndMedida,
	   p.Pre_CompraS as PrecioCompra,
	   rtrim(p.Id_Pro) as Id_Pro,
	   sum(p.Pre_CompraS * dk.Cantidad_In) as CostoEntrada,
	   sum(p.Pre_CompraS * dk.Cantidad_Out) as CostoSalida,
	   (sum(p.Pre_CompraS * dk.Cantidad_In)-sum(p.Pre_CompraS * dk.Cantidad_Out)) as CostoSaldo,
	   min(Fecha_Krdx) as fechaIni,
	   max(Fecha_Krdx) as fechaFin
  from Detalle_Kardex dk inner join KardexProducto kp on kp.Id_krdx=dk.Id_krdx
						 inner join Productos p on p.Id_Pro=kp.Id_Pro and p.IDPROVEE=kp.IDPROVEE 
 group by p.Descripcion_Larga,p.UndMedida,p.Pre_CompraS,p.Id_Pro

GO
/****** Object:  Table [dbo].[Cotizacion]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cotizacion](
	[Id_Cotiza] [nvarchar](15) NOT NULL,
	[Id_Ped] [nvarchar](15) NOT NULL,
	[FechaCoti] [datetime] NULL,
	[Vigencia] [int] NULL,
	[TotalCotiza] [real] NULL,
	[Condiciones] [varchar](450) NULL,
	[PrecioconIgv] [char](4) NULL,
	[EstadoCoti] [varchar](15) NULL,
 CONSTRAINT [PK__Cotizaci__D4CCEEA96B2CF0EC] PRIMARY KEY CLUSTERED 
(
	[Id_Cotiza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_Pedido]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Pedido](
	[id_Ped] [nvarchar](15) NOT NULL,
	[Id_Pro] [nvarchar](15) NOT NULL,
	[Precio_ConIgv] [real] NULL,
	[Cantidad] [real] NULL,
	[Importe_ConIgv] [real] NULL,
	[Tipo_Prod] [varchar](20) NULL,
	[Und_Medida] [varchar](10) NULL,
	[Utilidad_Unit] [real] NULL,
	[TotalUtilidad] [real] NULL,
	[AfectoIGV] [nvarchar](15) NULL,
	[Precio_sinIgv] [real] NULL,
	[subtotal_sinIgv] [real] NULL,
	[Igv_subtotal] [real] NULL,
	[Estado] [nvarchar](20) NOT NULL,
	[P_Cant_Original] [real] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[Id_Cliente] [nvarchar](15) NOT NULL,
	[Razon_Social_Nombres] [nvarchar](250) NULL,
	[DNI] [char](18) NOT NULL,
	[Direccion] [nvarchar](150) NULL,
	[Telefono] [char](10) NULL,
	[E_Mail] [nvarchar](150) NULL,
	[Id_Dis] [int] NOT NULL,
	[Fcha_Ncmnto_Anivsrio] [datetime] NULL,
	[Contacto] [varchar](50) NULL,
	[Limit_Credit] [real] NULL,
	[Estado_Cli] [varchar](12) NULL,
	[foto] [varchar](180) NULL,
 CONSTRAINT [PK__Cliente__3DD0A8CBA770AEA2] PRIMARY KEY CLUSTERED 
(
	[Id_Cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[id_Ped] [nvarchar](15) NOT NULL,
	[Id_Cliente] [nvarchar](15) NOT NULL,
	[Fecha_Ped] [datetime] NULL,
	[SubTotal] [real] NULL,
	[IgvPed] [real] NULL,
	[TotalPed] [real] NULL,
	[id_usuario] [nvarchar](15) NULL,
	[TotalGancia] [real] NULL,
	[Estado_ped] [nvarchar](12) NULL,
	[subtotal_Gravado] [real] NULL,
	[IgvGravado] [real] NULL,
	[totalGravado] [real] NULL,
 CONSTRAINT [PK__Pedido__76CD552B916C5C0D] PRIMARY KEY CLUSTERED 
(
	[id_Ped] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios2](
	[Id_Usu] [nvarchar](15) NOT NULL,
	[Nombres] [nvarchar](50) NOT NULL,
	[Apellidos] [nvarchar](50) NOT NULL,
	[Id_Dis] [int] NOT NULL,
	[Usuario] [nvarchar](15) NOT NULL,
	[Contraseña] [varbinary](max) NOT NULL,
	[Ubicacion_Foto] [varchar](180) NOT NULL,
	[Fecha_Ncmiento] [date] NOT NULL,
	[Id_Rol] [int] NOT NULL,
	[Correo] [varchar](150) NULL,
	[Estado_Usu] [varchar](12) NULL,
	[salt] [varbinary](max) NOT NULL,
	[Cod_establecimiento] [nvarchar](8) NULL,
 CONSTRAINT [PK__Usuarios__52A331EBE58A50DC] PRIMARY KEY CLUSTERED 
(
	[Id_Usu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ__Usuarios__E3237CF7917B0BC0] UNIQUE NONCLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_Vista_Cotizacion_Pedido_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





--Vista:
CREATE View [dbo].[v_Vista_Cotizacion_Pedido_Detalle]
As
Select 
c.Id_Cotiza, c.FechaCoti,c.TotalCotiza ,c.EstadoCoti ,c.Vigencia ,c.Condiciones,
p.id_Ped ,p.Estado_Ped , p.TotalGancia , p.SubTotal ,
cl.Id_Cliente ,cl.Razon_Social_Nombres , cl.DNI, cl.Direccion ,
dp.Cantidad,dp.Und_Medida, dp.Precio_ConIgv,dp.Importe_ConIgv, dp.Utilidad_Unit , dp.TotalUtilidad , dp.Tipo_Prod ,
pr.Id_Pro , pr.Descripcion_Larga , pr.Stock_Actual,
u.Id_Usu , u.Nombres , u.Apellidos 
from Cotizacion c, Pedido p, Cliente cl, Detalle_Pedido dp, Productos pr, Usuarios2 u
where
C.Id_Ped =p.id_Ped and
p.Id_Cliente =cl.Id_Cliente and
p.id_usuario = u.Id_Usu and
p.id_Ped =dp.id_Ped and
dp.Id_Pro = pr.Id_Pro
GO
/****** Object:  Table [dbo].[Credito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Credito](
	[IdNotaCred] [nvarchar](15) NOT NULL,
	[Id_Doc] [nvarchar](15) NOT NULL,
	[Fecha_Credito] [datetime] NOT NULL,
	[Nom_Cliente] [varchar](50) NULL,
	[Total_Cre] [real] NULL,
	[Saldo_Pdnte] [real] NULL,
	[Fecha_Vncimnto] [date] NULL,
	[Estado_Cred] [varchar](13) NOT NULL,
 CONSTRAINT [PK__Credito__25E448027BB1E92F] PRIMARY KEY CLUSTERED 
(
	[IdNotaCred] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documento](
	[id_Doc] [nvarchar](15) NOT NULL,
	[id_Ped] [nvarchar](15) NOT NULL,
	[Id_Tipo] [int] NOT NULL,
	[Fecha_Emi] [datetime] NULL,
	[ImporteDoc] [real] NOT NULL,
	[TipoPago] [varchar](50) NULL,
	[Nro_Operacion] [nchar](20) NULL,
	[Id_Usu] [nvarchar](15) NOT NULL,
	[IgvDoc] [real] NULL,
	[TotalLetra] [nvarchar](280) NULL,
	[TotalGanancia] [real] NULL,
	[Estado_Doc] [varchar](13) NULL,
	[CDR_Sunat] [nvarchar](max) NULL,
	[Hash_CPE] [nvarchar](50) NULL,
	[EstadoBajada] [nvarchar](15) NULL,
	[NroTicket_Baja] [nvarchar](50) NULL,
	[Hash_CPE_Baja] [nvarchar](55) NULL,
 CONSTRAINT [PK__Document__6ECABA3ECEB75158] PRIMARY KEY CLUSTERED 
(
	[id_Doc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Documento_Credito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






--una vista:
CREATE View [dbo].[V_Documento_Credito]
as
select c.IdNotaCred,CONVERT(date, c.Fecha_Credito, 103) as Fecha_Credito , c.Nom_Cliente , c.Total_Cre , c.Saldo_Pdnte, c.Fecha_Vncimnto , c.Estado_Cred ,
d.id_Doc , d.Fecha_Emi ,d.ImporteDoc, d.Estado_Doc,d.Id_Usu,
p.id_Ped, p.TotalGancia, p.TotalPed, p.Estado_Ped, 
k.Id_Cliente, k.Razon_Social_Nombres, k.Limit_Credit, k.DNI

from Credito c, Documento d, Pedido p , Cliente k
where
c.id_Doc=d.id_Doc and
d.id_Ped = p.Id_Ped and
p.Id_Cliente= k.Id_Cliente 

GO
/****** Object:  View [dbo].[v_Vista_Cotizacion_Pedido_Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





--=========Ahroa otra vista mas personalizada, para el explorador de cotizaciones
CREATE View [dbo].[v_Vista_Cotizacion_Pedido_Cliente]
As
Select 
c.Id_Cotiza,CONVERT(date, c.FechaCoti, 103) AS FechaCoti,c.TotalCotiza ,c.EstadoCoti , c.Vigencia , c.PrecioconIgv, c.Condiciones ,
p.id_Ped ,p.Estado_Ped , p.TotalPed , p.SubTotal ,
cl.Id_Cliente ,cl.Razon_Social_Nombres , cl.DNI, cl.Direccion ,
u.Id_Usu , u.Nombres , u.Apellidos,U.Usuario 
from Cotizacion c, Pedido p, Cliente cl, Usuarios2 u
where
C.Id_Ped =p.id_Ped and
p.Id_Cliente =cl.Id_Cliente and
p.id_usuario = u.Id_Usu 
GO
/****** Object:  Table [dbo].[NotaCredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotaCredito](
	[Id_Cre] [nvarchar](15) NOT NULL,
	[id_Doc] [nvarchar](15) NOT NULL,
	[Tipocomprobnte] [varchar](20) NULL,
	[OtrosDatos] [varchar](150) NULL,
	[Fecha_Emision] [date] NOT NULL,
	[Vlr_Total] [real] NOT NULL,
	[Igv_C] [real] NULL,
	[SubTotal_C] [real] NULL,
	[Id_Usu] [nvarchar](15) NOT NULL,
	[Motivo_Emis] [varchar](50) NULL,
	[Estado_Cr] [varchar](18) NULL,
	[SonCre] [varchar](150) NULL,
	[EstadoDinero] [varchar](15) NULL,
	[Id_Cliente] [nvarchar](15) NULL,
	[CdrSunat_NotaCre] [varchar](20) NULL,
	[HashCpe_NotaCre] [varchar](60) NULL,
	[NC_Enviado_Sunat] [nvarchar](15) NULL,
 CONSTRAINT [PK_notaCred] PRIMARY KEY CLUSTERED 
(
	[Id_Cre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_ista_Notacredito_Gnral]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE View [dbo].[V_ista_Notacredito_Gnral]
As
	Select nc.Id_Cre,nc.id_Doc,NC.Tipocomprobnte,NC.OtrosDatos ,
	nc.Fecha_Emision,nc.Vlr_Total ,nc.Igv_C,NC.SubTotal_C,NC.Motivo_Emis , nc.Estado_Cr  ,NC.sonCre,NC.EstadoDinero,nc.NC_Enviado_Sunat,
	NC.CdrSunat_NotaCre, NC.HashCpe_NotaCre,
	u.Id_Usu, u.Nombres, u.Apellidos , u.Ubicacion_Foto ,
 	C.Id_Cliente,C.Razon_Social_Nombres, C.DNI,C. Direccion        
	From NotaCredito NC,  Usuarios2 U, Cliente C
	where
	NC.Id_Cliente=C.Id_Cliente and 
	nc.Id_Usu =U.Id_Usu 
GO
/****** Object:  Table [dbo].[Detalle_NotaCredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_NotaCredito](
	[Id_Cre] [nvarchar](15) NOT NULL,
	[CantidadC] [real] NULL,
	[Id_Pro] [nvarchar](15) NULL,
	[PrecioUniC] [real] NULL,
	[ImporteC] [real] NULL,
	[TipoProdctonc] [varchar](20) NULL,
	[DetalleNotaCredi] [varchar](150) NULL,
	[Cant_Origen] [real] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Listado_Notacredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE View [dbo].[V_Listado_Notacredito]
As
	Select nc.Id_Cre,nc.id_Doc,NC.Tipocomprobnte,NC.OtrosDatos ,
		nc.Fecha_Emision,nc.Vlr_Total ,nc.Igv_C,NC.SubTotal_C,NC.Motivo_Emis , nc.Estado_Cr  ,NC.sonCre,NC.CdrSunat_NotaCre, NC.HashCpe_NotaCre,NC.NC_Enviado_Sunat,
		Det.Id_Pro, Det.PrecioUniC , Det.CantidadC, Det.ImporteC ,det.TipoProdctonc,det.DetalleNotaCredi ,
 		C.Id_Cliente,C.Razon_Social_Nombres, C.DNI,C. Direccion ,
		U.Id_Usu, U.Nombres, U.Apellidos  
	From NotaCredito NC, Detalle_NotaCredito  Det, Cliente C, Usuarios2 U
	where 
	NC.Id_Cliente=C.Id_Cliente and
	NC.Id_Usu=U.Id_Usu and
	NC.Id_Cre =Det.Id_Cre  	
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[IDPROVEE] [char](9) NOT NULL,
	[NOMBRE] [varchar](50) NOT NULL,
	[DIRECCION] [varchar](150) NULL,
	[TELEFONO] [nchar](15) NULL,
	[RUBRO] [varchar](50) NULL,
	[RUC] [nchar](20) NOT NULL,
	[CORREO] [varchar](150) NULL,
	[CONTACTO] [varchar](50) NULL,
	[FOTO_LOGO] [varchar](180) NOT NULL,
	[ESTADO_PROVDR] [varchar](12) NULL,
 CONSTRAINT [PK__Proveedo__A24D5EEA4797950D] PRIMARY KEY CLUSTERED 
(
	[IDPROVEE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Kardex_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create View [dbo].[V_Kardex_Detalle]
AS
SELECT 
KR.Id_krdx , KR.EstadoKrdx ,
x.IDPROVEE , x.NOMBRE , x.DIRECCION , x.CONTACTO , x.TELEFONO,
DT.Item, DT.Fecha_Krdx , DT.Doc_Soporte , DT.Det_Operacion , DT.Cantidad_In , DT.Precio_In , DT.Total_In ,
DT.Cantidad_Out , DT.Precio_Out , DT.Total_Out , DT.Cantidad_Saldo , DT.Promedio , DT.Costo_Total_Saldo ,
PR.Id_Pro , PR.Descripcion_Larga , PR.Stock_Actual 
FROM KardexProducto KR , Detalle_Kardex  DT , Productos PR , Proveedor x
WHERE 
KR.Id_krdx = DT.Id_krdx AND
KR.Id_Pro = PR.Id_Pro 
GO
/****** Object:  View [dbo].[V_Listado_Pedido_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--consultas:
CREATE View [dbo].[V_Listado_Pedido_Detalle]
As
	Select Ped.Id_Ped,Cli.id_cliente,Cli.Razon_Social_Nombres,
		Cli.DNI ,Cli.Direccion,Cli.Telefono, Cli.E_mail,
		Ped.SubTotal,Ped.Fecha_Ped,Ped.TotalPed, ped.Estado_Ped ,ped.TotalGancia ,
		Ped.id_usuario,
		Det.Precio_ConIgv, Det.Cantidad, Det.Importe_ConIgv,det.Tipo_Prod ,det.Und_Medida,Det.Utilidad_Unit ,Det.TotalUtilidad,
		Pro.Descripcion_Larga, Pro.Id_Pro ,Pro.Stock_Actual     
	From Pedido Ped, Detalle_Pedido Det, Productos Pro, Cliente Cli 
	where Ped.Id_Ped=Det.Id_Ped And
		Ped.id_cliente=Cli.id_cliente And
		Det.Id_Pro=Pro.Id_Pro
GO
/****** Object:  View [dbo].[V_Pedidos_Cliente_General]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--PEdidos para el Explorador:
CREATE view [dbo].[V_Pedidos_Cliente_General]
					as
					select P.id_Ped , P.SubTotal , P.TotalPed  , P.Fecha_Ped , p.Estado_Ped ,P.TotalGancia ,
							C.Id_Cliente , C.Razon_Social_Nombres , C.DNI,C.Estado_Cli ,
							u.Id_Usu , u.Nombres 
							from Pedido P,Cliente C,Usuarios2 U
					Where
							p.Id_Cliente = c.Id_Cliente  and
							p.id_usuario = u.Id_Usu 
GO
/****** Object:  Table [dbo].[Detalle_Temporal]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Temporal](
	[codTem] [nvarchar](15) NOT NULL,
	[CodPro] [nvarchar](15) NULL,
	[cantidad] [nchar](20) NULL,
	[Producto] [varchar](60) NULL,
	[Pre_Unt] [varchar](50) NULL,
	[ImporteT] [varchar](50) NULL,
	[UnidMedida] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Temporal]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Temporal](
	[codTem] [nvarchar](20) NOT NULL,
	[FechaEmi] [varchar](20) NULL,
	[cliente] [varchar](150) NULL,
	[Ruc] [varchar](50) NULL,
	[Direccion] [varchar](150) NULL,
	[SubTtal] [varchar](50) NULL,
	[IgvT] [varchar](50) NULL,
	[TotalT] [varchar](50) NULL,
	[SonT] [varchar](200) NULL,
	[Vendedor] [varchar](120) NULL,
	[CodigoQR] [varbinary](max) NULL,
	[tipoComprobante] [nvarchar](50) NULL,
	[hash_cpe] [nvarchar](100) NULL,
	[tipoPago] [nvarchar](50) NULL,
	[motivoEmis] [nvarchar](100) NULL,
	[forma_pago] [nvarchar](10) NULL,
	[monto_deuda] [nvarchar](10) NULL,
	[fecha_venc_credito] [nvarchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Temporales_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View  [dbo].[V_Temporales_Detalle]
As
Select T.CodTem , T.FechaEmi,T.cliente,T.Ruc,T.Direccion ,T.SubTtal , T.IgvT,T.TotalT,T.SonT , T.Vendedor ,t.codigoQR,		
		D.CodPro ,D.Producto ,D.Pre_Unt , D.ImporteT , D.cantidad,
		t.tipoComprobante,t.hash_cpe,t.tipoPago,t.motivoEmis,t.forma_pago,t.monto_deuda,t.fecha_venc_credito,d.UnidMedida
From Temporal T, Detalle_Temporal D
Where D.codTem = T.CodTem 
GO
/****** Object:  Table [dbo].[DocumentoCompras]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocumentoCompras](
	[Id_DocComp] [nvarchar](15) NOT NULL,
	[NroFac_Fisico] [char](20) NOT NULL,
	[IDPROVEE] [char](9) NOT NULL,
	[SubTotal_ingre] [real] NULL,
	[Fecha_Ingre] [datetime] NULL,
	[Total_Ingre] [real] NOT NULL,
	[id_Usu] [nvarchar](15) NOT NULL,
	[ModalidadPago] [varchar](50) NOT NULL,
	[TiempoEspera] [int] NULL,
	[Fecha_Vencimiento] [datetime] NULL,
	[Estado_Ingre] [varchar](20) NULL,
	[Recibiconforme] [bit] NULL,
	[Datos_Adicional] [nvarchar](150) NULL,
	[TipoDoc_Compra] [varchar](12) NOT NULL,
	[Tipo_Ingreso] [varchar](30) NULL,
 CONSTRAINT [PK__Document__452875B11A2ACAA1] PRIMARY KEY CLUSTERED 
(
	[Id_DocComp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Detalle_DocumCompra]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_DocumCompra](
	[Id_DocComp] [nvarchar](15) NULL,
	[Id_Pro] [nvarchar](15) NULL,
	[PrecioUnit] [real] NULL,
	[Cantidad] [real] NULL,
	[Importe] [real] NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Documentos_Compra_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Vista:
create View [dbo].[V_Documentos_Compra_Detalle]
As
	Select 
	c.Id_DocComp , c.NroFac_Fisico ,c.SubTotal_ingre , c.Fecha_Ingre , c.Total_Ingre , c.ModalidadPago, c.TiempoEspera , c.Fecha_Vencimiento ,
	c.Estado_Ingre ,c.Recibiconforme , c.Datos_Adicional , c.TipoDoc_Compra ,
	P.IDPROVEE ,P.NOMBRE ,P.RUC,
	Det.PrecioUnit , Det.Cantidad, Det.Importe,
	Pro.Id_Pro, Pro.Descripcion_Larga, pro.Stock_Actual,pro.Pre_Compra$ , pro.Pre_CompraS           
	From
	DocumentoCompras c, Detalle_DocumCompra Det, Productos Pro, Proveedor P
	where
	c.IDPROVEE =p.IDPROVEE and
	c.Id_DocComp =Det.Id_DocComp  And
	Det.Id_Pro=Pro.Id_Pro
GO
/****** Object:  View [dbo].[V_Documentos_CompraPrincipal]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--Una Vista solo de las Tablas Principales o Master:
CREATE View [dbo].[V_Documentos_CompraPrincipal]
As
	Select 
	c.Id_DocComp , c.NroFac_Fisico ,c.SubTotal_ingre , CONVERT(date, c.Fecha_Ingre, 103) as Fecha_Ingre , c.Total_Ingre , c.ModalidadPago, c.TiempoEspera , c.Fecha_Vencimiento ,
	c.Estado_Ingre ,c.Recibiconforme , c.Datos_Adicional , c.TipoDoc_Compra ,
	P.IDPROVEE ,P.NOMBRE ,P.RUC,c.Tipo_Ingreso,
	u.Id_Usu , u.Nombres , u.Apellidos , u.Usuario , u.Ubicacion_Foto 	   
	From
	DocumentoCompras c, Proveedor P, Usuarios2 u
	where
	c.IDPROVEE =p.IDPROVEE and
	c.id_Usu = u.Id_Usu 
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id_Cat] [int] IDENTITY(1,1) NOT NULL,
	[Categoria] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Cat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marcas]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marcas](
	[Id_Marca] [int] IDENTITY(1,1) NOT NULL,
	[Marca] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Marca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_Productos_yDependientes]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_Productos_yDependientes]
 AS
SELECT      rtrim(p.Id_Pro) as Id_Pro,--0 
			p.Descripcion_Larga, --1
			p.Frank, --2
			p.Pre_CompraS,--3 
			p.Pre_Compra$, --4
			p.Stock_Actual, --5
			p.Foto, --6
			p.Pre_vntaxMenor,--7 
			p.Pre_vntaxMayor, --8
			p.Pre_Vntadolar, --9
			p.UndMedida, --10
			p.PesoUnit, --11
			p.UtilidadUnit, --12
			p.TipoProdcto, --13
			p.Valor_porCant, --14
            p.Estado_Pro, --15
			x.IDPROVEE, --16
			x.NOMBRE, --17
			x.DIRECCION, --18
			x.TELEFONO, --19
			c.Id_Cat, --20
			c.Categoria, --21
			m.Id_Marca, --22
			m.Marca --23
FROM            dbo.Productos AS p INNER JOIN
                         dbo.Proveedor AS x ON p.IDPROVEE = x.IDPROVEE INNER JOIN
                         dbo.Categorias AS c ON p.Id_Cat = c.Id_Cat INNER JOIN
                         dbo.Marcas AS m ON p.Id_Marca = m.Id_Marca
GO
/****** Object:  Table [dbo].[Cierre_Caja]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cierre_Caja](
	[Id_cierre] [nvarchar](15) NOT NULL,
	[Fecha_Cierre] [datetime] NOT NULL,
	[Apertura_Caja] [real] NOT NULL,
	[Total_Ingreso] [real] NULL,
	[TotalEgreso] [real] NULL,
	[Id_Usu] [nvarchar](15) NULL,
	[TodoDeposito] [real] NULL,
	[Gananciadeldia] [real] NULL,
	[TotalEntregado] [real] NULL,
	[SaldoSiguiente] [real] NULL,
	[TotalFactura] [real] NULL,
	[TotalBoleta] [real] NULL,
	[TotalNotaVenta] [real] NULL,
	[TotalCreditoCobrado] [real] NULL,
	[TotalCreditoEmitido] [real] NULL,
	[Estado_cierre] [varchar](13) NULL,
 CONSTRAINT [PK__Cierre_C__B5D9E395F2A213A1] PRIMARY KEY CLUSTERED 
(
	[Id_cierre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[v_cierreCaja_usu]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--vista:
CREATE View [dbo].[v_cierreCaja_usu]
as
select c.Id_cierre,c.Fecha_Cierre , c.Apertura_Caja , c.Total_Ingreso,
c.TotalEgreso , c.TodoDeposito, c.Estado_cierre ,C.Gananciadeldia ,C.TotalEntregado, C.SaldoSiguiente,C.TotalFactura,
C.TotalBoleta, C.TotalNotaVenta, C.TotalCreditoCobrado,C.TotalCreditoEmitido,
u.Id_Usu , u.Nombres , u.Apellidos 
from Cierre_Caja c, Usuarios2 u
where
c.Id_Usu = u.Usuario
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[Idcaja] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_Caja] [date] NULL,
	[Tipo_Caja] [varchar](50) NULL,
	[Concepto] [nvarchar](190) NULL,
	[De_Para] [varchar](180) NULL,
	[Nro_Doc] [char](20) NULL,
	[ImporteCaja] [real] NULL,
	[Id_Usu] [nvarchar](15) NULL,
	[TotalUti] [real] NULL,
	[TipoPago] [varchar](13) NULL,
	[GeneradoPor] [varchar](15) NULL,
	[EstadoCaja] [varchar](13) NULL,
 CONSTRAINT [PK__Caja__08DCF1BC548FDD05] PRIMARY KEY CLUSTERED 
(
	[Idcaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Caja_Usuario]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View [dbo].[V_Caja_Usuario]
As
Select 
Cj.Idcaja , CONVERT(date, Cj.Fecha_Caja, 103) as Fecha_Caja, Cj.Tipo_Caja , Cj.Concepto , Cj.De_Para , Cj.Nro_Doc  , Cj.ImporteCaja , Cj.TipoPago ,
Cj.TotalUti,cj.EstadoCaja ,Cj.GeneradoPor,
Ui.Id_Usu , Ui.Nombres , Ui.Apellidos, ui.Usuario 
 from Caja Cj, Usuarios2 Ui
Where
cj.Id_Usu = Ui.Id_Usu 
GO
/****** Object:  Table [dbo].[Tipo_Doc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tipo_Doc](
	[Id_Tipo] [int] NOT NULL,
	[Documento] [nvarchar](50) NULL,
	[Serie] [nvarchar](4) NULL,
	[Numero] [nvarchar](10) NULL,
	[Estado_TiDoc] [varchar](12) NULL,
 CONSTRAINT [PK__Tipo_Doc__064163922DB9A596] PRIMARY KEY CLUSTERED 
(
	[Id_Tipo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Listado_Documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--Vista Genral de Todo Documento
CREATE View [dbo].[V_Listado_Documento]
As
Select Ped.Fecha_Ped as fecha_Hora,Doc.Id_Doc, doc.TipoPago , doc.ImporteDoc,CONVERT(date, doc.Fecha_Emi, 103) AS Fecha_Emi ,Doc.IgvDoc , doc.Estado_doc  ,Doc.Nro_Operacion ,
doc.TotalLetra, doc.TotalGanancia,doc.CDR_Sunat,doc.Hash_CPE,doc.EstadoBajada,doc.NroTicket_Baja,doc.Hash_CPE_Baja,
Cli.id_cliente,Cli.Razon_Social_Nombres, Cli.DNI ,Cli.Direccion,
CONVERT(date, Ped.Fecha_Ped, 103) as Fecha_Ped,Ped.SubTotal,Ped.TotalPed,Ped.Estado_Ped,Ped.id_Ped,subtotal_Gravado,IgvGravado,totalGravado,
t.Id_Tipo , t.Documento ,U.Id_Usu , U.Nombres , U.Apellidos, U.Nombres +' '+ U.Apellidos as NombreCompletoUsu       
From
Documento Doc, Pedido Ped,Cliente Cli , Tipo_Doc t, Usuarios2 U
where 
Doc.id_Ped  = Ped.id_Ped And
Ped.id_cliente=Cli.id_cliente and
doc.Id_Tipo = t.Id_Tipo and
Ped.id_usuario = u.Id_Usu
GO
/****** Object:  View [dbo].[V_Listado_Documento_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE View [dbo].[V_Listado_Documento_Detalle]
As

Select Doc.Id_Doc,Ped.id_Ped,Cli.id_cliente,Cli.Razon_Social_Nombres,Cli.DNI ,Cli.Direccion,Doc.ImporteDoc ,
		Ped.Fecha_Ped,Ped.SubTotal,Ped.TotalPed,
		Ped.id_usuario,Ped.Estado_Ped ,Ped.TotalGancia ,		
		Det.Precio_ConIgv, Det.Cantidad, Det.Importe_ConIgv,Det.Und_Medida ,Det.Tipo_Prod,Det.Utilidad_Unit,Det.TotalUtilidad,
		det.AfectoIGV,det.Precio_sinIgv,det.subtotal_sinIgv,det.Igv_subtotal,
		Pro.Id_Pro , Pro.Descripcion_Larga, Pro.Stock_Actual ,det.P_Cant_Original,
		doc.TotalLetra ,doc.IgvDoc , doc.Estado_doc  ,doc.Fecha_Emi, doc.Nro_Operacion , doc.TipoPago , doc.totalganancia,CDR_Sunat,
		tp.Id_Tipo , tp.Documento ,det.estado
			          
	From	Documento Doc inner join Pedido Ped on Doc.id_Ped  = Ped.id_Ped
						  inner join Detalle_Pedido Det on Det.Id_Ped = Ped.Id_Ped
						  inner join Tipo_Doc tp on Doc.Id_Tipo = Tp.Id_Tipo
						  inner join Cliente Cli on Ped.id_cliente=Cli.id_cliente
						  inner join Productos Pro on Det.Id_Pro=Pro.Id_Pro
	
GO
/****** Object:  Table [dbo].[Detalle_Credito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detalle_Credito](
	[Id_DetCred] [int] IDENTITY(1,1) NOT NULL,
	[IdNotaCred] [nvarchar](15) NOT NULL,
	[A_cuenta] [real] NOT NULL,
	[Saldo_Actual] [real] NULL,
	[Fecha_Pago] [datetime] NULL,
	[TipoPago] [varchar](50) NULL,
	[Nro_Opera_Coment] [nvarchar](180) NULL,
	[Id_Usu] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK__Detalle___ED16654A46A85C68] PRIMARY KEY CLUSTERED 
(
	[Id_DetCred] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Documento_Credito_yDetalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--una vista:
CREATE View [dbo].[V_Documento_Credito_yDetalle]
as
select c.IdNotaCred,CONVERT(date, c.Fecha_Credito, 103) as Fecha_Credito , c.Nom_Cliente , c.Total_Cre , c.Saldo_Pdnte, c.Fecha_Vncimnto , c.Estado_Cred ,
d.id_Doc , d.Fecha_Emi ,d.ImporteDoc, d.Estado_Doc,d.Id_Usu,
p.id_Ped, p.TotalGancia, p.TotalPed, p.Estado_Ped, 
k.Id_Cliente, k.Razon_Social_Nombres, k.Limit_Credit, k.DNI,
dc.Fecha_Pago, dc.saldo_actual,dc.A_cuenta,Nro_Opera_Coment
from Credito c, Documento d, Pedido p , Cliente k,Detalle_Credito dc
where
c.id_Doc=d.id_Doc and
d.id_Ped = p.Id_Ped and
p.Id_Cliente= k.Id_Cliente 
and c.IdNotaCred=dc.IdNotaCred

GO
/****** Object:  View [dbo].[V_Kardex_Detalle2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE View [dbo].[V_Kardex_Detalle2]
As
select dk.Item as item,
	   CONVERT(date, FECHA_KRDX, 103) as fecha,
	   dk.Doc_Soporte as docSoporte,
	   dk.Det_Operacion as detMovimiento,
	   dk.Cantidad_In as entrada,
	   dk.Cantidad_Out as salida,
	   dk.Cantidad_Saldo as saldo,
	   p.Descripcion_Larga as Descripcion_Larga,
	   p.UndMedida as UndMedida,
	   p.Pre_CompraS as PrecioCompra,
	   p.Id_Pro as Id_Pro,
	   sum(p.Pre_CompraS * dk.Cantidad_In) as costoEntrada
 
  from Detalle_Kardex dk inner join KardexProducto kp on kp.Id_krdx=dk.Id_krdx
						 inner join Productos p on p.Id_Pro=kp.Id_Pro and p.IDPROVEE=kp.IDPROVEE
 group by dk.Item,FECHA_KRDX,dk.Doc_Soporte,dk.Det_Operacion,dk.Cantidad_In,dk.Cantidad_Out,dk.Cantidad_Saldo,p.Descripcion_Larga,p.UndMedida,p.Pre_CompraS,p.Id_Pro

GO
/****** Object:  Table [dbo].[Distrito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Distrito](
	[Id_Dis] [int] IDENTITY(1,1) NOT NULL,
	[Distrito] [nvarchar](50) NULL,
	[Estado_Dis] [varchar](12) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Dis] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Clientes_Distritos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create View [dbo].[V_Clientes_Distritos]
As
Select Id_Cliente,Razon_Social_Nombres,DNI ,
Direccion,telefono, e_mail,Cliente.Id_Dis,Distrito, Fcha_Ncmnto_Anivsrio ,Contacto,Limit_Credit,Estado_cli
From  Cliente
	INNER JOIN Distrito  On Cliente.Id_Dis = Distrito .Id_Dis 
Where 
	Cliente.Estado_cli ='Activo'
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id_Rol] [int] NOT NULL,
	[Rol] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[V_Usuarios_Roles2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[V_Usuarios_Roles2]
As
Select Id_Usu,u.Nombres , u.Apellidos ,u.Usuario ,u.Contraseña ,u.Ubicacion_Foto,
U.Id_Rol,R.Rol  ,U.Estado_usu
From Usuarios2 U, Roles R
Where U.Id_Rol=R.Id_Rol
GO
/****** Object:  View [dbo].[V_Documento_Credito_Print2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





--una vista:
CREATE View [dbo].[V_Documento_Credito_Print2]
as
select c.IdNotaCred,CONVERT(date, c.Fecha_Credito, 103) as Fecha_Credito , c.Nom_Cliente , c.Total_Cre , c.Saldo_Pdnte, c.Fecha_Vncimnto , c.Estado_Cred ,
d.id_Doc , d.Fecha_Emi ,d.ImporteDoc, d.Estado_Doc,d.Id_Usu,
p.id_Ped, p.TotalGancia, p.TotalPed, p.Estado_Ped, 
k.Id_Cliente, k.Razon_Social_Nombres, k.Limit_Credit, k.DNI
,dc.A_cuenta,CONVERT(date, Fecha_Pago, 103) AS Fecha_Pago,dc.Saldo_Actual,dc.Id_DetCred
from Credito c, Documento d, Pedido p , Cliente k,Detalle_Credito dc
where
c.id_Doc=d.id_Doc and
d.id_Ped = p.Id_Ped and
p.Id_Cliente= k.Id_Cliente 
and c.IdNotaCred=dc.IdNotaCred
GO
/****** Object:  Table [dbo].[Catalogo]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Catalogo](
	[codigo] [nvarchar](5) NULL,
	[descripcion] [nvarchar](255) NULL,
	[tipo_documento] [nvarchar](200) NULL,
	[cod_tipo_documento] [nvarchar](12) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Det_guiaRemision]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Det_guiaRemision](
	[NRO_COMPROBANTE] [nvarchar](20) NULL,
	[ITEM] [int] NULL,
	[UNIDAD_MEDIDA] [nvarchar](10) NULL,
	[CANTIDAD] [decimal](6, 2) NULL,
	[DESCRIPCION] [nvarchar](max) NULL,
	[CODIGO_PROD] [nvarchar](14) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Establecimiento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Establecimiento](
	[Cod_establecimiento] [nvarchar](8) NULL,
	[descripcion] [nvarchar](max) NULL,
	[direccion] [nvarchar](max) NULL,
	[UBIGEO] [nvarchar](6) NULL,
	[estado] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GuiaRemision]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GuiaRemision](
	[NRO_COMPROBANTE] [nvarchar](20) NULL,
	[FECHA_DOCUMENTO] [datetime] NULL,
	[COD_TIPO_DOCUMENTO] [nvarchar](2) NULL,
	[NOTA] [nvarchar](255) NULL,
	[TIPO_DOCUMENTO_EMPRESA] [nvarchar](2) NULL,
	[NRO_DOCUMENTO_EMPRESA] [nvarchar](11) NULL,
	[RAZON_SOCIAL_EMPRESA] [nvarchar](255) NULL,
	[Id_Cliente] [nvarchar](15) NULL,
	[ITEM_ENVIO] [nvarchar](11) NULL,
	[COD_MOTIVO_TRASLADO] [nvarchar](2) NULL,
	[COD_UND_PESO_BRUTO] [nvarchar](5) NULL,
	[PESO_BRUTO] [decimal](5, 2) NULL,
	[TOTAL_BULTOS] [decimal](5, 2) NULL,
	[COD_MODALIDAD_TRASLADO] [nvarchar](2) NULL,
	[FECHA_INICIO] [datetime] NULL,
	[TIPO_DOCUMENTO_TRANSPORTISTA] [nvarchar](2) NULL,
	[NRO_DOCUMENTO_TRANSPORTISTA] [nvarchar](11) NULL,
	[RAZON_SOCIAL_TRANSPORTISTA] [nvarchar](max) NULL,
	[PLACA_VEHICULO] [nvarchar](8) NULL,
	[COD_TIPO_DOC_CHOFER] [nvarchar](2) NULL,
	[NRO_DOC_CHOFER] [nvarchar](11) NULL,
	[COD_UBIGEO_DESTINO] [nvarchar](8) NULL,
	[DIRECCION_DESTINO] [nvarchar](max) NULL,
	[PLACA_CARRETA] [nvarchar](8) NULL,
	[COD_UBIGEO_ORIGEN] [nvarchar](8) NULL,
	[DIRECCION_ORIGEN] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu_xUsu]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu_xUsu](
	[Id_menuxusu] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_menu] [varchar](50) NOT NULL,
	[Id_usu] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK__Menu_xUs__C8FF14F0E5B08088] PRIMARY KEY CLUSTERED 
(
	[Id_menuxusu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MiEmpresa]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MiEmpresa](
	[idrancho] [int] NOT NULL,
	[nombrerancho] [nvarchar](300) NULL,
	[nroRuc] [nvarchar](20) NULL,
	[direccionran] [nvarchar](300) NULL,
	[correo] [nvarchar](200) NULL,
	[clavecorreo] [nvarchar](20) NULL,
	[clavesol] [nvarchar](20) NULL,
	[usuariosol] [nvarchar](20) NULL,
	[clavecertificado] [nvarchar](200) NULL,
	[obs] [nvarchar](300) NULL,
	[ubigeo] [nvarchar](6) NULL,
PRIMARY KEY CLUSTERED 
(
	[idrancho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mot_traslado]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mot_traslado](
	[COD_MOTIVO_TRASLADO] [nvarchar](2) NULL,
	[DESCRIPCION_MOTIVO_TRASLADO] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ubigeo]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ubigeo](
	[idUbigeo] [nvarchar](6) NULL,
	[Departamento] [nvarchar](150) NULL,
	[Provincia] [nvarchar](150) NULL,
	[Distrito] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UnidadMedida]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UnidadMedida](
	[codigo] [nvarchar](10) NULL,
	[descripcion] [nvarchar](200) NULL,
	[estado] [nvarchar](15) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ValeCompra]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ValeCompra](
	[IdVale] [nvarchar](15) NOT NULL,
	[Id_Cliente] [nvarchar](15) NOT NULL,
	[NroDoc] [nvarchar](15) NOT NULL,
	[ImporteVale] [real] NULL,
	[DetalleVale] [varchar](220) NOT NULL,
	[EstadoVale] [varchar](12) NOT NULL,
 CONSTRAINT [PK__ValeComp__A84977C224666F6C] PRIMARY KEY CLUSTERED 
(
	[IdVale] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detalle_NotaCredito] ADD  CONSTRAINT [DF_Detalle_NotaCredito_Cant_Origen]  DEFAULT ((0)) FOR [Cant_Origen]
GO
ALTER TABLE [dbo].[Detalle_Pedido] ADD  CONSTRAINT [DF_Detalle_Pedido_Estado]  DEFAULT (N'Salida Venta') FOR [Estado]
GO
ALTER TABLE [dbo].[Detalle_Pedido] ADD  CONSTRAINT [DF_Detalle_Pedido_P_Cant_Original]  DEFAULT ((0)) FOR [P_Cant_Original]
GO
ALTER TABLE [dbo].[Establecimiento] ADD  CONSTRAINT [DF_Establecimiento_estado]  DEFAULT ((1)) FOR [estado]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_UndMedida]  DEFAULT ('NIU') FOR [UndMedida]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_FechaCreaProServ]  DEFAULT (getdate()) FOR [FechaCreaProServ]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cli_Dis] FOREIGN KEY([Id_Dis])
REFERENCES [dbo].[Distrito] ([Id_Dis])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cli_Dis]
GO
ALTER TABLE [dbo].[Cotizacion]  WITH CHECK ADD  CONSTRAINT [FK_coti_cli] FOREIGN KEY([Id_Ped])
REFERENCES [dbo].[Pedido] ([id_Ped])
GO
ALTER TABLE [dbo].[Cotizacion] CHECK CONSTRAINT [FK_coti_cli]
GO
ALTER TABLE [dbo].[Credito]  WITH CHECK ADD  CONSTRAINT [FK_cre_doc] FOREIGN KEY([Id_Doc])
REFERENCES [dbo].[Documento] ([id_Doc])
GO
ALTER TABLE [dbo].[Credito] CHECK CONSTRAINT [FK_cre_doc]
GO
ALTER TABLE [dbo].[Detalle_Credito]  WITH CHECK ADD  CONSTRAINT [FK_cre_det] FOREIGN KEY([IdNotaCred])
REFERENCES [dbo].[Credito] ([IdNotaCred])
GO
ALTER TABLE [dbo].[Detalle_Credito] CHECK CONSTRAINT [FK_cre_det]
GO
ALTER TABLE [dbo].[Detalle_DocumCompra]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_DocumCompra_DocumentoCompras] FOREIGN KEY([Id_DocComp])
REFERENCES [dbo].[DocumentoCompras] ([Id_DocComp])
GO
ALTER TABLE [dbo].[Detalle_DocumCompra] CHECK CONSTRAINT [FK_Detalle_DocumCompra_DocumentoCompras]
GO
ALTER TABLE [dbo].[Detalle_DocumCompra]  WITH CHECK ADD  CONSTRAINT [FK_Detalle_DocumCompra_Productos] FOREIGN KEY([Id_Pro])
REFERENCES [dbo].[Productos] ([Id_Pro])
GO
ALTER TABLE [dbo].[Detalle_DocumCompra] CHECK CONSTRAINT [FK_Detalle_DocumCompra_Productos]
GO
ALTER TABLE [dbo].[Detalle_Kardex]  WITH CHECK ADD  CONSTRAINT [FK_Kar_det] FOREIGN KEY([Id_krdx])
REFERENCES [dbo].[KardexProducto] ([Id_krdx])
GO
ALTER TABLE [dbo].[Detalle_Kardex] CHECK CONSTRAINT [FK_Kar_det]
GO
ALTER TABLE [dbo].[Detalle_NotaCredito]  WITH CHECK ADD  CONSTRAINT [FK_boleta2_Cod] FOREIGN KEY([Id_Cre])
REFERENCES [dbo].[NotaCredito] ([Id_Cre])
GO
ALTER TABLE [dbo].[Detalle_NotaCredito] CHECK CONSTRAINT [FK_boleta2_Cod]
GO
ALTER TABLE [dbo].[Detalle_Pedido]  WITH CHECK ADD  CONSTRAINT [FK_det_Prd] FOREIGN KEY([Id_Pro])
REFERENCES [dbo].[Productos] ([Id_Pro])
GO
ALTER TABLE [dbo].[Detalle_Pedido] CHECK CONSTRAINT [FK_det_Prd]
GO
ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_doc_ped] FOREIGN KEY([id_Ped])
REFERENCES [dbo].[Pedido] ([id_Ped])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_doc_ped]
GO
ALTER TABLE [dbo].[Documento]  WITH CHECK ADD  CONSTRAINT [FK_doc_tip] FOREIGN KEY([Id_Tipo])
REFERENCES [dbo].[Tipo_Doc] ([Id_Tipo])
GO
ALTER TABLE [dbo].[Documento] CHECK CONSTRAINT [FK_doc_tip]
GO
ALTER TABLE [dbo].[KardexProducto]  WITH CHECK ADD  CONSTRAINT [FK_Kar_Prod] FOREIGN KEY([Id_Pro])
REFERENCES [dbo].[Productos] ([Id_Pro])
GO
ALTER TABLE [dbo].[KardexProducto] CHECK CONSTRAINT [FK_Kar_Prod]
GO
ALTER TABLE [dbo].[NotaCredito]  WITH CHECK ADD  CONSTRAINT [FK_cliNC] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[NotaCredito] CHECK CONSTRAINT [FK_cliNC]
GO
ALTER TABLE [dbo].[NotaCredito]  WITH CHECK ADD  CONSTRAINT [FK_nota_doc] FOREIGN KEY([id_Doc])
REFERENCES [dbo].[Documento] ([id_Doc])
GO
ALTER TABLE [dbo].[NotaCredito] CHECK CONSTRAINT [FK_nota_doc]
GO
ALTER TABLE [dbo].[NotaCredito]  WITH CHECK ADD  CONSTRAINT [FK_notac_Usuario] FOREIGN KEY([Id_Usu])
REFERENCES [dbo].[Usuarios2] ([Id_Usu])
GO
ALTER TABLE [dbo].[NotaCredito] CHECK CONSTRAINT [FK_notac_Usuario]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Ped_cli] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Ped_cli]
GO
ALTER TABLE [dbo].[ValeCompra]  WITH CHECK ADD  CONSTRAINT [FK_val_cli] FOREIGN KEY([Id_Cliente])
REFERENCES [dbo].[Cliente] ([Id_Cliente])
GO
ALTER TABLE [dbo].[ValeCompra] CHECK CONSTRAINT [FK_val_cli]
GO
/****** Object:  StoredProcedure [dbo].[Reg_Cierre_Caja]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--insert de cierre de caja
CREATE Proc [dbo].[Reg_Cierre_Caja]
(
@idCierre nvarchar(15),
@Apertura_Caja real,
@Total_Ingreso real,
@TotalEgreso real,
@Id_usu nvarchar(15),
@TodoDeposito real,
@TotalGanancia Real,
@TotalEntregado Real,
@SaldoSiguiente Real,
@TotalFactura Real,
@TotalBoleta Real,
@Totalnota Real,
@TotalCreditoCobrado real,
@TotalCreditoEmitido real
)
As
Insert Into  Cierre_Caja
Values 
(
@idCierre,
GETDATE(),
@Apertura_Caja ,
@Total_Ingreso ,
@TotalEgreso,
@Id_usu,
@TodoDeposito ,
@TotalGanancia ,
@TotalEntregado,
@SaldoSiguiente,
@TotalFactura,
@TotalBoleta,
@Totalnota ,
@TotalCreditoCobrado,
@TotalCreditoEmitido,
'Abierto'
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actu_clien_Ped]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Cambiar solo el Cliente:

CREATE Procedure [dbo].[Sp_Actu_clien_Ped](
	@Id_Ped nvarchar (15),
	@Id_cli nvarchar(15)
	
)
As
	UPDATE Pedido SET
		Id_Cliente =@Id_cli 
	WHERE Id_Ped=@Id_Ped
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualiza_Tipo_Doc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------=============================================================
------ ACTUALIZA NUMERO CORRELATIVO DE DOCUMENTOS
------=============================================================
CREATE Procedure [dbo].[Sp_Actualiza_Tipo_Doc](
@Id_Tipo int
)
As

IF NOT EXISTS(SELECT * FROM TIPO_DOC
		WHERE Id_Tipo =@Id_Tipo)
	BEGIN		
		RETURN
	END

Begin
	Declare @NuevoNum char(10)
	Set @NuevoNum = dbo.Auto_Genera_Doc(@Id_Tipo)
End

BEGIN TRANSACTION

UPDATE TIPO_DOC SET	
	Numero = @NuevoNum
WHERE 
	Id_Tipo=@Id_Tipo
	
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualiza_Tipo_Prodcto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------Actualiza correlativo de producto
Create Procedure [dbo].[Sp_Actualiza_Tipo_Prodcto](
@Id_Tipo int
)
As

IF NOT EXISTS(SELECT * FROM TIPO_DOC
		WHERE Id_Tipo =@Id_Tipo)
	BEGIN		
		RETURN
	END

Begin
	Declare @NuevoNum char(5)
	Set @NuevoNum = dbo.Auto_Genera_Prodcto(@Id_Tipo)
End

BEGIN TRANSACTION

UPDATE TIPO_DOC SET	
	Numero = @NuevoNum
WHERE 
	Id_Tipo=@Id_Tipo
	
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_Cant_Origen_Pedi]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_Actualizar_Cant_Origen_Pedi](
@id_Ped				nvarchar(15),
@Id_Pro				nvarchar(15),
@P_Cant_Original	real
)
as
update Detalle_Pedido set P_Cant_Original=@P_Cant_Original
where id_Ped=@id_Ped
and Id_Pro=@Id_Pro
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualizar_documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Actualizar Totales del Documento:
CREATE Procedure [dbo].[Sp_Actualizar_documento](
	@Id_Doc Nvarchar(15),
	@importe Real,
	@Igv Real,
	@son nvarchar (180)
)
As
	UPDATE Documento SET
	ImporteDoc =@importe ,
	IgvDoc =@Igv ,
	TotalLetra=@son 
	WHERE
	Id_Doc=@Id_Doc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualizar_Estado_credito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--actualizar el estado de un credito, cuando es cancelado en su totalidad
CREATE Procedure [dbo].[Sp_Actualizar_Estado_credito]
@Id_credito  nvarchar(15),
@xstado varchar (13)
As
update Credito set 
Estado_Cred = @xstado 
where
IdNotaCred=@Id_credito 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualizar_EstadoDinero_NC]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Sp_Actualizar_EstadoDinero_NC]
@NroNotaCredi nvarchar (15),
@EstadoDinero varchar (15)
As
Update NotaCredito set
EstadoDinero =@EstadoDinero
Where
Id_Cre =@NroNotaCredi
GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_EstadoProducto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_Actualizar_EstadoProducto] (
@id_ped nvarchar(15),
@Estado nvarchar(20),
@Id_Pro nvarchar(15),
@cantidad real
)
as

update Detalle_Pedido set Estado=@Estado
where id_ped = @id_ped
and Id_Pro=@Id_Pro
and cantidad=@cantidad



GO
/****** Object:  StoredProcedure [dbo].[SP_Actualizar_EstadoTemporal]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_Actualizar_EstadoTemporal](
@codTem nvarchar(15),
@hash_cpe nvarchar(100)
)
as

update [dbo].[Temporal] set [hash_cpe]=@hash_cpe
where [codTem]=@codTem
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualizar_Saldo_Pdnte]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Sp_Actualizar_Saldo_Pdnte]
(
@idnotacredito nvarchar (15),
@Saldo_Pndte real,
@Stado varchar (13)
)
as
BEGIN TRAN
update Credito set Saldo_Pdnte = @Saldo_Pndte,Estado_Cred=@Stado 
where IdNotaCred =@idnotacredito  
 if @@ERROR <> 0 
begin 
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actualizar_Total_Caja]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Actualizar_Total_Caja]
@Nro_doc char (15),
@ImporteCaja Real,
@TotalUtilidad real,
@TipoPago varchar (12)
As
update caja set
ImporteCaja =@ImporteCaja ,
TotalUti =@TotalUtilidad 
where 
Nro_Doc =@Nro_doc and
TipoPago =@TipoPago 
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarBajasSunat]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_ActualizarBajasSunat](
@id_Doc nvarchar(15),
@EstadoBajada nvarchar(15),
@NroTicket_Baja nvarchar(50),
@Hash_CPE_Baja nvarchar(50)
)
as
update Documento set EstadoBajada=@EstadoBajada,NroTicket_Baja=@NroTicket_Baja,Hash_CPE_Baja=@Hash_CPE_Baja
where id_Doc=@id_Doc
GO
/****** Object:  StoredProcedure [dbo].[Sp_ActualizarEstadoSunat_NotaCre]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_ActualizarEstadoSunat_NotaCre] (
@IdNotaCre nvarchar (15),
@CdrSunat varchar (20),
@HashCpe varchar (60)
)
As
Update NotaCredito Set
CdrSunat_NotaCre=@CdrSunat ,
HashCpe_NotaCre=@HashCpe 
Where
Id_cre=@IdNotaCre or
NC_Enviado_Sunat=@IdNotaCre
GO
/****** Object:  StoredProcedure [dbo].[Sp_Actulizar_Precios_CompraVenta_Producto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Cuando hacemos el Ingreso de nuevos Productos..  Es Posible que el Precio de compra tenga variacioens.. y tenemos que hacer que
--el sistema actualice esos precios..de forma automatica:
Create procedure [dbo].[Sp_Actulizar_Precios_CompraVenta_Producto]  
(
@Id_Pro char (20),
@Pre_CompraS real,
@Pre_vntaxMenor real,
@Utilidad real,
@ValorAlmacen Real
)
as
update  Productos   set 
Pre_CompraS =@Pre_CompraS ,
Pre_vntaxMenor =@Pre_vntaxMenor ,
UtilidadUnit =@Utilidad 
where Id_Pro =@Id_Pro 
GO
/****** Object:  StoredProcedure [dbo].[sp_addDistrito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--1
create proc [dbo].[sp_addDistrito]
(
@distrito nvarchar (50)
)
As
insert into Distrito 
values
(
@distrito ,
'Activo'
)
GO
/****** Object:  StoredProcedure [dbo].[sp_addMarca]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_addMarca]
(
@marca nvarchar (50)
)
As
insert into Marcas 
values
(
@marca
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Anular_Documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Anular:
----=============================================================
CREATE Procedure [dbo].[Sp_Anular_Documento](
	@Id_Doc Nvarchar(15),
	@estado varchar (50)
)
As
BEGIN TRANSACTION
	UPDATE Documento SET
		Estado_doc =@estado
	WHERE Id_Doc=@Id_Doc
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[sp_anular_moviCaja]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_anular_moviCaja]
(
@Nro_Doc    nvarchar(15),
@EstadoCaja	nvarchar(15)
)
as
update caja set EstadoCaja=@EstadoCaja
where Nro_Doc=@Nro_Doc
GO
/****** Object:  StoredProcedure [dbo].[SP_Borrar_Factura_Ingresada]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Actualmente utilizando para eliminar la factura
CREATE Procedure [dbo].[SP_Borrar_Factura_Ingresada]
@Id_Fac nvarchar (15)
As
Delete from Detalle_DocumCompra
where Id_DocComp =@Id_Fac 
Delete from DocumentoCompras
where Id_DocComp =@Id_Fac 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_Credito_Print]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Buscador_Credito_Print]
@fechaInicio date,
@fechaFin date,
@idnotacred nvarchar(15)
As
select * 
  from V_Documento_Credito_Print2
WHERE CONVERT(date, Fecha_Credito, 103) BETWEEN CONVERT(date, @fechaInicio, 103) AND CONVERT(date, @fechaFin, 103)
and IdNotaCred = @idnotacred
order by fecha_pago asc,Id_DetCred asc;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_creditos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----buscar creditos por nombre de cliente
CREATE procedure [dbo].[Sp_Buscador_creditos]
@nomcliente varchar (50)
as
select * from V_Documento_Credito 
Where 0=0
and	(
	 IdNotaCred = @nomcliente 
  or Id_Doc = @nomcliente 
  or Nom_Cliente like '%' + @nomcliente + '%'
     )
 order by Fecha_Credito desc, IdNotaCred
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_DeKardex_Principal_yDetalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Proc [dbo].[Sp_Buscador_DeKardex_Principal_yDetalle]
@xvalor nvarchar (150) 
As
Select * from V_Kardex_Detalle
Where
Id_Pro = @xvalor  or
Doc_Soporte = @xvalor  or
Id_krdx = @xvalor  or
Descripcion_Larga  like @xvalor + '%' or Descripcion_Larga + '%' like @xvalor  + '%'
Order by Item Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_Documentos_xValor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--2
CREATE Procedure [dbo].[Sp_Buscador_Documentos_xValor]
@fechaInicio date,
@fechaFin date,
@Xvalor varchar (250)
As
Select * from V_Listado_Documento
where 
CONVERT(date, Fecha_Ped, 103) BETWEEN CONVERT(date, @fechaInicio, 103) AND CONVERT(date, @fechaFin, 103)
and
(id_Doc like '%' + @Xvalor + '%' or
DNI like '%' + @Xvalor + '%' or
Razon_Social_Nombres like '%' + @Xvalor + '%' )
order by Fecha_Emi asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_Documentos_xValorUnico]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Procedure [dbo].[Sp_Buscador_Documentos_xValorUnico]
@Xvalor nvarchar (15)
As
Select * from V_Listado_Documento
where 
id_Doc = @Xvalor
GO
/****** Object:  StoredProcedure [dbo].[SP_Buscador_Gneral_NotasCredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[SP_Buscador_Gneral_NotasCredito]
@xValor varchar (150)
As
Select * from V_ista_Notacredito_Gnral
Where
Id_Cre=@xValor or
id_Doc=@xValor or
Id_Cliente=@xValor or
Razon_Social_Nombres like + '%'+ @xValor or Razon_Social_Nombres like + '%' + @xValor + '%' or
Razon_Social_Nombres like @xValor + '%' or 
DNI=@xValor
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_Gnral_de_Cotizaciones]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Sp_Buscador_Gnral_de_Cotizaciones]
@valor varchar (50)
As
Select * from v_Vista_Cotizacion_Pedido_Cliente
where
Id_Cotiza=@valor or
Id_Ped=@valor or
Razon_Social_Nombres like @valor + '%' or
Razon_Social_Nombres like '%' + @valor 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_Gnral_deCompras]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Consultas para el Explorador de Compras:
--1) Ahora un Buscador General
CREATE Procedure [dbo].[Sp_Buscador_Gnral_deCompras]
@xvalor varchar (150)
As
Select * from V_Documentos_CompraPrincipal
Where Id_DocComp=@xvalor 
or NroFac_Fisico like '%' + @xvalor + '%' 
or TipoDoc_Compra=@xvalor 
or RUC = @xvalor 
or NOMBRE like @Xvalor + '%' 
or NOMBRE + '%' like  @Xvalor + '%' 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_MoviCaja_xValor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar movimiento de Caja por Cliente
create procedure [dbo].[Sp_Buscador_MoviCaja_xValor]
@xvalor varchar (150)
As
Select * from V_Caja_Usuario
Where
Nro_Doc=@xvalor or
TipoPago=@xvalor or
Tipo_caja=@xvalor or
Nombres=@xvalor or
GeneradoPor=@xvalor or
De_Para like + '%'+ @xvalor  or De_Para  like + '%' + @xvalor  + '%' or
De_Para like @xvalor  + '%' or
Nro_Doc like + '%'+ @xvalor or Nro_Doc  like + '%' + @xvalor  + '%' or Nro_Doc   like @xvalor  + '%'
Order by Fecha_Caja Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_buscador_Productos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Busar:
CREATE Procedure [dbo].[Sp_buscador_Productos](
@valor varchar (150)
)
As
Select * from v_Productos_yDependientes Where
Estado_Pro ='Activo' and
Id_Pro =@valor or
Marca =@valor or
Categoria =@valor or
Descripcion_Larga like '%' + @valor + '%'
order by Descripcion_Larga Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscador_TodoCreditos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Buscador_TodoCreditos]
@fechaInicio date,
@fechaFin date
,@nomcliente nvarchar(250)
As
select * 
  from V_Documento_Credito 
WHERE CONVERT(date, Fecha_Credito, 103) BETWEEN CONVERT(date, @fechaInicio, 103) AND CONVERT(date, @fechaFin, 103)
and LOWER(Nom_Cliente) like '%' + @nomcliente + '%' 
order by Fecha_Credito desc,IdNotaCred asc;
GO
/****** Object:  StoredProcedure [dbo].[sp_Buscar_Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Validar no ingresar doble Cliente :
CREATE procedure [dbo].[sp_Buscar_Cliente] (
@DNI char (18)
)
as
select rtrim(Id_Cliente) as Id_Cliente,Razon_Social_Nombres, DNI,Direccion,Telefono,E_Mail,Id_Dis,Fcha_Ncmnto_Anivsrio,Contacto,Limit_Credit,Estado_Cli,foto
from Cliente 
where
rtrim(DNI) = @DNI
GO
/****** Object:  StoredProcedure [dbo].[SP_Buscar_Cliente_exp]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Validar no ingresar doble Cliente :
CREATE procedure [dbo].[SP_Buscar_Cliente_exp] (
@Id_Cliente char (18)
)
as
select rtrim(Id_Cliente) as Id_Cliente,Razon_Social_Nombres, rtrim(DNI) as DNI,Direccion,Telefono,E_Mail,Id_Dis,Fcha_Ncmnto_Anivsrio,Contacto,Limit_Credit,Estado_Cli,foto
from Cliente 
where
rtrim(Id_Cliente) = @Id_Cliente
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Cliente_porValor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscamos por Nombre:
CREATE Procedure [dbo].[Sp_Buscar_Cliente_porValor] (
@Valor varchar (250),
@estado varchar (12)
)
As
Select * from V_Clientes_Distritos
where 1=1
and Estado_Cli =@estado
and DNI like '%'+@Valor+'%' 
 or Id_Cliente = @Valor 
 or Razon_Social_Nombres like '%' + @Valor + '%' 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Cotizaciones_yDetalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Ahra creamos un buscador para las cotizaciones
CREATE Procedure [dbo].[Sp_Buscar_Cotizaciones_yDetalle] (
@Nro_coti nvarchar (15)
)
As
Select * from  v_Vista_Cotizacion_Pedido_Detalle
Where
Id_Cotiza =@Nro_coti or
id_Ped =@Nro_coti 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Credito_Documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[Sp_Buscar_Credito_Documento]
@Id_Doc nvarchar (15)
as
select *
from Credito 
where Id_Doc =  @Id_Doc 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Documento_yDetalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[Sp_Buscar_Documento_yDetalle] (
@Nro_Doc nvarchar (15)
)
As
Select * from V_Listado_Documento_Detalle
where
Id_Doc=@Nro_Doc or
id_Ped =@Nro_Doc 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Documento_yDetalle2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Proc [dbo].[Sp_Buscar_Documento_yDetalle2] (
@Nro_Doc nvarchar (15)
)
As
Select * from V_Listado_Documento_Detalle
where estado ='Salida Venta'
and (Id_Doc=@Nro_Doc or id_Ped =@Nro_Doc)

GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_FacturasCompras_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar un Documento de Compra Completo:
CREATE Proc [dbo].[Sp_Buscar_FacturasCompras_Detalle]
@xvalor nchar (20)
As
Select * from V_Documentos_Compra_Detalle
Where
Id_DocComp=@xvalor or
NroFac_Fisico =@xvalor
GO
/****** Object:  StoredProcedure [dbo].[SP_Buscar_miempresa]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create proc [dbo].[SP_Buscar_miempresa](
@id int
)
as 
select * from MiEmpresa
where idrancho=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_Pedido_Para_Editar]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Buscar pedido completo con detalle:
CREATE  Procedure [dbo].[Sp_Buscar_Pedido_Para_Editar] (
@Id_Ped nvarchar(11)
)
As
	Select * from V_Listado_Pedido_Detalle
	Where Id_Ped = @Id_Ped
GO
/****** Object:  StoredProcedure [dbo].[Sp_buscar_Pedidos_porValor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--todos:




--Buscadir de Pedidos:
Create Procedure [dbo].[Sp_buscar_Pedidos_porValor](
@valor varchar(250)
)
As
	Select  * from V_Pedidos_Cliente_General
	Where
	Razon_Social_Nombres like @valor + '%' or
	Razon_Social_Nombres like '%' + @valor or
	id_Ped=@valor or
	Id_Cliente=@valor or
	DNI=@valor 	
	Order by Fecha_Ped  desc
GO
/****** Object:  StoredProcedure [dbo].[sp_buscar_proveedor_porvalor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sp_buscar_proveedor_porvalor] (
@valor varchar (50)
)
as
select 
rtrim(IDPROVEE) as IDPROVEE
,rtrim(NOMBRE) as NOMBRE
,rtrim(DIRECCION) as DIRECCION
,rtrim(TELEFONO) aS TELEFONO
,rtrim(RUBRO) AS RUBRO
,rtrim(RUC) AS RUC
,rtrim(CORREO) AS CORREO
,rtrim(CONTACTO) AS CONTACTO
,rtrim(FOTO_LOGO) AS FOTO_LOGO
,rtrim(ESTADO_PROVDR) AS ESTADO_PROVDR
from Proveedor
where 1=1
and idprovee=@valor 
 or RUC like  @valor + '%'
 or NOMBRE like '%' + @valor 
 or NOMBRE like @valor + '%'
order by NOMBRE Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Buscar_TipoDocumento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	CREATE Procedure [dbo].[Sp_Buscar_TipoDocumento]
	@nom_Tipo as nvarchar(20)	
AS
	Select * from Tipo_Doc 
	Where Documento=@nom_Tipo
GO
/****** Object:  StoredProcedure [dbo].[SP_Buscar_UniMedida]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[SP_Buscar_UniMedida](
@id nvarchar(10)
)
as 
select top 1 upper(descripcion) as descripcion from UnidadMedida
where codigo=@id
and estado='Activo'
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarDNI_Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_BuscarDNI_Cliente](
@DNI char (18)
)
as
select Razon_Social_Nombres
from Cliente 
where rtrim(DNI) = @DNI;
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarDNI_Usuario2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Validar no ingresar doble Cliente :
CREATE procedure [dbo].[SP_BuscarDNI_Usuario2](
@DNI char (18)
)
as
select CONCAT(apellidos,' ,',nombres) as nombre
from Usuarios2 
where rtrim(Id_Usu) = @DNI;
GO
/****** Object:  StoredProcedure [dbo].[SP_buscarNC_PendientePago]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_buscarNC_PendientePago](
@idCred nvarchar(15)
)
as
select * from V_ista_Notacredito_Gnral
where (id_cre=@idCred or id_Doc=@idCred)
and EstadoDinero='De Pago' 
and Estado_Cr='Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Calcular_Gastos_porTipoPago]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Calcular_Gastos_porTipoPago]
@tipoPago nvarchar(15)
As
Select * from Caja
Where
TipoPago =@tipoPago and
Tipo_caja = 'Salida' and
EstadoCaja ='Activo' And
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Calcular_Ventas_aCredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Calcular_Ventas_aCredito]
As
Select * from Caja
Where
Concepto = 'Por Venta al Publico - Credito'	and
Tipo_caja = 'Entrada' and
EstadoCaja ='Activo' And
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Calcular_Ventas_aDeposito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--4)Ahroa todos lso depositso
CREATE Procedure [dbo].[Sp_Calcular_Ventas_aDeposito]
As
Select * from Caja
Where
TipoPago = 'Deposito' and
Tipo_caja = 'Entrada' and
EstadoCaja ='Activo' And
concepto='Abono de Credito' and
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Calcular_Ventas_GananciadelDia]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--5)Ahora listamos la Utilidad
Create Procedure [dbo].[Sp_Calcular_Ventas_GananciadelDia]
As
Select * from Caja
Where
Tipo_caja = 'Entrada' and 
EstadoCaja ='Activo' And
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Calcular_Ventas_PorTipoDoc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Calcular_Ventas_PorTipoDoc]
@tipodoc varchar (15),
@tipoPago nvarchar (15)

As
Select * from Caja
Where
TipoPago =@tipoPago 	and
GeneradoPor=@tipodoc and
Tipo_caja = 'Entrada' and
EstadoCaja ='Activo' And
CONVERT(varchar(10), Fecha_Caja , 103) = CONVERT(varchar(10), GETDATE(), 103) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cambiar_Estado_Cotizacion]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Cambiamos de estado la cotizacion
CREATE Procedure [dbo].[Sp_Cambiar_Estado_Cotizacion]
@Id_coti nvarchar (15),
@Estadocoti varchar (15)
as
Update Cotizacion
set
EstadoCoti =@Estadocoti 
where
Id_Cotiza =@Id_coti 
GO
/****** Object:  StoredProcedure [dbo].[SP_Cambiar_RespuestaSunat]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_Cambiar_RespuestaSunat](
@id nvarchar(15),
@EstadoCDR nvarchar(max),
@hash_CPE nvarchar(50)
)
as
update  Documento set CDR_Sunat=@EstadoCDR, Hash_CPE=@hash_CPE
Where id_Doc=@id
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cambiar_TipoPago_Documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Cambiar:
CREATE Procedure [dbo].[Sp_Cambiar_TipoPago_Documento](
	@Id_Doc Nvarchar(15),
	@tipoPago varchar (50)
)
As
BEGIN TRANSACTION
	UPDATE Documento SET
		TipoPago  =@tipoPago 
	WHERE Id_Doc=@Id_Doc
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_CierreCaja_delDia]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--1
Create Proc [dbo].[Sp_Cargar_CierreCaja_delDia]
As
Select * from v_cierreCaja_usu
Where
DATEPART (YEAR ,Fecha_Cierre )= DATEPART (YEAR,GETDATE()) and
DATEPART (DAYOFYEAR ,Fecha_Cierre )= DATEPART (DAYOFYEAR,GETDATE()) 
GO
/****** Object:  StoredProcedure [dbo].[SP_Cargar_NotaCredito_Detalle]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE  Proc [dbo].[SP_Cargar_NotaCredito_Detalle]
	@nronotacred nvarchar (15)
	As
	Select * from V_Listado_Notacredito
	Where
	Id_Cre =@nronotacred  or
	id_Doc=@nronotacred or
	nc_enviado_sunat=@nronotacred
	
GO
/****** Object:  StoredProcedure [dbo].[Sp_Cargar_todas_Cotizaciones]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--Todos:;
Create Proc [dbo].[Sp_Cargar_todas_Cotizaciones]
As
Select * from v_Vista_Cotizacion_Pedido_Cliente
order by FechaCoti Desc
GO
/****** Object:  StoredProcedure [dbo].[SP_Cargar_Todas_Las_Notacredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--1º primero cargamos la nota de credito principal
CREATE Proc [dbo].[SP_Cargar_Todas_Las_Notacredito]
	As
	Select * from V_ista_Notacredito_Gnral
GO
/****** Object:  StoredProcedure [dbo].[sp_cargar_Todos_Productos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Todoslos productos:
create procedure [dbo].[sp_cargar_Todos_Productos]
As
select * from v_Productos_yDependientes
where
Estado_Pro ='Activo'
order by Descripcion_Larga Asc
GO
/****** Object:  StoredProcedure [dbo].[sp_crear_kardex]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_crear_kardex](
@idkardex nvarchar (15),
@idprod nvarchar (20),
@idprovee nvarchar (15)
)
as
insert into KardexProducto values (
@idkardex ,
@idprod ,
@idprovee,
GETDATE(),
'Activo'
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Darbaja_Producto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Eliminar:
CREATE Procedure [dbo].[Sp_Darbaja_Producto] (
@idpro nvarchar (20)
)
as
update Productos set
Estado_Pro ='Eliminado'
where
Id_Pro =@idpro 
GO
/****** Object:  StoredProcedure [dbo].[Sp_DarBajar_Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Eliminar:
CREATE Procedure [dbo].[Sp_DarBajar_Cliente] (
@idcliente nvarchar(15)
)
As
Update Cliente set
Estado_Cli ='De_Baja'
where
Id_Cliente =@idcliente 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Delete_Det_Temporal]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Delete_Det_Temporal]
@Id nvarchar (15)
As
Delete from detalle_Temporal
Where rtrim(codTem) =@Id 
Delete from Temporal 
Where rtrim(CodTem) =@Id 

GO
/****** Object:  StoredProcedure [dbo].[Sp_Editar_Cotizacion]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--editar:
CREATE procedure [dbo].[Sp_Editar_Cotizacion] (
@Id_Cotiza nvarchar (15) ,
@Id_Ped nvarchar (15),
@FechaCoti datetime,
@Vigencia int,
@TotalCotiza real,
@Condiciones varchar (450),
@PrecioconIgv char (4)
)
As
update Cotizacion set
Id_Cotiza =@Id_Cotiza ,
Id_Ped =@Id_Ped ,
FechaCoti =@FechaCoti ,
Vigencia =@Vigencia ,
TotalCotiza =@TotalCotiza ,
Condiciones =@Condiciones ,
PrecioconIgv =@PrecioconIgv 
where
Id_Cotiza =@Id_Cotiza 
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_Distrito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--editar:
Create proc [dbo].[sp_Editar_Distrito]
@idDis int,
@nomdis varchar (50)
As
Update Distrito set
Distrito =@nomdis 
where
Id_Dis =@idDis 
GO
/****** Object:  StoredProcedure [dbo].[sp_Editar_Marca]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--editar:
Create proc [dbo].[sp_Editar_Marca]
@idmar int,
@nom_marca varchar (50)
As
Update Marcas set
Marca =@nom_marca
where
Id_Marca=@idmar
GO
/****** Object:  StoredProcedure [dbo].[SP_editar_miempresa]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_editar_miempresa](
@idrancho int,
@nombrerancho nvarchar(300),
@nroRuc nvarchar(20),
@direccionran nvarchar(300),
@correo nvarchar(200),
@clavecorreo nvarchar(20),
@clavesol nvarchar(20),
@usuariosol nvarchar(20),
@clavecertificado nvarchar(200),
@obs nvarchar(300)
)
as
UPDATE [dbo].[MiEmpresa]
   SET [nombrerancho] = @nombrerancho,
       [nroRuc] = @nroRuc,
       [direccionran] = @direccionran,
       [correo] = @correo,
       [clavecorreo] = @clavecorreo,
       [clavesol] = @clavesol,
       [usuariosol] = @usuariosol,
       [clavecertificado] = @clavecertificado,
       [obs] = @obs
 WHERE [idrancho] = @idrancho
GO
/****** Object:  StoredProcedure [dbo].[Sp_Editar_Pedido]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--update:
CREATE Procedure [dbo].[Sp_Editar_Pedido](
@id_Ped nvarchar (15),
@Id_Cliente nvarchar (15),
@fechaPed datetime,
@SubTotal real,
@IgvPed real,
@TotalPed real,
@id_Usu int,
@TotalGancia real,
@Estado_ped varchar(12),
@subtotal_Gravado real,
@IgvGravado real,
@totalGravado real
)
As
update Pedido set
Id_Cliente =@Id_Cliente ,
Fecha_Ped =@fechaPed ,
SubTotal =@SubTotal ,
IgvPed=@IgvPed,
TotalPed =@TotalPed ,
TotalGancia =@TotalGancia,
Estado_Ped=@Estado_ped,
subtotal_Gravado=@subtotal_Gravado,
IgvGravado=@IgvGravado,
totalGravado=@totalGravado
where
id_Ped =@id_Ped 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Editar_Producto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--update:
CREATE procedure [dbo].[Sp_Editar_Producto] (
@idpro nvarchar (15),
@idprove nvarchar (15),
@descripcion varchar (150),
@frank real,
@Pre_compraSol real,
@pre_CompraDolar real,
@idCat int,
@idMar int,
@Foto varchar (180),
@Pre_Venta_Menor real,
@Pre_Venta_Mayor real,
@Pre_Venta_Dolar real,
@UndMdida char (6),
@PesoUnit real,
@Utilidad real,
@TipoProd varchar (12)
)
As
Update Productos set
IDPROVEE=@idprove ,
Descripcion_Larga=@descripcion ,
Frank=@frank ,
Pre_CompraS=@Pre_compraSol ,
Pre_Compra$=@pre_CompraDolar ,
Id_Cat=@idCat ,
Id_Marca=@idMar ,
Foto=@Foto ,
Pre_vntaxMenor=@Pre_Venta_Menor ,
Pre_vntaxMayor=@pre_venta_Mayor,
Pre_Vntadolar =@Pre_Venta_Dolar ,
UndMedida=@UndMdida ,
PesoUnit =@PesoUnit ,
UtilidadUnit =@Utilidad ,
TipoProdcto=@TipoProd 
where
Id_Pro =@idpro 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Editar_Tipo_Doc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

------update tipo_doc
CREATE proc [dbo].[Sp_Editar_Tipo_Doc]
(
@idtipo int,
@documento nvarchar(50),
@serie nvarchar(4),
@numero nvarchar (5) 
)
as
if not exists (select * from Tipo_Doc where Id_Tipo = @idtipo)
begin
print 'El Municipio no existe'
return
end
begin tran
update tipo_doc set 
Documento  = @documento ,
Serie = @serie ,
Numero = @numero   
where Id_Tipo = @idtipo    
if @@ERROR <> 0
begin
print @@error
rollback tran
return
end
commit tran
GO
/****** Object:  StoredProcedure [dbo].[Sp_Editar_TipoCambio]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Editar_TipoCambio]
(
@idtipo int,
@numero nvarchar (7)
)
as
update tipo_doc set Numero =@numero   
where Id_Tipo = @idtipo
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_Categoria]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Create eliminar:
create proc [dbo].[sp_eliminar_Categoria]
@idCateg int
As
Delete from [dbo].[Categorias]
where
Id_Cat =@idCateg 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Eliminar_Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Eliminar_Cliente](
@idcliente nvarchar (15)
)
As
Delete from Cliente 
where
Id_Cliente =@idcliente 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Eliminar_cotizacion]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Eliminar una Cotizacion
CREATE Proc [dbo].[Sp_Eliminar_cotizacion]
@NroCotiza nvarchar (15)
As
Delete from Cotizaciones
where Id_Cotiza=@NroCotiza 
GO
/****** Object:  StoredProcedure [dbo].[Sp_eliminar_Credito_Permanente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--eliminar creditos erroneo

CREATE Procedure [dbo].[Sp_eliminar_Credito_Permanente]
@Idcredito nvarchar (15)
As	
Delete from Detalle_Credito 
where IdNotaCred   =@Idcredito 
Delete from credito 
where IdNotaCred   =@Idcredito
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_detalle_Pedido]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--borrar Detalle:
CREATE procedure [dbo].[sp_eliminar_detalle_Pedido] (
@id_Ped nvarchar (15)
)
As
Delete from Detalle_Pedido where
id_Ped =@id_Ped 
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_distrito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Create eliminar:
create proc [dbo].[sp_eliminar_distrito]
@idDis int
As
Delete from Distrito 
where
Id_Dis =@idDis 
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_Marca]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Create eliminar:
create proc [dbo].[sp_eliminar_Marca]
@idmar int
As
Delete from Marcas
where
Id_Marca =@idmar 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Eliminar_Pedido_Completo]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Eliminar Todo el Pedido:
CREATE Procedure [dbo].[Sp_Eliminar_Pedido_Completo](
	@Id_Ped nvarchar(15)
)
As
Delete from Detalle_Pedido WHERE Id_Ped=@Id_Ped
Delete from Pedido WHERE Id_Ped=@Id_Ped
GO
/****** Object:  StoredProcedure [dbo].[sp_Eliminar_Producto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_Eliminar_Producto](
@idpro char (20)
)
As
Delete from Productos 
where
Id_Pro =@idpro 
GO
/****** Object:  StoredProcedure [dbo].[sp_eliminar_PROVEEDOR]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Create eliminar:
create proc [dbo].[sp_eliminar_PROVEEDOR]
@IDPROVEE int
As
Delete from Proveedor 
where
IDPROVEE=@IDPROVEE 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Estado_Documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Estado_Documento]
@nro_doc nvarchar (15)
As	
select 
Count(*) 
from Caja
where estadocaja='Anulado'
and nro_doc=@nro_doc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Facturas_Ingresadas_alDia]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--facturas ingreadas en el dia
create Procedure [dbo].[Sp_Facturas_Ingresadas_alDia] (
@tipo varchar (20),
@fecha date
)
As
if @tipo ='dia'
	Select * from V_Documentos_CompraPrincipal
	where
	DATEPART (YEAR ,Fecha_Ingre)= DATEPART (YEAR,@fecha)  and
	DATEPART (DAYOFYEAR ,Fecha_Ingre)= DATEPART (DAYOFYEAR,@fecha) 
	order by Fecha_Ingre Asc
else
Select * from V_Documentos_CompraPrincipal
	where
	DATEPART (YEAR ,Fecha_Ingre)= DATEPART (YEAR,@fecha)  and
	DATEPART (MONTH ,Fecha_Ingre)= DATEPART (MONTH,@fecha) 
	order by Fecha_Ingre Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Filtrar_creditos_deldia]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure  [dbo].[Sp_Filtrar_creditos_deldia]
@xdia date
as
select * from V_Documento_Credito
Where
DATEPART(YEAR,Fecha_Credito)= DATEPART(YEAR,@xdia) and
DATEPART(MONTH ,Fecha_Credito)= DATEPART(MONTH ,@xdia) and
DATEPART(DAYOFYEAR ,Fecha_Credito)= DATEPART(DAYOFYEAR ,@xdia)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Filtrar_creditos_delMes]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure  [dbo].[Sp_Filtrar_creditos_delMes]
@xmes date
as
select * from V_Documento_Credito
Where
DATEPART(YEAR,Fecha_Credito)= DATEPART(YEAR,@Xmes) and
DATEPART(MONTH ,Fecha_Credito)= DATEPART(MONTH ,@Xmes)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Filtrar_creditos_xEstado]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure  [dbo].[Sp_Filtrar_creditos_xEstado]
@Stado varchar (13)
as
select * from V_Documento_Credito 
Where
Estado_Cred=@Stado 
GO
/****** Object:  StoredProcedure [dbo].[Sp_ingresar_det_Credito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--======================
CREATE procedure [dbo].[Sp_ingresar_det_Credito]
(
@idnotacredito nvarchar(15),
@Acuenta real,
@saldoactual real,
@Fecha_Pago datetime,
@TipoPago varchar (50),
@nroOpera nvarchar (max),
@idUsu nvarchar(15)
)
as
insert into detalle_credito 
values
(
@idnotacredito ,
@Acuenta ,
@saldoactual,
@Fecha_Pago,
@TipoPago ,
@nroOpera ,
@idUsu 
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Detalle_ingreso]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Detalle:

CREATE Procedure [dbo].[Sp_Insert_Detalle_ingreso]
	@Id_ingreso nvarchar(15),
	@Id_Pro nvarchar(15),
	@Precio real,	
	@Cantidad real,
	@Importe real
As
INSERT INTO Detalle_DocumCompra
VALUES
(
@Id_ingreso ,
@Id_Pro,
@Precio,
@Cantidad,
@Importe
)	
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Detalle_notacredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


----=============================================================
CREATE Procedure [dbo].[Sp_Insert_Detalle_notacredito]
	@Id_cre				nvarchar(15),
	@Cantidad			Real,
	@Id_Pro				nvarchar(20),
	@Precio				real,	
	@Importe			real,
	@TipoProdcto		varchar (20),
	@DetalleNotaCredi   varchar (150),
	@Cant_Origen	    real
	
As
BEGIN TRANSACTION
INSERT INTO DETALLE_NOTACREDITO 
(Id_Cre ,Id_Pro,PrecioUniC ,CantidadC ,ImporteC, TipoProdctonc,DetalleNotaCredi,Cant_Origen)
VALUES
(@Id_cre ,@Id_Pro,@Precio,@Cantidad,@Importe,@TipoProdcto, @DetalleNotaCredi,@Cant_Origen )	

IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_Documento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Insert_Documento](
	@id_Doc nvarchar(15),	
	@id_Ped nvarchar(15),	
	@Id_Tipo int,
	@Fecha_Emi date,
	@Importe real,
	@TipoPago varchar (50),
	@NroOpera nchar (20),	
	@id_Usu varchar(15),
	@Igv real,
	@son varchar (180),
	@TotalGanancia real,
	@CDR_Sunat nvarchar(15),
@Hash_CPE nvarchar(50),
@EstadoBajada nvarchar(15),
@NroTicket_Baja nvarchar(50),
@Hash_CPE_Baja nvarchar(55)
)
As
INSERT INTO DOCUMENTO
VALUES(
@id_Doc,
@id_Ped,
@Id_Tipo, 
@Fecha_Emi, 
@Importe, 
@TipoPago , 
@NroOpera ,
@id_Usu,
@Igv ,
@son, 
@TotalGanancia,
'Activo',
@CDR_Sunat,
@Hash_CPE,
@EstadoBajada,
@NroTicket_Baja,
@Hash_CPE_Baja
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insert_NotaCredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Insert_NotaCredito](
	@Id_cre nvarchar(15),
	@Id_Doc nvarchar(15),
	@TipoComprabnte varchar (20),
	@OtrosDatos varchar (150),
	@Fecha_Cred date,
	@Total real,
	@IgvC Real,
	@Subtotal Real,
	@id_Usu int,
	@MotivoEmision char (50),
	@soncre varchar (150),
	@EstadoDinero varchar (15),
	@IdCliente nvarchar (15),
	@CdrSunat_NotaCre varchar (20),
	@HashCpe_NotaCre varchar (60),
	@NC_Enviado_Sunat nvarchar(15)
)
As
BEGIN TRANSACTION
INSERT INTO NotaCredito 
VALUES
(@Id_cre,@Id_Doc,@TipoComprabnte,@OtrosDatos ,@Fecha_Cred,@Total,@IgvC,@Subtotal, @id_Usu, @MotivoEmision , 'Activo',@soncre ,@EstadoDinero,@IdCliente,@CdrSunat_NotaCre,@HashCpe_NotaCre,@NC_Enviado_Sunat )
IF @@ERROR<>0
	BEGIN
		ROLLBACK TRAN
		RETURN
	END
COMMIT TRANSACTION
GO
/****** Object:  StoredProcedure [dbo].[Sp_Insertar_Temporal]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Insertar_Temporal]
(
@codTem nvarchar (15),
@FechaEmi varchar (20),
@cliente varchar (150),
@Ruc varchar (20),
@Direccion varchar (150),
@SubTtal varchar (10),
@IgvT varchar (10),
@TotalT varchar (10),
@SonT varchar (200),
@vendedor varchar (120),
@CodigoRQ varbinary(max),
@tipoComprobante nvarchar(50),
@hash_cpe nvarchar(100), --Activo, baja		
@tipoPago nvarchar(50),	
@motivoEmis nvarchar(100),
@forma_pago nvarchar(10),
@monto_deuda nvarchar(10),
@fecha_venc_credito nvarchar(10)
)
As
Insert Into Temporal Values
(
@codTem,
@FechaEmi,
@cliente,
@Ruc ,
@Direccion ,
@SubTtal ,
@IgvT ,
@TotalT,
@SonT,
@vendedor,
@CodigoRQ,
@tipoComprobante,
@hash_cpe,
@tipoPago,	
@motivoEmis,
@forma_pago,
@monto_deuda,
@fecha_venc_credito
)
GO
/****** Object:  StoredProcedure [dbo].[SP_Kardex_Detalle_Print]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SP_Kardex_Detalle_Print]
@fechaInicio date,
@fechaFin date
As
select --dk.Item as item,
	   --CONVERT(date, FECHA_KRDX, 103) as fecha,
	   --dk.Doc_Soporte as docSoporte,
	   --dk.Det_Operacion as detMovimiento,
	   sum(dk.Cantidad_In) as entrada,
	   sum(dk.Cantidad_Out) as salida,
	   (sum(dk.Cantidad_In)-sum(dk.Cantidad_Out)) as saldo,
	   p.Descripcion_Larga as Descripcion_Larga,
	   p.UndMedida as UndMedida,
	   p.Pre_CompraS as PrecioCompra,
	   rtrim(p.Id_Pro) as Id_Pro,
	   sum(p.Pre_CompraS * dk.Cantidad_In) as CostoEntrada,
	   sum(p.Pre_CompraS * dk.Cantidad_Out) as CostoSalida,
	   (sum(p.Pre_CompraS * dk.Cantidad_In)-sum(p.Pre_CompraS * dk.Cantidad_Out)) as CostoSaldo,
	   @fechaInicio as fechaIni, --min(Fecha_Krdx)
	   @fechaFin as fechaFin --max(Fecha_Krdx)
  from Detalle_Kardex dk inner join KardexProducto kp on kp.Id_krdx=dk.Id_krdx
						 inner join Productos p on p.Id_Pro=kp.Id_Pro and p.IDPROVEE=kp.IDPROVEE 
 WHERE CONVERT(date, Fecha_Krdx, 103) BETWEEN CONVERT(date, @fechaInicio, 103) AND CONVERT(date, @fechaFin, 103)
 group by p.Descripcion_Larga,p.UndMedida,p.Pre_CompraS,p.Id_Pro
GO
/****** Object:  StoredProcedure [dbo].[SP_Kardex_Detalle2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Kardex_Detalle2]
@fechaInicio date,
@fechaFin date,
@nomProd nvarchar(250)
As
select * 
  from V_Kardex_Detalle2
WHERE CONVERT(date, fecha, 103) BETWEEN CONVERT(date, @fechaInicio, 103) AND CONVERT(date, @fechaFin, 103)
and LOWER(Descripcion_Larga) like '%' + @nomProd + '%' 
order by item asc;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Leer_Comprobantes_Emtidas_EnunMes]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Procedure [dbo].[Sp_Leer_Comprobantes_Emtidas_EnunMes]
@Fecha_Mes Date,
@Docu Int
	As
	Select * from V_Listado_Documento 
where 
DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @Fecha_Mes )AND
DATEPART (MONTH ,Fecha_Emi ) =DATEPART (MONTH,@Fecha_Mes ) and
Id_Tipo =@Docu
ORDER BY Fecha_Emi ASC
GO
/****** Object:  StoredProcedure [dbo].[SP_Leer_Docs_delDia_PorTiopoDoc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_Leer_Docs_delDia_PorTiopoDoc](
@fecha_mes date,
@Docu int
)
as
select * from V_Listado_Documento
where DATEPART(YEAR, Fecha_Emi)= DATEPART(YEAR, @fecha_mes)
and DATEPART(DAYOFYEAR, Fecha_Emi)= DATEPART(DAYOFYEAR, @fecha_mes)
and Id_Tipo=@Docu
order by Id_Doc asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Leer_Fcturas_Emtidas_EnunMes]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create Procedure [dbo].[Sp_Leer_Fcturas_Emtidas_EnunMes]
@Fecha_Mes Date
	As
	Select * from V_Listado_Documento 
where 
DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @Fecha_Mes )AND
DATEPART (MONTH ,Fecha_Emi ) =DATEPART (MONTH,@Fecha_Mes )
ORDER BY Fecha_Emi ASC
GO
/****** Object:  StoredProcedure [dbo].[Sp_Leer_Pedidos_PorAtender]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--Ver Pedidos PEndiente de atencion:
create Procedure [dbo].[Sp_Leer_Pedidos_PorAtender]
as
select * from V_Pedidos_Cliente_General
where 
Estado_Ped ='Pendiente' and
DATEPART (YEAR ,Fecha_Ped )= DATEPART (YEAR,GETDATE()) and
DATEPART (DAYOFYEAR ,Fecha_Ped )= DATEPART (DAYOFYEAR,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[Sp_Leer_Todas_Facturas_Compras]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--cargamos todas las facturas ingresadas 
CREATE Procedure [dbo].[Sp_Leer_Todas_Facturas_Compras]
@fi date,
@ff date,
@valor nvarchar(25)
	As
	Select * from V_Documentos_CompraPrincipal
	where CONVERT(date, Fecha_ingre, 103) BETWEEN CONVERT(date, @fi, 103) AND CONVERT(date, @ff, 103)
	and NroFac_Fisico like '%' + @valor +'%'
	order by Id_DocComp desc

	
GO
/****** Object:  StoredProcedure [dbo].[Sp_Limpiar_Temporales_Venta]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Ahora una Limpieza General
Create Proc [dbo].[Sp_Limpiar_Temporales_Venta]
As
Delete from detalle_Temporal
Delete from Temporal 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listado_Tipo]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Para los Correlativos:
Create Procedure [dbo].[Sp_Listado_Tipo]
	@Id_Tipo as Int	
AS
	Select Serie + '-' + Numero as Nro from Tipo_Doc 
	Where Id_Tipo=@Id_Tipo
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listado_TipoCambio]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Para los Correlativos:
Create Procedure [dbo].[Sp_Listado_TipoCambio]
	@Id_Tipo as Int	
AS
	Select Numero from Tipo_Doc 
	Where Id_Tipo=@Id_Tipo
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listado_UniMedida]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/



create Procedure [dbo].[Sp_Listado_UniMedida]
AS
	SELECT [codigo]
      ,[descripcion]
      ,[estado]
  FROM [DI_ZEUS_FE].[dbo].[UnidadMedida]
 where estado='Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Cajas_del_Mes]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--delmes
Create  Procedure  [dbo].[Sp_Listar_Cajas_del_Mes]
@fechas date
as
select * from V_Caja_Usuario
where
DATEPART (YEAR ,Fecha_Caja)= DATEPART (YEAR,@fechas) AND
DATEPART (MONTH ,Fecha_Caja)= DATEPART (MONTH,@fechas)
order by Fecha_Caja ASc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Cajas_delDia]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Cajas del dia
---------select mostrar caja-----
Create  Procedure  [dbo].[Sp_Listar_Cajas_delDia]
as
select * from V_Caja_Usuario
where
DATEPART (YEAR ,Fecha_Caja)= DATEPART (YEAR,GETDATE()) AND
DATEPART (DAYOFYEAR ,Fecha_Caja)= DATEPART (DAYOFYEAR,GETDATE())
Order By Nro_Doc Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Cotizacion_porFecha]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--pedidos por Fecha:
Create Procedure [dbo].[Sp_Listar_Cotizacion_porFecha] (
@tipo varchar (20),
@fecha date
)
as
if @tipo ='dia'
	Select * from v_Vista_Cotizacion_Pedido_Cliente
	where
	DATEPART (YEAR ,FechaCoti)= DATEPART (YEAR,@fecha)  and
	DATEPART (DAYOFYEAR ,FechaCoti)= DATEPART (DAYOFYEAR,@fecha) 
	order by FechaCoti Asc
else
Select * from v_Vista_Cotizacion_Pedido_Cliente
	where
	DATEPART (YEAR ,FechaCoti)= DATEPART (YEAR,@fecha)  and
	DATEPART (MONTH ,FechaCoti)= DATEPART (MONTH,@fecha) 
	order by FechaCoti Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Cotizacion_PorRangoFecha]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Listar_Cotizacion_PorRangoFecha]
@fechaInicio date,
@fechaFin date,
@RazonSocial nvarchar(250)
As
select * 
  from v_Vista_Cotizacion_Pedido_Cliente
WHERE CONVERT(date, FechaCoti, 103) BETWEEN CONVERT(date, @fechaInicio, 103) AND CONVERT(date, @fechaFin, 103)
and LOWER(Razon_Social_Nombres) like '%' + @RazonSocial + '%' 
order by FechaCoti desc,Id_Cotiza asc;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Departamento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Script for SelectTopNRows command from SSMS  ******/
--SUBSTRING ( expression ,start , length ) 

create procedure [dbo].[Sp_Listar_Departamento]
as
-- Departamento
SELECT distinct [Departamento],SUBSTRING(idUbigeo,1,2) as ubi_dep
  FROM [DI_ZEUS_FE].[dbo].[Ubigeo]
 where SUBSTRING(idUbigeo,1,2) in ( select distinct SUBSTRING(idUbigeo,1,2) from Ubigeo);
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Distrito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_Listar_Distrito]
@provincia nvarchar(4)
as
-- Distrito
 SELECT distinct [Distrito],idUbigeo as ubi_dep
   FROM [DI_ZEUS_FE].[dbo].[Ubigeo]
  where idUbigeo in ( select distinct idUbigeo from Ubigeo where idUbigeo like @provincia+'%' )
    and provincia is not null
	and distrito is not null;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Doc_emitoshoy]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Listar_Doc_emitoshoy]
@FechaActual date
as
	Select * from V_Listado_Documento 
	Where 
	DATEPART (YEAR, Fecha_emi)=DATEPART(YEAR, @FechaActual)AND
	DATEPART (DAYOFYEAR ,Fecha_Emi )= DATEPART (DAYOFYEAR,@FechaActual)
	order by fecha_hora desc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_DOC_Identidad]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Listar_DOC_Identidad]
as
-- Departamento
SELECT [codigo] as cod, [descripcion] as des
  FROM [dbo].[Catalogo]
 where cod_tipo_documento='CATALOGO06'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Establecimiento]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Sp_Listar_Establecimiento]
as
-- Departamento
SELECT [Cod_establecimiento] as cod,[descripcion] as des,[direccion] as dir,[UBIGEO] as ubi
  FROM [dbo].[Establecimiento]
 where estado=1
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_MOT_TRASLADO]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Listar_MOT_TRASLADO]
as
-- Departamento
SELECT [COD_MOTIVO_TRASLADO] as cod, [DESCRIPCION_MOTIVO_TRASLADO] as des
  FROM [dbo].[Mot_traslado]
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_NotaCredito_delMes]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create Proc [dbo].[Sp_Listar_NotaCredito_delMes]
@fecha date
as
	Select * from V_ista_Notacredito_Gnral
	Where 
	DATEPART (YEAR,Fecha_Emision)= DATEPART (YEAR,@fecha) and
	DATEPART (MONTH,Fecha_Emision)= DATEPART (MONTH,@fecha)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_NotaCredito_EitidosHoy]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Listar_NotaCredito_EitidosHoy]
as
	Select * from V_ista_Notacredito_Gnral
	Where 
	DATEPART (YEAR ,Fecha_Emision  )= DATEPART (YEAR,GETDATE()) and
	DATEPART (DAYOFYEAR ,Fecha_Emision  )= DATEPART (DAYOFYEAR,GETDATE())
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Pedidos_porFecha]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--pedidos por Fecha:
Create Procedure [dbo].[Sp_Listar_Pedidos_porFecha] (
@tipo varchar (20),
@fecha date
)
as
if @tipo ='dia'
	Select * from V_Pedidos_Cliente_General
	where
	DATEPART (YEAR ,Fecha_Ped)= DATEPART (YEAR,@fecha)  and
	DATEPART (DAYOFYEAR ,Fecha_Ped)= DATEPART (DAYOFYEAR,@fecha) 
	order by Fecha_Ped Asc
else
Select * from V_Pedidos_Cliente_General
	where
	DATEPART (YEAR ,Fecha_Ped)= DATEPART (YEAR,@fecha)  and
	DATEPART (MONTH ,Fecha_Ped)= DATEPART (MONTH,@fecha) 
	order by Fecha_Ped Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Provincia]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_Listar_Provincia]
@departamento nvarchar(2)
as
-- Provincia
SELECT distinct [Provincia],SUBSTRING(idUbigeo,1,4) as ubi_dep
  FROM [DI_ZEUS_FE].[dbo].[Ubigeo]
 where SUBSTRING(idUbigeo,1,4) in ( select distinct SUBSTRING(idUbigeo,1,4) from Ubigeo where SUBSTRING(idUbigeo,1,4) like @departamento+'%' )
 and provincia is not null;
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Temporales]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--hacemos un sp por el codigo
CREATE Proc [dbo].[Sp_Listar_Temporales]
@id nvarchar (15)
As
Select * from V_Temporales_Detalle
where CodTem= @id 
GO
/****** Object:  StoredProcedure [dbo].[SP_Listar_Tipo_Doc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_Listar_Tipo_Doc]
as
(select 0 as Id_Tipo,'Seleccionar...' as Documento,'0' as Serie,'0' as Numero,'0' as Estado_TiDoc)
union
(select * from Tipo_Doc 
where Estado_tiDoc='Activo'
and Id_Tipo not in(7)) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Todas_Cajas]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[Sp_Listar_Todas_Cajas]
@Concepto nvarchar(100)
	As
	Select * from V_Caja_Usuario
	 where lower(Concepto) like '%' + @Concepto +'%'
	 order by fecha_caja desc,idcaja asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_Todas_Cajas_RangoFechas]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Listar_Todas_Cajas_RangoFechas]
@fechaInicio date,
@fechaFin date,
@Concepto nvarchar(250)
As
Select * 
  from V_Caja_Usuario
 where CONVERT(date, Fecha_Caja, 103) BETWEEN CONVERT(date, @fechaInicio, 103) AND CONVERT(date, @fechaFin, 103)
   and lower(Concepto) like '%' + @Concepto +'%'
 order by fecha_caja desc,idcaja asc
GO
/****** Object:  StoredProcedure [dbo].[sp_listar_todas_Categorias]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--conuslta:
CREATE procedure [dbo].[sp_listar_todas_Categorias]
as
Select * from Categorias 
order by Categoria asc
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Todos_Clientes]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Listamos todos los clientes:
create Procedure [dbo].[sp_Listar_Todos_Clientes] (
@estado varchar (12)
)
As
Select * from V_Clientes_Distritos
where
Estado_Cli =@estado 
order by Razon_Social_Nombres Asc
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Todos_Distritos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_Listar_Todos_Distritos]
As
Select * from Distrito 
order by Distrito asc
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Todos_Marcas]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_Listar_Todos_Marcas]
As
Select * from Marcas
order by Marca asc
GO
/****** Object:  StoredProcedure [dbo].[sp_Listar_Todos_Proveedores]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--listar_Todos_Pr
CREATE procedure [dbo].[sp_Listar_Todos_Proveedores]
as
select 
rtrim(IDPROVEE) as IDPROVEE
,rtrim(NOMBRE) as NOMBRE
,rtrim(DIRECCION) as DIRECCION
,rtrim(TELEFONO) aS TELEFONO
,rtrim(RUBRO) AS RUBRO
,rtrim(RUC) AS RUC
,rtrim(CORREO) AS CORREO
,rtrim(CONTACTO) AS CONTACTO
,rtrim(FOTO_LOGO) AS FOTO_LOGO
,rtrim(ESTADO_PROVDR) AS ESTADO_PROVDR
from Proveedor
order by NOMBRE Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Listar_UniMedida_todos]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Sp_Listar_UniMedida_todos]
as
-- Departamento
SELECT codigo as cod, descripcion as des
  FROM [dbo].[UnidadMedida]
 where estado='Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Login]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--login
Create Procedure [dbo].[Sp_Login]
@Usuario nvarchar(20),
@Contraseña nvarchar(12)
As
	Select Count(*)from Usuarios 
	Where Usuario =@Usuario and Contraseña =@Contraseña
GO
/****** Object:  StoredProcedure [dbo].[sp_modificar_categoria]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create procedure [dbo].[sp_modificar_categoria] (
@idcat int,
@nombre varchar (50)
)
as
update Categorias set
Categoria =@nombre 
where
Id_Cat =@idcat
GO
/****** Object:  StoredProcedure [dbo].[Sp_Modificar_Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--update:
CREATE Procedure [dbo].[Sp_Modificar_Cliente] (
@idcliente varchar(15),
@razonsocial varchar (250),
@dni char (18),
@direccion varchar (150),
@telefono char (10),
@email varchar (150),
@idDis int,
@fechaAniver date,
@contacto varchar (50),
@limiteCred real,
@foto varchar(180)
)
As
update cliente set
Razon_Social_Nombres = @razonsocial ,
DNI=@dni ,
Direccion=@direccion ,
Telefono=@telefono ,
E_Mail=@email ,
Id_Dis=@idDis ,
Fcha_Ncmnto_Anivsrio=@fechaAniver ,
Contacto=@contacto ,
Limit_Credit=@limiteCred,
foto=@foto
where
rtrim(Id_Cliente) =@idcliente 
GO
/****** Object:  StoredProcedure [dbo].[sp_Modificar_Proveedor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--inser:
CREATE proc [dbo].[sp_Modificar_Proveedor](
@idproveedor char (9),
@nombre varchar (50),
@direccion varchar (150),
@telefono char (15),
@rubro varchar (50),
@ruc char (20),
@correo varchar (150),
@contacto varchar (50),
@fotologo varchar (180)
)
As
update Proveedor set 
[NOMBRE]=@nombre ,
[DIRECCION]=@direccion ,
[TELEFONO]=@telefono ,
[RUBRO]=@rubro ,
[RUC]=@ruc ,
[CORREO]=@correo ,
[CONTACTO]=@contacto ,
[FOTO_LOGO]=@fotologo
Where
[IDPROVEE]=@idproveedor 
GO
/****** Object:  StoredProcedure [dbo].[SP_MOSTRAR_STOCK_PRODUCTO]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--todos:




--Buscadir de Pedidos:
CREATE Procedure [dbo].[SP_MOSTRAR_STOCK_PRODUCTO](
@IDPROD nvarchar(15)
)
As
	Select distinct Stock_Actual from PRODUCTOS
	Where Id_Pro=@IDPROD
GO
/****** Object:  StoredProcedure [dbo].[Sp_MostrarUsuario2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--login
create Procedure [dbo].[Sp_MostrarUsuario2]
@username nvarchar(20)
As
	select Usuario, salt, Contraseña from usuarios2 where Usuario = @username
GO
/****** Object:  StoredProcedure [dbo].[Sp_Pedido_Atendido]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--cambiar Estado:
CREATE Procedure [dbo].[Sp_Pedido_Atendido](
	@Id_Ped Nvarchar(15)
)
As
	UPDATE Pedido  SET
	Estado_Ped  ='Atendido'
	WHERE Id_Ped=@Id_Ped
GO
/****** Object:  StoredProcedure [dbo].[sp_registrar_Caja]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--insert:
CREATE Procedure [dbo].[sp_registrar_Caja] (

@Fecha_Caja datetime,
@Tipo_Caja varchar (50),
@Concepto varchar (190),
@De_Para varchar (180),
@Nro_Doc char (20),
@ImporteCaja real,
@Id_Usu nvarchar(15),
@TotalUti real,
@TipoPago varchar (13),
@GeneradoPor varchar (15)
)
As
Insert into Caja Values (
@Fecha_Caja ,
@Tipo_Caja ,
@Concepto ,
@De_Para ,
@Nro_Doc ,
@ImporteCaja ,
@Id_Usu,
@TotalUti ,
@TipoPago ,
@GeneradoPor ,
'Activo'
)
GO
/****** Object:  StoredProcedure [dbo].[sp_registrar_categoria]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--insert:
Create procedure [dbo].[sp_registrar_categoria] (

@nombre varchar (50)
)
as
insert into Categorias values (
@nombre 
)
GO
/****** Object:  StoredProcedure [dbo].[sp_registrar_Cierre_Caja]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_registrar_Cierre_Caja](
@idCierre nvarchar(15),
@Apertura_Caja real,
@Total_Ingreso real,
@TotalEgreso real,
@Id_usu nvarchar(15),
@TodoDeposito real,
@TotalGanancia Real,
@TotalEntregado Real,
@SaldoSiguiente Real,
@TotalFactura Real,
@TotalBoleta Real,
@Totalnota Real,
@TotalCreditoCobrado real,
@TotalCreditoEmitido real
)
AS
update Cierre_Caja set
Apertura_Caja =@Apertura_Caja ,
Total_Ingreso =@Total_Ingreso ,
TotalEgreso = @TotalEgreso ,
Id_Usu=@Id_usu,
TodoDeposito =@TodoDeposito ,
Gananciadeldia =@TotalGanancia ,
TotalEntregado =@TotalEntregado ,
SaldoSiguiente =@SaldoSiguiente ,
TotalFactura =@TotalFactura,
TotalBoleta =@TotalBoleta,
TotalNotaVenta =@Totalnota ,
TotalCreditoCobrado =@TotalCreditoCobrado ,
TotalCreditoEmitido =@TotalCreditoEmitido ,
Estado_cierre ='Cerrado'
where
Id_cierre =@idCierre 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Cliente]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--insert:
CREATE Procedure [dbo].[Sp_Registrar_Cliente] (
@idcliente varchar (15),
@razonsocial varchar (250),
@dni char (18),
@direccion varchar (150),
@telefono char (10),
@email varchar (150),
@idDis int,
@fechaAniver date,
@contacto varchar (50),
@limiteCred real,
@foto varchar(180)
)
As
Insert into Cliente values
(
@idcliente ,
@razonsocial ,
@dni ,
@direccion ,
@telefono,
@email ,
@idDis ,
@fechaAniver ,
@contacto ,
@limiteCred ,
'Activo',
@foto
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Compra]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Insert:
CREATE procedure [dbo].[Sp_Registrar_Compra](
@idCom nvarchar (15),
@Nro_Fac_Fisico char (20),
@IdProvee nvarchar (15),
@SubTotal_Com real,
@FechaIngre date,
@TotalCompra real,
@IdUsu nvarchar(15),
@ModalidadPago varchar (50),
@TiempoEspera int,
@FechaVence date,
@EstadoIngre varchar (20),
@RecibiConforme bit,
@Datos_Adicional varchar (150),
@Tipo_Doc_Compra varchar (12),
@Tipo_Ingreso varchar (30)
)
as
insert into DocumentoCompras values (
@idCom,
@Nro_Fac_Fisico ,
@IdProvee ,
@SubTotal_Com ,
@FechaIngre ,
@TotalCompra ,
@IdUsu ,
@ModalidadPago ,
@TiempoEspera ,
@FechaVence ,
@EstadoIngre ,
@RecibiConforme ,
@Datos_Adicional ,
@Tipo_Doc_Compra,
@Tipo_Ingreso
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Cotizacion]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Ahora los Insert:
CREATE procedure [dbo].[Sp_Registrar_Cotizacion] (
@Id_Cotiza nvarchar (15) ,
@Id_Ped nvarchar (15),
--@FechaCoti datetime,
@Vigencia int,
@TotalCotiza real,
@Condiciones varchar (450),
@PrecioconIgv char (4)
)
As
Insert into Cotizacion  values (

@Id_Cotiza  ,
@Id_Ped ,
getdate() ,
@Vigencia ,
@TotalCotiza ,
@Condiciones ,
@PrecioconIgv ,
'Pendiente'
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Credito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[Sp_Registrar_Credito]
(
@idnotacredito nvarchar (15),
@idDoc nvarchar (15),
@Fecha_Credito datetime,
@nomcliente varchar (50),
@total_ped real,
@Saldo_Pdnte real,
@Fecha_vncmnto Date

)
as
insert into credito 
values
(
@idnotacredito ,
@idDoc  ,
@Fecha_Credito ,
@nomcliente ,
@total_ped ,
@Saldo_Pdnte ,
@Fecha_vncmnto ,
'Pendiente'
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_registrar_Det_Temporal]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



--detalle
CREATE Proc [dbo].[Sp_registrar_Det_Temporal]
(
@Codtem Nvarchar (15),
@CodProd nvarchar (15),
@Cantidad nchar (20),
@Producto varchar (60),
@PreUnt Varchar (50),
@Importe Varchar (50),
@UnidMedida nvarchar(50)
)
As
Insert Into dbo.Detalle_Temporal
Values (
@Codtem ,
@CodProd,
@Cantidad ,
@Producto,
@PreUnt ,
@Importe,
@UnidMedida
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_registrar_detalle_kardex]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--detalle del Kardex:
CREATE procedure [dbo].[Sp_registrar_detalle_kardex](
@Id_Krdx nvarchar (15),
@Item int,
@Doc_Soport nchar (29),
@Det_Operacion varchar (50),
--entrada
@Cantidad_In Real,
@Precio_Unt_In Real,
@Costo_Total_In Real,
--salida
@Cantidad_Out Real,
@Precio_Unt_Out Real,
@Importe_Total_Out Real,
--saldo
@Cantidad_Saldo Real,
@Promedio Real,
@Costo_Total_Saldo Real
)
as
insert into Detalle_Kardex values (
@Id_Krdx ,
@Item ,
GETDATE(),
@Doc_Soport ,
@Det_Operacion ,
--entrada
@Cantidad_In ,
@Precio_Unt_In ,
@Costo_Total_In ,
--salida
@Cantidad_Out ,
@Precio_Unt_Out ,
@Importe_Total_Out ,
--saldo
@Cantidad_Saldo ,
@Promedio ,
@Costo_Total_Saldo 
)
GO
/****** Object:  StoredProcedure [dbo].[sp_Registrar_detalle_Pedido]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--detalle:
CREATE procedure [dbo].[sp_Registrar_detalle_Pedido](
@id_Ped nvarchar (15),
@Id_Pro nvarchar (20),
@Precio real,
@Cantidad real,
@Importe real,
@Tipo_Prod varchar (20),
@Und_Medida varchar (10),
@Utilidad_Unit real,
@TotalUtilidad real,
@AfectoIGV nvarchar(30),
@Precio_sinIgv real,
@subtotal_sinIgv real,
@Igv_subtotal real,
@P_Cant_Original real
)
as
insert into Detalle_Pedido values
(
@id_Ped ,
@Id_Pro ,
@Precio ,
@Cantidad,
@Importe ,
@Tipo_Prod ,
@Und_Medida ,
@Utilidad_Unit ,
@TotalUtilidad,
@AfectoIGV,
@Precio_SinIGV,
@subtotal_SinIGV,
@IGV_subtotal,
'Salida Venta',
@P_Cant_Original
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Registrar_Pedido]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Sp_Registrar_Pedido](
@id_Ped nvarchar (15),
@Id_Cliente nvarchar (15),
@SubTotal real,
@IgvPed real,
@TotalPed real,
@id_Usu nvarchar(15),
@TotalGancia real,
@Estado_ped varchar(12),
@subtotal_Gravado real,
@IgvGravado real,
@totalGravado real
)
As
Insert into Pedido values
(
@id_Ped ,
@Id_Cliente ,
getdate(),
@SubTotal ,
@IgvPed ,
@TotalPed ,
@id_Usu ,
@TotalGancia,
@Estado_ped,
@subtotal_Gravado,
@IgvGravado,
@totalGravado
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_registrar_Producto]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--insert:
CREATE procedure [dbo].[Sp_registrar_Producto] (
@idpro nvarchar (15),
@idprove nvarchar (15),
@descripcion varchar (150),
@frank real,
@Pre_compraSol real,
@pre_CompraDolar real,
@StockActual real,
@idCat int,
@idMar int,
@Foto varchar (MAX),
@Pre_Venta_Menor real,
@Pre_Venta_Mayor real,
@Pre_Venta_Dolar real,
@UndMdida char (6),
@PesoUnit real,
@Utilidad real,
@TipoProd varchar (12),
@ValorporProd real
)
As
Insert into Productos values (
@idpro ,
@idprove ,
@descripcion ,
@frank ,
@Pre_compraSol ,
@pre_CompraDolar ,
@StockActual ,
@idCat ,
@idMar ,
@Foto ,
@Pre_Venta_Menor ,
@Pre_Venta_Mayor ,
@Pre_Venta_Dolar ,
@UndMdida ,
@PesoUnit ,
@Utilidad ,
@TipoProd ,
@ValorporProd ,
'Activo',
GetDate()
)
GO
/****** Object:  StoredProcedure [dbo].[sp_registrar_Proveedor]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--1:
CREATE proc [dbo].[sp_registrar_Proveedor](
@idproveedor nvarchar (15),
@nombre varchar (50),
@direccion varchar (150),
@telefono char (15),
@rubro varchar (50),
@ruc char (20),
@correo varchar (150),
@contacto varchar (50),
@fotologo varchar (180)
)
As
insert into Proveedor values (
@idproveedor,
@nombre ,
@direccion ,
@telefono ,
@rubro ,
@ruc ,
@correo,
@contacto,
@fotologo,
'Activo'
)
GO
/****** Object:  StoredProcedure [dbo].[Sp_RegistrarUsuario2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--insert:
create procedure [dbo].[Sp_RegistrarUsuario2] (
@Id_Usu nvarchar(10),
@Nombres nvarchar(50),
@Apellidos nvarchar(50),
@Id_Dis int,
@username nvarchar(20),
@pass varbinary(MAX),
@Ubicacion_Foto varchar(180),
@Fecha_Ncmiento datetime,
@Id_Rol int,
@Correo varchar(150),
@Estado_Usu varchar(12),
@salt varbinary(MAX)
)
as
INSERT into usuarios2 (Id_Usu,Nombres,Apellidos,Id_Dis,Usuario,Contraseña,Ubicacion_Foto,Fecha_Ncmiento,Id_Rol,Correo,Estado_Usu,salt) 
VALUES (@Id_Usu,@Nombres,@Apellidos,@Id_Dis,@username,@pass,@Ubicacion_Foto,@Fecha_Ncmiento,@Id_Rol,@Correo,@Estado_Usu,@salt)

/* insert into Categorias values (@nombre)
select * from usuarios2
*/
GO
/****** Object:  StoredProcedure [dbo].[sp_Restar_Stock]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_Restar_Stock] (
@idpro nvarchar (20),
@stock real
)
as
update Productos set
Stock_Actual = Stock_Actual - @stock 
where
Id_Pro =@idpro 
GO
/****** Object:  StoredProcedure [dbo].[sp_SumarStock]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Para el Control de Inventario:
CREATE procedure [dbo].[sp_SumarStock] (
@idpro nvarchar (20),
@stock real
)
as
update Productos set
Stock_Actual = Stock_Actual + @stock 
where
Id_Pro =@idpro 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Tipod_Doc_Spcial]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Proc [dbo].[Sp_Tipod_Doc_Spcial]
As
Select Id_Tipo,Documento from Tipo_Doc 
Where Id_Tipo in (1,2,3)
order by Id_Tipo desc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Usuario_Login]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create Procedure [dbo].[Sp_Usuario_Login](
	@Usuario nvarchar(50)=''
)
As
	Select * from V_Usuarios_Roles
	Where
	Usuario=@Usuario and Estado_usu = 'Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Usuario_Login2]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


create Procedure [dbo].[Sp_Usuario_Login2](
	@Usuario nvarchar(50)=''
)
As
	Select * from V_Usuarios_Roles2
	Where
	Usuario=@Usuario and Estado_usu = 'Activo'
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_Archivos_Temporales]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




--validar archivo existente del temporal
CREATE Proc [dbo].[Sp_Validar_Archivos_Temporales]
@Id_tem nvarchar (15)
AS
select COUNT (*) from Temporal 
where CodTem =@Id_tem 
GO
/****** Object:  StoredProcedure [dbo].[Sp_validar_credito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_validar_credito]
@Id_Doc nvarchar (15)
as
select --COUNT (*) 
case when COUNT (*) is null then 0 end
from Credito 
where Id_Doc =  @Id_Doc 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_Factura_enNotaCredito]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


Create Proc [dbo].[Sp_Validar_Factura_enNotaCredito]
@nrFactu nvarchar (15)
As
Select COUNT(*) from NotaCredito 
Where
id_Doc =@nrFactu  
GO
/****** Object:  StoredProcedure [dbo].[SP_Validar_FechaDoc_EnResumenBoleta]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_Validar_FechaDoc_EnResumenBoleta](
@fechaElegida date,
@fecha_doc date
)
as
select count(*) from documento
where DATEPART(YEAR, @fecha_doc)= DATEPART(YEAR, @fechaElegida)
and DATEPART(DAYOFYEAR, @fecha_doc)= DATEPART(DAYOFYEAR, @fechaElegida)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_Id_Doc]    Script Date: 7/08/2022 19:46:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--validar codigo de comprobante
CREATE Procedure [dbo].[Sp_Validar_Id_Doc] 
@Id_Doc nvarchar (15)
As
Select COUNT (*) from Documento 
Where id_Doc =@Id_Doc 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Validar_NotaCredito]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--validar nota de credito
Create Proc [dbo].[Sp_Validar_NotaCredito]
@nrodoc nvarchar (15)
As
Select COUNT(*) from NotaCredito 
Where id_Doc =@nrodoc 
GO
/****** Object:  StoredProcedure [dbo].[sp_Validar_NroDNI]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Validar no ingresar doble Cliente :
CREATE procedure [dbo].[sp_Validar_NroDNI] (
@DNI char (18)
)
as
select count(*)
from Cliente 
where
DNI =@DNI
GO
/****** Object:  StoredProcedure [dbo].[sp_Validar_NroDNI_Cliente]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_Validar_NroDNI_Cliente] (
@DNI char (18)
)
as
select count(*)
from Cliente 
where rtrim(DNI) = @DNI;

GO
/****** Object:  StoredProcedure [dbo].[sp_Validar_NroDNI_Usuario2]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Validar no ingresar doble Cliente :
CREATE procedure [dbo].[sp_Validar_NroDNI_Usuario2] (
@DNI char (18)
)
as
select count(*)
from Usuarios2 
where Id_Usu =@DNI;
GO
/****** Object:  StoredProcedure [dbo].[sp_validar_NroFisico_Compra]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--
create procedure [dbo].[sp_validar_NroFisico_Compra] (
@Nro_Doc_fisico char  (20)
)
as
select COUNT(*) from DocumentoCompras 
where
NroFac_Fisico =@Nro_Doc_fisico 
GO
/****** Object:  StoredProcedure [dbo].[SP_VALIDAR_REGISTRO_CAJA]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--- validar registro de caja
Create procedure [dbo].[SP_VALIDAR_REGISTRO_CAJA]
AS
SELECT COUNT (*) FROM Cierre_Caja  
WHERE 
DATEPART (YEAR ,Fecha_Cierre )= DATEPART (YEAR,GETDATE()) and
DATEPART (DAYOFYEAR ,Fecha_Cierre )= DATEPART (DAYOFYEAR,GETDATE()) 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_Det_credito]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Sp_Ver_Det_credito]
@id_Cred nvarchar (15)
as
select [Id_DetCred]
      ,[IdNotaCred]
      ,[A_cuenta]
      ,[Saldo_Actual]
      ,CONVERT(date, Fecha_Pago, 103) as Fecha_Pago
      ,[TipoPago]
      ,[Nro_Opera_Coment]
      ,[Id_Usu] 
from Detalle_Credito 
Where
IdNotaCred =@id_Cred 
order by Saldo_Actual asc

GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_Kardex_delDia]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[Sp_Ver_Kardex_delDia]
@Fecha date
As
Select * from V_Kardex_Detalle
Where
DATEPART (YEAR,Fecha_Krdx)= DATEPART (YEAR,@Fecha) AND
DATEPART (DAYOFYEAR,Fecha_Krdx)= DATEPART (DAYOFYEAR,@Fecha)
GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_sihay_Kardex]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create Proc [dbo].[Sp_Ver_sihay_Kardex]
@Id_Prod char (20)
As
select COUNT (*) from KardexProducto
where
Id_Pro =@Id_Prod 
GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_SumaTotal_credito_xcliente]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--nuevo nuevo nuevo nuevo
CREATE Procedure [dbo].[Sp_Ver_SumaTotal_credito_xcliente]
@valor varchar (50)
as
select --SUM(Total_Cre),
case when SUM(Total_Cre) is null then 0 else SUM(Total_Cre) end
from V_Documento_Credito
Where
Id_Cliente=@valor or
Nom_Cliente = @valor and
Saldo_Pdnte > 0
GO
/****** Object:  StoredProcedure [dbo].[Sp_Ver_Todo_Credito]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

----============== Nuevo Cambiar Nro de Doc en Credito
--Create Procedure Sp_Cambiar_NroDoc_Encredito (
--@Id_credito  char (6),
--@NroDocu char (11)
--)	
--As	
--update  Credito    set 
--Id_Doc= @NroDocu 
--where
--IdNotaCred =@Id_credito 
--Go



--=================CONSULTAS PARA EL EXPLORADOR DE CREDITOS ===========================

----select--mostrar notas de crdito
Create procedure  [dbo].[Sp_Ver_Todo_Credito]
as
select * from V_Documento_Credito 
order by Fecha_Credito Asc
GO
/****** Object:  StoredProcedure [dbo].[Sp_Verificar_Id_Pedido]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE Procedure [dbo].[Sp_Verificar_Id_Pedido]
@Id_Ped nvarchar (15)
As
Select COUNT (*) from Pedido 
Where id_Ped = @Id_Ped 
GO
/****** Object:  StoredProcedure [dbo].[Sp_verificar_vencimiento_credito]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- verificamos si la fecha de vencimiento es igual al dia de hoy, para avisar al admin que
 --hay un credito vencido hoy
CREATE Procedure [dbo].[Sp_verificar_vencimiento_credito]
	@Cod_credito nvarchar (15)
	as
	select COUNT (*) from Credito 
	where 
	DATEPART (YEAR,GETDATE()) = DATEPART(YEAR ,Fecha_Vncimnto) and
	DATEPART (DAYOFYEAR,GETDATE()) > DATEPART (DAYOFYEAR ,Fecha_Vncimnto)
	and IdNotaCred =@Cod_credito OR 
	DATEPART (YEAR,GETDATE()) > DATEPART(YEAR ,Fecha_Vncimnto) and
	DATEPART (DAYOFYEAR,GETDATE()) < DATEPART (DAYOFYEAR ,Fecha_Vncimnto)
	and IdNotaCred =@Cod_credito 
GO
/****** Object:  StoredProcedure [dbo].[SP_VerificarNC_PendientePago]    Script Date: 7/08/2022 19:46:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[SP_VerificarNC_PendientePago](
@idCred nvarchar(15)
)
as
select count(*) from V_ista_Notacredito_Gnral
where (id_cre=@idCred or id_Doc=@idCred)
and EstadoDinero='De Pago' 
and Estado_Cr='Activo'
GO
