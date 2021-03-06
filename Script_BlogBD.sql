USE [BlogBD]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[Avatar] [nvarchar](500) NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[IdEstado] [int] NOT NULL CONSTRAINT [DF_AspNetUsers_IdEstado]  DEFAULT ((1)),
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Eliminado] [bit] NULL CONSTRAINT [DF_Categorias_Eliminado]  DEFAULT ((0)),
	[Imagen] [nvarchar](500) NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Categorias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Comentarios]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comentarios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NULL,
	[Contenido] [nvarchar](max) NOT NULL,
	[FechaPublicacion] [datetime] NOT NULL,
	[Autor] [nvarchar](128) NOT NULL,
	[Post] [int] NOT NULL,
	[IdEstado] [int] NOT NULL CONSTRAINT [DF_Comentarios_IdEstado]  DEFAULT ((1)),
	[Eliminado] [bit] NULL CONSTRAINT [DF_Comentarios_Eliminado]  DEFAULT ((0)),
 CONSTRAINT [PK_Comentarios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ComentariosDenunciados]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComentariosDenunciados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdComentario] [int] NULL,
	[Usuario] [nvarchar](128) NULL,
	[Motivo] [int] NULL,
	[Fecha] [datetime] NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_ComentariosDenunciados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Estados]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estados](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NULL,
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MotivosDenuncia]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MotivosDenuncia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](200) NULL,
 CONSTRAINT [PK_MotivosDenuncia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Posts]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [nvarchar](100) NOT NULL,
	[Contenido] [nvarchar](max) NOT NULL,
	[FechaPublicacion] [datetime] NOT NULL,
	[Autor] [nvarchar](128) NOT NULL,
	[Puntaje] [int] NOT NULL,
	[Eliminado] [bit] NOT NULL CONSTRAINT [DF_Posts_Eliminado]  DEFAULT ((0)),
	[Imagen] [nvarchar](500) NULL,
	[Descripcion] [nvarchar](375) NULL,
	[IdCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Post] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PostsTags]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostsTags](
	[IdPost] [int] NOT NULL,
	[IdTags] [int] NOT NULL,
 CONSTRAINT [PK_PostTags] PRIMARY KEY CLUSTERED 
(
	[IdPost] ASC,
	[IdTags] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tags]    Script Date: 23/11/2018 11:32:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tags](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Tags] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'Administrador')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2', N'Usuario')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'58bc0ce9-5c4e-4dc9-8799-180cf3e7706a', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8f023bb8-48e6-45ef-b599-e689fdd8c001', N'2')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f52c49fb-8836-4a49-99c8-c66b387d3710', N'1')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Avatar], [Nombre], [Apellido], [IdEstado]) VALUES (N'58bc0ce9-5c4e-4dc9-8799-180cf3e7706a', N'gaston_sorati@hotmail.com', 1, N'ALw4ib57TPuyhmMyDY5qnVlUBjn0IbJC4/UEEWLy1x8a8+4kkdikB+1GZ3D96ClPOg==', N'29584104-684c-41f0-bd5b-0160dfd3dbf1', NULL, 0, 0, NULL, 1, 0, N'gaston_sorati@hotmail.com', N'/Imagenes/ImagenUsuario/5ad0733c-4d58-455a-93c9-3006f8a75b1c.jpeg', NULL, NULL, 1)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Avatar], [Nombre], [Apellido], [IdEstado]) VALUES (N'8f023bb8-48e6-45ef-b599-e689fdd8c001', N'resennasjuegos@gmail.com', 1, N'AMb6SA0MfWYQEjk4KNoGdR1WM+ttyJwXV8/cuNKLIfsuc3AjdIIL6m4kxicSTDlAsg==', N'5fd70620-5f85-47ce-9502-578c7bcc7be2', NULL, 0, 0, NULL, 1, 0, N'resennasjuegos@gmail.com', N'/Imagenes/ImagenUsuario/43e751ed-756a-457d-870a-634b4efb9fa7.jpg', NULL, NULL, 1)
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [Avatar], [Nombre], [Apellido], [IdEstado]) VALUES (N'f52c49fb-8836-4a49-99c8-c66b387d3710', N'gastonsorati@gmail.com', 1, N'AMTh9JIellV50VSvVQb/Hzngjoz7bn7dX+ahIJVsSXAiSNSCQV74J2SadSXCW+gLTQ==', N'f10311cc-3b18-47ef-9fab-9d0d4a70e6e6', NULL, 0, 0, NULL, 1, 0, N'gastonsorati@gmail.com', N'/Imagenes/ImagenUsuario/697b24c0-55ac-471f-ad99-19dce3877cbe.jpg', N'Gastón', N'Sorati', 1)
SET IDENTITY_INSERT [dbo].[Categorias] ON 

