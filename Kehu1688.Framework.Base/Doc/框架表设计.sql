USE NJLFramework
GO
IF OBJECT_ID('SysCompany') IS NOT NULL
	DROP TABLE dbo.SysCompany
GO
CREATE TABLE SysCompany
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_SysCompany_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_SysCompany_Id PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	License NVARCHAR(256) NOT NULL,
	Tel NVARCHAR(50) NOT NULL,
	Fax NVARCHAR(50) NOT NULL,
	Address NVARCHAR(256) NOT NULL,
	Domain NVARCHAR(50) NOT NULL,
	Remark NVARCHAR(max) NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��Ȩ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'License' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�绰', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Tel' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Fax' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾��ַ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Address' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Domain' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysCompany', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_SysCompany_Domain ON dbo.SysCompany
	(
	Domain
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('SysTables') IS NOT NULL
	DROP TABLE dbo.SysTables
GO
CREATE TABLE SysTables
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_SysTables_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_SysTables_Id PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	FLName NVARCHAR(50) NOT NULL,
	Authorize BIT NOT NULL,
	Remark NVARCHAR(max) NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳ������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysTables' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'FLName' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����Ȩ����֤��0:����֤��1����֤', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Authorize' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_SysTables_Name ON dbo.SysTables
	(
	Name
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('SysFields') IS NOT NULL
	DROP TABLE dbo.SysFields
GO
CREATE TABLE SysFields
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_SysFields_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_SysFields_Id PRIMARY KEY,
	Field NVARCHAR(50) NOT NULL,
	FLName NVARCHAR(50) NOT NULL,
	TableId UNIQUEIDENTIFIER NOT NULL,
	Authorize BIT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳ�ֶι����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysFields' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�ֶ�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Field' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'FLName' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��Id,��SysTables��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'TableId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����Ȩ����֤��0������֤��1����֤', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Authorize' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_SysFields_TableId ON dbo.SysFields
	(
	TableId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_SysFields_TableId_Field ON dbo.SysFields
	(
	TableId,
	Field
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('SysModules') IS NOT NULL
	DROP TABLE dbo.SysModules
GO
CREATE TABLE SysModules
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_SysModules_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_SysModules PRIMARY KEY,
	ModuleKey NVARCHAR(20) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	MenuId UNIQUEIDENTIFIER NOT NULL,
	Enabled BIT NOT NULL,
	Authorize BIT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳģ������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ģ��key', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ModuleKey' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ģ����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵�Id,��SysMenus��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'MenuId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����ô�ģ�飬0:�����ã�1������,��������ã���Ӧ��ɾ��CompanyModules��Ӧ�ļ�¼', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����Ȩ����֤��0:����֤��1����֤', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Authorize' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE UNIQUE NONCLUSTERED INDEX IX_SysModules_ModuleKey ON dbo.SysModules
	(
	ModuleKey
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_SysModules_MenuId ON dbo.SysModules
	(
	MenuId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO

IF OBJECT_ID('SysModuleTable') IS NOT NULL
	DROP TABLE dbo.SysModuleTable
GO
CREATE TABLE SysModuleTable
(
	ModuleId UNIQUEIDENTIFIER NOT NULL,
	TableId NVARCHAR(20) NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳģ�����Ĺ�ϵ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleTable' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,ģ��Id,��ӦSysModules��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleTable', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ModuleId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��Id,��ӦSysTables��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleTable', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'TableId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleTable', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
ALTER TABLE dbo.SysModuleTable ADD CONSTRAINT
PK_SysModuleTables_ModuleId_TableId PRIMARY KEY CLUSTERED 
(
	ModuleId,
	TableId
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

IF OBJECT_ID('SysMenus') IS NOT NULL
	DROP TABLE dbo.SysMenus
GO
CREATE TABLE SysMenus
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_SysMenus_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_SysMenus_Id PRIMARY KEY,
	MenuKey NVARCHAR(20) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	ParentMenuId UNIQUEIDENTIFIER NOT NULL,
	Enabled BIT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳ�˵���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysMenus' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵�keyֵ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'MenuKey' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵�����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����˵�Id,��ӦSysMenus��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ParentMenuId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵��Ƿ����ã�0�������ã�1������,�����ã���ɾ��CompanyMenus����صļ�¼', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_SysMenus_ParentMenuId ON dbo.SysMenus
	(
	ParentMenuId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_SysMenus_MenuKey ON dbo.SysMenus
	(
	MenuKey
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO

IF OBJECT_ID('SysRights') IS NOT NULL
	DROP TABLE dbo.SysRights
GO
CREATE TABLE SysRights
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_SysRights_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_SysRights_Id PRIMARY KEY,
	RightKey NVARCHAR(20) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	ParallelRight NVARCHAR(500) NOT NULL,
	Enabled BIT NOT NULL,
	[Order] INT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳȨ�����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'Ȩ��keyֵ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RightKey' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'Ȩ������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ӵ��RightKey��Ȩ��ʱ��ParallelRight��ָ���Ȩ��Ҳ��ӵ���ˡ�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ParallelRight' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����ã�0�������ã�1������,�����ã���ɾ��CompanyRights����صļ�¼', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'Ȩ����˳��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Order' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO

IF OBJECT_ID('SysModuleRight') IS NOT NULL
	DROP TABLE dbo.SysModuleRight
GO
CREATE TABLE SysModuleRight
(
	ModuleId UNIQUEIDENTIFIER NOT NULL,
	RightId UNIQUEIDENTIFIER NOT NULL,
	Enabled BIT NOT NULL,
	Remark NVARCHAR(MAX)
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳģ��Ȩ�ޱ�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleRight' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,ģ��Id,��ӦSysModules��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ModuleId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,Ȩ����Id,��ӦSysRights��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RightId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����ã�0�������ã�1������,�����ã���ɾ��CompanyModuleRight����صļ�¼', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'SysModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
ALTER TABLE dbo.SysModuleRight ADD CONSTRAINT
PK_SysModuleRight_ModuleId_RightId PRIMARY KEY CLUSTERED 
(
	ModuleId,
	RightId
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


IF OBJECT_ID('CompanyTables') IS NOT NULL
	DROP TABLE dbo.CompanyTables
GO
CREATE TABLE CompanyTables
(
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Id UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	FLName NVARCHAR(50) NOT NULL,
	Authorize BIT NOT NULL,
	Remark NVARCHAR(max) NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyTables' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��Id����ӦSysTables��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'FLName' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����Ȩ����֤��0:����֤��1����֤', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Authorize' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyTables', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
ALTER TABLE dbo.CompanyTables ADD CONSTRAINT
PK_CompanyTables_CompanyId_Id PRIMARY KEY CLUSTERED 
(
	CompanyId,
	Id
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


IF OBJECT_ID('CompanyFields') IS NOT NULL
	DROP TABLE dbo.CompanyFields
GO
CREATE TABLE CompanyFields
(
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Id UNIQUEIDENTIFIER NOT NULL,
	Field NVARCHAR(50) NOT NULL,
	FLName NVARCHAR(50) NOT NULL,
	TableId UNIQUEIDENTIFIER NOT NULL,
	Authorize BIT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾�ֶι����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,�ֶ�Id����ӦSysFields��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�ֶ�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Field' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'FLName' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��Id,��SysTables��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'TableId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����Ȩ����֤��0������֤��1����֤', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Authorize' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyFields', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
ALTER TABLE dbo.CompanyFields ADD CONSTRAINT
PK_CompanyFields_CompanyId_Id PRIMARY KEY CLUSTERED 
(
	CompanyId,
	Id
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_CompanyFields_TableId ON dbo.CompanyFields
	(
	TableId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO

IF OBJECT_ID('CompanyModules') IS NOT NULL
	DROP TABLE dbo.CompanyModules
GO
CREATE TABLE CompanyModules
(
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Id UNIQUEIDENTIFIER NOT NULL,
	ModuleKey NVARCHAR(20) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	MenuId UNIQUEIDENTIFIER NOT NULL,
	Enabled BIT NOT NULL,
	Authorize BIT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾ģ������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,ģ��Id,��ӦSysModules��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ģ��key', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ModuleKey' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ģ����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵�Id,��SysMenus��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'MenuId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����ô�ģ�飬0:�����ã�1������,��������ã���Ӧ��ɾ��CompanyModules��Ӧ�ļ�¼', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����Ȩ����֤��0:����֤��1����֤', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Authorize' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModules', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_CompanyModules_ModuleKey ON dbo.CompanyModules
	(
	ModuleKey
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_CompanyModules_MenuId ON dbo.CompanyModules
	(
	MenuId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
ALTER TABLE dbo.CompanyModules ADD CONSTRAINT
PK_CompanyModules_CompanyId_Id PRIMARY KEY CLUSTERED 
(
	CompanyId,
	Id
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


IF OBJECT_ID('CompanyMenus') IS NOT NULL
	DROP TABLE dbo.CompanyMenus
GO
CREATE TABLE CompanyMenus
(
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Id UNIQUEIDENTIFIER NOT NULL,
	MenuKey NVARCHAR(20) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	ParentMenuId UNIQUEIDENTIFIER NOT NULL,
	Enabled BIT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾�˵���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,�˵�Id,��ӦSysMenus��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵�keyֵ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'MenuKey' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵�����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����˵�Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ParentMenuId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵��Ƿ����ã�0�������ã�1������,�����ã���ɾ��CompanyMenus����صļ�¼', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyMenus', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
ALTER TABLE dbo.CompanyMenus ADD CONSTRAINT
PK_CompanyMenus_CompanyId_Id PRIMARY KEY CLUSTERED 
(
	CompanyId,
	Id
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_CompanyMenus_ParentMenuId ON dbo.CompanyMenus
	(
	ParentMenuId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('CompanyRights') IS NOT NULL
	DROP TABLE dbo.CompanyRights
GO
CREATE TABLE CompanyRights
(
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Id UNIQUEIDENTIFIER NOT NULL,
	RightKey NVARCHAR(20) NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	ParallelRight NVARCHAR(500) NOT NULL,
	Enabled BIT NOT NULL,
	[Order] INT NOT NULL,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳȨ�����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,Ȩ����Id,��ӦSysRights��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'Ȩ��keyֵ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RightKey' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'Ȩ������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ӵ��RightKey��Ȩ��ʱ��ParallelRight��ָ���Ȩ��Ҳ��ӵ���ˡ�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ParallelRight' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����ã�0�������ã�1������,�����ã���ɾ��CompanyRights����صļ�¼', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'Ȩ����˳��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Order' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyRights', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
ALTER TABLE dbo.CompanyRights ADD CONSTRAINT
PK_CompanyRights_CompanyId_Id PRIMARY KEY CLUSTERED 
(
	CompanyId,
	Id
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

IF OBJECT_ID('CompanyModuleRight') IS NOT NULL
	DROP TABLE dbo.CompanyModuleRight
GO
CREATE TABLE CompanyModuleRight
(
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	ModuleId UNIQUEIDENTIFIER NOT NULL,
	RightId UNIQUEIDENTIFIER NOT NULL,
	Enabled BIT NOT NULL,
	Remark NVARCHAR(MAX) NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ϵͳģ��Ȩ�ޱ�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModuleRight' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,ģ��Id,��ӦSysModules��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ModuleId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,Ȩ����Id,��ӦSysRights��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RightId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����ã�0�������ã�1������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'CompanyModuleRight', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
ALTER TABLE dbo.CompanyModuleRight ADD CONSTRAINT
PK_CompanyModuleRight_CompanyId_ModuleId_RightId PRIMARY KEY CLUSTERED 
(
	CompanyId,
	ModuleId,
	RightId
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO


IF OBJECT_ID('Departments') IS NOT NULL
	DROP TABLE dbo.Departments
GO
CREATE TABLE Departments
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_Departments_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_Departments_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	ParentId UNIQUEIDENTIFIER NOT NULL,
	DepartmentType INT NOT NULL,
	ConcurrencyStamp VarBinary(10) NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL,
	UpdateUserId UNIQUEIDENTIFIER NULL,
	UpdateTime DATETIME NULL,
	Remark NVARCHAR(MAX) NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���ű�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ParentId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������,0:��˾;1:����;2:С��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'DepartmentType' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ConcurrencyStamp' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸��û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸�ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Departments', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_Departments_CompanyId ON dbo.Departments
	(
	CompanyId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Departments_CreateUserId ON dbo.Departments
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Departments_UpdateUserId ON dbo.Departments
	(
	UpdateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('Users') IS NOT NULL
	DROP TABLE dbo.Users
GO
CREATE TABLE Users
(
    Id UNIQUEIDENTIFIER CONSTRAINT Default_Users_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_Users_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER,
	AccessFailedCount INT NOT NULL,
	LockoutEnabled BIT NOT NULL,
	LockoutEnd DATETIMEOFFSET NOT NULL,
	Email NVARCHAR(50) NULL,
	NormalizedEmail NVARCHAR(50) NULL,
	EmailConfirmed BIT NULL,
	PhoneNumber NVARCHAR(50),
	PhoneNumberConfirmed BIT,
	UserName NVARCHAR(50) NOT NULL,
	NormalizedUserName NVARCHAR(50) NOT NULL,
	PasswordHash NVARCHAR(256) NOT NULL,
	SecurityStamp NVARCHAR(256),
	TwoFactorEnabled BIT NOT NULL,
	UserSecret NVARCHAR(256),
	UserToken NVARCHAR(256),
	IsSysUser BIT NOT NULL,
	ConcurrencyStamp VARBINARY(10) NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL,
	UpdateUserId UNIQUEIDENTIFIER,
	UpdateTime DATETIME,
	Remark NVARCHAR(MAX) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�û���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��½ʧ�ܴ���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'AccessFailedCount' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����õ�½ʧ������,0:�����ã�1:����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'LockoutEnabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'LockoutEnd' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��½�ʼ���ַ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Email' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���л����ĵ�½�ʼ���ַ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'NormalizedEmail' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ������ʼ���ַ��֤,0:������,1:����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'EmailConfirmed' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��½�ֻ�����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'PhoneNumber' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ������ֻ�������֤,0:�����ã�1������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'PhoneNumberConfirmed' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�û���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UserName' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���л������û���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'NormalizedUserName' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����hash��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'PasswordHash' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ȫ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'SecurityStamp' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ����ö�������֤,0:�����ã�1;:����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'TwoFactorEnabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�û���Կ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UserSecret' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'token', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UserToken' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ�ϵͳ�û�', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'IsSysUser' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ConcurrencyStamp' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸��û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸�ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Users', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_Users_CompanyId ON dbo.Users
	(
	CompanyId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Users_CreateUserId ON dbo.Users
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Users_UpdateUserId ON dbo.Users
	(
	UpdateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('Roles') IS NOT NULL
	DROP TABLE dbo.Roles
GO
CREATE TABLE Roles
(
    Id UNIQUEIDENTIFIER CONSTRAINT Default_Roles_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_Roles_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	NormalizedName NVARCHAR(50) NOT NULL,
	Enabled BIT NOT NULL,
	IsSysRole BIT NOT NULL,
	ConcurrencyStamp VARBINARY(10) NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL,
	UpdateUserId UNIQUEIDENTIFIER,
	UpdateTime DATETIME,
	Remark NVARCHAR(Max) NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ɫ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ɫ����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���л����Ľ�ɫ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'NormalizedName' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ�����,0:�����ã�1������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Enabled' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ�ϵͳ��ɫ,0:����,1:��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'IsSysRole' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ConcurrencyStamp' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸��û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸�ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Roles', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_Roles_CompanyId ON dbo.Roles
	(
	CompanyId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Roles_CreateUserId ON dbo.Roles
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Roles_UpdateUserId ON dbo.Roles
	(
	UpdateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('UserRole') IS NOT NULL
	DROP TABLE dbo.UserRole
GO
CREATE TABLE UserRole
(
	RoleId UNIQUEIDENTIFIER NOT NULL,
	UserId UNIQUEIDENTIFIER NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�û���ɫ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'UserRole' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'UserRole', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RoleId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��������', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'UserRole', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'UserRole', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'UserRole', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
ALTER TABLE dbo.UserRole ADD CONSTRAINT
PK_UserRole_RoleId_UserId PRIMARY KEY CLUSTERED 
(
	RoleId,
	UserId
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX IX_UserRole_CreateUserId ON dbo.UserRole
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('FieldPermission') IS NOT NULL
	DROP TABLE dbo.FieldPermission
GO
CREATE TABLE FieldPermission
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_FieldPermission_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_FieldPermission_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	ModuleId UNIQUEIDENTIFIER NOT NULL,
	TableId UNIQUEIDENTIFIER NOT NULL,
	FieldId UNIQUEIDENTIFIER NOT NULL,
	RelationId UNIQUEIDENTIFIER NOT NULL,
	RelationType INT NOT NULL,
	Properties INT NOT NULL,
	Remark NVARCHAR(MAX) NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�ֶ�Ȩ�޹���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ģ��Id,��CompanyModules��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ModuleId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��Id,��CompanyTables��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'TableId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�ֶ�Id,��CompanyFields��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'FieldId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���Id,��ӦRoles,Users,Positions�е�Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '������ʶ,0:�û�,1:��ɫ,2:ְλ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationType' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'Ȩ�޿��� 1:�ɲ�ѯ,2:����ʾ��4:�ɱ༭,8:��ֹ��ѯ,16:��ֹ��ʾ,32:��ֹ�༭,���ֵʱ���.', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Properties' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'FieldPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_FieldPermission_CompanyId_ModuleId_TableId_FieldId ON dbo.FieldPermission
	(
	CompanyId,
	ModuleId,
	TableId,
	FieldId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_FieldPermission_CreateUserId ON dbo.FieldPermission
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO

IF OBJECT_ID('Positions') IS NOT NULL
	DROP TABLE dbo.Positions
GO
CREATE TABLE Positions
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_Positions_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_Positions_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	Name NVARCHAR(50) NOT NULL,
	IsSysPosition BIT NOT NULL,
	ConcurrencyStamp VARBINARY(10) NOT NULL,
	Remark nvarchar(max) NULL,
	UpdateUserId UNIQUEIDENTIFIER NOT NULL,
	UpdateTime DATETIME NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ְλ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ְλ����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Name' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�Ƿ�Ϊϵͳְ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'IsSysPosition' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ���', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ConcurrencyStamp' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id����ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸��û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�޸�ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'UpdateTime' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ע', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'Positions', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Remark' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_Positions_CompanyId ON dbo.Positions
	(
	CompanyId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Positions_CreateUserId ON dbo.Positions
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_Positions_UpdateUserId ON dbo.Positions
	(
	UpdateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO

IF OBJECT_ID('MenuPermission') IS NOT NULL
	DROP TABLE dbo.MenuPermission
GO
CREATE TABLE MenuPermission
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_MenuPermission_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_MenuPermission_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	MenuId UNIQUEIDENTIFIER NOT NULL,
	RelationId UNIQUEIDENTIFIER NOT NULL,
	RelationType INT NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵���Ȩ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�˵�Id,��ӦCompanyMenus��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'MenuId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���Id,��ӦRoles,Users,Positions�е�Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ر�ʶ,0:�û�,1:��ɫ,2:ְλ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationType' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'MenuPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_MenuPermission_CompanyId_MenuId ON dbo.MenuPermission
	(
	CompanyId,
	MenuId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_MenuPermission_CreateUserId ON dbo.MenuPermission
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO


IF OBJECT_ID('DepartmentPermission') IS NOT NULL
	DROP TABLE dbo.DepartmentPermission
GO
CREATE TABLE DepartmentPermission
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_DepartmentPermission_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_DepartmentPermission_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	DepartmentId UNIQUEIDENTIFIER NOT NULL,
	RelationId UNIQUEIDENTIFIER NOT NULL,
	RelationType INT NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '������Ȩ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����Id,��ӦDepartments��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'DepartmentId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id,��ӦSysCompany��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���Id,��ӦRoles,Users,Positions�е�Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ر�ʶ,0:�û�,1:��ɫ,2:ְλ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationType' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id,��ӦUsers��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'DepartmentPermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_DepartmentPermission_CompanyId_DepartmentId ON dbo.DepartmentPermission
	(
	CompanyId,
	DepartmentId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_DepartmentPermission_CreateUserId ON dbo.DepartmentPermission
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO



IF OBJECT_ID('ModulePermission') IS NOT NULL
	DROP TABLE dbo.ModulePermission
GO
CREATE TABLE ModulePermission
(
	Id UNIQUEIDENTIFIER CONSTRAINT Default_ModulePermission_Id DEFAULT(NEWSEQUENTIALID()) ROWGUIDCOL CONSTRAINT PK_ModulePermission_Id PRIMARY KEY,
	CompanyId UNIQUEIDENTIFIER NOT NULL,
	ModuleId UNIQUEIDENTIFIER NOT NULL,
	RelationId UNIQUEIDENTIFIER NOT NULL,
	RelationType INT NOT NULL,
	Properties INT NOT NULL,
	CreateUserId UNIQUEIDENTIFIER NOT NULL,
	CreateTime DATETIME NOT NULL
)
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ģ����Ȩ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'Id' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = 'ģ��Id,��ӦCompanyModule��Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'ModuleId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��˾Id,��SysCompany��Id����', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CompanyId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '���Id,��ӦRoles,Users,Positions�е�Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '��ر�ʶ,0:�û�,1:��ɫ,2:ְλ', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'RelationType' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '�����û�Id����ӦUsers���Id', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateUserId' -- sysname
GO
EXEC sys.sp_addextendedproperty @name = 'MS_Description', -- sysname
    @value = '����ʱ��', -- sql_variant
    @level0type = 'SCHEMA', -- varchar(128)
    @level0name = 'dbo', -- sysname
    @level1type = 'TABLE', -- varchar(128)
    @level1name = 'ModulePermission', -- sysname
    @level2type = 'COLUMN', -- varchar(128)
    @level2name = 'CreateTime' -- sysname
GO
CREATE NONCLUSTERED INDEX IX_ModulePermission_CompanyId_ModuleId ON dbo.ModulePermission
	(
	CompanyId,
	ModuleId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
CREATE NONCLUSTERED INDEX IX_ModulePermission_CreateUserId ON dbo.ModulePermission
	(
	CreateUserId
	) WITH( PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [INDEX]
GO