INSERT [dbo].[Categorias] ([Id], [Eliminado], [Imagen], [Descripcion]) VALUES (1, 0, N'/Imagenes/ImagenCategoria/57d24fbd-7d5c-42b0-9220-744e5533fa31.gif', N'Argentina')
INSERT [dbo].[Categorias] ([Id], [Eliminado], [Imagen], [Descripcion]) VALUES (2, 0, N'/Imagenes/ImagenCategoria/1b2934f7-795b-4ef5-996f-af1454bda01d.gif', N'España')
INSERT [dbo].[Categorias] ([Id], [Eliminado], [Imagen], [Descripcion]) VALUES (3, 0, N'/Imagenes/ImagenCategoria/7e936586-cadd-4408-8aaf-69cced065617.gif', N'Inglaterra')
INSERT [dbo].[Categorias] ([Id], [Eliminado], [Imagen], [Descripcion]) VALUES (4, 0, N'/Imagenes/ImagenCategoria/49af6bc7-b469-420e-af7b-a34c41dba26e.gif', N'Italia')
INSERT [dbo].[Categorias] ([Id], [Eliminado], [Imagen], [Descripcion]) VALUES (5, 0, N'/Imagenes/ImagenCategoria/b3fe0ac6-7e9a-4773-b8af-bfc9c1045e5d.gif', N'Francia')
INSERT [dbo].[Categorias] ([Id], [Eliminado], [Imagen], [Descripcion]) VALUES (6, 0, N'/Imagenes/ImagenCategoria/b5e0451f-7b9a-4900-9fa6-378863d17697.png', N'Selecciones')
INSERT [dbo].[Categorias] ([Id], [Eliminado], [Imagen], [Descripcion]) VALUES (12, 1, N'/Imagenes/ImagenCategoria/9768cf56-339e-426a-b5b4-a3482ac79b35.jpg', N'asd')
SET IDENTITY_INSERT [dbo].[Categorias] OFF
SET IDENTITY_INSERT [dbo].[Comentarios] ON 

INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (1, NULL, N'prueba', CAST(N'2018-11-23 02:03:13.217' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 1, 4, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (2, NULL, N'das', CAST(N'2018-11-23 02:04:09.320' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 1, 4, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (3, NULL, N'prueba', CAST(N'2018-11-23 02:07:17.770' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 1, 4, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (4, NULL, N'asd', CAST(N'2018-11-23 02:07:22.837' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 1, 4, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (5, NULL, N'asd', CAST(N'2018-11-23 02:08:07.000' AS DateTime), N'58bc0ce9-5c4e-4dc9-8799-180cf3e7706a', 1, 2, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (6, NULL, N'prueba', CAST(N'2018-11-23 02:12:52.027' AS DateTime), N'58bc0ce9-5c4e-4dc9-8799-180cf3e7706a', 2, 1, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (7, NULL, N'Vamos River!!', CAST(N'2018-11-23 17:08:21.907' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 1, 1, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (8, NULL, N'Vamos Boca!!', CAST(N'2018-11-23 21:56:11.750' AS DateTime), N'58bc0ce9-5c4e-4dc9-8799-180cf3e7706a', 1, 1, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (9, NULL, N'Vamos Argentina!!', CAST(N'2018-11-23 22:03:27.623' AS DateTime), N'58bc0ce9-5c4e-4dc9-8799-180cf3e7706a', 2, 1, NULL)
INSERT [dbo].[Comentarios] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Post], [IdEstado], [Eliminado]) VALUES (10, NULL, N'Vamos Ñuueeeellss!!', CAST(N'2018-11-23 23:02:51.000' AS DateTime), N'8f023bb8-48e6-45ef-b599-e689fdd8c001', 1, 1, NULL)
SET IDENTITY_INSERT [dbo].[Comentarios] OFF
SET IDENTITY_INSERT [dbo].[ComentariosDenunciados] ON 

INSERT [dbo].[ComentariosDenunciados] ([Id], [IdComentario], [Usuario], [Motivo], [Fecha], [Descripcion]) VALUES (1, 6, N'f52c49fb-8836-4a49-99c8-c66b387d3710', 1, CAST(N'2018-11-23 05:20:18.007' AS DateTime), NULL)
INSERT [dbo].[ComentariosDenunciados] ([Id], [IdComentario], [Usuario], [Motivo], [Fecha], [Descripcion]) VALUES (2, 8, N'8f023bb8-48e6-45ef-b599-e689fdd8c001', 2, CAST(N'2018-11-23 23:03:10.573' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[ComentariosDenunciados] OFF
SET IDENTITY_INSERT [dbo].[Estados] ON 

INSERT [dbo].[Estados] ([Id], [Descripcion]) VALUES (1, N'Activo')
INSERT [dbo].[Estados] ([Id], [Descripcion]) VALUES (2, N'Suspendido')
INSERT [dbo].[Estados] ([Id], [Descripcion]) VALUES (4, N'Eliminado')
SET IDENTITY_INSERT [dbo].[Estados] OFF
SET IDENTITY_INSERT [dbo].[MotivosDenuncia] ON 

INSERT [dbo].[MotivosDenuncia] ([Id], [Descripcion]) VALUES (1, N'Discriminación')
INSERT [dbo].[MotivosDenuncia] ([Id], [Descripcion]) VALUES (2, N'Insultos')
SET IDENTITY_INSERT [dbo].[MotivosDenuncia] OFF
SET IDENTITY_INSERT [dbo].[Posts] ON 

INSERT [dbo].[Posts] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Puntaje], [Eliminado], [Imagen], [Descripcion], [IdCategoria]) VALUES (1, N'River vs Boca: la ''final del siglo''', N'Se termina el chamuyo. Se acaban las palabras. Fueron semanas de especulaciones, nerviosismo, ansiedad, promesas y cábalas. Ahora es tiempo de entrar a la cancha y jugar. Es la hora de ganar la Copa Libertadores jugando al fútbol. Y que sea lo que tenga que ser para River y Boca. Eso sí: para que uno gane el otro tendrá que perder. Y entonces, ante todo, hay que saber ganar y también saber perder.  Será en el Monumental y solo con hinchas de River, lo cual no deja de ser un posible factor que en algún momento influya emocionalmente sobre el juego. Pero de ninguna manera será determinante, como no lo fue en el partido de ida en la Bombonera. Los 66 mil hinchas gritan y alientan, pero no patean al arco ni pueden meter un pase filtrado de 30 metros. Jugarán su partido. Pero en la cancha serán 11 con una banda roja contra 11 de azul y oro.', CAST(N'2018-11-23 00:28:50.000' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 0, 0, N'/Imagenes/ImagenPosts/542f1b5b-f0ef-48a0-ae1f-afe970d423a3.jpg', N'Se acaban las palabras y se define el título de la Copa Libertadores. Saber ganar y perder será la gran clave para una fiesta completa.', 1)
INSERT [dbo].[Posts] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Puntaje], [Eliminado], [Imagen], [Descripcion], [IdCategoria]) VALUES (2, N'Amistoso internacional  Argentina vs. México: hora, formaciones y cómo ver el partido en vivo', N'Tras el 2-0 conseguido en Córdoba el viernes pasado ante México y mientras espera definir su futuro como DT de la Selección Nacional, Lionel Scaloni estará al frente de Argentina esta noche, cuando el conjunto albiceleste enfrente nuevamente al seleccionado azteca, esta vez en Mendoza. Del equipo que ganó en Córdoba sólo dos nombres se repetirán: Ramiro Funes Mori y Marcos Acuña. Emanuel Mammana iba a ser tenido en cuenta por Scaloni, pero una molestia en la zona de la ingle lo marginó de este encuentro. ', CAST(N'2018-11-20 01:06:27.000' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 0, 0, N'/Imagenes/ImagenPosts/d9800301-1428-4bfc-8fbe-b5e255aaa798.jpg', N'Tras el 2-0 en Córdoba, el equipo de Lionel Scaloni vuelve a enfrentar al seleccionado azteca en Mendoza. ', 6)
INSERT [dbo].[Posts] ([Id], [Titulo], [Contenido], [FechaPublicacion], [Autor], [Puntaje], [Eliminado], [Imagen], [Descripcion], [IdCategoria]) VALUES (3, N'Prueba5', N'asdas
asddsa', CAST(N'2018-11-23 23:12:57.000' AS DateTime), N'f52c49fb-8836-4a49-99c8-c66b387d3710', 0, 1, N'/Imagenes/ImagenPosts/7a35cfe3-1090-4437-938e-a7b3168427bd.jpg', N'asd', 3)
SET IDENTITY_INSERT [dbo].[Posts] OFF
INSERT [dbo].[PostsTags] ([IdPost], [IdTags]) VALUES (1, 4)
INSERT [dbo].[PostsTags] ([IdPost], [IdTags]) VALUES (1, 5)
INSERT [dbo].[PostsTags] ([IdPost], [IdTags]) VALUES (2, 14)
INSERT [dbo].[PostsTags] ([IdPost], [IdTags]) VALUES (2, 15)
INSERT [dbo].[PostsTags] ([IdPost], [IdTags]) VALUES (3, 1)
INSERT [dbo].[PostsTags] ([IdPost], [IdTags]) VALUES (3, 3)
INSERT [dbo].[PostsTags] ([IdPost], [IdTags]) VALUES (3, 4)
SET IDENTITY_INSERT [dbo].[Tags] ON 

INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (1, N'Superliga')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (2, N'B Nacional')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (3, N'BBVA')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (4, N'River')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (5, N'Boca')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (6, N'Atletico de Rafaela')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (7, N'Instituto')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (8, N'Real Madrid')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (9, N'Barcelona')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (10, N'Champion League')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (11, N'Serie A')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (12, N'Premier League')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (13, N'Independiente')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (14, N'Argentina')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (15, N'Mexico')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (16, N'Copa Libertadores')
INSERT [dbo].[Tags] ([Id], [Descripcion]) VALUES (17, N'Copa Argentina')
SET IDENTITY_INSERT [dbo].[Tags] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUsers]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUsers_Estados] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[AspNetUsers] CHECK CONSTRAINT [FK_AspNetUsers_Estados]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_AspNetUsers] FOREIGN KEY([Autor])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_AspNetUsers]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Estados] FOREIGN KEY([IdEstado])
REFERENCES [dbo].[Estados] ([Id])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Estados]
GO
ALTER TABLE [dbo].[Comentarios]  WITH CHECK ADD  CONSTRAINT [FK_Comentarios_Post] FOREIGN KEY([Post])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[Comentarios] CHECK CONSTRAINT [FK_Comentarios_Post]
GO
ALTER TABLE [dbo].[ComentariosDenunciados]  WITH CHECK ADD  CONSTRAINT [FK_ComentariosDenunciados_AspNetUsers] FOREIGN KEY([Usuario])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ComentariosDenunciados] CHECK CONSTRAINT [FK_ComentariosDenunciados_AspNetUsers]
GO
ALTER TABLE [dbo].[ComentariosDenunciados]  WITH CHECK ADD  CONSTRAINT [FK_ComentariosDenunciados_Comentarios] FOREIGN KEY([IdComentario])
REFERENCES [dbo].[Comentarios] ([Id])
GO
ALTER TABLE [dbo].[ComentariosDenunciados] CHECK CONSTRAINT [FK_ComentariosDenunciados_Comentarios]
GO
ALTER TABLE [dbo].[ComentariosDenunciados]  WITH CHECK ADD  CONSTRAINT [FK_ComentariosDenunciados_MotivosDenuncia] FOREIGN KEY([Motivo])
REFERENCES [dbo].[MotivosDenuncia] ([Id])
GO
ALTER TABLE [dbo].[ComentariosDenunciados] CHECK CONSTRAINT [FK_ComentariosDenunciados_MotivosDenuncia]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_AspNetUsers] FOREIGN KEY([Autor])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_AspNetUsers]
GO
ALTER TABLE [dbo].[Posts]  WITH CHECK ADD  CONSTRAINT [FK_Posts_Categorias] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categorias] ([Id])
GO
ALTER TABLE [dbo].[Posts] CHECK CONSTRAINT [FK_Posts_Categorias]
GO
ALTER TABLE [dbo].[PostsTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTags_Post] FOREIGN KEY([IdPost])
REFERENCES [dbo].[Posts] ([Id])
GO
ALTER TABLE [dbo].[PostsTags] CHECK CONSTRAINT [FK_PostTags_Post]
GO
ALTER TABLE [dbo].[PostsTags]  WITH CHECK ADD  CONSTRAINT [FK_PostTags_Tags] FOREIGN KEY([IdTags])
REFERENCES [dbo].[Tags] ([Id])
GO
ALTER TABLE [dbo].[PostsTags] CHECK CONSTRAINT [FK_PostTags_Tags]
GO
